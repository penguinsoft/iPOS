using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.DTO.Products;

namespace iPOS.IMC.Products
{
    public partial class uc_District : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private List<PRO_tblDistrictDTO> curItem = new List<PRO_tblDistrictDTO>();

        private string district_id_list = "", district_code_list = "";
        #endregion

        #region [Personal Methods]

        #endregion

        public uc_District()
        {
            InitializeComponent();
        }
    }
}
