using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iPOS.DTO.Products;
using System.Data;
using iPOS.Core.Helper;

namespace iPOS.DAO.Products
{
    public interface IPRO_tblProductGroupLevel1DAO
    {
        List<PRO_tblProductGroupLevel1DTO> LoadAllData(string username, string language_id);

        List<PRO_tblProductGroupLevel1DTO> GetDataCombobox(string username, string language_id);

        PRO_tblProductGroupLevel1DTO GetDataByID(string username, string language_id, string level1_id);

        string InsertLevel1(PRO_tblProductGroupLevel1DTO item);

        string UpdateLevel1(PRO_tblProductGroupLevel1DTO item);

        string DeleteLevel1(string username, string language_id, string level1_id);

        string DeleteLevel1List(string username, string language_id, string level1_id_list);
    }

    public class PRO_tblProductGroupLevel1DAO : BaseDAO, IPRO_tblProductGroupLevel1DAO
    {
        public List<PRO_tblProductGroupLevel1DTO> LoadAllData(string username, string language_id)
        {
            List<PRO_tblProductGroupLevel1DTO> result = new List<PRO_tblProductGroupLevel1DTO>();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmProductGroupLevel1", new string[] { "Activity", "Username", "LanguageID" }, new object[] { BaseConstant.COMMAND_LOAD_ALL_DATA_EN, username, language_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblProductGroupLevel1DTO>(data);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public List<PRO_tblProductGroupLevel1DTO> GetDataCombobox(string username, string language_id)
        {
            List<PRO_tblProductGroupLevel1DTO> result = new List<PRO_tblProductGroupLevel1DTO>();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmProductGroupLevel1", new string[] { "Activity", "Username", "LanguageID" }, new object[] { BaseConstant.COMMAND_GET_COMBO_BOX, username, language_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblProductGroupLevel1DTO>(data);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblProductGroupLevel1DTO GetDataByID(string username, string language_id, string level1_id)
        {
            PRO_tblProductGroupLevel1DTO result = new PRO_tblProductGroupLevel1DTO();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmProductGroupLevel1", new string[] { "Activity", "Username", "LanguageID", "Level1ID" }, new object[] { BaseConstant.COMMAND_GET_DATA_BY_ID_EN, username, language_id, level1_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblProductGroupLevel1DTO>(data)[0];
                    return result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public string InsertLevel1(PRO_tblProductGroupLevel1DTO item)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmProductGroupLevel1", new string[] { "Activity", "Username", "LanguageID", "Level1Code", "Level1ShortCode", "VNName", "ENName", "Rank", "Used", "Note", "Description" }, new object[] { item.Activity, item.UserID, item.LanguageID, item.Level1Code, item.Level1ShortCode, item.VNName, item.ENName, item.Rank, item.Used, item.Note, item.Description });

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

        public string UpdateLevel1(PRO_tblProductGroupLevel1DTO item)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmProductGroupLevel1", new string[] { "Activity", "Username", "LanguageID", "Level1ID", "Level1Code", "Level1ShortCode", "VNName", "ENName", "Rank", "Used", "Note", "Description" }, new object[] { item.Activity, item.UserID, item.LanguageID, item.Level1ID, item.Level1Code, item.Level1ShortCode, item.VNName, item.ENName, item.Rank, item.Used, item.Note, item.Description });

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

        public string DeleteLevel1(string username, string language_id, string level1_id)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmProductGroupLevel1", new string[] { "Activity", "Username", "LanguageID", "Level1ID" }, new object[] { BaseConstant.COMMAND_DELETE_EN, username, language_id, level1_id });

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

        public string DeleteLevel1List(string username, string language_id, string level1_id_list)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmProductGroupLevel1", new string[] { "Activity", "Username", "LanguageID", "Level1IDList" }, new object[] { BaseConstant.COMMAND_DELETE_LIST_EN, username, language_id, level1_id_list });

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