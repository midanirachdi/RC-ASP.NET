﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RefugeeCamp.Web.Startup))]

namespace RefugeeCamp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            var idProvider = new CustomUserIdProvider();

            GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => idProvider);

            app.MapSignalR();
        }
    }
}
