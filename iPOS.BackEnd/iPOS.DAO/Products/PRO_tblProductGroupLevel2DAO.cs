using iPOS.Core.Helper;
using iPOS.DTO.Products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPOS.DAO.Products
{
    public interface IPRO_tblProductGroupLevel2DAO
    {
        List<PRO_tblProductGroupLevel2DTO> LoadAllData(string username, string language_id, string level1_id);

        List<PRO_tblProductGroupLevel2DTO> GetDataCombobox(string username, string language_id, string level1_id);

        PRO_tblProductGroupLevel2DTO GetDataByID(string username, string language_id, string level2_id);

        string InsertLevel2(PRO_tblProductGroupLevel2DTO item);

        string UpdateLevel2(PRO_tblProductGroupLevel2DTO item);

        string DeleteLevel2(string username, string language_id, string level2_id);

        string DeleteLevel2List(string username, string language_id, string level2_id_list);
    }

    public class PRO_tblProductGroupLevel2DAO : BaseDAO, IPRO_tblProductGroupLevel2DAO
    {
        public List<PRO_tblProductGroupLevel2DTO> LoadAllData(string username, string language_id, string level1_id)
        {
            List<PRO_tblProductGroupLevel2DTO> result = new List<PRO_tblProductGroupLevel2DTO>();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmProductGroupLevel2", new string[] { "Activity", "Username", "LanguageID", "Level1ID" }, new object[] { BaseConstant.COMMAND_LOAD_ALL_DATA_EN, username, language_id, level1_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblProductGroupLevel2DTO>(data);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public List<PRO_tblProductGroupLevel2DTO> GetDataCombobox(string username, string language_id, string level1_id)
        {
            List<PRO_tblProductGroupLevel2DTO> result = new List<PRO_tblProductGroupLevel2DTO>();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmProductGroupLevel2", new string[] { "Activity", "Username", "LanguageID", "Level1ID" }, new object[] { BaseConstant.COMMAND_GET_COMBO_BOX, username, language_id, level1_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblProductGroupLevel2DTO>(data);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblProductGroupLevel2DTO GetDataByID(string username, string language_id, string level2_id)
        {
            PRO_tblProductGroupLevel2DTO result = new PRO_tblProductGroupLevel2DTO();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmProductGroupLevel2", new string[] { "Activity", "Username", "LanguageID", "Level2ID" }, new object[] { BaseConstant.COMMAND_GET_DATA_BY_ID_EN, username, language_id, level2_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblProductGroupLevel2DTO>(data)[0];
                    return result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public string InsertLevel2(PRO_tblProductGroupLevel2DTO item)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmProductGroupLevel2", new string[] { "Activity", "Username", "LanguageID", "Level2Code", "Level2ShortCode", "Level1ID", "VNName", "ENName", "Rank", "Used", "Note", "Description" }, new object[] { item.Activity, item.UserID, item.LanguageID, item.Level2Code, item.Level2ShortCode, item.Level1ID, item.VNName, item.ENName, item.Rank, item.Used, item.Note, item.Description });

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

        public string UpdateLevel2(PRO_tblProductGroupLevel2DTO item)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmProductGroupLevel2", new string[] { "Activity", "Username", "LanguageID", "Level2ID", "Level2Code", "Level2ShortCode", "Level1ID", "VNName", "ENName", "Rank", "Used", "Note", "Description" }, new object[] { item.Activity, item.UserID, item.LanguageID, item.Level2ID, item.Level2Code, item.Level2ShortCode, item.Level1ID, item.VNName, item.ENName, item.Rank, item.Used, item.Note, item.Description });

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

        public string DeleteLevel2(string username, string language_id, string level2_id)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmProductGroupLevel2", new string[] { "Activity", "Username", "LanguageID", "Level2ID" }, new object[] { BaseConstant.COMMAND_DELETE_EN, username, language_id, level2_id });

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

        public string DeleteLevel2List(string username, string language_id, string level2_id_list)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmProductGroupLevel2", new string[] { "Activity", "Username", "LanguageID", "Level2IDList" }, new object[] { BaseConstant.COMMAND_DELETE_LIST_EN, username, language_id, level2_id_list });

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
