﻿using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
// For Adf execution.
using Microsoft.Identity.Client;
using CrossBreeze.CrossTest.Process.Adf.Configuration;
using System.Threading.Tasks;
using Microsoft.Rest;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Azure.Management.DataFactory;

namespace CrossBreeze.CrossTest.Process.Adf
{
    public static class AdfExecutor

    {
        const string azureLoginUrl = "https://login.microsoftonline.com/";
        const string getTokenUrl = "https://management.azure.com//.default";
        /// <summary>
        /// The Adf Operation Message types.
        /// As defined in the catalog.operation_messages table:
        ///  - https://docs.microsoft.com/en-us/sql/integration-services/system-views/catalog-operation-messages-Adfdb-database?view=sql-server-2017#remarks
        /// </summary>
        private enum AdfOperationMessageType : short
        {
            Unknown = -1
            , Error = 120
            , Warning = 110
            , Information = 70
            , PreValidate = 10
            , PostValidate = 20
            , PreExecute = 30
            , PostExecute = 40
            , Progress = 60
            , StatusChange = 50
            , QueryCancel = 100
            , TaskFailed = 130
            , Diagnostic = 90
            , Custom = 200
            , DiagnosticEx = 140
        }

        public static void ExecuteAdfProcess(string projectName, string pipelineName, Dictionary<string, string> parameters = null)
        {
            // Check whether the Adf process config exists
            if (crossTestAdfConfig.GetConfig() == null)
                throw new Exception(string.Format("No Adf process configuration exists!"));

            // Get the Adf project configuration for the given project name.
            AdfProcessConfig AdfProjectConfig = crossTestAdfConfig.GetConfig().AdfProcesses[projectName];
            if (AdfProjectConfig == null)
                throw new Exception(string.Format("The specified Adf process config '{0}' doens't exist!", projectName));

            if (AdfProjectConfig.parameters != null)
                foreach (var paramter in AdfProjectConfig.parameters)
                    parameters.Add(paramter.Key, paramter.Value);

            // Based on the process type, start the execution.
            switch (AdfProjectConfig.ProcessType)
            {
                case AdfProcessType.AdfPipeline:
                    // beschrijving

                    ExecuteAdfPipelineAsync(AdfProjectConfig.tenantID, AdfProjectConfig.subscriptionId, AdfProjectConfig.applicationId, AdfProjectConfig.clientSecret,
                        AdfProjectConfig.resourceGroupName, AdfProjectConfig.dataFactoryName, pipelineName, parameters).Wait();
                    break;



                default:
                    throw new Exception(string.Format("The Adf Process Type {0} is not supported yet!", AdfProjectConfig.ProcessType.ToString()));
            }
        }


        /// <summary>
        /// Execute a Adf pipeline which resides in a azure data factory.
        /// </summary>
        /// <param name="tenantID">The instance id of the whole azure environment</param>
        /// <param name="subscriptionId">The subsciption from where the costs will be billed</param>
        /// <param name="applicationId">This is an application that would be made only for this purpose</param>
        /// <param name="clientSecret">The secret of the application</param>
        /// <param name="resourceGroupName">The group where the pipeline and its datafactory would be created</param>
        /// <param name="dataFactoryName">The dataactory where the pipeline exists</param>
        /// <param name="pipelineName">The pipeline that should be run</param>
        /// <param name="parameters">The optional parameters of the pipeline</param>
        private static async Task ExecuteAdfPipelineAsync(string tenantID, string subscriptionId, string applicationId, string clientSecret,
            string resourceGroupName, string dataFactoryName, string pipelineName, IDictionary<string, string> parameters)
        {
            IConfidentialClientApplication app = ConfidentialClientApplicationBuilder.Create(applicationId)
                 .WithAuthority(azureLoginUrl + tenantID)
                 .WithClientSecret(clientSecret)
                 .WithLegacyCacheCompatibility(false)
                 .WithCacheOptions(CacheOptions.EnableSharedCacheOptions)
                 .Build();

            AuthenticationResult result = await app.AcquireTokenForClient(
              new string[] { getTokenUrl })
               .ExecuteAsync();
            ServiceClientCredentials cred = new TokenCredentials(result.AccessToken);
            var client = new DataFactoryManagementClient(cred)
            {
                SubscriptionId = subscriptionId
            };
            Dictionary<string, object> dObjectParameters = parameters.ToDictionary(k => k.Key, k => (object)k.Value);
            Console.WriteLine("Creating pipeline run...");
            var run = await client.Pipelines.CreateRunWithHttpMessagesAsync(resourceGroupName, dataFactoryName, pipelineName, parameters: dObjectParameters);
            Console.WriteLine("Pipeline run ID: " + run.Body.RunId);

            // Monitor the pipeline run
            Console.WriteLine("Waiting for pipeline to complete...");
            PipelineRun pipelineRun;
            while (true)
            {
                pipelineRun = client.PipelineRuns.Get(
                    resourceGroupName, dataFactoryName, run.Body.RunId);
                //Console.WriteLine("Status: " + pipelineRun.Status);
                if (pipelineRun.Status == "InProgress" || pipelineRun.Status == "Queued")
                    System.Threading.Thread.Sleep(1000);
                else
                    break;
            }
            Console.WriteLine(string.Format("Pipeline completed with status '{0}'.", pipelineRun.Status));

            if (pipelineRun.Status == "Failed")
            {
                Console.WriteLine(string.Format("The pipeline {0} failed during execution: {1}", pipelineName, pipelineRun.Message));
                throw new Exception(pipelineRun.Message);
            }

        }
    }
}
