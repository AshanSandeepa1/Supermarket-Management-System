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
            TransactionDetails TransactionDetailsScreen = new TransactionDetails(this);
            TransactionDetailsScreen.Show();
            this.Hide();
        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
                Session.EndSession();
            }
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Hide the current form (ManagerHomeScreen)
            this.Hide();
            Session.EndSession();

            // Show the previous form
            if (previousForm != null && !previousForm.IsDisposed)
            {
                previousForm.Show();
            }
            else
            {
                // If previous form is null, just close this form
                Application.Exit();
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            Cart CreateOrderScreen = new Cart(this);
            CreateOrderScreen.Show();
            this.Hide();
        }

        private void btnBillTracker_Click(object sender, EventArgs e)
        {
            BillTracker BillTrackerScreen = new BillTracker(this);
            BillTrackerScreen.Show();
            this.Hide();
        }

        private void btnViewInventory_Click(object sender, EventArgs e)
        {
            ViewInventory ViewInventoryScreen = new ViewInventory(this);
            ViewInventoryScreen.Show();
            this.Hide();
        }

        private void btnCustData_Click(object sender, EventArgs e)
        {
            ViewCustomerData ViewCustomerDataScreen = new ViewCustomerData(this);
            ViewCustomerDataScreen.Show();
            this.Hide();
        }

        private void btnAddLoyaltyData_Click(object sender, EventArgs e)
        {
            UpdateCustomerData UpdateCustomerDataScreen = new UpdateCustomerData(this);
            UpdateCustomerDataScreen.Show();
            this.Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports ReportsScreen = new Reports(this);
            ReportsScreen.Show();
            this.Hide();
        }

        private void btnReturnProducts_Click(object sender, EventArgs e)
        {
            ReturnOfProducts ReturnOfProductsScreen = new ReturnOfProducts(this);
            ReturnOfProductsScreen.Show();
            this.Hide();
        }
    }
}
