using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using iPOS.DCO.Products;
using iPOS.DCO.Systems;
using iPOS.DCO.Tools;

namespace iPOS.WCFService
{
    [ServiceContract]
    public interface IIMCService
    {
        #region [SYS_tblActionLog]
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertUpdateLog",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        SYS_tblActionLogDRO InsertUpdateLog(SYS_tblActionLogDCO actionLog);
        #endregion

        #region [SYS_tblGroupUser]
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAllGroupUsers?Username={Username}&LanguageID={LanguageID}&GetComboBox={GetComboBox}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SYS_tblGroupUserDRO GetAllGroupUsers(string Username, string LanguageID, bool GetComboBox);

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
        [WebInvoke(Method = "GET", UriTemplate = "/DeleteGroupUser?Username={Username}&LanguageID={LanguageID}&GroupUserIDList={GroupUserIDList}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SYS_tblGroupUserDRO DeleteGroupUser(string Username, string LanguageID, string GroupUserIDList);
        #endregion

        #region [SYS_tblUser]
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/CheckLogin?Username={Username}&Password={Password}&LanguageID={LanguageID}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SYS_tblUserDRO CheckLogin(string Username, string Password, string LanguageID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAllUsers?Username={Username}&LanguageID={LanguageID}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SYS_tblUserDRO GetAllUsers(string Username, string LanguageID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetUserByID?Username={Username}&LanguageID={LanguageID}&UsernameOther={UsernameOther}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SYS_tblUserDRO GetUserByID(string Username, string LanguageID, string UsernameOther);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertUpdateUser",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        SYS_tblUserDRO InsertUpdateUser(SYS_tblUserDCO user); 

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/DeleteUser?Username={Username}&LanguageID={LanguageID}&UserCodeList={UserCodeList}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SYS_tblUserDRO DeleteUser(string Username, string LanguageID, string UserCodeList); 

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/ChangeUserPassword?Username={Username}&LanguageID={LanguageID}&Password={Password}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SYS_tblUserDRO ChangeUserPassword(string Username, string LanguageID, string Password); 
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

        #region [SYS_tblPermission]
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetPermissionList?Username={Username}&LanguageID={LanguageID}&ID={ID}&ParentID={ParentID}&IsUser={IsUser}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SYS_tblPermissionDRO GetPermissionList(string Username, string LanguageID, string ID, string ParentID, bool IsUser);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/UpdatePermission",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        SYS_tblPermissionDRO UpdatePermission(string Username, string LanguageID, bool IsUser, List<SYS_tblPermissionDCO> permissionList);
        #endregion

        #region [PRO_tblProvince]
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAllProvinces?Username={Username}&LanguageID={LanguageID}&GetCombobox={GetCombobox}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PRO_tblProvinceDRO GetAllProvinces(string Username, string LanguageID, bool GetCombobox);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetProvinceByID?Username={Username}&LanguageID={LanguageID}&ProvinceID={ProvinceID}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PRO_tblProvinceDRO GetProvinceByID(string Username, string LanguageID, string ProvinceID);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertUpdateProvince",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        PRO_tblProvinceDRO InsertUpdateProvince(PRO_tblProvinceDCO province);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/DeleteProvince?Username={Username}&LanguageID={LanguageID}&ProvinceIDList={ProvinceIDList}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PRO_tblProvinceDRO DeleteProvince(string Username, string LanguageID, string ProvinceIDList); 
        #endregion

        #region [PRO_tblDistrict]
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAllDistrict?Username={Username}&LanguageID={LanguageID}&ProvinceID={ProvinceID}&GetCombobox={GetCombobox}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PRO_tblDistrictDRO GetAllDistrict(string Username, string LanguageID, string ProvinceID, bool GetCombobox);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetDistrictByID?Username={Username}&LanguageID={LanguageID}&DistrictID={DistrictID}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PRO_tblDistrictDRO GetDistrictByID(string Username, string LanguageID, string DistrictID);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertUpdateDistrict",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        PRO_tblDistrictDRO InsertUpdateDistrict(PRO_tblDistrictDCO district);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/DeleteDistrict?Username={Username}&LanguageID={LanguageID}&DistrictIDList={DistrictIDList}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PRO_tblDistrictDRO DeleteDistrict(string Username, string LanguageID, string DistrictIDList);
        #endregion

        #region [PRO_tblStore]
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAllStores?Username={Username}&LanguageID={LanguageID}&GetCombobox={GetCombobox}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PRO_tblStoreDRO GetAllStores(string Username, string LanguageID, bool GetCombobox);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetStoreByID?Username={Username}&LanguageID={LanguageID}&StoreID={StoreID}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PRO_tblStoreDRO GetStoreByID(string Username, string LanguageID, string StoreID);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertUpdateStore",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        PRO_tblStoreDRO InsertUpdateStore(PRO_tblStoreDCO store);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/DeleteStore?Username={Username}&LanguageID={LanguageID}&StoreIDList={StoreIDList}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PRO_tblStoreDRO DeleteStore(string Username, string LanguageID, string StoreIDList);
        #endregion

        #region [PRO_tblWarehouse]
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAllWarehouses?Username={Username}&LanguageID={LanguageID}&StoreID={StoreID}&ProvinceID={ProvinceID}&DistrictID={DistrictID}&GetCombobox={GetCombobox}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PRO_tblWarehouseDRO GetAllWarehouses(string Username, string LanguageID, string StoreID, string ProvinceID, string DistrictID, bool GetCombobox);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetWarehouseByID?Username={Username}&LanguageID={LanguageID}&WarehouseID={WarehouseID}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PRO_tblWarehouseDRO GetWarehouseByID(string Username, string LanguageID, string WarehouseID);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertUpdateWarehouse",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        PRO_tblWarehouseDRO InsertUpdateWarehouse(PRO_tblWarehouseDCO warehouse);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/DeleteWarehouse?Username={Username}&LanguageID={LanguageID}&WarehouseIDList={WarehouseIDList}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PRO_tblWarehouseDRO DeleteWarehouse(string Username, string LanguageID, string WarehouseIDList);
        #endregion 

        #region [PRO_tblStall]
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAllStalls?Username={Username}&LanguageID={LanguageID}&StoreID={StoreID}&WarehouseID={WarehouseID}&GetCombobox={GetCombobox}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PRO_tblStallDRO GetAllStalls(string Username, string LanguageID, string StoreID, string WarehouseID, bool GetCombobox);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetStallByID?Username={Username}&LanguageID={LanguageID}&StallID={StallID}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PRO_tblStallDRO GetStallByID(string Username, string LanguageID, string StallID);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/InsertUpdateStall",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        PRO_tblStallDRO InsertUpdateStall(PRO_tblStallDCO stall);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/DeleteStall?Username={Username}&LanguageID={LanguageID}&StallIDList={StallIDList}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        PRO_tblStallDRO DeleteStall(string Username, string LanguageID, string StallIDList);
        #endregion 

        #region [Tools]
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetTableColumnList?Username={Username}&ObjectName={ObjectName}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        OBJ_TableColumnDRO GetTableColumnList(string Username, string ObjectName);
        #endregion
    }
}
