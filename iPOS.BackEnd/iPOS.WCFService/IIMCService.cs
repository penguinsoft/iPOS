using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using iPOS.DCO.Product;
using iPOS.DCO.System;

namespace iPOS.WCFService
{
    [ServiceContract]
    public interface IIMCService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/CheckLogin?Username={Username}&Password={Password}&LanguageID={LanguageID}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SYS_tblUserDRO CheckLogin(string Username, string Password, string LanguageID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAllProvinces?Username={Username}&LanguageID={LanguageID}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PRO_tblProvinceDRO GetAllProvinces(string Username, string LanguageID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetProvinceByID?Username={Username}&LanguageID={LanguageID}&ProvinceID={ProvinceID}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PRO_tblProvinceDRO GetProvinceByID(string Username, string LanguageID, string ProvinceID);
    }
}
