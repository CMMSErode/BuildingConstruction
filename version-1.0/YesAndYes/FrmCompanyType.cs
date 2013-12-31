using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityLayer;
using DataLayer;
using UtilityLayer;


namespace YesAndYes
{
    public partial class FrmCompanyType : Form
    {
        #region Variables
        public string strHeader;
        string ErrMsg = "";
        string tableName = "CompanyType";
        #endregion Variables

        #region Methods 
        private void ClearControls()
        {
            foreach (Control ctrl in gbName.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    ctrl.Text = "";
                }
                else if (ctrl.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)ctrl).Checked = false;
                }
                else if (ctrl.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)ctrl).SelectedIndex = 1;
                }
            }

            txtCode.Focus();
        }

        private bool Validations()
        {
            bool retValue = true;

            if (txtCode.Text.Length <= 0 || txtCode.Text == "")
            {
                ErrMsg = "Enter Valid Code";

                ErrCode.SetError(txtCode, "Enter Valid Code");

                retValue = false;
            }
            if (txtName.Text.Length <= 0 || txtName.Text == "")
            {
                ErrMsg += "Enter Material Name";
                ErrName.SetError(txtName, "Enter Material Name");

                retValue = false;
            }

            return retValue;
        }
        #endregion Methods

        #region Form load
        public FrmCompanyType()
        {
            InitializeComponent();
        }

        private void FrmCompany_Load(object sender, EventArgs e)
        {
            lblHeader.Text = strHeader;
            gv.Visible = false;

            DataView dv = DLCompany.FetchAll();            
            if (dv != null)
            {
                //Dictionary<int,string> DicObj=null;
                for (int index = 0; index < dv.Count; index++)
                {
                    //DicObj = new Dictionary<int, string>();
                    //DicObj = new Dictionary<int, string>();
                    //DicObj.Add(Convert.ToInt16(dv[index].Row["ID"]),Convert.ToString(dv[index].Row["Name"]));
                    //cbTypes.Items.Add(DicObj);
                    cbTypes.Items.Add(Convert.ToString(dv[index].Row["Name"]));
                }
            }
        }
        #endregion Form load

        #region Button Functions
        private void btnSave_Click(object sender, EventArgs e)
        {
            ELCompanyType objEL = new ELCompanyType();
            
            int newID = 0;

            if (lblID.Text.Length > 0)
            {
                objEL.ID = Convert.ToInt32(lblID.Text);
            }
            else
            {
                newID = Common.GetNewID(tableName);
                objEL.ID = newID;
            }

            objEL.Code = txtCode.Text;
            objEL.Name = txtName.Text;
            objEL.Creator = 0;
            objEL.Created = DateTime.Now;
            objEL.IsActive = false;
            
            if (chkIsActive.Checked) objEL.IsActive = true;

            if (Validations())
            {
                if (DLCompanyType.Add(objEL) > 0)
                {
                    MessageBox.Show("Record Inserted");
                    ClearControls();
                }
                else
                {
                    MessageBox.Show("Record not Inserted");
                }
            }            
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            gv.Visible = true;
            //ClearControls();
           
            gv.DataSource = DLCompanyType.FetchAll();

            if (gv.Rows.Count > 0)
            {
                for (int i = 0; i <= gv.Rows.Count - 1; i++)
                {
                    gv.Columns[0].Visible = false;
                }
            }            
            // gvMaterial.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        private void btnRights_Click(object sender, EventArgs e)
        {
            FrmRights frm = new FrmRights();
            FrmMaterials objfrmMaterial = new FrmMaterials();
            frm.frmName = this.Name;
            frm.frmRightsControl = objfrmMaterial;
            frm.Show();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        #endregion Button Functions

        #region GridView
        private void gv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {

                string strCode = gv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string ID = gv.Rows[e.RowIndex].Cells[0].Value.ToString();
                string CompanyCode = gv.Rows[e.RowIndex].Cells[3].Value.ToString();

                ELCompanyType objEL = new ELCompanyType();
                DLCompanyType objDL = new DLCompanyType();
                objEL = DLCompanyType.FetchByID(Convert.ToInt32(ID));


                if (objEL != null)
                {
                    lblID.Text = objEL.ID.ToString();
                    txtCode.Text = objEL.Code;
                    txtName.Text = objEL.Name;
                    chkIsActive.Checked = Convert.ToBoolean(objEL.IsActive);
                    if (CompanyCode == objEL.ID.ToString())
                        cbTypes.SelectedItem = objEL.CompanyName;
                }
            }
        }
        #endregion Gridview
    }
}
