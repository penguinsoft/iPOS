using System;
using System.Collections.Generic;
using System.Data;
using iPOS.DTO.Product;

namespace iPOS.DAO.Product
{
    public interface IPRO_tblProvinceDAO
    {
        List<PRO_tblProvinceDTO> LoadAllData(string username, string language_id);
    }

    public class PRO_tblProvinceDAO : BaseDAO, IPRO_tblProvinceDAO
    {
        public List<PRO_tblProvinceDTO> LoadAllData(string username, string language_id)
        {
            List<PRO_tblProvinceDTO> result = new List<PRO_tblProvinceDTO>();
            //this.InsertActionLog(new SYS_tblActionLogDTO
            //{
            //    Activity = "Insert",
            //    Username = username,
            //    LanguageID = language_id,
            //    ActionVN = "Tải Tất Cả Dữ Liệu",
            //    ActionEN = "Load All Data",
            //    FunctionID = "8",
            //    DescriptionVN = string.Format("Tài khoản '{0}' vừa tải thành công dữ liệu tỉnh thành.", username),
            //    DescriptionEN = string.Format("Account '{0}' downloaded successfully data of provinces.", username)
            //});

            DataTable data = db.GetDataTable("PRO_spfrmProvince", new string[] { "Activity", "Username", "LanguageID" }, new object[] { "LoadAllData", username, language_id });
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    result.Add(new PRO_tblProvinceDTO
                    {
                        ProvinceID = dr["ProvinceID"] + "",
                        ProvinceCode = dr["ProvinceCode"] + "",
                        VNName = dr["VNName"] + "",
                        ENName = dr["ENName"] + "",
                        Note = dr["Note"] + "",
                        Rank = dr["Rank"],
                        Used = Convert.ToBoolean(dr["Used"])
                    });
                }
            }

            return result;
        }
    }
}
