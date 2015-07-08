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
using iPOS.DCO.Product;
using iPOS.DTO.Product;

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
            Mapper.CreateMap<PRO_tblProvinceDTO, PRO_tblProvinceDCO>();
            Mapper.CreateMap<PRO_tblProvinceDCO, PRO_tblProvinceDTO>();

            Mapper.AssertConfigurationIsValid();
        }

        public static void Autofac()
        {
            var afBuilder = new ContainerBuilder();
            afBuilder.RegisterType<PRO_tblProvinceDAO>().As<IPRO_tblProvinceDAO>();

            Container = afBuilder.Build();
        }

        public PRO_tblProvinceDRO GetAllProvinces()
        {
            PRO_tblProvinceDRO result = new PRO_tblProvinceDRO();
            try
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    List<PRO_tblProvinceDTO> temp = new List<PRO_tblProvinceDTO>();
                    var db = scope.Resolve<IPRO_tblProvinceDAO>();
                    temp = db.LoadAllData("admin", "VN");
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

            return result;
        }
    }
}
