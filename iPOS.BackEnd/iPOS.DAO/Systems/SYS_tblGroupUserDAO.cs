using System;
using System.Collections.Generic;
using System.Data;
using iPOS.Core.Helper;
using iPOS.DTO.Systems;

namespace iPOS.DAO.Systems
{
    public interface ISYS_tblGroupUserDAO
    {
        List<SYS_tblGroupUserDTO> LoadAllData(string username, string language_id);

        SYS_tblGroupUserDTO GetDataByID(string group_user_id, string username, string language_id);

        string InsertGroupUser(SYS_tblGroupUserDTO item);

        string UpdateGroupUser(SYS_tblGroupUserDTO item);

        string DeleteGroupUser(string group_user_id, string group_user_code, string username, string language_id);

        string DeleteGroupUserList(string group_user_id_list, string group_user_code_list, string username, string language_id);
    }

    public class SYS_tblGroupUserDAO : BaseDAO, ISYS_tblGroupUserDAO
    {
        public List<SYS_tblGroupUserDTO> LoadAllData(string username, string language_id)
        {
            List<SYS_tblGroupUserDTO> result = new List<SYS_tblGroupUserDTO>();
            try
            {
                string strErr = InsertActionLog(new SYS_tblActionLogDTO
                {
                    Activity = BaseConstant.COMMAND_INSERT_EN,
                    Username = username,
                    LanguageID = language_id,
                    ActionEN = BaseConstant.COMMAND_LOAD_ALL_DATA_EN,
                    ActionVN = BaseConstant.COMMAND_LOAD_ALL_DATA_VI,
                    FunctionID = "9",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa tải thành công dữ liệu nhóm người dùng.", username),
                    DescriptionEN = string.Format("Account '{0}' downloaded successfully data of group users.", username)
                });

                if (string.IsNullOrEmpty(strErr))
                {
                    DataTable data = db.GetDataTable("SYS_spfrmGroupUser", new string[] { "Activity", "Username", "LanguageID" }, new object[] { BaseConstant.COMMAND_LOAD_ALL_DATA_EN, username, language_id });
                    if (data != null && data.Rows.Count > 0)
                    {
                        foreach (DataRow dr in data.Rows)
                            result.Add(new SYS_tblGroupUserDTO
                            {
                                GroupID = dr["GroupID"] + "",
                                GroupCode = dr["GroupCode"] + "",
                                GroupName = dr["GroupName"] + "",
                                Note = dr["Note"] + "",
                                Active = Convert.ToBoolean(dr["Active"]),
                                IsDefault = Convert.ToBoolean(dr["IsDefault"]),
                                IsRoot = Convert.ToBoolean(dr["IsRoot"]),
                                Activity = BaseConstant.COMMAND_LOAD_ALL_DATA_EN,
                                Username = username,
                                LanguageID = language_id,
                                Visible = Convert.ToBoolean(dr["Visible"]),
                                Creater = dr["Creater"] + "",
                                CreateTime = Convert.ToDateTime(dr["CreateTime"]),
                                Editer = dr["Editer"] + "",
                                EditTime = (dr["EditTime"] == DBNull.Value) ? (DateTime?)null : (DateTime)dr["EditTime"]
                            });
                    }
                }
                else
                {
                    logger.Error(strErr);
                    return result;
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
                        GroupID = dr["GroupID"] + "",
                        GroupCode = dr["GroupCode"] + "",
                        VNName = dr["VNName"] + "",
                        ENName = dr["ENName"] + "",
                        Note = dr["Note"] + "",
                        Active = Convert.ToBoolean(dr["Active"]),
                        IsDefault = Convert.ToBoolean(dr["IsDefault"]),
                        IsRoot = Convert.ToBoolean(dr["IsRoot"]),
                        Activity = BaseConstant.COMMAND_GET_DATA_BY_ID_EN,
                        Username = username,
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
                result = db.sExecuteSQL("SYS_spfrmGroupUser", new string[] { "Activity", "Username", "LanguageID", "GroupCode", "VNName", "ENName", "Note", "Active", "IsDefault", "IsRoot" }, new object[] { BaseConstant.COMMAND_INSERT_EN, item.Username, item.LanguageID, item.GroupCode, item.VNName, item.ENName, item.Note, item.Active, item.IsDefault, item.IsRoot });

                if (string.IsNullOrEmpty(result))
                {
                    result = InsertActionLog(new SYS_tblActionLogDTO
                    {
                        Activity = BaseConstant.COMMAND_INSERT_EN,
                        Username = item.Username,
                        LanguageID = item.LanguageID,
                        ActionEN = BaseConstant.COMMAND_INSERT_EN,
                        ActionVN = BaseConstant.COMMAND_INSERT_VI,
                        FunctionID = "9",
                        DescriptionVN = string.Format("Tài khoản '{0}' vừa thêm mới thành công nhóm người dùng có mã '{1}'.", item.Username, item.GroupCode),
                        DescriptionEN = string.Format("Account '{0}' has inserted new group user successfully with group code is '{1}'.", item.Username, item.GroupCode)
                    });
                }

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
                result = db.sExecuteSQL("SYS_spfrmGroupUser", new string[] { "Activity", "Username", "LanguageID", "GroupID", "GroupCode", "VNName", "ENName", "Note", "Active", "IsDefault", "IsRoot" }, new object[] { BaseConstant.COMMAND_UPDATE_EN, item.Username, item.LanguageID, item.GroupID, item.GroupCode, item.VNName, item.ENName, item.Note, item.Active, item.IsDefault, item.IsRoot });

                if (string.IsNullOrEmpty(result))
                {
                    result = InsertActionLog(new SYS_tblActionLogDTO
                    {
                        Activity = BaseConstant.COMMAND_UPDATE_EN,
                        Username = item.Username,
                        LanguageID = item.LanguageID,
                        ActionEN = BaseConstant.COMMAND_UPDATE_EN,
                        ActionVN = BaseConstant.COMMAND_UPDATE_VI,
                        FunctionID = "9",
                        DescriptionVN = string.Format("Tài khoản '{0}' vừa cập nhật thành công nhóm người dùng có mã '{1}'.", item.Username, item.GroupCode),
                        DescriptionEN = string.Format("Account '{0}' has updated group user successfully with group code is '{1}'.", item.Username, item.GroupCode)
                    });
                }

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

        public string DeleteGroupUser(string group_user_id, string group_user_code, string username, string language_id)
        {
            string result = "";
            try
            {
                result = db.sExecuteSQL("SYS_spfrmGroupUser", new string[] { "Activity", "Username", "LanguageID", "GroupID" }, new object[] { BaseConstant.COMMAND_DELETE_EN, username, language_id, group_user_id });

                if (string.IsNullOrEmpty(result))
                {
                    result = InsertActionLog(new SYS_tblActionLogDTO
                    {
                        Activity = BaseConstant.COMMAND_DELETE_EN,
                        Username = username,
                        LanguageID = language_id,
                        ActionEN = BaseConstant.COMMAND_DELETE_EN,
                        ActionVN = BaseConstant.COMMAND_DELETE_VI,
                        FunctionID = "9",
                        DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công nhóm người dùng có mã '{1}'.", username, group_user_code),
                        DescriptionEN = string.Format("Account '{0}' has deleted group user successfully with group code is '{1}'.", username, group_user_code)
                    });
                }

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

        public string DeleteGroupUserList(string group_user_id_list, string group_user_code_list, string username, string language_id)
        {
            string result = "";
            try
            {
                result = db.sExecuteSQL("SYS_spfrmGroupUser", new string[] { "Activity", "Username", "LanguageID", "GroupIDList" }, new object[] { BaseConstant.COMMAND_DELETE_LIST_EN, username, language_id, group_user_id_list });

                if (string.IsNullOrEmpty(result))
                {
                    result = InsertActionLog(new SYS_tblActionLogDTO
                    {
                        Activity = BaseConstant.COMMAND_DELETE_EN,
                        Username = username,
                        LanguageID = language_id,
                        ActionEN = BaseConstant.COMMAND_DELETE_LIST_EN,
                        ActionVN = BaseConstant.COMMAND_DELETE_LIST_VI,
                        FunctionID = "9",
                        DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công nhóm người dùng có mã '{1}'.", username, group_user_code_list.Replace("$", ", ")),
                        DescriptionEN = string.Format("Account '{0}' has deleted group user successfully with group code are '{1}'.", username, group_user_code_list.Replace("$", ", "))
                    });
                }

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
