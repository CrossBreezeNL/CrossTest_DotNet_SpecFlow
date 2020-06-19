/********************************************************************************
 * INFORMATICA DISCLAIMER:
 * THE SAMPLE CODE IS PROVIDED ``AS IS'' AND ANY EXPRESSED OR IMPLIED  WARRANTIES,
 * INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
 * FOR A PARTICULAR PURPOSE ARE DISCLAIMED.  IN NO EVENT SHALL INFORMATICA CORPORATION
 * BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
 * THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN
 * IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *******************************************************************************/

/*******************************************************************************
 *
 * Copyright (c) 2003-2004 Informatica Corporation.  This file contains material
 * proprietary to Informatica Corporation and may not be copied or distributed
 * in any form without the written permission of Informatica Corporation.
 *
 *******************************************************************************/

/**
 * This sample shows how to start/ stop a workflow and task on PowerCenter Server.
 * It mainly focuses on usage of Data Integration Web Service.
 * Metadata Calls made
 *      Login
 *      Logout
 *
 * DataIntegration calls made
 *      InitializeDIServerConnection
 *      StartWorkflow
 *      StopWorkflow
 *      GetWorkflowDetails
 *      StartTask
 *      WaitTillTaskComplete
 *      GetTaskDetails
 *      DeinitializeDIServerConnection
 */

using System.IO;
using System.Net;
using System;
using System.Web.Services.Protocols;
using System.Xml;

using System.Security.Cryptography.X509Certificates;

using BatchWebServices.dotnet.csharp.proxyclasses;

namespace BatchWebServices.dotnet.csharp.dataintegration
{

    // This class is used to indicate not to authenticate the certificate
    // sent by Web Services Hub while using https
    class NoAuthCertPolicy : ICertificatePolicy
    {
        public bool CheckValidationResult(ServicePoint sp, X509Certificate cert,
                            WebRequest request, int problem)
        {
            return true;
        }
    }


    public class Sample1
    {

        // define the static data members

        // WSH host name
        private static string WSH_HOST_NAME = null;
        // WSH port number
        private static string WSH_PORT_NUM = null;

        // Service endpoint URL for Metadata web service
        private static string MWS_URL = null;
        // Service endpoint URL for DataIntegration web service
        private static string DIWS_URL = null;

        // Repository domain name used for login
        private static string REPO_DOMAIN_NAME = null;
        // Repositry name used for login
        private static string REPO_NAME = null;
        // User name used for login
        private static string USER_NAME = null;
        // Password used for login
        private static string PASSWORD = null;
        // DI Server domain name
        private static string DI_DOMAIN_NAME = null;
        // DI Server name used for DataIntegration Web Service
        private static string DI_SERVICE_NAME = null;

        // Folder name to be used in DI Web Service
        private static string FOLDER_NAME = null;
        // Workflow name to be used in DI Web Service
        private static string WORKFLOW_NAME = null;

        // Task name to be used in DI Web Service
        private static string TASK_NAME = null;

        // declares proxy object for Meta Data Web Service
        private static MetadataService MWSProxy;
        // declares proxy object for Load Manager Web Service
        private static DataIntegrationService DIWSProxy;

