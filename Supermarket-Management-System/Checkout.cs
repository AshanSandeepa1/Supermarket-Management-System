using MySql.Data.MySqlClient;
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
        private int points = 0;
        private decimal discount = 0;
        private decimal total = 0;
        private decimal price;
        private const string connectionString = "server=127.0.0.1; user=root; database=supermarket_mgmt_system; password=";

        public Checkout(decimal subtotal, Form previousFrom)
        {
            InitializeComponent();
            this.previousForm = previousFrom;
            lblSubTotal.Text = subtotal.ToString("0.00");
            lblDisplay.Text = "Rs."+ subtotal.ToString("0.00");
            lblTotal.Text = subtotal.ToString("0.00");
            price = subtotal;
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

        private void btnRegCustmer_Click(object sender, EventArgs e)
        {
            LoyaltyCustomerReg customerRegister = new LoyaltyCustomerReg();
            customerRegister.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string loyaltyNumber = txtLoyaltyNum.Text;

            string query = "SELECT name, points FROM customer_table WHERE loyalty_number = @LoyaltyNumber";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LoyaltyNumber", loyaltyNumber);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // If a matching record is found
                            string name = reader["name"].ToString();
                            points = Convert.ToInt32(reader["points"]);

                            lblUser.Text = "Name: " + name;
                            lblPoints.Text = "Points: " + points.ToString();
                        }
                        else
                        {
                            lblUser.Text = "No user found";
                            lblPoints.Text = "";
                            points = 0;
                        }
                    }
                }
            }
        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void rdbtnYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnYes.Checked) {
                if (points > 0)
                {
                    discount = points * 0.20m;
                    lblDiscount.Text = discount.ToString();

                    total = price - discount;
                    lblTotal.Text = total.ToString();
                    lblDisplay.Text = "Rs." + total.ToString();
                }
                else
                {
                    MessageBox.Show("No Loyalty points available to Redeem");
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if rdbtnCard.Checked -- open card payment
            //else PDF preview
        }
    }
}
