using Manpower.Web.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Manpower.Web.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            //configure Autofac
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
            //configure AutoMapper
            AutoMapperConfiguration.Configure();

        }
    }
}