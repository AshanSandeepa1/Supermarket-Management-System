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
    public partial class BillTracker : Form
    {
        private Form previousForm; // Reference to the previous form
        public BillTracker(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm; // Assign the previous form
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            long billNumber;
            if (long.TryParse(txtBillNum.Text, out billNumber))
            {
                BillPreview billPreviewForm = new BillPreview(billNumber);
                billPreviewForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid bill number. Please enter a valid number.");
            }
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

        private void BillTracker_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
