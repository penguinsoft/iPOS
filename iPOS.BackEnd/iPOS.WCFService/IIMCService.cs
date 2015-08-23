using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using iPOS.DCO.Product;
using iPOS.DCO.Systems;
using iPOS.DCO.Tools;

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

        #region [SYS_tblUser]
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAllUsers?Username={Username}&LanguageID={LanguageID}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SYS_tblUserDRO GetAllUsers(string Username, string LanguageID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetUserByID?Username={Username}&LanguageID={LanguageID}&UsernameOther={UsernameOther}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SYS_tblUserDRO GetUserByID(string Username, string LanguageID, string UsernameOther);
        #endregion

        #region [SYS_tblReportCaption]
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetReportCaption?Username={Username}&LanguageID={LanguageID}&FunctionID={FunctionID}&IsImport={IsImport}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SYS_tblReportCaptionDRO GetReportCaption(string Username, string LanguageID, string FunctionID, bool IsImport);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetComboDynamicList?Username={Username}&LanguageID={LanguageID}&Code={Code}&TableName={TableName}&GetBy={GetBy}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SYS_tblReportCaptionDRO GetComboDynamicList(string Username, string LanguageID, string Code, string TableName, string GetBy);
        #endregion

        #region [SYS_tblImportFileConfig]
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/CheckValidImportTemplate?Username={Username}&LanguageID={LanguageID}&StoreProcedure={StoreProcedure}&FileName={FileName}&ModuleID={ModuleID}&FunctionID={FunctionID}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SYS_tblImportFileConfigDRO CheckValidImportTemplate(string Username, string LanguageID, string StoreProcedure, string FileName, string ModuleID, string FunctionID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/ImportDataRow?Username={Username}&InputData={InputData}&StoreProcedure={StoreProcedure}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SYS_tblImportFileConfigDRO ImportDataRow(string Username, string InputData, string StoreProcedure);
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

        #region [Tools]
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetTableColumnList?Username={Username}&ObjectName={ObjectName}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        OBJ_TableColumnDRO GetTableColumnList(string Username, string ObjectName);
        #endregion
    }
}
