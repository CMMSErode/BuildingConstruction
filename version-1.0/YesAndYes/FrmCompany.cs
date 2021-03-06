﻿using System;
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
    public partial class FrmCompany : Form
    {
        #region Variables
        public string strHeader;
        string ErrMsg = "";
        string tableName = "Company";
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
        public FrmCompany()
        {
            InitializeComponent();
        }

        private void FrmCompany_Load(object sender, EventArgs e)
        {
            lblHeader.Text = strHeader;
            gv.Visible = false;
        }
        #endregion Form load

        #region Button Functions
        private void btnSave_Click(object sender, EventArgs e)
        {
            ELCompany objEL = new ELCompany();
            
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
                if (DLCompany.Add(objEL) > 0)
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
           
            gv.DataSource = DLCompany.FetchAll();

            if (gv.Rows.Count > 0)
            {
                for (int i = 0; i <= gv.Rows.Count - 1; i++)
                {
                    gv.Columns[0].Visible = false;
                }
            }   
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

                ELCompany objEL = new ELCompany();
                DLCompany objDL = new DLCompany();
                objEL = DLCompany.FetchByID(Convert.ToInt32(ID));


                if (objEL != null)
                {
                    lblID.Text = objEL.ID.ToString();
                    txtCode.Text = objEL.Code;
                    txtName.Text = objEL.Name;
                    chkIsActive.Checked = Convert.ToBoolean(objEL.IsActive);                    
                }
            }
        }
        #endregion Gridview
    }
}
