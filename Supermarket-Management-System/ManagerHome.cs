using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket_Management_System
{
    public partial class ManagerHome : Form
    {
        private string username;
        private Form previousForm;
        public ManagerHome(string username, Form previousForm)
        {
            InitializeComponent();
            this.username = username;
            this.previousForm = previousForm;
            lblUser.Text = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Hide the current form (ManagerHomeScreen)
            this.Hide();

            // Show the previous form
            if (previousForm != null)
            {
                previousForm.Show();
            }
            else
            {
                // If previous form is null, just close this form
                this.Close();
            }
        }
    }
}
