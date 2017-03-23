using System;
using System.Web;

namespace DemoModules.Module2
{ 
    public class DemoModule2 : IHttpModule
    {
        public DemoModule2()
        {
            System.Diagnostics.Debug.WriteLine("DemoModules.Module2: Constructor");
        }

        public String ModuleName
        {
            get { return "DemoModule2"; }
        }

        // In the Init function, register for HttpApplication 
        // events by adding your handlers.
        public void Init(HttpApplication application)
        {
            System.Diagnostics.Debug.WriteLine("DemoModules.Module2: Init");

            application.BeginRequest += (new EventHandler(this.Application_BeginRequest));
            application.EndRequest += (new EventHandler(this.Application_EndRequest));
        }

        private void Application_BeginRequest(Object source,
             EventArgs e)
        {
            // Create HttpApplication and HttpContext objects to access
            // request and response properties.
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            string filePath = context.Request.FilePath;
            string fileExtension =
                VirtualPathUtility.GetExtension(filePath);
            if (fileExtension.Equals(".aspx"))
            {
                context.Response.Write("<h1><font color=red>" +
                    "DemoModule2: Beginning of Request" +
                    "</font></h1><hr>");
            }
        }

        private void Application_EndRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            string filePath = context.Request.FilePath;
            string fileExtension =
                VirtualPathUtility.GetExtension(filePath);
            if (fileExtension.Equals(".aspx"))
            {
                context.Response.Write("<hr><h1><font color=red>" +
                    "DemoModule2: End of Request</font></h1>");
            }
        }

        public void Dispose() { }
    }

}
