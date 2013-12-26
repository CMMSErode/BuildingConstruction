using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;
using UtilityLayer;
using EntityLayer;

namespace YesAndYes
{
    public partial class FrmUnits : Form
    {
        public FrmUnits()
        {
            InitializeComponent();
        }

        public string strHeader;
        string ErrMsg = "";
        string tableName = "Unit";

        private void btnNew_Click(object sender, EventArgs e)
        {
            lblUnitID.Text = "";
            ClearControls();
            gvUnit.Visible = false;
            txtCode.Focus();
        }

        private void ClearControls()
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    ctrl.Text = "";
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
                DLUnit objDLUnit = new DLUnit();

                int ID = objDLUnit.FetchIDbyCode(txtCode.Text);

                if (ID > 0)
                {
                    if (objDLUnit.DeleteByID(ID) > 0)
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

        private void FrmUnits_Load(object sender, EventArgs e)
        {
            lblHeader.Text = strHeader;
            gvUnit.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ELUnit objELUnit = new ELUnit();
            DLUnit objDLUnit = new DLUnit();
            int newID = 0;

            if (lblUnitID.Text.Length > 0)
            {
                objELUnit.ID = Convert.ToInt32(lblUnitID.Text);
            }
            else
            {
                newID = Common.GetNewID(tableName);
                objELUnit.ID = newID;
            }

            
            objELUnit.Code = txtCode.Text;
            objELUnit.Name = txtName.Text;
            objELUnit.Creator = 0;
            objELUnit.Created = DateTime.Now;
            objELUnit.IsActive = false;

            if (chkIsActive.Checked) objELUnit.IsActive = true;

            if (Validations())
            {
                if (objDLUnit.Add(objELUnit) > 0)
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
                ErrMsg += "Enter Unit Name";
                ErrName.SetError(txtName, "Enter Unit Name");

                retValue = false;
            }

            return retValue;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            gvUnit.Visible = true;
            ClearControls();
            DLUnit objDLUnit = new DLUnit();

            gvUnit.DataSource = objDLUnit.FetchUnits();

            if (gvUnit.Rows.Count > 0)
            {
                for (int i = 0; i <= gvUnit.Rows.Count - 1; i++)
                {
                    gvUnit.Columns[0].Visible = false;
                }
            }
        }

        private void gvUnit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {

                string strCode = gvUnit.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string unitID = gvUnit.Rows[e.RowIndex].Cells[0].Value.ToString();

                ELUnit objELUnit = new ELUnit();
                DLUnit objDLUnit = new DLUnit();

                objELUnit = objDLUnit.FetchUnitsByID(Convert.ToInt32(unitID));

                if (objELUnit != null)
                {
                    lblUnitID.Text = objELUnit.ID.ToString();
                    txtCode.Text = objELUnit.Code;
                    txtName.Text = objELUnit.Name;
                    chkIsActive.Checked = Convert.ToBoolean(objELUnit.IsActive);
                }
            }
            gvUnit.Visible = false;
        }

        private void btnRights_Click(object sender, EventArgs e)
        {
            FrmRights frm = new FrmRights();
            FrmUnits objfrmUnit = new FrmUnits();
            frm.frmName = this.Name;
            frm.frmRightsControl = objfrmUnit;
            frm.Show();
        }
       
    }
}
