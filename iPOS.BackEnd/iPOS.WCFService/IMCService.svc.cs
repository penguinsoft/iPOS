using System;
using System.Collections.Generic;
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
using iPOS.DAO.Product;
using iPOS.DAO.Systems;
using iPOS.DCO.Product;
using iPOS.DCO.Systems;
using iPOS.DTO.Product;
using iPOS.DTO.Systems;

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

            Mapper.CreateMap<PRO_tblProvinceDTO, PRO_tblProvinceDCO>();
            Mapper.CreateMap<PRO_tblProvinceDCO, PRO_tblProvinceDTO>();

            Mapper.AssertConfigurationIsValid();
        }

        public static void Autofac()
        {
            var afBuilder = new ContainerBuilder();
            afBuilder.RegisterType<LogEngine>().As<ILogEngine>();

            afBuilder.RegisterType<SYS_tblActionLogDAO>().As<ISYS_tblActionLogDAO>();
            afBuilder.RegisterType<SYS_tblGroupUserDAO>().As<ISYS_tblGroupUserDAO>();
            afBuilder.RegisterType<SYS_tblUserDAO>().As<ISYS_tblUserDAO>();
            afBuilder.RegisterType<PRO_tblProvinceDAO>().As<IPRO_tblProvinceDAO>();

            Container = afBuilder.Build();
        }

        #region [SYS_tblActionLog]
        public SYS_tblActionLogDRO ManageActionLog(SYS_tblActionLogDCO actionLog)
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
                    temp = db.ManageActionLog(data);

                    result.Result = !string.IsNullOrEmpty(temp) ? false : true;
                    result.Message = !string.IsNullOrEmpty(temp) ? temp : "";
                    result.Username = actionLog.Username;
                    result.TotalItemCount = !string.IsNullOrEmpty(temp) ? 0 : 1;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
                result.Username = actionLog.Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }
        #endregion

        #region [SYS_tblGroupUser]
        public SYS_tblGroupUserDRO GetAllGroupUsers(string Username, string LanguageID)
        {
            SYS_tblGroupUserDRO result = new SYS_tblGroupUserDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    List<SYS_tblGroupUserDTO> temp = new List<SYS_tblGroupUserDTO>();
                    var db = scope.Resolve<ISYS_tblGroupUserDAO>();
                    temp = db.LoadAllData(Username, LanguageID);
                    if (temp != null)
                    {
                        result.GroupUserList = Mapper.Map<List<SYS_tblGroupUserDCO>>(temp);
                        result.Result = true;
                        result.Status = DCO.ResponseStatus.Success;
                        result.Message = "Load data success!";
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
                result.Message = "Load data failed: " + ex.Message;
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
                        result.Message = "Get data success!";
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
                    result.Username = groupUser.Username;
                    result.TotalItemCount = string.IsNullOrEmpty(temp) ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Status = DCO.ResponseStatus.Exception;
                result.Message = "Insert new group user failed because " + ex.Message;
                result.Username = groupUser.Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }

        public SYS_tblGroupUserDRO DeleteGroupUser(string Username, string LanguageID, string GroupUserIDList, string GroupUserCodeList)
        {
            SYS_tblGroupUserDRO result = new SYS_tblGroupUserDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    string temp = "";
                    var db = scope.Resolve<ISYS_tblGroupUserDAO>();
                    if (GroupUserIDList.Contains("$"))
                        temp = db.DeleteGroupUserList(GroupUserIDList, GroupUserCodeList, Username, LanguageID);
                    else temp = db.DeleteGroupUser(GroupUserIDList, GroupUserCodeList, Username, LanguageID);

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
                        result.Message = temp.Username.Substring(temp.Username.IndexOf("$") + 1);
                        result.Username = Username;
                        result.TotalItemCount = 1;
                    }
                }
            }
            catch
            {
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
                        result.Message = "Load data success!";
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
                result.Message = "Load data failed: " + ex.Message;
                result.Username = Username;
                result.TotalItemCount = 0;
                logger.Error(ex);
            }

            return result;
        }
        #endregion

        #region [PRO_tblProvince]
        public PRO_tblProvinceDRO GetAllProvinces(string Username, string LanguageID)
        {
            PRO_tblProvinceDRO result = new PRO_tblProvinceDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    List<PRO_tblProvinceDTO> temp = new List<PRO_tblProvinceDTO>();
                    var db = scope.Resolve<IPRO_tblProvinceDAO>();
                    temp = db.LoadAllData(Username, LanguageID);
                    if (temp != null)
                    {
                        result.ProvinceList = Mapper.Map<List<PRO_tblProvinceDCO>>(temp);
                        result.Result = true;
                        result.Message = "Done!";
                        result.Username = "admin";
                        result.TotalItemCount = temp.Count;
                    }
                }
            }
            catch
            {
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
                    PRO_tblProvinceDTO temp = new PRO_tblProvinceDTO();
                    var db = scope.Resolve<IPRO_tblProvinceDAO>();
                    temp = db.GetDataByID(Username, LanguageID, ProvinceID);
                    if (temp != null)
                    {
                        result.ProvinceItem = Mapper.Map<PRO_tblProvinceDCO>(temp);
                        result.Result = true;
                        result.Message = "Done!";
                        result.Username = Username;
                        result.TotalItemCount = 1;
                    }
                }
            }
            catch
            {
            }

            return result;
        }
        #endregion
    }
}
