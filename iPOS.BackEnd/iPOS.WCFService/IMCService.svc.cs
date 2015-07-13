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
using iPOS.DAO.Product;
using iPOS.DAO.System;
using iPOS.DCO.Product;
using iPOS.DCO.System;
using iPOS.DTO.Product;
using iPOS.DTO.System;

namespace iPOS.WCFService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
        InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class IMCService : IIMCService
    {
        private static IContainer Container { get; set; }

        public IMCService()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
            }
        }

        public static void AutoMapper()
        {
            Mapper.CreateMap<SYS_tblUserDTO, SYS_tblUserDCO>();
            Mapper.CreateMap<SYS_tblUserDCO, SYS_tblUserDTO>();

            Mapper.CreateMap<PRO_tblProvinceDTO, PRO_tblProvinceDCO>();
            Mapper.CreateMap<PRO_tblProvinceDCO, PRO_tblProvinceDTO>();

            Mapper.AssertConfigurationIsValid();
        }

        public static void Autofac()
        {
            var afBuilder = new ContainerBuilder();
            afBuilder.RegisterType<SYS_tblUserDAO>().As<ISYS_tblUserDAO>();
            afBuilder.RegisterType<PRO_tblProvinceDAO>().As<IPRO_tblProvinceDAO>();

            Container = afBuilder.Build();
        }

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
                        result.Message = "Login success!";
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
