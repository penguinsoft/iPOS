using iPOS.DTO.Products;
using System;
using System.Collections.Generic;

namespace iPOS.DAO.Products
{
    public interface IPRO_tblUnitDAO
    {
        List<PRO_tblUnitDTO> LoadAllData(string username, string language_id);

        List<PRO_tblUnitDTO> GetDataCombobox(string username, string language_id);

        PRO_tblUnitDTO GetDataByID(string username, string language_id, string unit_id);

        string InsertUnit(PRO_tblUnitDTO item);

        string UpdateUnit(PRO_tblUnitDTO item);

        string DeleteUnit(string username, string language_id, string unit_id);

        string DeleteUnitList(string username, string language_id, string unit_id_list);
    }

    public class PRO_tblUnitDAO : BaseDAO, IPRO_tblUnitDAO
    {
        public List<PRO_tblUnitDTO> LoadAllData(string username, string language_id)
        {
            throw new NotImplementedException();
        }

        public List<PRO_tblUnitDTO> GetDataCombobox(string username, string language_id)
        {
            throw new NotImplementedException();
        }

        public PRO_tblUnitDTO GetDataByID(string username, string language_id, string unit_id)
        {
            throw new NotImplementedException();
        }

        public string InsertUnit(PRO_tblUnitDTO item)
        {
            throw new NotImplementedException();
        }

        public string UpdateUnit(PRO_tblUnitDTO item)
        {
            throw new NotImplementedException();
        }

        public string DeleteUnit(string username, string language_id, string unit_id)
        {
            throw new NotImplementedException();
        }

        public string DeleteUnitList(string username, string language_id, string unit_id_list)
        {
            throw new NotImplementedException();
        }
    }
}
