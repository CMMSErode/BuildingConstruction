using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YesAndYes
{
    public partial class FrmRights : Form
    {
        public FrmRights()
        {
            InitializeComponent();
        }
        public string frmName;
        public Form frmRightsControl;
        private void FrmRights_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in frmRightsControl.Controls)
            {
                if (ctrl.Name.ToLower() == "txtcode")
                {
                }
                else if (ctrl.Name.ToLower() == "panel1")
                {
                    if (ctrl.HasChildren)
                    {
                        string strnames = "";
                        foreach (Control crl in ctrl.Controls)
                        {
                            Label lbl = new Label();
                            lbl.Name = crl.Name;
                            
                            strnames += crl.Name;
                            lbl.Visible = true;
                            this.panel1.Controls.Add(lbl);
                           
                    
                        }
                        MessageBox.Show(strnames);
                        Label lb = new Label();
                        lb.Name = lb.Name;
                        this.panel1.Controls.Add(lb);
                    }       
            
                }
            }
        }
    }
}
