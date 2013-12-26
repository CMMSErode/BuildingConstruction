using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UtilityLayer;
using EntityLayer;
using DataLayer;

namespace YesAndYes
{
    public partial class FrmDesignations : Form
    {
        public FrmDesignations()
        {
            InitializeComponent();
        }

        public string strHeader;
        string ErrMsg = "";
        string tableName = "Designation";

        private void FrmDesignations_Load(object sender, EventArgs e)
        {
            lblHeader.Text = strHeader;
            gvDesignation.Visible = false;
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            lblDesignationID.Text = "";
            ClearControls();
            gvDesignation.Visible = false;
            txtCode.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtCode.Text != "")
            {
                DLDesignation objDLDesignation = new DLDesignation();

                int ID = objDLDesignation.FetchIDbyCode(txtCode.Text);

                if (ID > 0)
                {
                    if (objDLDesignation.DeleteByID(ID) > 0)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            ELDesignation objELDesignation = new ELDesignation();
            DLDesignation objDLDesignation = new DLDesignation();

            int newID = 0;

            if (lblDesignationID.Text.Length > 0)
            {
                objELDesignation.ID = Convert.ToInt32(lblDesignationID.Text);
            }
            else
            {
                newID = Common.GetNewID(tableName);
                objELDesignation.ID = newID;
            }


            objELDesignation.Code = txtCode.Text;
            objELDesignation.Name = txtName.Text;
            objELDesignation.Creator = 0;
            objELDesignation.Created = DateTime.Now;
            objELDesignation.IsActive = false;

            if (chkIsActive.Checked) objELDesignation.IsActive = true;

            if (Validations())
            {
                if (objDLDesignation.Add(objELDesignation) > 0)
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
            gvDesignation.Visible = true;
            ClearControls();
            DLDesignation objDLDesignation = new DLDesignation();

            gvDesignation.DataSource = objDLDesignation.FetchDesginations();

            if (gvDesignation.Rows.Count > 0)
            {
                for (int i = 0; i <= gvDesignation.Rows.Count - 1; i++)
                {
                    gvDesignation.Columns[0].Visible = false;
                }
            }
        }

        private void gvDesignation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {

                string strCode = gvDesignation.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string designationID = gvDesignation.Rows[e.RowIndex].Cells[0].Value.ToString();

                ELDesignation objELDesignation = new ELDesignation();
                DLDesignation objDLDesignation = new DLDesignation();

                objELDesignation = objDLDesignation.FetchDesignationsByID(Convert.ToInt32(designationID));

                if (objELDesignation != null)
                {
                    lblDesignationID.Text = objELDesignation.ID.ToString();
                    txtCode.Text = objELDesignation.Code;
                    txtName.Text = objELDesignation.Name;
                    chkIsActive.Checked = Convert.ToBoolean(objELDesignation.IsActive);
                }
            }
            gvDesignation.Visible = false;
        }

        private void btnRights_Click(object sender, EventArgs e)
        {
            FrmRights frm = new FrmRights();
            FrmDesignations objfrmDesignation = new FrmDesignations();
            frm.frmName = this.Name;
            frm.frmRightsControl = objfrmDesignation;
            frm.Show();
        }
    }
}