        /**
         * method to init various parameters
         * @param args
         */
        private static void init(string[] args)
        {

            WSH_HOST_NAME = args[1];
            WSH_PORT_NUM = args[2];
            REPO_DOMAIN_NAME = args[3];
            REPO_NAME = args[4];
            USER_NAME = args[5];
            PASSWORD = args[6];
            DI_DOMAIN_NAME = args[7];
            DI_SERVICE_NAME = args[8];
            FOLDER_NAME = args[9];
            WORKFLOW_NAME = args[10];
            TASK_NAME = args[11];


            string protocol = "http://";
            if (args[0].Equals("-s"))
            {
                protocol = "https://";
                // set the certificate policy which does not authenticate
                ServicePointManager.CertificatePolicy = new NoAuthCertPolicy();
            }

            // Constructing Service endpoint URL for Metadata web service
            MWS_URL = protocol + args[1] + ":" + args[2] + "/wsh/services/" + args[3] + "/" + args[4] + "/Metadata";

            // Constructing Service endpoint URL for DataIntegration web service
            DIWS_URL = protocol + args[1] + ":" + args[2] + "/wsh/services/" + args[3] + "/" + args[4] + "/DataIntegration";


            try
            {

                /**
                 * This implements the part of step 1 of developing client applications discussed in
                 * Getting Started chapter of documentation.
                 * 
                 */

                // create proxy object for Metadata Web Service
                MWSProxy = new MetadataService();

                if (MWSProxy == null)
                {
                    Console.WriteLine("MWSProxy object is null");
                    return;
                }

                MWSProxy.Url = MWS_URL;

                LoginRequest loginReq = new LoginRequest();
                loginReq.RepositoryDomainName = REPO_DOMAIN_NAME;
                loginReq.RepositoryName = REPO_NAME;
                loginReq.UserName = USER_NAME;
                loginReq.Password = PASSWORD;
                Console.WriteLine("[Status] : calling Login...");
                String sessID = MWSProxy.Login(loginReq);
                Console.WriteLine("[Status] : Done");

                MWSProxy.Context = new SessionHeader();
                MWSProxy.Context.SessionId = sessID;

                // create proxy object for DataIntegration Web Service
                DIWSProxy = new DataIntegrationService();
                if (DIWSProxy == null)
                {
                    Console.WriteLine("DIWSProxy object is null");
                    return;
                }

                DIWSProxy.Url = DIWS_URL;
                DIWSProxy.Context = new SessionHeader();
                DIWSProxy.Context.SessionId = sessID;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Exception caught in init. : " + e.StackTrace);
            }
        }

        public static void printUsage()
        {

            Console.WriteLine("Usage: DataIntegrationSample1.exe [-s|-ns] <WSH Hostname> <WSH Port Num> <Repository Domain Name> <Repository Name> <User Name> <Password> <DI Service Domain Name> <DI Service Name> <Folder Name> <Workflow Name> <Task Name>");
            Console.WriteLine("-s: secure mode | -ns: non secure mode");
            Console.WriteLine("<WSH Hostname> : host name of WSH");
            Console.WriteLine("<WSH Port Num> : port number of WSH");
            Console.WriteLine("<Repository Domain Name> : name of the domain of the repository");
            Console.WriteLine("<Repository Name> : name of the repository");
            Console.WriteLine("<User name> : user name for the repository");
            Console.WriteLine("<Password> : pass word for repository");
            Console.WriteLine("<DI Service Domain Name> : name of the domain of the di service");
            Console.WriteLine("<DI Service Name> : name of DI service");
            Console.WriteLine("<Folder Name> : Folder name to be used in DI WS");
            Console.WriteLine("<Workflow Name> : Workflow name to be used in DI WS");
            Console.WriteLine("<Task Name> : Task name to be used in DI WS");
            Console.WriteLine();
            Console.WriteLine("This sample does login to the specfied repository and connects to PowerCenter " +
                                "Server. It then starts and stops the specified workflow. " +
                                "After that it starts the specified task and wait till it completes");

        }

