using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using iPOS.DCO.Product;

namespace iPOS.WCFService
{
    [ServiceContract]
    public interface IIMCService
    {

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAllProvinces",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PRO_tblProvinceDRO GetAllProvinces();
    }
}
