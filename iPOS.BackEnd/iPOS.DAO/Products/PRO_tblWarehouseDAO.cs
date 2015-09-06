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
    public interface IPRO_tblWarehouseDAO
    {
        List<PRO_tblWarehouseDTO> LoadAllData(string username, string language_id, string store_id, string province_id, string district_id);

        List<PRO_tblWarehouseDTO> GetDataCombobox(string username, string language_id, string store_id);

        PRO_tblWarehouseDTO GetDataByID(string username, string language_id, string warehouse_id);

        string InsertWarehouse(PRO_tblWarehouseDTO item);

        string UpdateWarehouse(PRO_tblWarehouseDTO item);

        string DeleteWarehouse(string username, string language_id, string warehouse_id);

        string DeleteWarehouseList(string username, string language_id, string warehouse_id_list);
    }

    public class PRO_tblWarehouseDAO : BaseDAO, IPRO_tblWarehouseDAO
    {
        public List<PRO_tblWarehouseDTO> LoadAllData(string username, string language_id, string store_id, string province_id, string district_id)
        {
            List<PRO_tblWarehouseDTO> result = new List<PRO_tblWarehouseDTO>();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmWarehouse", new string[] { "Activity", "Username", "LanguageID", "StoreID", "ProvinceID", "DistrictID" }, new object[] { BaseConstant.COMMAND_LOAD_ALL_DATA_EN, username, language_id, store_id, province_id, district_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblWarehouseDTO>(data);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public List<PRO_tblWarehouseDTO> GetDataCombobox(string username, string language_id, string store_id)
        {
            List<PRO_tblWarehouseDTO> result = new List<PRO_tblWarehouseDTO>();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmWarehouse", new string[] { "Activity", "Username", "LanguageID", "StoreID" }, new object[] { BaseConstant.COMMAND_GET_COMBO_BOX, username, language_id, store_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblWarehouseDTO>(data);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblWarehouseDTO GetDataByID(string username, string language_id, string warehouse_id)
        {
            PRO_tblWarehouseDTO result = new PRO_tblWarehouseDTO();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmWarehouse", new string[] { "Activity", "Username", "LanguageID", "WarehouseID" }, new object[] { BaseConstant.COMMAND_GET_DATA_BY_ID_EN, username, language_id, warehouse_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblWarehouseDTO>(data)[0];
                    return result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public string InsertWarehouse(PRO_tblWarehouseDTO item)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmWarehouse", new string[] { "Activity", "Username", "LanguageID", "WarehouseID", "WarehouseCode", "VNName", "ENName", "AddressVN", "AddressEN", "Phone", "Fax", "Rank", "Used", "Note", "StoreID", "ProvinceID", "DistrictID" }, new object[] { item.Activity, item.UserID, item.LanguageID, item.WarehouseID, item.WarehouseCode, item.VNName, item.ENName, item.AddressVN, item.AddressEN, item.Phone, item.Fax, item.Rank, item.Used, item.Note, item.StoreID, item.ProvinceID, item.DistrictID });

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

        public string UpdateWarehouse(PRO_tblWarehouseDTO item)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmWarehouse", new string[] { "Activity", "Username", "LanguageID", "WarehouseID", "WarehouseCode", "VNName", "ENName", "AddressVN", "AddressEN", "Phone", "Fax", "Rank", "Used", "Note", "StoreID", "ProvinceID", "DistrictID" }, new object[] { item.Activity, item.UserID, item.LanguageID, item.WarehouseID, item.WarehouseCode, item.VNName, item.ENName, item.AddressVN, item.AddressEN, item.Phone, item.Fax, item.Rank, item.Used, item.Note, item.StoreID, item.ProvinceID, item.DistrictID });

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

        public string DeleteWarehouse(string username, string language_id, string warehouse_id)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmWarehouse", new string[] { "Activity", "Username", "LanguageID", "WarehouseID" }, new object[] { BaseConstant.COMMAND_DELETE_EN, username, language_id, warehouse_id });

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

        public string DeleteWarehouseList(string username, string language_id, string warehouse_id_list)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmWarehouse", new string[] { "Activity", "Username", "LanguageID", "WarehouseIDList" }, new object[] { BaseConstant.COMMAND_DELETE_EN, username, language_id, warehouse_id_list });

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
