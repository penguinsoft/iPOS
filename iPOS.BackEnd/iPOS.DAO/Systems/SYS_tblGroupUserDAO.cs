﻿using System;
using System.Collections.Generic;
using System.Data;
using iPOS.Core.Helper;
using iPOS.DTO.Systems;

namespace iPOS.DAO.Systems
{
    public interface ISYS_tblGroupUserDAO
    {
        List<SYS_tblGroupUserDTO> LoadAllData(string username, string language_id);

        List<SYS_tblGroupUserDTO> GetDataCombobox(string username, string language_id);

        SYS_tblGroupUserDTO GetDataByID(string group_user_id, string username, string language_id);

        string InsertGroupUser(SYS_tblGroupUserDTO item);

        string UpdateGroupUser(SYS_tblGroupUserDTO item);

        string DeleteGroupUser(string group_user_id, string username, string language_id);

        string DeleteGroupUserList(string group_user_id_list, string username, string language_id);
    }

    public class SYS_tblGroupUserDAO : BaseDAO, ISYS_tblGroupUserDAO
    {
        public List<SYS_tblGroupUserDTO> LoadAllData(string username, string language_id)
        {
            List<SYS_tblGroupUserDTO> result = new List<SYS_tblGroupUserDTO>();
            try
            {
                DataTable data = db.GetDataTable("SYS_spfrmGroupUser", new string[] { "Activity", "Username", "LanguageID" }, new object[] { BaseConstant.COMMAND_LOAD_ALL_DATA_EN, username, language_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<SYS_tblGroupUserDTO>(data);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public List<SYS_tblGroupUserDTO> GetDataCombobox(string username, string language_id)
        {
            List<SYS_tblGroupUserDTO> result = new List<SYS_tblGroupUserDTO>();
            try
            {
                DataTable data = db.GetDataTable("SYS_spfrmGroupUser", new string[] { "Activity", "Username", "LanguageID" }, new object[] { BaseConstant.COMMAND_GET_COMBO_BOX, username, language_id });
                if (data != null && data.Rows.Count > 0)
                {
                    result = ConvertEngine.ConvertDataTableToObjectList<SYS_tblGroupUserDTO>(data);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public SYS_tblGroupUserDTO GetDataByID(string group_user_id, string username, string language_id)
        {
            SYS_tblGroupUserDTO result = new SYS_tblGroupUserDTO();
            try
            {
                DataRow dr = db.GetDataRow("SYS_spfrmGroupUser", new string[] { "Activity", "Username", "LanguageID", "GroupID" }, new object[] { BaseConstant.COMMAND_GET_DATA_BY_ID_EN, username, language_id, group_user_id });
                if (dr != null)
                {
                    result = new SYS_tblGroupUserDTO
                    {
                        GroupID = Convert.ToInt32(dr["GroupID"]),
                        GroupCode = dr["GroupCode"] + "",
                        VNName = dr["VNName"] + "",
                        ENName = dr["ENName"] + "",
                        Note = dr["Note"] + "",
                        Active = Convert.ToBoolean(dr["Active"]),
                        IsDefault = Convert.ToBoolean(dr["IsDefault"]),
                        IsRoot = Convert.ToBoolean(dr["IsRoot"]),
                        Activity = BaseConstant.COMMAND_GET_DATA_BY_ID_EN,
                        UserID = username,
                        LanguageID = language_id,
                        Visible = Convert.ToBoolean(dr["Visible"]),
                        Creater = dr["Creater"] + "",
                        CreateTime = Convert.ToDateTime(dr["CreateTime"]),
                        Editer = dr["Editer"] + "",
                        EditTime = (dr["EditTime"] == DBNull.Value) ? (DateTime?)null : (DateTime)dr["EditTime"]
                    };

                    return result;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return result;
        }

        public string InsertGroupUser(SYS_tblGroupUserDTO item)
        {
            string result = "";
            try
            {
                result = db.sExecuteSQL("SYS_spfrmGroupUser", new string[] { "Activity", "Username", "LanguageID", "GroupCode", "VNName", "ENName", "Note", "Active", "IsDefault", "IsRoot" }, new object[] { BaseConstant.COMMAND_INSERT_EN, item.UserID, item.LanguageID, item.GroupCode, item.VNName, item.ENName, item.Note, item.Active, item.IsDefault, item.IsRoot });

                if (!string.IsNullOrEmpty(result))
                    logger.Error(result);

                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                logger.Error(ex);
            }

            return result;
        }

        public string UpdateGroupUser(SYS_tblGroupUserDTO item)
        {
            string result = "";
            try
            {
                result = db.sExecuteSQL("SYS_spfrmGroupUser", new string[] { "Activity", "Username", "LanguageID", "GroupID", "GroupCode", "VNName", "ENName", "Note", "Active", "IsDefault", "IsRoot" }, new object[] { BaseConstant.COMMAND_UPDATE_EN, item.UserID, item.LanguageID, item.GroupID, item.GroupCode, item.VNName, item.ENName, item.Note, item.Active, item.IsDefault, item.IsRoot });

                if (!string.IsNullOrEmpty(result))
                    logger.Error(result);

                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                logger.Error(ex);
            }

            return result;
        }

        public string DeleteGroupUser(string group_user_id, string username, string language_id)
        {
            string result = "";
            try
            {
                result = db.sExecuteSQL("SYS_spfrmGroupUser", new string[] { "Activity", "Username", "LanguageID", "GroupID" }, new object[] { BaseConstant.COMMAND_DELETE_EN, username, language_id, group_user_id });

                if (!string.IsNullOrEmpty(result))
                    logger.Error(result);

                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                logger.Error(ex);
            }

            return result;
        }

        public string DeleteGroupUserList(string group_user_id_list, string username, string language_id)
        {
            string result = "";
            try
            {
                result = db.sExecuteSQL("SYS_spfrmGroupUser", new string[] { "Activity", "Username", "LanguageID", "GroupIDList" }, new object[] { BaseConstant.COMMAND_DELETE_LIST_EN, username, language_id, group_user_id_list });

                if (!string.IsNullOrEmpty(result))
                    logger.Error(result);

                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                logger.Error(ex);
            }

            return result;
        }
    }
}
