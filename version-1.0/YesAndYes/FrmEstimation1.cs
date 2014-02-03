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
    public partial class FrmEstimation1 : Form
    {
        public string strHeader;
        string ErrMsg = "";
        string tableName = "Estimation";
        DataGridViewCheckBoxColumn c1;
        DataGridViewTextBoxColumn tb1;
        DataGridViewTextBoxColumn tb2;
        DataGridViewTextBoxColumn tb3;
        DataGridViewTextBoxColumn tb4;
        CheckBox ckBox;

        public FrmEstimation1()
        {
            InitializeComponent();
        }
       
        private int Calculation(int Units, int Rate)
        {
            return Units * Rate;
        }

        private int CostCalculate()
        {
            int Cost = 0;
            if (Validations())
            {
                int Unit = Convert.ToInt16(tbUnits.Text);
                int Rate = Convert.ToInt16(tbRate.Text);
                Cost = Calculation(Unit, Rate);               
            }
            return Cost;
        }        

        private bool Validations()
        {
            bool retValue = true;

            if (cbQuality.SelectedItem.ToString() == "")
            {
                ErrMsg = "Enter Valid Units";

                ErrorQuality.SetError(cbQuality, "Enter Valid Units");

                retValue = false;
            }
            if ((tbUnits.Text.Length > 0 || tbUnits.Text != "" ) && !IsInteger(tbUnits.Text))
            {
                ErrMsg = "Enter Valid Units";

                ErrorUnits.SetError(tbUnits, "Enter Valid Units");

                retValue = false;
            }
            if ((tbRate.Text.Length > 0 || tbRate.Text != "") && !IsInteger(tbRate.Text))
            {
                ErrMsg += "Enter Valid Rate";
                ErrorRate.SetError(tbRate, "Enter Valid Rate");
                retValue = false;
            }
            

            return retValue;
        }

        public static bool IsInteger(string sInteger)
        {
            int intVal;
            bool IsValidInteger = true;
            if (string.IsNullOrEmpty(sInteger))
            {
                IsValidInteger = false;
            }
            else
            {
                IsValidInteger = int.TryParse(sInteger, out  intVal);
            }
            return IsValidInteger;
        }

        private void ClearControls()
        {
            foreach (Control ctrl in pEstimation.Controls)
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

            tbUnits.Focus();
        }

        void ckBox_CheckedChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < this.dgvEstimation.RowCount; j++)
            {
                this.dgvEstimation[0, j].Value = this.ckBox.Checked;
            }
            this.dgvEstimation.EndEdit();
        }

        private void FrmEstimation1_Load(object sender, EventArgs e)
        {
            lblHeader.Text = strHeader;
            c1 = new DataGridViewCheckBoxColumn();
            c1.Width = 18;            
            c1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvEstimation.Columns.Add(c1);

            tb1 = new DataGridViewTextBoxColumn();
            tb1.Width = 70;
            tb1.Name = "Quality";
            tb1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvEstimation.Columns.Add(tb1);

            tb2 = new DataGridViewTextBoxColumn();
            tb2.Width = 70;
            tb2.Name = "Units";
            tb2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvEstimation.Columns.Add(tb2);

            tb3 = new DataGridViewTextBoxColumn();
            tb3.Width = 70;
            tb3.Name = "Rate/Unit";
            tb3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvEstimation.Columns.Add(tb3);

            tb4 = new DataGridViewTextBoxColumn();
            tb4.Width = 50;
            tb4.Name = "Cost";
            tb4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvEstimation.Columns.Add(tb4);

            //this.dgvEstimation.Rows.Add();           

            ckBox = new CheckBox(); //Get the column header cell bounds 
            Rectangle rect = this.dgvEstimation.GetCellDisplayRectangle(0, -1, true);
            ckBox.Size = new Size(15, 15); //Change the location of the CheckBox to make it stay on the header 
            //ckBox.Location = rect.Location;
            ckBox.Location = new Point(rect.Location.X+2, rect.Location.Y + 4);
            ckBox.CheckedChanged += new EventHandler(ckBox_CheckedChanged); //Add the CheckBox into the DataGridView 
            this.dgvEstimation.Controls.Add(ckBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validations())
            {
                this.dgvEstimation.Rows.Add();
                DataGridView dgv = dgvEstimation;
                int cost = CostCalculate();
                dgv.Rows[dgvEstimation.Rows.Count - 1].Cells[0].Value = true;
                dgv.Rows[dgvEstimation.Rows.Count-1].Cells["Quality"].Value = cbQuality.SelectedItem.ToString();
                dgv.Rows[dgvEstimation.Rows.Count-1].Cells["Units"].Value = tbUnits.Text;
                dgv.Rows[dgvEstimation.Rows.Count-1].Cells["Rate/Unit"].Value = tbRate.Text;
                dgv.Rows[dgvEstimation.Rows.Count-1].Cells["Cost"].Value = cost;
                ClearControls();
            }            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvEstimation;
            Dictionary<int, ELEstimation> objDic = new Dictionary<int, ELEstimation>();
            ELEstimation objEL;
            int newID = 0;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
               if(Convert.ToBoolean(dgv.Rows[i].Cells[0].Value))
               {
                   objEL = new ELEstimation();
                   newID = Common.GetNewID(tableName);
                   objEL.ID = newID;
                   objEL.Code = "Estm" + newID.ToString();
                   objEL.Creator = 0;
                   objEL.Created = DateTime.Now;
                   objEL.IsActive = true;
                   objEL.QualityType =Convert.ToString(dgv.Rows[i].Cells["Quality"].Value);
                   objEL.RatePerUnit = Convert.ToInt16(dgv.Rows[i].Cells["Rate/Unit"].Value);
                   objEL.Site = "Site1";
                   objEL.TotalCost = Convert.ToInt16(dgv.Rows[i].Cells["Cost"].Value);
                   objEL.Units = Convert.ToInt16(dgv.Rows[i].Cells["Units"].Value);
                   objEL.UnitType = "Type1";
                   objDic.Add(i, objEL);
                   dgv.Rows[dgvEstimation.Rows.Count - 1].Cells[0].Value = false;                  
               }
            }
            DLEstimation.AddALL(objDic);
        }
    }
}
