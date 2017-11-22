using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GISApp
{
    public partial class Login : Form
    {
        public string name;
        public string pass;
        public Login()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "SteelBlue.ssk";
            password.Text = "123";
            username.Text = "木子lee";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            name = username.Text;
            pass = password.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbUserSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry, Ur Internet is unstable\n Please try later again !");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
