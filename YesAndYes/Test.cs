using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
//using BusinessLayer;
using DataLayer;

namespace YesAndYes
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Result_Click(object sender, EventArgs e)
        {
            if (Value1.Text == "test" && value2.Text == "test")
            {
                MDIParent1 frmmdi = new MDIParent1();
                frmmdi.Show();
            }
        }
    }
}
