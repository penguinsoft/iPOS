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
        [WebInvoke(Method = "POST", UriTemplate = "/ManageActionLog",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        SYS_tblActionLogDRO ManageActionLog(SYS_tblActionLogDCO actionLog);

        #region [SYS_tblGroupUser]
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAllGroupUsers?Username={Username}&LanguageID={LanguageID}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SYS_tblGroupUserDRO GetAllGroupUsers(string Username, string LanguageID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetGroupUserByID?Username={Username}&LanguageID={LanguageID}&GroupID={GroupID}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SYS_tblGroupUserDRO GetGroupUserByID(string Username, string LanguageID, string GroupID);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertUpdateGroupUser",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        SYS_tblGroupUserDRO InsertUpdateGroupUser(SYS_tblGroupUserDCO groupUser);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/DeleteGroupUser?Username={Username}&LanguageID={LanguageID}&GroupUserIDList={GroupUserIDList}&GroupUserCodeList={GroupUserCodeList}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SYS_tblGroupUserDRO DeleteGroupUser(string Username, string LanguageID, string GroupUserIDList, string GroupUserCodeList);
        #endregion

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
