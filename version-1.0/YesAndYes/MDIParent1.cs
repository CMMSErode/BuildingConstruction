using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UtilityLayer;

namespace YesAndYes
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            bool Result = Common.CheckOpened("FrmCompanyType");
            if (Result == false)
            {
                FrmCompanyType frm = new FrmCompanyType();
                frm.strHeader = "FrmCompanyType";
                frm.Show();
            }

        }

       

       
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

      

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MaterailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Result = Common.CheckOpened("frmmaterials");
             if (Result == false)
             {
                 FrmMaterials frm = new FrmMaterials();
                 frm.strHeader = "MATERIALS";
                 frm.Show();
             }
        }

        private void UnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Result = Common.CheckOpened("frmunits");
            FrmUnits frm = new FrmUnits();
            if (Result == false)
            {
                frm.strHeader = "UNITS";
                frm.Show();
            }
            else
            {
                FormCollection fc = Application.OpenForms;

                foreach (Form frm1 in fc)
                {
                    if (frm1.Name.ToLower() == "frmunits")
                    {
                        frm1.StartPosition = FormStartPosition.CenterParent;
                    }
                }
            }
        }        

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Result = Common.CheckOpened("FrmCompany");
            if (Result == false)
            {
                FrmCompany frm = new FrmCompany();
                frm.strHeader = "Company";
                frm.Show();
            }
        }

        private void companyTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Result = Common.CheckOpened("FrmCompanyType");
            if (Result == false)
            {
                FrmCompanyType frm = new FrmCompanyType();
                frm.strHeader = "Company Type";
                frm.Show();
            }
        }

    }
}
