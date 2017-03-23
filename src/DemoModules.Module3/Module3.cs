using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Collections;

namespace DemoModules.Module3
{ 
    /// <summary>
    /// Summary description for clsLifeCycle
    /// </summary>
    public class DemoModule3 : IHttpModule
    {
        private HttpApplication httpApp;
        public static ArrayList objArrayList = new ArrayList();

        public DemoModule3()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void Init(HttpApplication context)
        {
            System.Diagnostics.Debug.WriteLine("DemoModules.Module3: Init");

            this.httpApp = context;
            httpApp.Context.Response.Clear();
            objArrayList.Clear();
            objArrayList.Add("httpModule:Init");
            httpApp.AuthenticateRequest += new EventHandler(OnAuthentication);
            httpApp.AuthorizeRequest += new EventHandler(OnAuthorization);
            httpApp.BeginRequest += new EventHandler(OnBeginrequest);
            httpApp.EndRequest += new EventHandler(OnEndRequest);
            httpApp.ResolveRequestCache += new EventHandler(OnResolveRequestCache);
            httpApp.AcquireRequestState += new EventHandler(OnAcquireRequestState);
            httpApp.PreRequestHandlerExecute += new EventHandler(OnPreRequestHandlerExecute);
            httpApp.PostRequestHandlerExecute += new EventHandler(OnPostRequestHandlerExecute);
            httpApp.ReleaseRequestState += new EventHandler(OnReleaseRequestState);
            httpApp.UpdateRequestCache += new EventHandler(OnUpdateRequestCache);
        }
        void OnUpdateRequestCache(object sender, EventArgs a)
        {
            objArrayList.Add("httpModule:OnUpdateRequestCache");
        }
        void OnReleaseRequestState(object sender, EventArgs a)
        {
            objArrayList.Add("httpModule:OnReleaseRequestState");
        }
        void OnPostRequestHandlerExecute(object sender, EventArgs a)
        {
            objArrayList.Add("httpModule:OnPostRequestHandlerExecute");
        }
        void OnPreRequestHandlerExecute(object sender, EventArgs a)
        {
            objArrayList.Add("httpModule:OnPreRequestHandlerExecute");
        }
        void OnAcquireRequestState(object sender, EventArgs a)
        {
            objArrayList.Add("httpModule:OnAcquireRequestState");
        }
        void OnResolveRequestCache(object sender, EventArgs a)
        {
            objArrayList.Add("httpModule:OnResolveRequestCache");
        }
        void OnAuthorization(object sender, EventArgs a)
        {
            objArrayList.Add("httpModule:OnAuthorization");
        }
        void OnAuthentication(object sender, EventArgs a)
        {
            objArrayList.Add("httpModule:AuthenticateRequest");
        }
        void OnBeginrequest(object sender, EventArgs a)
        {
            objArrayList.Add("httpModule:BeginRequest");
        }
        void OnEndRequest(object sender, EventArgs a)
        {
            objArrayList.Add("httpModule:EndRequest");
            objArrayList.Add("<hr>");
            foreach (string str in objArrayList)
            {
                httpApp.Context.Response.Write(str + "<br>");
            }
        }

        public void Dispose()
        {
            //throw new Exception("The method or operation is not implemented.");
        }
    }

    public class clsHttpHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            DemoModule3.objArrayList.Add("HttpHandler:ProcessRequest");
            context.Response.Redirect("Default.aspx");
        }
    }
}
