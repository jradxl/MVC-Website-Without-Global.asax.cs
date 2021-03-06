﻿using System;
using System.Web;

namespace DemoModules.Startup2
{
    public class DemoStartup2 : IHttpModule
    {
        #region Static privates
        private static volatile bool applicationStarted = false;
        private static object applicationStartLock = new object();
        private const string Realm = "DemoModules.Startup1";
        #endregion

        #region 
        /// <summary>
        /// Initializes the specified module.
        /// </summary>
        /// <param name="context">The application context that instantiated and will be running this module.</param>
        public void Init(HttpApplication context)
        {
            System.Diagnostics.Debug.WriteLine("DemoModules.Startup2: Init");

            context.BeginRequest += Context_BeginRequest;

            if (!applicationStarted)
            {
                lock (applicationStartLock)
                {
                    if (!applicationStarted)
                    {
                        System.Diagnostics.Debug.WriteLine("DemoModules.Startup2: =============================");
                        // this will run only once per application start                
                        this.OnStart(context);
                        applicationStarted = true;
                    }
                }
            }
            // this will run on every HttpApplication initialization in the application pool
            this.OnInit(context);
        }
        #endregion

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        /// <summary>Initializes any data/resources on application start.</summary>
        /// <param name="context">The application context that instantiated and will be running this module.</param>
        public virtual void OnStart(HttpApplication context)
        {
            // put your application start code here
        }

        /// <summary>Initializes any data/resources on HTTP module start.</summary>
        /// <param name="context">The application context that instantiated and will be running this module.</param>
        public virtual void OnInit(HttpApplication context)
        {
            // put your module initialization code here
        }

        #region IHttpModule implementation
        /// <summary>
        /// Disposes of the resources (other than memory) used by the module that implements <see cref="T:System.Web.IHttpModule"/>.
        /// </summary>
        public void Dispose()
        {
            // dispose any resources if needed
        }
        #endregion
    }
}
