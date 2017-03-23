using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using WebApplication3;

[assembly: PreApplicationStartMethod(typeof(MyNamespace.PreApplicationStartCode), "Start")]

namespace MyNamespace
{
    public static class PreApplicationStartCode
    {
        private static bool _startWasCalled = false;
        public static void Start()
        {
            System.Diagnostics.Debug.WriteLine("++++++++++++++++++++++++++++++++ MyNamespace: Start");
            if (!_startWasCalled)
            {
                _startWasCalled = true;
                //Example
                Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(StaticResource));
                // Do your startup logic here.
            }
        }
    }

    public class StaticResource : IHttpModule
    {
        public StaticResource()
        {
            System.Diagnostics.Debug.WriteLine("MyNamespace: Dyanamic In Constructor");
        }
        public void Init(HttpApplication context)
        {
            System.Diagnostics.Debug.WriteLine("MyNamespace: Dyanamic Init");
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }
        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            string strUrl = context.Request.Url.OriginalString.ToLower();

            //HERE WE CAN CHECK IF REQUESTED URL IS FOR STATIC RESOURCE OR NOT
            if (strUrl.Contains("Path/To/Static-Bundle/Resource") == false)
            {
                //string strMainDomain = ConfigurationManager.AppSettings["MainDomain"];
                //context.Response.Redirect(strMainDomain);
            }
        }
        public void Dispose() { }
    }
}

namespace WebApplication3
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            System.Diagnostics.Debug.WriteLine("Application_Start");
        }

        void Application_Init(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Global.asax : Application_Init");
        }

        public override void Init()
        {
            base.Init();
            System.Diagnostics.Debug.WriteLine("Global.asax Init");
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Global.asax BeginRequest");
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
        }
    }
}
