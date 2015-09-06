using System;
using System.Collections.Generic;
using System.Data;
using iPOS.Core.Helper;
using iPOS.DTO.Products;

namespace iPOS.DAO.Products
{
    public interface IPRO_tblStoreDAO
    {
        List<PRO_tblStoreDTO> LoadAllData(string username, string language_id);

        List<PRO_tblStoreDTO> GetDataCombobox(string username, string language_id);

        PRO_tblStoreDTO GetDataByID(string username, string language_id, string store_id);

        string InsertStore(PRO_tblStoreDTO item);

        string UpdateStore(PRO_tblStoreDTO item);

        string DeleteStore(string username, string language_id, string store_id);

        string DeleteStoreList(string username, string language_id, string store_id_list);
    }

    public class PRO_tblStoreDAO : BaseDAO, IPRO_tblStoreDAO
    {
        public List<PRO_tblStoreDTO> LoadAllData(string username, string language_id)
        {
            List<PRO_tblStoreDTO> result = new List<PRO_tblStoreDTO>();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmStore", new string[] { "Activity", "Username", "LanguageID" }, new object[] { BaseConstant.COMMAND_LOAD_ALL_DATA_EN, username, language_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblStoreDTO>(data);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public List<PRO_tblStoreDTO> GetDataCombobox(string username, string language_id)
        {
            List<PRO_tblStoreDTO> result = new List<PRO_tblStoreDTO>();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmStore", new string[] { "Activity", "Username", "LanguageID" }, new object[] { BaseConstant.COMMAND_GET_COMBO_BOX, username, language_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblStoreDTO>(data);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public PRO_tblStoreDTO GetDataByID(string username, string language_id, string store_id)
        {
            PRO_tblStoreDTO result = new PRO_tblStoreDTO();
            try
            {
                DataTable data = db.GetDataTable("PRO_spfrmStore", new string[] { "Activity", "Username", "LanguageID", "StoreID" }, new object[] { BaseConstant.COMMAND_GET_DATA_BY_ID_EN, username, language_id, store_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<PRO_tblStoreDTO>(data)[0];
                    return result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public string InsertStore(PRO_tblStoreDTO item)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmStore", new string[] { "Activity", "Username", "LanguageID", "StoreID", "StoreCode", "ShortCode", "VNName", "ENName", "BuildDate", "EndDate", "AddressVN", "AddressEN", "Phone", "Fax", "Rank", "TaxCode", "Used", "IsRoot", "Representives", "Note", "Photo", "ProvinceID", "DistrictID" }, new object[] { item.Activity, item.UserID, item.LanguageID, item.StoreID, item.StoreCode, item.ShortCode, item.VNName, item.ENName, item.BuildDate, item.EndDate, item.AddressVN, item.AddressEN, item.Phone, item.Fax, item.Rank, item.TaxCode, item.Used, item.IsRoot, item.Representatives, item.Note, item.Photo, item.ProvinceID, item.DistrictID });

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

        public string UpdateStore(PRO_tblStoreDTO item)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmStore", new string[] { "Activity", "Username", "LanguageID", "StoreID", "StoreCode", "ShortCode", "VNName", "ENName", "BuildDate", "EndDate", "AddressVN", "AddressEN", "Phone", "Fax", "Rank", "TaxCode", "Used", "IsRoot", "Representives", "Note", "Photo", "ProvinceID", "DistrictID" }, new object[] { item.Activity, item.UserID, item.LanguageID, item.StoreID, item.StoreCode, item.ShortCode, item.VNName, item.ENName, item.BuildDate, item.EndDate, item.AddressVN, item.AddressEN, item.Phone, item.Fax, item.Rank, item.TaxCode, item.Used, item.IsRoot, item.Representatives, item.Note, item.Photo, item.ProvinceID, item.DistrictID });

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

        public string DeleteStore(string username, string language_id, string store_id)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmStore", new string[] { "Activity", "Username", "LanguageID", "StoreID" }, new object[] { BaseConstant.COMMAND_DELETE_EN, username, language_id, store_id });

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

        public string DeleteStoreList(string username, string language_id, string store_id_list)
        {
            string strError = "";
            try
            {
                strError = db.sExecuteSQL("PRO_spfrmStore", new string[] { "Activity", "Username", "LanguageID", "StoreIDList" }, new object[] { BaseConstant.COMMAND_DELETE_LIST_EN, username, language_id, store_id_list });

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
