using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;
using CrossBeeze.CrossTest.Process.PowerCenter.proxyclasses;

namespace CrossBeeze.CrossTest.Process.PowerCenter
{
    public class PowerCenterExecutor
    {
        private Boolean isLoggedIn = false;
        private string metaUrl = "http://10.1.0.5:7333/wsh/services/Metadata";
        private string diUrl = "http://10.1.0.5:7333/wsh/services/DataIntegration";
        private string sessionID;

        //TODO make this configurable
        private string domain = "InfaDemo";
        private string repository = "InfaDemo-RS";
        private string integrationService = "InfaDemo_IS";

        DataIntegrationService DISProxy;
       
        public PowerCenterExecutor()
        {
            loginAndInitialize();
        }

        public void ExecuteWorkflow(String folderName, String workflowName)
        {
            //Create workflow request.
            WorkflowRequest workflowReq = new WorkflowRequest();
            DIServiceInfo diInfo = new DIServiceInfo();
            diInfo.DomainName = this.domain;
            diInfo.ServiceName = this.integrationService;
            workflowReq.WorkflowName = workflowName;
            workflowReq.FolderName = folderName;
            workflowReq.RequestMode = ETaskRunMode.NORMAL;
            workflowReq.DIServiceInfo = diInfo;

            //Start workflow
            DISProxy.startWorkflow(workflowReq);
            try
            {
                //Wait until workflow is finished
                DISProxy.waitTillWorkflowComplete(workflowReq);
            }
            catch (System.Web.Services.Protocols.SoapException exc)
            {
                throw new Exception("An error occured during workflow execution: " + exc.Message);
            }

        }

        private void loginAndInitialize()
        {
            MetadataService MWSProxy = new MetadataService(metaUrl);

            if (MWSProxy == null)
            {
                Console.WriteLine("MWSProxy object is null");
                return;
            }

            //Login
            LoginRequest loginReq = new LoginRequest();
            //TODO make this configurable
            loginReq.RepositoryDomainName = this.domain;
            loginReq.RepositoryName = this.repository;
            loginReq.UserName = "InfaDemo";
            loginReq.Password = "ZBvi9LD8Yk9T63QEgHxK";
            sessionID = MWSProxy.Login(loginReq);

            //Initialize the Data Integration Service Proxy
            DISProxy = new DataIntegrationService(diUrl);
            DISProxy.Context = new SessionHeader();
            DISProxy.Context.SessionId = sessionID;
            
        }
    }
}
