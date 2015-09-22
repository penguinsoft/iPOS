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
    public partial class uc_StallDetail : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private uc_Stall parent_form;
        #endregion

        public uc_StallDetail()
        {
            InitializeComponent();
        }

        public uc_StallDetail(uc_Stall _parent_form, PRO_tblStallDTO item = null)
        {
            InitializeComponent();
            parent_form = _parent_form;
        }
    }
}
