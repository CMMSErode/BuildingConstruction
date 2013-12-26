using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using DataLayer;
using UtilityLayer;

namespace YesAndYes
{
    public partial class FrmMaterials : Form
    {
        public FrmMaterials()
        {
            InitializeComponent();
        }

        public string strHeader;
        string ErrMsg = "";
        string tableName = "Material";

        private void FrmMaterials_Load(object sender, EventArgs e)
        {
            lblHeader.Text = strHeader;
            gvMaterial.Visible = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ELMaterial objELMaterail = new ELMaterial();
            DLMaterial objDLMaterial = new DLMaterial();
            int newID = 0;

            if (lblMaterialID.Text.Length > 0)
            {
                objELMaterail.ID = Convert.ToInt32(lblMaterialID.Text);
            }
            else
            {
                newID = Common.GetNewID(tableName);
                objELMaterail.ID = newID;
            }
            
            objELMaterail.Code = txtCode.Text;
            objELMaterail.Name = txtName.Text;
            objELMaterail.Creator = 0;
            objELMaterail.Created = DateTime.Now;
            objELMaterail.IsActive = false;
            if (chkIsActive.Checked) objELMaterail.IsActive = true;

            if (Validations())
            {
                if (objDLMaterial.Add(objELMaterail) > 0)
                {
                    MessageBox.Show("Record Inserted");                 
                   // ClearControls();
                }
                else
                {
                    MessageBox.Show("Record not Inserted");
                }
            }            
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

        private void txtCode_Leave(object sender, EventArgs e)
        {
            if (txtCode.Text != "" && txtCode.Text.Length > 0)
            {
                ErrCode.Clear();
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtName.Text.Length > 0)
            {
                ErrName.Clear();
            }
        }

        private void ClearControls()
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    ctrl.Text ="";
                }
                else if (ctrl.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)ctrl).Checked = false;
                }
            }

            txtCode.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtCode.Text != "")
            {
                DLMaterial objDLMaterial = new DLMaterial();

                int ID = objDLMaterial.FetchIDbyCode(txtCode.Text);

                if (ID > 0)
                {
                    if (objDLMaterial.DeleteByID(ID) > 0)
                    {
                        MessageBox.Show("Record Deleted");
                        ClearControls();
                    }
                    else
                    {
                        MessageBox.Show("Record not Deleted");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Code");
                }
            }
            else
            {
                MessageBox.Show("Invalid Code");
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            gvMaterial.Visible = true;
            ClearControls();
            DLMaterial objDLMaterial = new DLMaterial();

            gvMaterial.DataSource = objDLMaterial.FetchMaterials();

            if (gvMaterial.Rows.Count > 0)
            {
                for (int i = 0; i <= gvMaterial.Rows.Count - 1; i++)
                {
                    gvMaterial.Columns[0].Visible  = false;
                }
            }
           // gvMaterial.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

        }

        private void gvMaterial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                
                string strCode = gvMaterial.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string materialID = gvMaterial.Rows[e.RowIndex].Cells[0].Value.ToString();

                ELMaterial objELMaterial = new ELMaterial();
                DLMaterial objDLMaterial = new DLMaterial();

                objELMaterial = objDLMaterial.FetchMaterialsByID(Convert.ToInt32(materialID));

                if (objELMaterial != null)
                {
                    lblMaterialID.Text = objELMaterial.ID.ToString();
                    txtCode.Text = objELMaterial.Code;
                    txtName.Text = objELMaterial.Name;
                    chkIsActive.Checked = Convert.ToBoolean( objELMaterial.IsActive);
                }
            }
            gvMaterial.Visible = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            lblMaterialID.Text = "";
            ClearControls();
            gvMaterial.Visible = false;
            txtCode.Focus();
        }

        private void btnRights_Click(object sender, EventArgs e)
        {
            FrmRights frm = new FrmRights();
            FrmMaterials objfrmMaterial = new FrmMaterials();
            frm.frmName = this.Name;
            frm.frmRightsControl = objfrmMaterial;
            frm.Show();

        }
    }
}
