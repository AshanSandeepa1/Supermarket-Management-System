using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket_Management_System
{
    public partial class Checkout : Form
    {
        private List<CartItem> cartItems;
        private Form previousForm;
        private int points = 0;
        private decimal discount = 0;
        private decimal total = 0;
        private decimal price;
        private MySqlConnection mysqlConnection;

        public Checkout(decimal subtotal, List<CartItem> cartItems, Form previousFrom)
        {
            InitializeComponent();
            this.previousForm = previousFrom;
            this.cartItems = cartItems;
            lblSubTotal.Text = subtotal.ToString("0.00");
            lblDisplay.Text = "Rs."+ subtotal.ToString("0.00");
            lblTotal.Text = subtotal.ToString("0.00");
            price = subtotal;
            mysqlConnection = new MySqlConnection("server=127.0.0.1; user=root; database=supermarket_mgmt_system; password=");
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

                using (MySqlCommand command = new MySqlCommand(query, mysqlConnection))
                {
                    mysqlConnection.Open();

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
                mysqlConnection.Close(); // Close the connection
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
        private void rdbtnNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnNo.Checked)
            {
                discount = 0.00m;
                lblDiscount.Text = "0.00";
                total = price;
                lblTotal.Text = total.ToString("0.00");
                lblDisplay.Text = "Rs." + total.ToString("0.00");
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Get the sender radio button
            RadioButton selectedRadioButton = sender as RadioButton;

            // Get the parent group box of the sender radio button
            GroupBox parentGroupBox = selectedRadioButton.Parent as GroupBox;

            // Iterate through each control in the group box
            foreach (Control control in parentGroupBox.Controls)
            {
                // Check if the control is a radio button and is not the sender radio button
                if (control is RadioButton && control != selectedRadioButton)
                {
                    // Disable the radio button
                    (control as RadioButton).Enabled = !selectedRadioButton.Checked;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Open the database connection
                mysqlConnection.Open();

                // Insert data into transactions table
                string transactionQuery = "INSERT INTO transactions (loyaltyNumber, transactionDate, totalAmount, discount, netTotal) " +
                                          "VALUES (@LoyaltyNumber, @TransactionDate, @TotalAmount, @Discount, @NetTotal)";
                MySqlCommand transactionCommand = new MySqlCommand(transactionQuery, mysqlConnection);
                transactionCommand.Parameters.AddWithValue("@LoyaltyNumber", txtLoyaltyNum.Text); // Assuming loyalty number is entered in a textbox
                transactionCommand.Parameters.AddWithValue("@TransactionDate", DateTime.Now); // Assuming current date/time
                transactionCommand.Parameters.AddWithValue("@TotalAmount", lblSubTotal.Text);
                transactionCommand.Parameters.AddWithValue("@Discount", lblDiscount.Text);
                transactionCommand.Parameters.AddWithValue("@NetTotal", lblTotal.Text);
                transactionCommand.ExecuteNonQuery(); // Execute transaction query

                // Get the last inserted transaction ID
                long lastInsertedBillNumber = transactionCommand.LastInsertedId;

                
                // Insert data into transaction_items table
                foreach (var item in cartItems)
                {
                    string transactionItemQuery = "INSERT INTO transaction_items (billNumber, barcode, itemName, quantity, unitPrice, totalItemPrice) " +
                                                  "VALUES (@billNumber, @Barcode, @ItemName, @Quantity, @UnitPrice, @TotalItemPrice)";
                    MySqlCommand itemCommand = new MySqlCommand(transactionItemQuery, mysqlConnection);
                    itemCommand.Parameters.AddWithValue("@billNumber", lastInsertedBillNumber);
                    itemCommand.Parameters.AddWithValue("@Barcode", item.Barcode);
                    itemCommand.Parameters.AddWithValue("@ItemName", item.ItemName);
                    itemCommand.Parameters.AddWithValue("@Quantity", item.Quantity);
                    itemCommand.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                    itemCommand.Parameters.AddWithValue("@TotalItemPrice", item.TotalPrice);
                    itemCommand.ExecuteNonQuery(); // Execute item query
                }

                MessageBox.Show("Transaction recorded successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                mysqlConnection.Close(); // Close the database connection
            }



            //if rdbtnCard.Checked -- open card payment
            //else PDF preview
        }
    }
}
