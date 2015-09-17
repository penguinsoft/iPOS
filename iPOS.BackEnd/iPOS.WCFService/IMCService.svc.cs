using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Autofac;
using AutoMapper;
using iPOS.Core.Helper;
using iPOS.Core.Logger;
using iPOS.DAO.Products;
using iPOS.DAO.Systems;
using iPOS.DAO.Tools;
using iPOS.DCO.Products;
using iPOS.DCO.Systems;
using iPOS.DCO.Tools;
using iPOS.DTO.Products;
using iPOS.DTO.Systems;
using iPOS.DTO.Tools;
using Newtonsoft.Json;

namespace iPOS.WCFService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
        InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class IMCService : IIMCService
    {
        private static IContainer Container { get; set; }
        private static ILogEngine logger;

        public IMCService()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                logger = scope.Resolve<ILogEngine>();
            }
        }

        public static void AutoMapper()
        {
            Mapper.CreateMap<SYS_tblActionLogDTO, SYS_tblActionLogDCO>();
            Mapper.CreateMap<SYS_tblActionLogDCO, SYS_tblActionLogDTO>();
            Mapper.CreateMap<SYS_tblGroupUserDTO, SYS_tblGroupUserDCO>();
            Mapper.CreateMap<SYS_tblGroupUserDCO, SYS_tblGroupUserDTO>();
            Mapper.CreateMap<SYS_tblUserDTO, SYS_tblUserDCO>();
            Mapper.CreateMap<SYS_tblUserDCO, SYS_tblUserDTO>();
            Mapper.CreateMap<SYS_tblReportCaptionDTO, SYS_tblReportCaptionDCO>();
            Mapper.CreateMap<SYS_tblReportCaptionDCO, SYS_tblReportCaptionDTO>();
            Mapper.CreateMap<ComboDynamicItemDTO, ComboDynamicItemDCO>();
            Mapper.CreateMap<ComboDynamicItemDCO, ComboDynamicItemDTO>();
            Mapper.CreateMap<SYS_tblImportFileConfigDTO, SYS_tblImportFileConfigDCO>();
            Mapper.CreateMap<SYS_tblImportFileConfigDCO, SYS_tblImportFileConfigDTO>();
            Mapper.CreateMap<SYS_tblPermissionDTO, SYS_tblPermissionDCO>();
            Mapper.CreateMap<SYS_tblPermissionDCO, SYS_tblPermissionDTO>();

            Mapper.CreateMap<PRO_tblProvinceDTO, PRO_tblProvinceDCO>();
            Mapper.CreateMap<PRO_tblProvinceDCO, PRO_tblProvinceDTO>();
            Mapper.CreateMap<PRO_tblDistrictDTO, PRO_tblDistrictDCO>();
            Mapper.CreateMap<PRO_tblDistrictDCO, PRO_tblDistrictDTO>();
            Mapper.CreateMap<PRO_tblStoreDTO, PRO_tblStoreDCO>();
            Mapper.CreateMap<PRO_tblStoreDCO, PRO_tblStoreDTO>();
            Mapper.CreateMap<PRO_tblWarehouseDTO, PRO_tblWarehouseDCO>();
            Mapper.CreateMap<PRO_tblWarehouseDCO, PRO_tblWarehouseDTO>();
            Mapper.CreateMap<PRO_tblStallDTO, PRO_tblStallDCO>();
            Mapper.CreateMap<PRO_tblStallDCO, PRO_tblStallDTO>();

            Mapper.CreateMap<OBJ_TableColumnDTO, OBJ_TableColumnDCO>();
            Mapper.CreateMap<OBJ_TableColumnDCO, OBJ_TableColumnDTO>();

            Mapper.AssertConfigurationIsValid();
        }

        public static void Autofac()
        {
            var afBuilder = new ContainerBuilder();
            afBuilder.RegisterType<LogEngine>().As<ILogEngine>();

            afBuilder.RegisterType<SYS_tblActionLogDAO>().As<ISYS_tblActionLogDAO>();
            afBuilder.RegisterType<SYS_tblGroupUserDAO>().As<ISYS_tblGroupUserDAO>();
            afBuilder.RegisterType<SYS_tblUserDAO>().As<ISYS_tblUserDAO>();
            afBuilder.RegisterType<SYS_tblReportCaptionDAO>().As<ISYS_tblReportCaptionDAO>();
            afBuilder.RegisterType<SYS_tblImportFileConfigDAO>().As<ISYS_tblImportFileConfigDAO>();
            afBuilder.RegisterType<SYS_tblPermissionDAO>().As<ISYS_tblPermissionDAO>();

            afBuilder.RegisterType<PRO_tblProvinceDAO>().As<IPRO_tblProvinceDAO>();
            afBuilder.RegisterType<PRO_tblDistrictDAO>().As<IPRO_tblDistrictDAO>();
            afBuilder.RegisterType<PRO_tblStoreDAO>().As<IPRO_tblStoreDAO>();
            afBuilder.RegisterType<PRO_tblWarehouseDAO>().As<IPRO_tblWarehouseDAO>();
            afBuilder.RegisterType<PRO_tblStallDAO>().As<IPRO_tblStallDAO>();

            afBuilder.RegisterType<OBJ_TableColumnDAO>().As<IOBJ_TableColumnDAO>();

            Container = afBuilder.Build();
        }

        #region [SYS_tblActionLog]
        public SYS_tblActionLogDRO InsertUpdateLog(SYS_tblActionLogDCO actionLog)
        {
            logger.Info("Start insert new action log");
            SYS_tblActionLogDRO result = new SYS_tblActionLogDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<ISYS_tblActionLogDAO>();
                    var data = Mapper.Map<SYS_tblActionLogDTO>(actionLog);
                    temp = db.InsertUpdateLog(data);

                    result.Result = !string.IsNullOrEmpty(temp) ? false : true;
                    result.Message = !string.IsNullOrEmpty(temp) ? temp : "";
                    result.Username = actionLog.UserID;
                    result.TotalItemCount = !string.IsNullOrEmpty(temp) ? 0 : 1;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
                result.Username = actionLog.UserID;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }
        #endregion

        #region [SYS_tblGroupUser]
        public SYS_tblGroupUserDRO GetAllGroupUsers(string Username, string LanguageID, bool GetComboBox)
        {
            SYS_tblGroupUserDRO result = new SYS_tblGroupUserDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    List<SYS_tblGroupUserDTO> temp = new List<SYS_tblGroupUserDTO>();
                    var db = scope.Resolve<ISYS_tblGroupUserDAO>();
                    if (!GetComboBox)
                        temp = db.LoadAllData(Username, LanguageID);
                    else temp = db.GetDataCombobox(Username, LanguageID);
                    if (temp != null)
                    {
                        result.GroupUserList = Mapper.Map<List<SYS_tblGroupUserDCO>>(temp);
                        result.Result = true;
                        result.Status = DCO.ResponseStatus.Success;
                        result.Message = "";
                        result.Username = Username;
                        result.TotalItemCount = temp.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                result.GroupUserList = Mapper.Map<List<SYS_tblGroupUserDCO>>(new List<SYS_tblGroupUserDTO>());
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Load group user list failed: " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public SYS_tblGroupUserDRO GetGroupUserByID(string Username, string LanguageID, string GroupID)
        {
            SYS_tblGroupUserDRO result = new SYS_tblGroupUserDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    SYS_tblGroupUserDTO temp = new SYS_tblGroupUserDTO();
                    var db = scope.Resolve<ISYS_tblGroupUserDAO>();
                    temp = db.GetDataByID(GroupID, Username, LanguageID);
                    if (temp != null)
                    {
                        result.GroupUserItem = Mapper.Map<SYS_tblGroupUserDCO>(temp);
                        result.Result = true;
                        result.Status = DCO.ResponseStatus.Success;
                        result.Message = "";
                        result.Username = Username;
                        result.TotalItemCount = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                result.GroupUserItem = Mapper.Map<SYS_tblGroupUserDCO>(new SYS_tblGroupUserDTO());
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Get data failed: " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
            }

            return result;
        }

        public SYS_tblGroupUserDRO InsertUpdateGroupUser(SYS_tblGroupUserDCO groupUser)
        {
            SYS_tblGroupUserDRO result = new SYS_tblGroupUserDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<ISYS_tblGroupUserDAO>();
                    var data = Mapper.Map<SYS_tblGroupUserDTO>(groupUser);
                    if (groupUser.Activity.Equals(BaseConstant.COMMAND_INSERT_EN))
                        temp = db.InsertGroupUser(data);
                    else temp = db.UpdateGroupUser(data);

                    result.Result = string.IsNullOrEmpty(temp) ? true : false;
                    result.Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure;
                    result.Message = string.IsNullOrEmpty(temp) ? string.Empty : temp;
                    result.Username = groupUser.UserID;
                    result.TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Insert new group user failed because " + ex.Message;
                result.Username = groupUser.UserID;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public SYS_tblGroupUserDRO DeleteGroupUser(string Username, string LanguageID, string GroupUserIDList)
        {
            SYS_tblGroupUserDRO result = new SYS_tblGroupUserDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<ISYS_tblGroupUserDAO>();
                    if (GroupUserIDList.Contains("$"))
                        temp = db.DeleteGroupUserList(GroupUserIDList, Username, LanguageID);
                    else temp = db.DeleteGroupUser(GroupUserIDList, Username, LanguageID);

                    result.Result = string.IsNullOrEmpty(temp) ? true : false;
                    result.Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure;
                    result.Message = string.IsNullOrEmpty(temp) ? string.Empty : temp;
                    result.Username = Username;
                    result.TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Delete group user failed because " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }
        #endregion

        #region [SYS_tblUser]
        public SYS_tblUserDRO CheckLogin(string Username, string Password, string LanguageID)
        {
            SYS_tblUserDRO result = new SYS_tblUserDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    SYS_tblUserDTO temp = new SYS_tblUserDTO();
                    var db = scope.Resolve<ISYS_tblUserDAO>();
                    temp = db.CheckLogin(Username, Password, LanguageID);
                    if (temp != null)
                    {
                        result.UserItem = Mapper.Map<SYS_tblUserDCO>(temp);
                        result.Result = true;
                        result.Message = temp.Username;
                        result.Username = Username;
                        result.TotalItemCount = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                result.UserItem = Mapper.Map<SYS_tblUserDCO>(new SYS_tblUserDTO());
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = " Check login failed: " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public SYS_tblUserDRO GetAllUsers(string Username, string LanguageID)
        {
            SYS_tblUserDRO result = new SYS_tblUserDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    List<SYS_tblUserDTO> temp = new List<SYS_tblUserDTO>();
                    var db = scope.Resolve<ISYS_tblUserDAO>();
                    temp = db.LoadAllData(Username, LanguageID);
                    if (temp != null)
                    {
                        result.UserList = Mapper.Map<List<SYS_tblUserDCO>>(temp);
                        result.Result = true;
                        result.Status = DCO.ResponseStatus.Success;
                        result.Message = "";
                        result.Username = Username;
                        result.TotalItemCount = temp.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                result.UserList = Mapper.Map<List<SYS_tblUserDCO>>(new List<SYS_tblUserDTO>());
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Load user list failed: " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public SYS_tblUserDRO GetUserByID(string Username, string LanguageID, string UsernameOther)
        {
            SYS_tblUserDRO result = new SYS_tblUserDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    SYS_tblUserDTO temp = new SYS_tblUserDTO();
                    var db = scope.Resolve<ISYS_tblUserDAO>();
                    temp = db.GetDataByID(UsernameOther, Username, LanguageID);
                    if (temp != null)
                    {
                        result.UserItem = Mapper.Map<SYS_tblUserDCO>(temp);
                        result.Result = true;
                        result.Status = DCO.ResponseStatus.Success;
                        result.Message = "";
                        result.Username = Username;
                        result.TotalItemCount = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                result.UserItem = Mapper.Map<SYS_tblUserDCO>(new SYS_tblUserDTO());
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Get data failed: " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
            }

            return result;
        }

        public SYS_tblUserDRO InsertUpdateUser(SYS_tblUserDCO user)
        {
            SYS_tblUserDRO result = new SYS_tblUserDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<ISYS_tblUserDAO>();
                    var data = Mapper.Map<SYS_tblUserDTO>(user);
                    if (user.Activity.Equals(BaseConstant.COMMAND_INSERT_EN))
                        temp = db.InsertUser(data);
                    else temp = db.UpdateUser(data);

                    result.Result = string.IsNullOrEmpty(temp) ? true : false;
                    result.Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure;
                    result.Message = string.IsNullOrEmpty(temp) ? string.Empty : temp;
                    result.Username = user.Username;
                    result.TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Insert new user failed because " + ex.Message;
                result.Username = user.Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public SYS_tblUserDRO DeleteUser(string Username, string LanguageID, string UserCodeList)
        {
            SYS_tblUserDRO result = new SYS_tblUserDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<ISYS_tblUserDAO>();
                    if (UserCodeList.Contains("$"))
                        temp = db.DeleteUserList(UserCodeList, Username, LanguageID);
                    else temp = db.DeleteUser(UserCodeList, Username, LanguageID);

                    result.Result = string.IsNullOrEmpty(temp) ? true : false;
                    result.Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure;
                    result.Message = string.IsNullOrEmpty(temp) ? string.Empty : temp;
                    result.Username = Username;
                    result.TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Delete user failed because " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public SYS_tblUserDRO ChangeUserPassword(string Username, string LanguageID, string Password)
        {
            SYS_tblUserDRO result = new SYS_tblUserDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<ISYS_tblUserDAO>();
                    temp = db.ChangeUserPassword(Username, LanguageID, Password);

                    result.Result = string.IsNullOrEmpty(temp) ? true : false;
                    result.Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure;
                    result.Message = string.IsNullOrEmpty(temp) ? string.Empty : temp;
                    result.Username = Username;
                    result.TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Change user password failed because " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }
        #endregion

        #region [SYS_tblReportCaption]
        public SYS_tblReportCaptionDRO GetReportCaption(string Username, string LanguageID, string FunctionID, bool IsImport)
        {
            SYS_tblReportCaptionDRO result = new SYS_tblReportCaptionDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    List<SYS_tblReportCaptionDTO> temp = new List<SYS_tblReportCaptionDTO>();
                    var db = scope.Resolve<ISYS_tblReportCaptionDAO>();
                    temp = db.LoadImportCaption(Username, LanguageID, FunctionID, IsImport);
                    if (temp != null)
                    {
                        result.ReportCaptionList = Mapper.Map<List<SYS_tblReportCaptionDCO>>(temp);
                        result.Result = true;
                        result.Status = DCO.ResponseStatus.Success;
                        result.Message = "";
                        result.Username = Username;
                        result.TotalItemCount = temp.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ReportCaptionList = Mapper.Map<List<SYS_tblReportCaptionDCO>>(new List<SYS_tblReportCaptionDTO>());
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Load data failed: " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public SYS_tblReportCaptionDRO GetComboDynamicList(string Username, string LanguageID, string Code, string TableName, string GetBy)
        {
            SYS_tblReportCaptionDRO result = new SYS_tblReportCaptionDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    List<ComboDynamicItemDTO> temp = new List<ComboDynamicItemDTO>();
                    var db = scope.Resolve<ISYS_tblReportCaptionDAO>();
                    temp = db.LoadComboDynamicList(Username, LanguageID, Code, TableName, GetBy);
                    if (temp != null)
                    {
                        result.ComboDynamicList = Mapper.Map<List<ComboDynamicItemDCO>>(temp);
                        result.Result = true;
                        result.Status = DCO.ResponseStatus.Success;
                        result.Message = "";
                        result.Username = Username;
                        result.TotalItemCount = temp.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ComboDynamicList = Mapper.Map<List<ComboDynamicItemDCO>>(new List<ComboDynamicItemDTO>());
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Load data failed: " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }
        #endregion

        #region [SYS_tblImportFileConfig]
        public SYS_tblImportFileConfigDRO CheckValidImportTemplate(string Username, string LanguageID, string StoreProcedure, string FileName, string ModuleID, string FunctionID)
        {
            SYS_tblImportFileConfigDRO result = new SYS_tblImportFileConfigDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    SYS_tblImportFileConfigDTO temp = new SYS_tblImportFileConfigDTO();
                    var db = scope.Resolve<ISYS_tblImportFileConfigDAO>();
                    temp = db.CheckValidImportTemplate(Username, LanguageID, StoreProcedure, FileName, ModuleID, FunctionID);
                    if (temp != null)
                    {
                        result.ImportFileConfigItem = Mapper.Map<SYS_tblImportFileConfigDCO>(temp);
                        result.Result = true;
                        result.Status = DCO.ResponseStatus.Success;
                        result.Message = "";
                        result.Username = Username;
                        result.TotalItemCount = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ImportFileConfigItem = Mapper.Map<SYS_tblImportFileConfigDCO>(new SYS_tblImportFileConfigDTO());
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Get data failed: " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
            }

            return result;
        }

        public SYS_tblImportFileConfigDRO ImportDataRow(string Username, string InputData, string StoreProcedure)
        {
            SYS_tblImportFileConfigDRO result = new SYS_tblImportFileConfigDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<ISYS_tblImportFileConfigDAO>();
                    Dictionary<string, string> input = JsonConvert.DeserializeObject<Dictionary<string, string>>(InputData);
                    temp = db.ImportDataRow(input, StoreProcedure);

                    result.Result = string.IsNullOrEmpty(temp) ? true : false;
                    result.Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure;
                    result.Message = string.IsNullOrEmpty(temp) ? string.Empty : temp;
                    result.Username = Username;
                    result.TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Import data failed because " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }
        #endregion

        #region [SYS_tblPermission]
        public SYS_tblPermissionDRO GetPermissionList(string Username, string LanguageID, string ID, string ParentID, bool IsUser)
        {
            if (string.IsNullOrEmpty(ParentID)) ParentID = "";
            SYS_tblPermissionDRO result = new SYS_tblPermissionDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    List<SYS_tblPermissionDTO> temp = new List<SYS_tblPermissionDTO>();
                    var db = scope.Resolve<ISYS_tblPermissionDAO>();
                    temp = db.GetAllPermisionList(Username, LanguageID, ID, ParentID, IsUser);
                    if (temp != null)
                    {
                        result.PermissionList = Mapper.Map<List<SYS_tblPermissionDCO>>(temp);
                        result.Result = true;
                        result.Status = DCO.ResponseStatus.Success;
                        result.Message = "";
                        result.Username = Username;
                        result.TotalItemCount = temp.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                result.PermissionList = Mapper.Map<List<SYS_tblPermissionDCO>>(new List<SYS_tblPermissionDTO>());
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Load permission failed: " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public SYS_tblPermissionDRO UpdatePermission(string Username, string LanguageID, bool IsUser, List<SYS_tblPermissionDCO> permissionList)
        {
            SYS_tblPermissionDRO result = new SYS_tblPermissionDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<ISYS_tblPermissionDAO>();
                    var permissions = Mapper.Map<List<SYS_tblPermissionDTO>>(permissionList);
                    temp = db.UpdatePermission(Username, LanguageID, permissions, IsUser);

                    result.Result = string.IsNullOrEmpty(temp) ? true : false;
                    result.Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure;
                    result.Message = string.IsNullOrEmpty(temp) ? string.Empty : temp;
                    result.Username = Username;
                    result.TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Update permission failed because " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }
        #endregion

        #region [PRO_tblProvince]
        public PRO_tblProvinceDRO GetAllProvinces(string Username, string LanguageID, bool GetCombobox)
        {
            PRO_tblProvinceDRO result = new PRO_tblProvinceDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    List<PRO_tblProvinceDTO> temp = new List<PRO_tblProvinceDTO>();
                    var db = scope.Resolve<IPRO_tblProvinceDAO>();
                    if (!GetCombobox)
                        temp = db.LoadAllData(Username, LanguageID);
                    else temp = db.GetDataCombobox(Username, LanguageID);
                    if (temp != null)
                    {
                        result.ProvinceList = Mapper.Map<List<PRO_tblProvinceDCO>>(temp);
                        result.Result = true;
                        result.Status = DCO.ResponseStatus.Success;
                        result.Message = "";
                        result.Username = Username;
                        result.TotalItemCount = temp.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ProvinceList = Mapper.Map<List<PRO_tblProvinceDCO>>(new List<PRO_tblProvinceDTO>());
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Load province list failed: " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblProvinceDRO GetProvinceByID(string Username, string LanguageID, string ProvinceID)
        {
            PRO_tblProvinceDRO result = new PRO_tblProvinceDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    var db = scope.Resolve<IPRO_tblProvinceDAO>();
                    var temp = db.GetDataByID(ProvinceID, Username, LanguageID);
                    if (temp != null)
                    {
                        result.ProvinceItem = Mapper.Map<PRO_tblProvinceDCO>(temp);
                        result.Result = true;
                        result.Status = DCO.ResponseStatus.Success;
                        result.Message = "";
                        result.Username = Username;
                        result.TotalItemCount = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ProvinceItem = Mapper.Map<PRO_tblProvinceDCO>(new PRO_tblProvinceDTO());
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Load province item failed: " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblProvinceDRO InsertUpdateProvince(PRO_tblProvinceDCO province)
        {
            PRO_tblProvinceDRO result = new PRO_tblProvinceDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<IPRO_tblProvinceDAO>();
                    var data = Mapper.Map<PRO_tblProvinceDTO>(province);
                    if (province.Activity.Equals(BaseConstant.COMMAND_INSERT_EN))
                        temp = db.InsertProvince(data);
                    else temp = db.UpdateProvince(data);

                    result.Result = string.IsNullOrEmpty(temp) ? true : false;
                    result.Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure;
                    result.Message = string.IsNullOrEmpty(temp) ? string.Empty : temp;
                    result.Username = province.UserID;
                    result.TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Insert new province failed because " + ex.Message;
                result.Username = province.UserID;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblProvinceDRO DeleteProvince(string Username, string LanguageID, string ProvinceIDList)
        {
            PRO_tblProvinceDRO result = new PRO_tblProvinceDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<IPRO_tblProvinceDAO>();
                    if (ProvinceIDList.Contains("$"))
                        temp = db.DeleteProvinceList(ProvinceIDList, Username, LanguageID);
                    else temp = db.DeleteProvince(ProvinceIDList, Username, LanguageID);

                    result.Result = string.IsNullOrEmpty(temp) ? true : false;
                    result.Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure;
                    result.Message = string.IsNullOrEmpty(temp) ? string.Empty : temp;
                    result.Username = Username;
                    result.TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Delete province failed because " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }
        #endregion

        #region [PRO_tblDistrict]
        public PRO_tblDistrictDRO GetAllDistrict(string Username, string LanguageID, string ProvinceID, bool GetCombobox)
        {
            PRO_tblDistrictDRO result = new PRO_tblDistrictDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    List<PRO_tblDistrictDTO> temp = new List<PRO_tblDistrictDTO>();
                    var db = scope.Resolve<IPRO_tblDistrictDAO>();
                    if (!GetCombobox)
                        temp = db.LoadAllData(Username, LanguageID, ProvinceID);
                    else temp = db.GetDataCombobox(Username, LanguageID, ProvinceID);
                    if (temp != null)
                    {
                        result.DistrictList = Mapper.Map<List<PRO_tblDistrictDCO>>(temp);
                        result.Result = true;
                        result.Status = DCO.ResponseStatus.Success;
                        result.Message = "";
                        result.Username = Username;
                        result.TotalItemCount = temp.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                result.DistrictList = Mapper.Map<List<PRO_tblDistrictDCO>>(new List<PRO_tblDistrictDTO>());
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Load district list failed: " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblDistrictDRO GetDistrictByID(string Username, string LanguageID, string DistrictID)
        {
            PRO_tblDistrictDRO result = new PRO_tblDistrictDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    var db = scope.Resolve<IPRO_tblDistrictDAO>();
                    var temp = db.GetDataByID(DistrictID, Username, LanguageID);
                    if (temp != null)
                    {
                        result.DistrictItem = Mapper.Map<PRO_tblDistrictDCO>(temp);
                        result.Result = true;
                        result.Status = DCO.ResponseStatus.Success;
                        result.Message = "";
                        result.Username = Username;
                        result.TotalItemCount = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                result.DistrictItem = Mapper.Map<PRO_tblDistrictDCO>(new PRO_tblDistrictDTO());
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Load district item failed: " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblDistrictDRO InsertUpdateDistrict(PRO_tblDistrictDCO district)
        {
            PRO_tblDistrictDRO result = new PRO_tblDistrictDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<IPRO_tblDistrictDAO>();
                    var data = Mapper.Map<PRO_tblDistrictDTO>(district);
                    if (district.Activity.Equals(BaseConstant.COMMAND_INSERT_EN))
                        temp = db.InsertDistrict(data);
                    else temp = db.UpdateDistrict(data);

                    result.Result = string.IsNullOrEmpty(temp) ? true : false;
                    result.Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure;
                    result.Message = string.IsNullOrEmpty(temp) ? string.Empty : temp;
                    result.Username = district.UserID;
                    result.TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Insert new district failed because " + ex.Message;
                result.Username = district.UserID;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblDistrictDRO DeleteDistrict(string Username, string LanguageID, string DistrictIDList)
        {
            PRO_tblDistrictDRO result = new PRO_tblDistrictDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<IPRO_tblDistrictDAO>();
                    if (DistrictIDList.Contains("$"))
                        temp = db.DeleteDistrictList(DistrictIDList, Username, LanguageID);
                    else temp = db.DeleteDistrict(DistrictIDList, Username, LanguageID);

                    result.Result = string.IsNullOrEmpty(temp) ? true : false;
                    result.Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure;
                    result.Message = string.IsNullOrEmpty(temp) ? string.Empty : temp;
                    result.Username = Username;
                    result.TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Delete district failed because " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }
        #endregion

        #region [PRO_tblStore]
        public PRO_tblStoreDRO GetAllStores(string Username, string LanguageID, bool GetCombobox)
        {
            PRO_tblStoreDRO result = new PRO_tblStoreDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    List<PRO_tblStoreDTO> temp = new List<PRO_tblStoreDTO>();
                    var db = scope.Resolve<IPRO_tblStoreDAO>();
                    if (!GetCombobox)
                        temp = db.LoadAllData(Username, LanguageID);
                    else temp = db.GetDataCombobox(Username, LanguageID);
                    if (temp != null)
                    {
                        result.StoreList = Mapper.Map<List<PRO_tblStoreDCO>>(temp);
                        result.Result = true;
                        result.Status = DCO.ResponseStatus.Success;
                        result.Message = "";
                        result.Username = Username;
                        result.TotalItemCount = temp.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                result.StoreList = Mapper.Map<List<PRO_tblStoreDCO>>(new List<PRO_tblStoreDTO>());
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Load store list failed: " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblStoreDRO GetStoreByID(string Username, string LanguageID, string StoreID)
        {
            PRO_tblStoreDRO result = new PRO_tblStoreDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    var db = scope.Resolve<IPRO_tblStoreDAO>();
                    var temp = db.GetDataByID(Username, LanguageID, StoreID);
                    if (temp != null)
                    {
                        result.StoreItem = Mapper.Map<PRO_tblStoreDCO>(temp);
                        result.Result = true;
                        result.Status = DCO.ResponseStatus.Success;
                        result.Message = "";
                        result.Username = Username;
                        result.TotalItemCount = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                result.StoreItem = Mapper.Map<PRO_tblStoreDCO>(new PRO_tblStoreDTO());
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Load store item failed: " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblStoreDRO InsertUpdateStore(PRO_tblStoreDCO store)
        {
            PRO_tblStoreDRO result = new PRO_tblStoreDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<IPRO_tblStoreDAO>();
                    var data = Mapper.Map<PRO_tblStoreDTO>(store);
                    if (store.Activity.Equals(BaseConstant.COMMAND_INSERT_EN))
                        temp = db.InsertStore(data);
                    else temp = db.UpdateStore(data);

                    result.Result = string.IsNullOrEmpty(temp) ? true : false;
                    result.Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure;
                    result.Message = string.IsNullOrEmpty(temp) ? string.Empty : temp;
                    result.Username = store.UserID;
                    result.TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Insert new store failed because " + ex.Message;
                result.Username = store.UserID;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblStoreDRO DeleteStore(string Username, string LanguageID, string StoreIDList)
        {
            PRO_tblStoreDRO result = new PRO_tblStoreDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<IPRO_tblStoreDAO>();
                    if (StoreIDList.Contains("$"))
                        temp = db.DeleteStoreList(StoreIDList, Username, LanguageID);
                    else temp = db.DeleteStore(StoreIDList, Username, LanguageID);

                    result.Result = string.IsNullOrEmpty(temp) ? true : false;
                    result.Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure;
                    result.Message = string.IsNullOrEmpty(temp) ? string.Empty : temp;
                    result.Username = Username;
                    result.TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Delete store failed because " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }
        #endregion

        #region [PRO_tblWarehouse]
        public PRO_tblWarehouseDRO GetAllWarehouses(string Username, string LanguageID, string StoreID, string ProvinceID, string DistrictID, bool GetCombobox)
        {
            PRO_tblWarehouseDRO result = new PRO_tblWarehouseDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    List<PRO_tblWarehouseDTO> temp = new List<PRO_tblWarehouseDTO>();
                    var db = scope.Resolve<IPRO_tblWarehouseDAO>();
                    if (!GetCombobox)
                        temp = db.LoadAllData(Username, LanguageID, StoreID, ProvinceID, DistrictID);
                    else temp = db.GetDataCombobox(Username, LanguageID, StoreID);
                    if (temp != null)
                    {
                        result.WarehouseList = Mapper.Map<List<PRO_tblWarehouseDCO>>(temp);
                        result.Result = true;
                        result.Status = DCO.ResponseStatus.Success;
                        result.Message = "";
                        result.Username = Username;
                        result.TotalItemCount = temp.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                result.WarehouseList = Mapper.Map<List<PRO_tblWarehouseDCO>>(new List<PRO_tblWarehouseDTO>());
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Load warehouse list failed: " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblWarehouseDRO GetWarehouseByID(string Username, string LanguageID, string WarehouseID)
        {
            PRO_tblWarehouseDRO result = new PRO_tblWarehouseDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    var db = scope.Resolve<IPRO_tblWarehouseDAO>();
                    var temp = db.GetDataByID(Username, LanguageID, WarehouseID);
                    if (temp != null)
                    {
                        result.WarehouseItem = Mapper.Map<PRO_tblWarehouseDCO>(temp);
                        result.Result = true;
                        result.Status = DCO.ResponseStatus.Success;
                        result.Message = "";
                        result.Username = Username;
                        result.TotalItemCount = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                result.WarehouseItem = Mapper.Map<PRO_tblWarehouseDCO>(new PRO_tblWarehouseDTO());
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Load warehouse item failed: " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblWarehouseDRO InsertUpdateWarehouse(PRO_tblWarehouseDCO warehouse)
        {
            PRO_tblWarehouseDRO result = new PRO_tblWarehouseDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<IPRO_tblWarehouseDAO>();
                    var data = Mapper.Map<PRO_tblWarehouseDTO>(warehouse);
                    if (warehouse.Activity.Equals(BaseConstant.COMMAND_INSERT_EN))
                        temp = db.InsertWarehouse(data);
                    else temp = db.UpdateWarehouse(data);

                    result.Result = string.IsNullOrEmpty(temp) ? true : false;
                    result.Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure;
                    result.Message = string.IsNullOrEmpty(temp) ? string.Empty : temp;
                    result.Username = warehouse.UserID;
                    result.TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Insert new warehouse failed because " + ex.Message;
                result.Username = warehouse.UserID;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblWarehouseDRO DeleteWarehouse(string Username, string LanguageID, string WarehouseIDList)
        {
            PRO_tblWarehouseDRO result = new PRO_tblWarehouseDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<IPRO_tblWarehouseDAO>();
                    if (WarehouseIDList.Contains("$"))
                        temp = db.DeleteWarehouseList(WarehouseIDList, Username, LanguageID);
                    else temp = db.DeleteWarehouse(WarehouseIDList, Username, LanguageID);

                    result.Result = string.IsNullOrEmpty(temp) ? true : false;
                    result.Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure;
                    result.Message = string.IsNullOrEmpty(temp) ? string.Empty : temp;
                    result.Username = Username;
                    result.TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Delete warehouse failed because " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }
        #endregion

        #region [PRO_tblStall]
        public PRO_tblStallDRO GetAllStalls(string Username, string LanguageID, string StoreID, string WarehouseID, bool GetCombobox)
        {
            PRO_tblStallDRO result = new PRO_tblStallDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    List<PRO_tblStallDTO> temp = new List<PRO_tblStallDTO>();
                    var db = scope.Resolve<IPRO_tblStallDAO>();
                    if (!GetCombobox)
                        temp = db.LoadAllData(Username, LanguageID, StoreID, WarehouseID);
                    else temp = db.GetDataCombobox(Username, LanguageID, WarehouseID);
                    if (temp != null)
                    {
                        result.StallList = Mapper.Map<List<PRO_tblStallDCO>>(temp);
                        result.Result = true;
                        result.Status = DCO.ResponseStatus.Success;
                        result.Message = "";
                        result.Username = Username;
                        result.TotalItemCount = temp.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                result.StallList = Mapper.Map<List<PRO_tblStallDCO>>(new List<PRO_tblStallDTO>());
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Load stall list failed: " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblStallDRO GetStallByID(string Username, string LanguageID, string StallID)
        {
            PRO_tblStallDRO result = new PRO_tblStallDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    var db = scope.Resolve<IPRO_tblStallDAO>();
                    var temp = db.GetDataByID(Username, LanguageID, StallID);
                    if (temp != null)
                    {
                        result.StallItem = Mapper.Map<PRO_tblStallDCO>(temp);
                        result.Result = true;
                        result.Status = DCO.ResponseStatus.Success;
                        result.Message = "";
                        result.Username = Username;
                        result.TotalItemCount = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                result.StallItem = Mapper.Map<PRO_tblStallDCO>(new PRO_tblStallDTO());
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Load stall item failed: " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblStallDRO InsertUpdateStall(PRO_tblStallDCO stall)
        {
            PRO_tblStallDRO result = new PRO_tblStallDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<IPRO_tblStallDAO>();
                    var data = Mapper.Map<PRO_tblStallDTO>(stall);
                    if (stall.Activity.Equals(BaseConstant.COMMAND_INSERT_EN))
                        temp = db.InsertStall(data);
                    else temp = db.UpdateStall(data);

                    result.Result = string.IsNullOrEmpty(temp) ? true : false;
                    result.Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure;
                    result.Message = string.IsNullOrEmpty(temp) ? string.Empty : temp;
                    result.Username = stall.UserID;
                    result.TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Insert new stall failed because " + ex.Message;
                result.Username = stall.UserID;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblStallDRO DeleteStall(string Username, string LanguageID, string StallIDList)
        {
            PRO_tblStallDRO result = new PRO_tblStallDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<IPRO_tblStallDAO>();
                    if (StallIDList.Contains("$"))
                        temp = db.DeleteStallList(StallIDList, Username, LanguageID);
                    else temp = db.DeleteStall(StallIDList, Username, LanguageID);

                    result.Result = string.IsNullOrEmpty(temp) ? true : false;
                    result.Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure;
                    result.Message = string.IsNullOrEmpty(temp) ? string.Empty : temp;
                    result.Username = Username;
                    result.TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Delete stall failed because " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }
        #endregion

        #region [Tools]
        public OBJ_TableColumnDRO GetTableColumnList(string Username, string ObjectName)
        {
            OBJ_TableColumnDRO result = new OBJ_TableColumnDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    List<OBJ_TableColumnDTO> temp = new List<OBJ_TableColumnDTO>();
                    var db = scope.Resolve<IOBJ_TableColumnDAO>();
                    temp = db.GetTableColumnList(ObjectName);
                    if (temp != null)
                    {
                        result.TableColumnObjectList = Mapper.Map<List<OBJ_TableColumnDCO>>(temp);
                        result.Result = true;
                        result.Status = DCO.ResponseStatus.Success;
                        result.Message = "";
                        result.Username = Username;
                        result.TotalItemCount = temp.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                result.TableColumnObjectList = Mapper.Map<List<OBJ_TableColumnDCO>>(new List<OBJ_TableColumnDTO>());
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Load data failed: " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public iPOS.DCO.BaseDRO FileUpload(OBJ_ImageDCO bitmap)
        {
            iPOS.DCO.BaseDRO result=new DCO.BaseDRO();
            var m = new System.IO.MemoryStream(Convert.FromBase64String(bitmap.Image));
            System.Drawing.Bitmap _bitmap = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromStream(m);

            //if (System.IO.Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\Data\Images"))
            //{
            //    using (System.IO.FileStream file = new System.IO.FileStream(AppDomain.CurrentDomain.BaseDirectory + @"\Data\Images\abc.png", System.IO.FileMode.Create, System.IO.FileAccess.Write))
            //    {
            //        m.WriteTo(file);
            //    }
            //}
            //else
            //{

            //}

            //using (var scope = Container.BeginLifetimeScope())
            //{
            //    var db = scope.Resolve<IPRO_tblStoreDAO>();
            //    string tmp = db.UpdateStore(new PRO_tblStoreDTO
            //    {
            //        StoreID = 7,
            //        StoreCode = "delete3",
            //        ShortCode = "007",
            //        Photo = _bitmap
            //    });
            //}
            result.Result = true;
            result.Status = DCO.ResponseStatus.Success;
            result.Message = "";
            result.Username = "";
            result.TotalItemCount = 1;

            return result;
        }
        #endregion
    }
}
