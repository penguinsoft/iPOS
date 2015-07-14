using System;
using System.Collections.Generic;
using System.Data;
using iPOS.Core.Helper;
using iPOS.DTO.Product;

namespace iPOS.DAO.Product
{
    public interface IPRO_tblProvinceDAO
    {
        List<PRO_tblProvinceDTO> LoadAllData(string username, string language_id);

        PRO_tblProvinceDTO GetDataByID(string username, string language_id, string province_id);
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

            DataTable data = db.GetDataTable("PRO_spfrmProvince", new string[] { "Activity", "Username", "LanguageID" }, new object[] { BaseConstant.COMMAND_LOAD_ALL_DATA_EN, username, language_id });
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
                        Used = Convert.ToBoolean(dr["Used"]),
                        Activity = BaseConstant.COMMAND_LOAD_ALL_DATA_EN,
                        Username = username,
                        LanguageID = language_id,
                        Visible = Convert.ToBoolean(dr["Visible"]),
                        Creater = dr["Creater"] + "",
                        CreateTime = Convert.ToDateTime(dr["CreateTime"]),
                        Editer = dr["Editer"] + "",
                        EditTime = (!string.IsNullOrEmpty(dr["EditTime"] + "")) ? Convert.ToDateTime(dr["EditTime"]) + "" : null,
                        ProvinceName = dr["ProvinceName"] + "",
                        UsedString = dr["UsedString"] + ""
                    });
                }
            }

            return result;
        }

        public PRO_tblProvinceDTO GetDataByID(string username, string language_id, string province_id)
        {
            DataRow dr = db.GetDataRow("PRO_spfrmProvince", new string[] { "Activity", "Username", "LanguageID", "ProvinceID" }, new object[] { BaseConstant.COMMAND_GET_DATA_BY_ID_EN, username, language_id, province_id });
            if (dr != null)
                return new PRO_tblProvinceDTO
                {
                    ProvinceID = dr["ProvinceID"] + "",
                    ProvinceCode = dr["ProvinceCode"] + "",
                    VNName = dr["VNName"] + "",
                    ENName = dr["ENName"] + "",
                    Note = dr["Note"] + "",
                    Rank = dr["Rank"],
                    Used = Convert.ToBoolean(dr["Used"]),
                    Activity = BaseConstant.COMMAND_GET_DATA_BY_ID_EN,
                    Username = username,
                    LanguageID = language_id,
                    Visible = Convert.ToBoolean(dr["Visible"]),
                    Creater = dr["Creater"] + "",
                    CreateTime = Convert.ToDateTime(dr["CreateTime"]),
                    Editer = dr["Editer"] + "",
                    EditTime = (!string.IsNullOrEmpty(dr["EditTime"] + "")) ? Convert.ToDateTime(dr["EditTime"]) + "" : null,
                    ProvinceName = dr["ProvinceName"] + "",
                    UsedString = dr["UsedString"] + ""
                };

            return null;
        }
    }
}
