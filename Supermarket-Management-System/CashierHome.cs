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
    public partial class CashierHome : Form
    {
        private string username;
        private Form previousForm;
        public CashierHome(string username, Form previousForm)
        {
            InitializeComponent();
            this.username = username;
            this.previousForm = previousForm;
            lblUser.Text = username;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Create an instance of BillTracker and pass 'this' as the previousForm parameter, and hide this form
            Cart CreateOrderScreen = new Cart(this);
            CreateOrderScreen.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an instance of BillTracker and pass 'this' as the previousForm parameter, and hide this form
            ViewInventory ViewInventoryScreen = new ViewInventory(this);
            ViewInventoryScreen.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create an instance of BillTracker and pass 'this' as the previousForm parameter, and hide this form
            ViewCustomerData ViewCustomerDataScreen = new ViewCustomerData(this);
            ViewCustomerDataScreen.Show();
            this.Hide();
        }

        private void btnBillTracker_Click(object sender, EventArgs e)
        {
            BillTracker BillTrackerScreen = new BillTracker(this);
            BillTrackerScreen.Show();
            this.Hide();
        }

        private void btnReturnProducts_Click(object sender, EventArgs e)
        {
            // Create an instance of BillTracker and pass 'this' as the previousForm parameter, and hide this form
            ReturnOfProducts ReturnOfProductsScreen = new ReturnOfProducts(this);
            ReturnOfProductsScreen.Show();
            this.Hide();
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
            Application.Exit();
        }

        private void CashierHome_Load(object sender, EventArgs e)
        {

        }

        private void btnAddLoyaltyData_Click(object sender, EventArgs e)
        {
            // Create an instance of BillTracker and pass 'this' as the previousForm parameter, and hide this form
            UpdateCustomerData UpdateCustomerDataScreen = new UpdateCustomerData(this);
            UpdateCustomerDataScreen.Show();
            this.Hide();
        }
    }
}
