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
    public interface IPRO_tblProductGroupLevel3DAO
    {
        List<PRO_tblProductGroupLevel3DTO> LoadAllData(string username, string language_id, string level1_id, string Level3_id);

        List<PRO_tblProductGroupLevel3DTO> GetDataCombobox(string username, string language_id, string level1_id, string Level3_id);

        PRO_tblProductGroupLevel3DTO GetDataByID(string username, string language_id, string level3_id);

        string InsertLevel3(PRO_tblProductGroupLevel3DTO item);

        string UpdateLevel3(PRO_tblProductGroupLevel3DTO item);

        string DeleteLevel3(string username, string language_id, string level3_id);

        string DeleteLevel3List(string username, string language_id, string level3_id_list);
    }

    public class PRO_tblProductGroupLevel3DAO : BaseDAO, IPRO_tblProductGroupLevel3DAO
    {
        public List<PRO_tblProductGroupLevel3DTO> LoadAllData(string username, string language_id, string level1_id, string Level3_id)
        {
            List<PRO_tblProductGroupLevel3DTO> result = new List<PRO_tblProductGroupLevel3DTO>();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmProductGroupLevel3", new string[] { "Activity", "Username", "LanguageID", "Level1ID", "Level3ID" }, new object[] { BaseConstant.COMMAND_LOAD_ALL_DATA_EN, username, language_id, level1_id, Level3_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblProductGroupLevel3DTO>(data);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public List<PRO_tblProductGroupLevel3DTO> GetDataCombobox(string username, string language_id, string level1_id, string Level3_id)
        {
            throw new NotImplementedException();
        }

        public PRO_tblProductGroupLevel3DTO GetDataByID(string username, string language_id, string level3_id)
        {
            PRO_tblProductGroupLevel3DTO result = new PRO_tblProductGroupLevel3DTO();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmProductGroupLevel3", new string[] { "Activity", "Username", "LanguageID", "Level3ID" }, new object[] { BaseConstant.COMMAND_GET_DATA_BY_ID_EN, username, language_id, level3_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblProductGroupLevel3DTO>(data)[0];
                    return result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public string InsertLevel3(PRO_tblProductGroupLevel3DTO item)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmProductGroupLevel3", new string[] { "Activity", "Username", "LanguageID", "Level3Code", "Level3ShortCode", "Level1ID", "Level2ID", "VNName", "ENName", "Rank", "Used", "Note", "Description" }, new object[] { item.Activity, item.UserID, item.LanguageID, item.Level3Code, item.Level3ShortCode, item.Level1ID, item.Level2ID, item.VNName, item.ENName, item.Rank, item.Used, item.Note, item.Description });

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

        public string UpdateLevel3(PRO_tblProductGroupLevel3DTO item)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmProductGroupLevel3", new string[] { "Activity", "Username", "LanguageID", "Level3ID", "Level3Code", "Level3ShortCode", "Level1ID", "Level2ID", "VNName", "ENName", "Rank", "Used", "Note", "Description" }, new object[] { item.Activity, item.UserID, item.LanguageID, item.Level3ID, item.Level3Code, item.Level3ShortCode, item.Level1ID, item.Level2ID, item.VNName, item.ENName, item.Rank, item.Used, item.Note, item.Description });

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

        public string DeleteLevel3(string username, string language_id, string level3_id)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmProductGroupLevel3", new string[] { "Activity", "Username", "LanguageID", "Level3ID" }, new object[] { BaseConstant.COMMAND_DELETE_EN, username, language_id, level3_id });

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

        public string DeleteLevel3List(string username, string language_id, string level3_id_list)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmProductGroupLevel3", new string[] { "Activity", "Username", "LanguageID", "Level3IDList" }, new object[] { BaseConstant.COMMAND_DELETE_LIST_EN, username, language_id, level3_id_list });

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
