using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iPOS.Core.Helper;
using iPOS.DTO.Products;

namespace iPOS.DAO.Products
{
    public interface IPRO_tblStallDAO
    {
        List<PRO_tblStallDTO> LoadAllData(string username, string language_id, string store_id, string warehouse_id);

        List<PRO_tblStallDTO> GetDataCombobox(string username, string language_id, string warehouse_id);

        PRO_tblStallDTO GetDataByID(string username, string language_id, string stall_id);

        string InsertStall(PRO_tblStallDTO item);

        string UpdateStall(PRO_tblStallDTO item);

        string DeleteStall(string username, string language_id, string stall_id);

        string DeleteStallList(string username, string language_id, string stall_id_list);
    }

    public class PRO_tblStallDAO : BaseDAO, IPRO_tblStallDAO
    {
        public List<PRO_tblStallDTO> LoadAllData(string username, string language_id, string store_id, string warehouse_id)
        {
            List<PRO_tblStallDTO> result = new List<PRO_tblStallDTO>();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmStall", new string[] { "Activity", "Username", "LanguageID", "StoreID", "WarehouseID" }, new object[] { BaseConstant.COMMAND_LOAD_ALL_DATA_EN, username, language_id, store_id, warehouse_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblStallDTO>(data);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public List<PRO_tblStallDTO> GetDataCombobox(string username, string language_id, string warehouse_id)
        {
            List<PRO_tblStallDTO> result = new List<PRO_tblStallDTO>();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmStall", new string[] { "Activity", "Username", "LanguageID", "WarehouseID" }, new object[] { BaseConstant.COMMAND_GET_COMBO_BOX, username, language_id, warehouse_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblStallDTO>(data);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblStallDTO GetDataByID(string username, string language_id, string stall_id)
        {
            PRO_tblStallDTO result = new PRO_tblStallDTO();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmStall", new string[] { "Activity", "Username", "LanguageID", "StallID" }, new object[] { BaseConstant.COMMAND_GET_DATA_BY_ID_EN, username, language_id, stall_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblStallDTO>(data)[0];
                    return result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public string InsertStall(PRO_tblStallDTO item)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmStall", new string[] { "Activity", "Username", "LanguageID", "StallID", "VNName", "ENName", "Rank", "Used", "Note", "StoreID", "WarehouseID" }, new object[] { item.Activity, item.UserID, item.LanguageID, item.StallID, item.StallCode, item.VNName, item.ENName, item.Rank, item.Used, item.Note, item.StoreID, item.WarehouseID });

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

        public string UpdateStall(PRO_tblStallDTO item)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmStall", new string[] { "Activity", "Username", "LanguageID", "StallID", "VNName", "ENName", "Rank", "Used", "Note", "StoreID", "WarehouseID" }, new object[] { item.Activity, item.UserID, item.LanguageID, item.StallID, item.StallCode, item.VNName, item.ENName, item.Rank, item.Used, item.Note, item.StoreID, item.WarehouseID });

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

        public string DeleteStall(string username, string language_id, string stall_id)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmStall", new string[] { "Activity", "Username", "LanguageID", "StallID" }, new object[] { BaseConstant.COMMAND_DELETE_EN, username, language_id, stall_id });

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

        public string DeleteStallList(string username, string language_id, string stall_id_list)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmStall", new string[] { "Activity", "Username", "LanguageID", "StallIDList" }, new object[] { BaseConstant.COMMAND_DELETE_EN, username, language_id, stall_id_list });

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
