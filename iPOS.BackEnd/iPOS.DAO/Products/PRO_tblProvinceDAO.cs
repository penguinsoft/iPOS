using System;
using System.Collections.Generic;
using System.Data;
using iPOS.Core.Helper;
using iPOS.DTO.Products;

namespace iPOS.DAO.Products
{
    public interface IPRO_tblProvinceDAO
    {
        List<PRO_tblProvinceDTO> LoadAllData(string username, string language_id);

        List<PRO_tblProvinceDTO> GetDataCombobox(string username, string language_id);

        PRO_tblProvinceDTO GetDataByID(string province_id, string username, string language_id);

        string InsertProvince(PRO_tblProvinceDTO item);

        string UpdateProvince(PRO_tblProvinceDTO item);

        string DeleteProvince(string province_id, string username, string language_id);

        string DeleteProvinceList(string province_id_list, string username, string language_id);
    }

    public class PRO_tblProvinceDAO : BaseDAO, IPRO_tblProvinceDAO
    {
        public List<PRO_tblProvinceDTO> LoadAllData(string username, string language_id)
        {
            List<PRO_tblProvinceDTO> result = new List<PRO_tblProvinceDTO>();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmProvince", new string[] { "Activity", "Username", "LanguageID" }, new object[] { BaseConstant.COMMAND_LOAD_ALL_DATA_EN, username, language_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblProvinceDTO>(data);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public List<PRO_tblProvinceDTO> GetDataCombobox(string username, string language_id)
        {
            List<PRO_tblProvinceDTO> result = new List<PRO_tblProvinceDTO>();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmProvince", new string[] { "Activity", "Username", "LanguageID" }, new object[] { BaseConstant.COMMAND_GET_COMBO_BOX, username, language_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblProvinceDTO>(data);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblProvinceDTO GetDataByID(string province_id, string username, string language_id)
        {
            PRO_tblProvinceDTO result = new PRO_tblProvinceDTO();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmProvince", new string[] { "Activity", "Username", "LanguageID", "ProvinceID" }, new object[] { BaseConstant.COMMAND_GET_DATA_BY_ID_EN, username, language_id, province_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblProvinceDTO>(data)[0];
                    return result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public string InsertProvince(PRO_tblProvinceDTO item)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmProvince", new string[] { "Activity", "Username", "LanguageID", "ProvinceID", "ProvinceCode", "VNName", "ENName", "Rank", "Used", "Note" }, new object[] { item.Activity, item.UserID, item.LanguageID, item.ProvinceID, item.ProvinceCode, item.VNName, item.ENName, item.Rank, item.Used, item.Note });
                
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

        public string UpdateProvince(PRO_tblProvinceDTO item)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmProvince", new string[] { "Activity", "Username", "LanguageID", "ProvinceID", "ProvinceCode", "VNName", "ENName", "Rank", "Used", "Note" }, new object[] { item.Activity, item.UserID, item.LanguageID, item.ProvinceID, item.ProvinceCode, item.VNName, item.ENName, item.Rank, item.Used, item.Note });

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

        public string DeleteProvince(string province_id, string username, string language_id)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmProvince", new string[] { "Activity", "Username", "LanguageID", "ProvinceID" }, new object[] { BaseConstant.COMMAND_DELETE_EN, username, language_id, province_id });

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

        public string DeleteProvinceList(string province_id_list, string username, string language_id)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmProvince", new string[] { "Activity", "Username", "LanguageID", "ProvinceIDList" }, new object[] { BaseConstant.COMMAND_DELETE_LIST_EN, username, language_id, province_id_list });

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
