using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

[assembly: PreApplicationStartMethod(typeof(DemoModules.PreStartup1.PreApplicationStartCode), "Start")]
namespace DemoModules.PreStartup1
{
    public static class PreApplicationStartCode
    {
        private static bool _startWasCalled = false;
        public static void Start()
        {
            System.Diagnostics.Debug.WriteLine("++++++++++++++++++++++++++++++++ DemoModules.PreStartup1: Start");
            if (!_startWasCalled)
            {
                _startWasCalled = true;
                Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(DemoPreStartup1));
                System.Diagnostics.Debug.WriteLine("DemoModules.PreStartup1: Load Modules Here - Single call");
                // Do your startup logic here.

                //Configure here as would have been done in Global.asax.cs
                //This is the earliest in the application life-cycle.
                //There will still be multiple calls to PreStartup1, but
                //only once to this code
                BundleConfig.RegisterBundles(BundleTable.Bundles);
                AuthConfig.RegisterOpenAuth();
                RouteConfig.RegisterRoutes(RouteTable.Routes);
            }
        }
    }

    public class DemoPreStartup1 : IHttpModule
    {
        public DemoPreStartup1()
        {
            System.Diagnostics.Debug.WriteLine("DemoModules.PreStartup1: Dynamically Loaded In Constructor");
        }
        public void Init(HttpApplication context)
        {
            System.Diagnostics.Debug.WriteLine("DemoModules.PreStartup1: Dynamically Loaded In Init");
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
