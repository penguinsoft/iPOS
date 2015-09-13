using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iPOS.DTO.Products;

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
            throw new NotImplementedException();
        }

        public List<PRO_tblProductGroupLevel1DTO> GetDataCombobox(string username, string language_id)
        {
            throw new NotImplementedException();
        }

        public PRO_tblProductGroupLevel1DTO GetDataByID(string username, string language_id, string level1_id)
        {
            throw new NotImplementedException();
        }

        public string InsertLevel1(PRO_tblProductGroupLevel1DTO item)
        {
            throw new NotImplementedException();
        }

        public string UpdateLevel1(PRO_tblProductGroupLevel1DTO item)
        {
            throw new NotImplementedException();
        }

        public string DeleteLevel1(string username, string language_id, string level1_id)
        {
            throw new NotImplementedException();
        }

        public string DeleteLevel1List(string username, string language_id, string level1_id_list)
        {
            throw new NotImplementedException();
        }
    }
}