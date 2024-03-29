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
    public partial class Checkout : Form
    {
        private Form previousForm;

        public Checkout(decimal subtotal, Form previousFrom)
        {
            InitializeComponent();
            this.previousForm = previousFrom;
            lblSubTotal.Text = subtotal.ToString("0.00");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
