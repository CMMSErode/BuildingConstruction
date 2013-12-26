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
            lblBackColor.BackColor = Color.Aquamarine;
            foreach (Control ctrl in frmRightsControl.Controls)
            {
                if (ctrl.Name.ToLower() == "panel1")
                {
                    if (ctrl.HasChildren)
                    {
                        int x = 10;
                        int y = 100;

                        int cex = 110;
                        int cev = 210;

                        Label lblhFields = new Label();
                        lblhFields.Text = "Fields";
                        Label lblhEdit = new Label();
                        lblhEdit.Text = "Edit";
                        Label lblhView = new Label();
                        lblhView.Text = "View";

                        System.Drawing.Point lf = new System.Drawing.Point(x, y - 25);
                        System.Drawing.Point le = new System.Drawing.Point(cex, y - 25);
                        System.Drawing.Point lv = new System.Drawing.Point(cev, y - 25);

                        lblhFields.Location = lf;
                        lblhEdit.Location = le;
                        lblhView.Location = lv;

                        this.panel1.Controls.Add(lblhFields);
                        this.panel1.Controls.Add(lblhEdit);
                        this.panel1.Controls.Add(lblhView);

                        foreach (Control crl in ctrl.Controls)
                        {
                            int ex = 110;
                            int ev = 210;

                            if (crl.Text != "*" && crl.Text != "")
                            {
                                if (crl.Name.StartsWith("btn"))
                                {
                                    Label lbl = new Label();
                                    CheckBox chkEdit = new CheckBox();
                                    CheckBox chkView = new CheckBox();

                                    System.Drawing.Point l0 = new System.Drawing.Point(x, y);
                                    System.Drawing.Point eRights = new System.Drawing.Point(x + ex, y);
                                    System.Drawing.Point vRights = new System.Drawing.Point(x + ev, y);

                                    lbl.Name = crl.Name;
                                    lbl.Text = crl.Text;
                                    //lbl.Text = crl.Text.Replace("&", "");
                                    lbl.Text = lbl.Text;
                                    lbl.BackColor = Color.Aquamarine;
                                    lbl.Visible = true;
                                    lbl.Location = l0;

                                    chkEdit.Name = "chke" + crl.Name;
                                    chkView.Name = "chkv" + crl.Name;
                                    chkEdit.Location = eRights;
                                    chkView.Location = vRights;
                                    chkView.AutoSize = true;
                                    chkEdit.AutoSize = true;
                                    this.panel1.Controls.Add(lbl);
                                    this.panel1.Controls.Add(chkEdit);
                                    this.panel1.Controls.Add(chkView);

                                    ex += 50;
                                    ev += 50;
                                    y += 25;
                                }
                                else if (crl.Name.StartsWith("gv"))
                                {
                                    MessageBox.Show("present");
                                }
                                else
                                {
                                    Label lbl = new Label();
                                    CheckBox chkEdit = new CheckBox();
                                    CheckBox chkView = new CheckBox();

                                    System.Drawing.Point l0 = new System.Drawing.Point(x, y);
                                    System.Drawing.Point eRights = new System.Drawing.Point(x + ex, y);
                                    System.Drawing.Point vRights = new System.Drawing.Point(x + ev, y);

                                    lbl.Name = crl.Name;
                                    lbl.Text = crl.Text;
                                    lbl.Visible = true;
                                    lbl.Location = l0;
                                    lbl.AutoSize = true;

                                    chkEdit.Name = "chke" + crl.Name;
                                    chkView.Name = "chkv" + crl.Name;
                                    chkEdit.Location = eRights;
                                    chkView.Location = vRights;
                                    chkView.AutoSize = true;
                                    chkEdit.AutoSize = true;

                                    this.panel1.Controls.Add(lbl);
                                    this.panel1.Controls.Add(chkEdit);
                                    this.panel1.Controls.Add(chkView);

                                    y += 25;
                                    ex += 50;
                                    ev += 50;
                                }
                            }
                        }
                    }
                }
                else if (ctrl.GetType() == typeof(DataGrid))
                {
                    MessageBox.Show("yes");
                }
            }
        }
    }
}
