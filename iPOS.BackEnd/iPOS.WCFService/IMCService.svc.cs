﻿using System;
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
            Mapper.CreateMap<SYS_tblUserLevelDTO, SYS_tblUserLevelDCO>();
            Mapper.CreateMap<SYS_tblUserLevelDCO, SYS_tblUserLevelDTO>();

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
            Mapper.CreateMap<PRO_tblProductGroupLevel1DTO, PRO_tblProductGroupLevel1DCO>();
            Mapper.CreateMap<PRO_tblProductGroupLevel1DCO, PRO_tblProductGroupLevel1DTO>();
            Mapper.CreateMap<PRO_tblProductGroupLevel2DTO, PRO_tblProductGroupLevel2DCO>();
            Mapper.CreateMap<PRO_tblProductGroupLevel2DCO, PRO_tblProductGroupLevel2DTO>();
            Mapper.CreateMap<PRO_tblProductGroupLevel3DTO, PRO_tblProductGroupLevel3DCO>();
            Mapper.CreateMap<PRO_tblProductGroupLevel3DCO, PRO_tblProductGroupLevel3DTO>();

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
            afBuilder.RegisterType<SYS_tblUserLevelDAO>().As<ISYS_tblUserLevelDAO>();

            afBuilder.RegisterType<PRO_tblProvinceDAO>().As<IPRO_tblProvinceDAO>();
            afBuilder.RegisterType<PRO_tblDistrictDAO>().As<IPRO_tblDistrictDAO>();
            afBuilder.RegisterType<PRO_tblStoreDAO>().As<IPRO_tblStoreDAO>();
            afBuilder.RegisterType<PRO_tblWarehouseDAO>().As<IPRO_tblWarehouseDAO>();
            afBuilder.RegisterType<PRO_tblStallDAO>().As<IPRO_tblStallDAO>();
            afBuilder.RegisterType<PRO_tblProductGroupLevel1DAO>().As<IPRO_tblProductGroupLevel1DAO>();
            afBuilder.RegisterType<PRO_tblProductGroupLevel2DAO>().As<IPRO_tblProductGroupLevel2DAO>();
            afBuilder.RegisterType<PRO_tblProductGroupLevel3DAO>().As<IPRO_tblProductGroupLevel3DAO>();

            afBuilder.RegisterType<OBJ_TableColumnDAO>().As<IOBJ_TableColumnDAO>();

            Container = afBuilder.Build();
        }

        #region [SYS_tblActionLog]
        public SYS_tblActionLogDRO InsertUpdateLog(SYS_tblActionLogDCO actionLog)
        {
            SYS_tblActionLogDRO result = new SYS_tblActionLogDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<ISYS_tblActionLogDAO>();
                    var data = Mapper.Map<SYS_tblActionLogDTO>(actionLog);
                    temp = db.InsertUpdateLog(data);

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = !string.IsNullOrEmpty(temp) ? false : true,
                        Message = !string.IsNullOrEmpty(temp) ? temp : "",
                        RequestUser = actionLog.UserID,
                        TotalItemCount = !string.IsNullOrEmpty(temp) ? 0 : 1
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Message = ex.Message,
                    RequestUser = actionLog.UserID,
                    TotalItemCount = 0
                };
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
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = temp.Count
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.GroupUserList = Mapper.Map<List<SYS_tblGroupUserDCO>>(new List<SYS_tblGroupUserDTO>());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load group user list failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = 1
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.GroupUserItem = Mapper.Map<SYS_tblGroupUserDCO>(new SYS_tblGroupUserDTO());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Get data failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
                logger.Error(ex);
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

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = groupUser.UserID,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Insert new group user failed because " + ex.Message,
                    RequestUser = groupUser.UserID,
                    TotalItemCount = 0
                };
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

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = Username,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Delete group user failed because " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = temp.Username,
                            RequestUser = Username,
                            TotalItemCount = 1
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.UserItem = Mapper.Map<SYS_tblUserDCO>(new SYS_tblUserDTO());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Check login failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = temp.Count
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.UserList = Mapper.Map<List<SYS_tblUserDCO>>(new List<SYS_tblUserDTO>());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load user list failed: " + ex.Message,
                    TotalItemCount = 0
                };
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
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = 1
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.UserItem = Mapper.Map<SYS_tblUserDCO>(new SYS_tblUserDTO());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Get data failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
                logger.Error(ex);
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

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = temp,
                        RequestUser = user.UserID,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Insert new user failed because: " + ex.Message,
                    RequestUser = user.UserID,
                    TotalItemCount = 0
                };
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

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = Username,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Delete user failed because: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = Username,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Change user password failed because: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = temp.Count
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.ReportCaptionList = Mapper.Map<List<SYS_tblReportCaptionDCO>>(new List<SYS_tblReportCaptionDTO>());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load data failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = temp.Count
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.ComboDynamicList = Mapper.Map<List<ComboDynamicItemDCO>>(new List<ComboDynamicItemDTO>());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load data failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = 1
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.ImportFileConfigItem = Mapper.Map<SYS_tblImportFileConfigDCO>(new SYS_tblImportFileConfigDTO());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Get data failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
                logger.Error(ex);
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

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = Username,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Import data failed because: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
                logger.Error(ex);
            }

            return result;
        }
        #endregion

        #region [SYS_tblPermission]
        public SYS_tblPermissionDRO GetPermissionList(string Username, string LanguageID, string ID, bool IsUser)
        {
            SYS_tblPermissionDRO result = new SYS_tblPermissionDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    List<SYS_tblPermissionDTO> temp = new List<SYS_tblPermissionDTO>();
                    var db = scope.Resolve<ISYS_tblPermissionDAO>();
                    temp = db.GetAllPermisionList(Username, LanguageID, ID, IsUser);
                    if (temp != null)
                    {
                        result.PermissionList = Mapper.Map<List<SYS_tblPermissionDCO>>(temp);
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = temp.Count
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.PermissionList = Mapper.Map<List<SYS_tblPermissionDCO>>(new List<SYS_tblPermissionDTO>());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load permission failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
                logger.Error(ex);
            }

            return result;
        }

        public SYS_tblPermissionDRO GetPermissionItem(string Username, string LanguageID, string FunctionID)
        {
            SYS_tblPermissionDRO result = new SYS_tblPermissionDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    SYS_tblPermissionDTO temp = new SYS_tblPermissionDTO();
                    var db = scope.Resolve<ISYS_tblPermissionDAO>();
                    temp = db.GetPermissionItem(Username, LanguageID, FunctionID);
                    if (temp != null)
                    {
                        result.PermissionItem = Mapper.Map<SYS_tblPermissionDCO>(temp);
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = 1
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.PermissionItem = Mapper.Map<SYS_tblPermissionDCO>(new SYS_tblPermissionDTO());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load permission failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = Username,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Update permission failed because: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = temp.Count
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.ProvinceList = Mapper.Map<List<PRO_tblProvinceDCO>>(new List<PRO_tblProvinceDTO>());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load province list failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = 1
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.ProvinceItem = Mapper.Map<PRO_tblProvinceDCO>(new PRO_tblProvinceDTO());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load province item failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = province.UserID,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Insert new province failed because: " + ex.Message,
                    RequestUser = province.UserID,
                    TotalItemCount = 0
                };
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

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = Username,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Delete province failed because: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = temp.Count
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.DistrictList = Mapper.Map<List<PRO_tblDistrictDCO>>(new List<PRO_tblDistrictDTO>());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load district list failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = 1
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.DistrictItem = Mapper.Map<PRO_tblDistrictDCO>(new PRO_tblDistrictDTO());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load district item failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = district.UserID,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Insert new district failed because: " + ex.Message,
                    RequestUser = district.UserID,
                    TotalItemCount = 0
                };
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

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = Username,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Delete district failed because: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = temp.Count
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.StoreList = Mapper.Map<List<PRO_tblStoreDCO>>(new List<PRO_tblStoreDTO>());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load store list failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = 1
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.StoreItem = Mapper.Map<PRO_tblStoreDCO>(new PRO_tblStoreDTO());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load store item failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = store.UserID,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Insert new store failed because: " + ex.Message,
                    RequestUser = store.UserID,
                    TotalItemCount = 0
                };
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
                        temp = db.DeleteStoreList(Username, LanguageID, StoreIDList);
                    else temp = db.DeleteStore(Username, LanguageID, StoreIDList);

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = Username,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Delete store failed because: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = temp.Count
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.WarehouseList = Mapper.Map<List<PRO_tblWarehouseDCO>>(new List<PRO_tblWarehouseDTO>());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load warehouse list failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = 1
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.WarehouseItem = Mapper.Map<PRO_tblWarehouseDCO>(new PRO_tblWarehouseDTO());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load warehouse item failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = warehouse.UserID,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Insert new warehouse failed because: " + ex.Message,
                    RequestUser = warehouse.UserID,
                    TotalItemCount = 0
                };
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

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = Username,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Delete warehouse failed because: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = temp.Count
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.StallList = Mapper.Map<List<PRO_tblStallDCO>>(new List<PRO_tblStallDTO>());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load stall list failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = 1
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.StallItem = Mapper.Map<PRO_tblStallDCO>(new PRO_tblStallDTO());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load stall item failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = stall.UserID,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Insert new stall failed because: " + ex.Message,
                    RequestUser = stall.UserID,
                    TotalItemCount = 0
                };
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

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = Username,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Delete stall failed because: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
                logger.Error(ex);
            }

            return result;
        }
        #endregion

        #region [PRO_tblProductGroupLevel1]
        public PRO_tblProductGroupLevel1DRO GetAllLevel1(string Username, string LanguageID, bool GetCombobox)
        {
            PRO_tblProductGroupLevel1DRO result = new PRO_tblProductGroupLevel1DRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    List<PRO_tblProductGroupLevel1DTO> temp = new List<PRO_tblProductGroupLevel1DTO>();
                    var db = scope.Resolve<IPRO_tblProductGroupLevel1DAO>();
                    if (!GetCombobox)
                        temp = db.LoadAllData(Username, LanguageID);
                    else temp = db.GetDataCombobox(Username, LanguageID);
                    if (temp != null)
                    {
                        result.Level1List = Mapper.Map<List<PRO_tblProductGroupLevel1DCO>>(temp);
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = temp.Count
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.Level1List = Mapper.Map<List<PRO_tblProductGroupLevel1DCO>>(new List<PRO_tblProductGroupLevel1DTO>());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load level1 list failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblProductGroupLevel1DRO GetLevel1ByID(string Username, string LanguageID, string Level1ID)
        {
            PRO_tblProductGroupLevel1DRO result = new PRO_tblProductGroupLevel1DRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    var db = scope.Resolve<IPRO_tblProductGroupLevel1DAO>();
                    var temp = db.GetDataByID(Username, LanguageID, Level1ID);
                    if (temp != null)
                    {
                        result.Level1Item = Mapper.Map<PRO_tblProductGroupLevel1DCO>(temp);
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = 1
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.Level1Item = Mapper.Map<PRO_tblProductGroupLevel1DCO>(new PRO_tblProductGroupLevel1DTO());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load level1 item failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblProductGroupLevel1DRO InsertUpdateLevel1(PRO_tblProductGroupLevel1DCO level1)
        {
            PRO_tblProductGroupLevel1DRO result = new PRO_tblProductGroupLevel1DRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<IPRO_tblProductGroupLevel1DAO>();
                    var data = Mapper.Map<PRO_tblProductGroupLevel1DTO>(level1);
                    if (level1.Activity.Equals(BaseConstant.COMMAND_INSERT_EN))
                        temp = db.InsertLevel1(data);
                    else temp = db.UpdateLevel1(data);

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = level1.UserID,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Insert new level1 failed because: " + ex.Message,
                    RequestUser = level1.UserID,
                    TotalItemCount = 0
                };
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblProductGroupLevel1DRO DeleteLevel1(string Username, string LanguageID, string Level1IDList)
        {
            PRO_tblProductGroupLevel1DRO result = new PRO_tblProductGroupLevel1DRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<IPRO_tblProductGroupLevel1DAO>();
                    if (Level1IDList.Contains("$"))
                        temp = db.DeleteLevel1List(Username, LanguageID, Level1IDList);
                    else temp = db.DeleteLevel1(Username, LanguageID, Level1IDList);

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = Username,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Delete level1 failed because: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
                logger.Error(ex);
            }

            return result;
        }
        #endregion

        #region [PRO_tblProductGroupLevel2]
        public PRO_tblProductGroupLevel2DRO GetAllLevel2(string Username, string LanguageID, string Level1ID, bool GetCombobox)
        {
            PRO_tblProductGroupLevel2DRO result = new PRO_tblProductGroupLevel2DRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    List<PRO_tblProductGroupLevel2DTO> temp = new List<PRO_tblProductGroupLevel2DTO>();
                    var db = scope.Resolve<IPRO_tblProductGroupLevel2DAO>();
                    if (!GetCombobox)
                        temp = db.LoadAllData(Username, LanguageID, Level1ID);
                    else temp = db.GetDataCombobox(Username, LanguageID, Level1ID);
                    if (temp != null)
                    {
                        result.Level2List = Mapper.Map<List<PRO_tblProductGroupLevel2DCO>>(temp);
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = temp.Count
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.Level2List = Mapper.Map<List<PRO_tblProductGroupLevel2DCO>>(new List<PRO_tblProductGroupLevel2DTO>());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load level2 list failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblProductGroupLevel2DRO GetLevel2ByID(string Username, string LanguageID, string Level2ID)
        {
            PRO_tblProductGroupLevel2DRO result = new PRO_tblProductGroupLevel2DRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    var db = scope.Resolve<IPRO_tblProductGroupLevel2DAO>();
                    var temp = db.GetDataByID(Username, LanguageID, Level2ID);
                    if (temp != null)
                    {
                        result.Level2Item = Mapper.Map<PRO_tblProductGroupLevel2DCO>(temp);
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = 1
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.Level2Item = Mapper.Map<PRO_tblProductGroupLevel2DCO>(new PRO_tblProductGroupLevel2DTO());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load level2 item failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblProductGroupLevel2DRO InsertUpdateLevel2(PRO_tblProductGroupLevel2DCO level2)
        {
            PRO_tblProductGroupLevel2DRO result = new PRO_tblProductGroupLevel2DRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<IPRO_tblProductGroupLevel2DAO>();
                    var data = Mapper.Map<PRO_tblProductGroupLevel2DTO>(level2);
                    if (level2.Activity.Equals(BaseConstant.COMMAND_INSERT_EN))
                        temp = db.InsertLevel2(data);
                    else temp = db.UpdateLevel2(data);

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = level2.UserID,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Insert new level2 failed because: " + ex.Message,
                    RequestUser = level2.UserID,
                    TotalItemCount = 0
                };
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblProductGroupLevel2DRO DeleteLevel2(string Username, string LanguageID, string Level2IDList)
        {
            PRO_tblProductGroupLevel2DRO result = new PRO_tblProductGroupLevel2DRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<IPRO_tblProductGroupLevel2DAO>();
                    if (Level2IDList.Contains("$"))
                        temp = db.DeleteLevel2List(Username, LanguageID, Level2IDList);
                    else temp = db.DeleteLevel2(Username, LanguageID, Level2IDList);

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = Username,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Delete level2 failed because: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
                logger.Error(ex);
            }

            return result;
        }
        #endregion

        #region [PRO_tblProductGroupLevel3]
        public PRO_tblProductGroupLevel3DRO GetAllLevel3(string Username, string LanguageID, string Level1ID, string Level2ID, bool GetCombobox)
        {
            PRO_tblProductGroupLevel3DRO result = new PRO_tblProductGroupLevel3DRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    List<PRO_tblProductGroupLevel3DTO> temp = new List<PRO_tblProductGroupLevel3DTO>();
                    var db = scope.Resolve<IPRO_tblProductGroupLevel3DAO>();
                    if (!GetCombobox)
                        temp = db.LoadAllData(Username, LanguageID, Level1ID, Level2ID);
                    else temp = db.GetDataCombobox(Username, LanguageID, Level1ID, Level2ID);
                    if (temp != null)
                    {
                        result.Level3List = Mapper.Map<List<PRO_tblProductGroupLevel3DCO>>(temp);
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = temp.Count
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.Level3List = Mapper.Map<List<PRO_tblProductGroupLevel3DCO>>(new List<PRO_tblProductGroupLevel3DTO>());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load level3 list failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblProductGroupLevel3DRO GetLevel3ByID(string Username, string LanguageID, string Level3ID)
        {
            PRO_tblProductGroupLevel3DRO result = new PRO_tblProductGroupLevel3DRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    var db = scope.Resolve<IPRO_tblProductGroupLevel3DAO>();
                    var temp = db.GetDataByID(Username, LanguageID, Level3ID);
                    if (temp != null)
                    {
                        result.Level3Item = Mapper.Map<PRO_tblProductGroupLevel3DCO>(temp);
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = 1
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.Level3Item = Mapper.Map<PRO_tblProductGroupLevel3DCO>(new PRO_tblProductGroupLevel3DTO());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load level3 item failed: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblProductGroupLevel3DRO InsertUpdateLevel3(PRO_tblProductGroupLevel3DCO level3)
        {
            PRO_tblProductGroupLevel3DRO result = new PRO_tblProductGroupLevel3DRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<IPRO_tblProductGroupLevel3DAO>();
                    var data = Mapper.Map<PRO_tblProductGroupLevel3DTO>(level3);
                    if (level3.Activity.Equals(BaseConstant.COMMAND_INSERT_EN))
                        temp = db.InsertLevel3(data);
                    else temp = db.UpdateLevel3(data);

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = level3.UserID,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Insert new level3 failed because: " + ex.Message,
                    RequestUser = level3.UserID,
                    TotalItemCount = 0
                };
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblProductGroupLevel3DRO DeleteLevel3(string Username, string LanguageID, string Level3IDList)
        {
            PRO_tblProductGroupLevel3DRO result = new PRO_tblProductGroupLevel3DRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<IPRO_tblProductGroupLevel3DAO>();
                    if (Level3IDList.Contains("$"))
                        temp = db.DeleteLevel3List(Username, LanguageID, Level3IDList);
                    else temp = db.DeleteLevel3(Username, LanguageID, Level3IDList);

                    result.ResponseItem = new DCO.ResponseItem
                    {
                        Result = string.IsNullOrEmpty(temp) ? true : false,
                        Status = string.IsNullOrEmpty(temp) ? DCO.ResponseStatus.Success : DCO.ResponseStatus.Failure,
                        Message = string.IsNullOrEmpty(temp) ? string.Empty : temp,
                        RequestUser = Username,
                        TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0
                    };
                }
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Delete level3 failed because: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
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
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = temp.Count
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.TableColumnObjectList = Mapper.Map<List<OBJ_TableColumnDCO>>(new List<OBJ_TableColumnDTO>());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load column list failed because: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
                logger.Error(ex);
            }

            return result;
        }

        public SYS_tblUserLevelDRO GetUserLevelList(string Username, string LanguageID)
        {
            SYS_tblUserLevelDRO result = new SYS_tblUserLevelDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    List<SYS_tblUserLevelDTO> temp = new List<SYS_tblUserLevelDTO>();
                    var db = scope.Resolve<ISYS_tblUserLevelDAO>();
                    temp = db.LoadAllData(Username, LanguageID);
                    if (temp != null)
                    {
                        result.UserLevelList = Mapper.Map<List<SYS_tblUserLevelDCO>>(temp);
                        result.ResponseItem = new DCO.ResponseItem
                        {
                            Result = true,
                            Status = DCO.ResponseStatus.Success,
                            Message = "",
                            RequestUser = Username,
                            TotalItemCount = temp.Count
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.UserLevelList = Mapper.Map<List<SYS_tblUserLevelDCO>>(new List<SYS_tblUserLevelDTO>());
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Load user level list failed because: " + ex.Message,
                    RequestUser = Username,
                    TotalItemCount = 0
                };
                logger.Error(ex);
            }

            return result;
        }

        public iPOS.DCO.BaseDRO FileUpload(OBJ_FileDCO file)
        {
            iPOS.DCO.BaseDRO result = new DCO.BaseDRO();
            try
            {
                string tmp = FileEngine.CreateFile(file.Data, file.Type, file.Owner);
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = true,
                    Status = DCO.ResponseStatus.Success,
                    Message = "Filename:" + tmp,
                    RequestUser = "",
                    TotalItemCount = 1
                };
            }
            catch (Exception ex)
            {
                result.ResponseItem = new DCO.ResponseItem
                {
                    Result = false,
                    Status = DCO.ResponseStatus.Exception,
                    Message = "Upload failed: " + ex.Message,
                    RequestUser = "",
                    TotalItemCount = 0
                };
                logger.Error(ex);
            }

            return result;
        }
        #endregion
    }
}
