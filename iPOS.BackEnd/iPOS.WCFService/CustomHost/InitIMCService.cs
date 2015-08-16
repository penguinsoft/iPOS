using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using iPOS.Core.BasicValidation;
using Microsoft.ServiceModel.Web;

namespace iPOS.WCFService.CustomHost
{
    public class InitIMCService : ServiceHostFactoryBase
    {
        public override ServiceHostBase CreateServiceHost(string service, Uri[] baseAddresses)
        {
            IMCService.AutoMapper();
            IMCService.Autofac();
            WebServiceHost2 serviceHost = new WebServiceHost2(typeof(IMCService), true, baseAddresses);
            serviceHost.Interceptors.Add(new BasicRequestInterceptor(new AuthenticationServiceStub("helldemons", "_P@ssw0rds"), "iPOS"));

            return serviceHost;
        }
    }
}