        // main function
        public static void Main(string[] args)
        {

            try
            {
                // check for the no. of arguments
                if (args.Length < 12)
                {
                    Console.WriteLine("Invalid Parameters");
                    printUsage();
                    return;
                }

                // call init function
                Console.WriteLine("[Status] : Initializing...");
                init(args);
                Console.WriteLine("[Status] : Done");

                /**
                 * This implements the step 4 of developing client applications discussed in
                 * Getting Started chapter of documentation.
                 */

                // create a workflow request object and set various fields
                WorkflowRequest wfReq = new WorkflowRequest();
                DIServiceInfo diInfo = new DIServiceInfo();
                diInfo.DomainName = DI_DOMAIN_NAME;
                diInfo.ServiceName = DI_SERVICE_NAME;
                wfReq.WorkflowName = (WORKFLOW_NAME);
                wfReq.FolderName = (FOLDER_NAME);
                wfReq.RequestMode = (ETaskRunMode.NORMAL);
                wfReq.DIServiceInfo = diInfo;

                // Call StartWorkflow method of Data Integration Web Service
                Console.WriteLine("[Status] : Calling StartWorkflow...");
                DIWSProxy.startWorkflow(wfReq);
                Console.WriteLine("[Status] : Done");

                // sleep for some time
                System.Threading.Thread.Sleep(3000);

                // get workflow details
                Console.WriteLine("[Status] : Calling GetWorkflowDetails...");
                WorkflowDetails wfDetails = DIWSProxy.getWorkflowDetails(wfReq);
                Console.WriteLine("[Status] : Done");

                // print workflow details, this prints only some of the fields
                // one can get other fields in WorkflowDetails as per requirement
                Console.WriteLine("[Output] : Workflow details are as follows...");
                Console.WriteLine("[Output] : Workflow name : " + wfDetails.WorkflowName);
                Console.WriteLine("[Output] : Workflow run id: " + wfDetails.WorkflowRunId);
                Console.WriteLine("[Output] : User name : " + wfDetails.UserName);
                Console.WriteLine("[Output] : Log file name : " + wfDetails.LogFileName);

                // stop workflow
                Console.WriteLine("[Status] : Calling StopWorkflow...");
                // stop this workflow with abort flag true. This will abort the workflow
                wfReq.IsAbort = (true);
                DIWSProxy.stopWorkflow(wfReq);
                Console.WriteLine("[Status] : Done");


                // create a task request object and set various fields
                TaskRequest tReq = new TaskRequest();
                tReq.FolderName = (FOLDER_NAME);
                tReq.WorkflowName = (WORKFLOW_NAME);
                tReq.TaskInstancePath = (TASK_NAME);
                tReq.RequestMode = (ETaskRunMode.NORMAL);
                tReq.DIServiceInfo = diInfo;

                // Call StartTask method of Data Integration Web Service
                Console.WriteLine("[Status] : Calling StartTask...");
                DIWSProxy.startTask(tReq);
                Console.WriteLine("[Status] : Done");

                // sleep for some time
                System.Threading.Thread.Sleep(3000);

                // get task details
                Console.WriteLine("[Status] : Calling GetTaskDetails...");
                TaskDetails tDetails = DIWSProxy.getTaskDetails(tReq);
                Console.WriteLine("[Status] : Done");

                // print task details, this prints only some of the fields
                // one can get other fields from TaskDetails as per requirement
                Console.WriteLine("[Output] : Task details are as follows...");
                Console.WriteLine("[Output] : Task instance name : " + tDetails.InstanceName);
                Console.WriteLine("[Output] : Task type : " + tDetails.TaskType);
                Console.WriteLine("[Output] : Task run status : " + tDetails.TaskRunStatus);


                // waiting for task to complete
                Console.WriteLine("[Status] : Calling WaitTillTaskComplete...");
                // waiting till this task completes
                DIWSProxy.waitTillTaskComplete(tReq);
                Console.WriteLine("[Status] : Done");

                Console.WriteLine("[Status] : calling Logout...");
                VoidRequest voidReq = new VoidRequest();
                MWSProxy.Logout(voidReq);
                Console.WriteLine("[Status] : Done");
            }

            catch (SoapException fault)
            {
                /*
                  SoapFault will contain the following schema

                  <SOAP-ENV: Fault>
                        <faultcode> Client/Server </faultcode>
                        <faultstring>Brief Description of Error</faultstring>
                        <detail>
                            <ns:WSHFaultDetails xmlns:ns="www.informatica.com/PowerCenter">
                                <ErrorCode>
                                    Error Code
                                </ ErrorCode >
                                <ExtendedDetails>
                                    Actual Error
                                </ ExtendedDetails >
                            </ns:WSHFaultDetails>
                        </detail>
                    </SOAP-ENV: Fault>

                    Thus essentially it contains the following four fields.

                    a. faultcode
                    b. faultstring
                    c. Error Code
                    d. Extended Details


                    For details on error cases refer to documentation

                    These four fields will be extracted as shown below

                */


                // displaying fault code
                Console.WriteLine("fault code is : " + fault.Code);

                // displaying fault string
                Console.WriteLine("fault string is : " + fault.Message);

                // Detail element, This will contain ErrorCode and ExtendedDetails
                XmlNode detail = fault.Detail;
                if (detail == null)
                    return;

                // get WSHFaultDetails element in the detail element 
                XmlElement WSHFaultDetails = detail["WSHFaultDetails", "http://www.informatica.com/wsh"];
                if (WSHFaultDetails == null)
                    return;

                XmlElement ErrorCode = WSHFaultDetails["ErrorCode"];
                XmlElement ExtendedDetails = WSHFaultDetails["ExtendedDetails"];

                // Display error code
                Console.WriteLine("error code is : " + ErrorCode.InnerText);

                // Display extended details
                Console.WriteLine("extended detail is : " + ExtendedDetails.InnerText);
            }
        }
    }
}
