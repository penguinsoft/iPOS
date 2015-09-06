using System;
using System.Collections.Generic;
using System.Data;
using iPOS.Core.Helper;
using iPOS.DTO.Products;

namespace iPOS.DAO.Products
{
    public interface IPRO_tblDistrictDAO
    {
        List<PRO_tblDistrictDTO> LoadAllData(string username, string language_id, string province_id);

        List<PRO_tblDistrictDTO> GetDataCombobox(string username, string language_id, string province_id);

        PRO_tblDistrictDTO GetDataByID(string district_id, string username, string language_id);

        string InsertDistrict(PRO_tblDistrictDTO item);

        string UpdateDistrict(PRO_tblDistrictDTO item);

        string DeleteDistrict(string district_id, string username, string language_id);

        string DeleteDistrictList(string district_id_list, string username, string language_id);
    }

    public class PRO_tblDistrictDAO : BaseDAO, IPRO_tblDistrictDAO
    {
        public List<PRO_tblDistrictDTO> LoadAllData(string username, string language_id, string province_id)
        {
            List<PRO_tblDistrictDTO> result = new List<PRO_tblDistrictDTO>();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmDistrict", new string[] { "Activity", "Username", "LanguageID", "ProvinceID" }, new object[] { BaseConstant.COMMAND_LOAD_ALL_DATA_EN, username, language_id, province_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblDistrictDTO>(data);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public List<PRO_tblDistrictDTO> GetDataCombobox(string username, string language_id, string province_id)
        {
            List<PRO_tblDistrictDTO> result = new List<PRO_tblDistrictDTO>();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmDistrict", new string[] { "Activity", "Username", "LanguageID", "ProvinceID" }, new object[] { BaseConstant.COMMAND_GET_COMBO_BOX, username, language_id, province_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblDistrictDTO>(data);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblDistrictDTO GetDataByID(string district_id, string username, string language_id)
        {
            PRO_tblDistrictDTO result = new PRO_tblDistrictDTO();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmDistrict", new string[] { "Activity", "Username", "LanguageID", "DistrictID" }, new object[] { BaseConstant.COMMAND_GET_DATA_BY_ID_EN, username, language_id, district_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblDistrictDTO>(data)[0];
                    return result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public string InsertDistrict(PRO_tblDistrictDTO item)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmDistrict", new string[] { "Activity", "Username", "LanguageID", "DistrictID", "DistrictCode", "ProvinceID", "VNName", "ENName", "Rank", "Used", "Note" }, new object[] { item.Activity, item.UserID, item.LanguageID, item.DistrictID, item.DistrictCode, item.ProvinceID, item.VNName, item.ENName, item.Rank, item.Used, item.Note });

                if (!string.IsNullOrEmpty(strError))
                    logger.Error(strError);

                return strError;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                strError = ex.Message;
            }

            return strError;
        }

        public string UpdateDistrict(PRO_tblDistrictDTO item)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmDistrict", new string[] { "Activity", "Username", "LanguageID", "DistrictID", "DistrictCode", "ProvinceID", "VNName", "ENName", "Rank", "Used", "Note" }, new object[] { item.Activity, item.UserID, item.LanguageID, item.DistrictID, item.DistrictCode, item.ProvinceID, item.VNName, item.ENName, item.Rank, item.Used, item.Note });

                if (!string.IsNullOrEmpty(strError))
                    logger.Error(strError);

                return strError;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                strError = ex.Message;
            }

            return strError;
        }

        public string DeleteDistrict(string district_id, string username, string language_id)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmDistrict", new string[] { "Activity", "Username", "LanguageID", "DistrictID" }, new object[] { BaseConstant.COMMAND_DELETE_EN, username, language_id, district_id });

                if (!string.IsNullOrEmpty(strError))
                    logger.Error(strError);

                return strError;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                strError = ex.Message;
            }

            return strError;
        }

        public string DeleteDistrictList(string district_id_list, string username, string language_id)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmDistrict", new string[] { "Activity", "Username", "LanguageID", "DistrictIDList" }, new object[] { BaseConstant.COMMAND_DELETE_LIST_EN, username, language_id, district_id_list });

                if (!string.IsNullOrEmpty(strError))
                    logger.Error(strError);

                return strError;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                strError = ex.Message;
            }

            return strError;
        }
    }
}
