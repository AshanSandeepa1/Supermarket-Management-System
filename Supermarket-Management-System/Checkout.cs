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
            RadioButton selectedRadioButton = sender as RadioButton;
            GroupBox parentGroupBox = selectedRadioButton.Parent as GroupBox;
            foreach (Control control in parentGroupBox.Controls)
            {
                if (control is RadioButton && control != selectedRadioButton)
                {
                    (control as RadioButton).Enabled = !selectedRadioButton.Checked;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                mysqlConnection.Open();
                string loyaltyNumber = string.IsNullOrEmpty(txtLoyaltyNum.Text) ? "NA" : txtLoyaltyNum.Text;

                string transactionQuery = "INSERT INTO transactions (loyaltyNumber, transactionDate, paymentMethod, totalAmount, discount, netTotal) " +
                                          "VALUES (@LoyaltyNumber, @TransactionDate, @PaymentMethod, @TotalAmount, @Discount, @NetTotal)";
                MySqlCommand transactionCommand = new MySqlCommand(transactionQuery, mysqlConnection);
                transactionCommand.Parameters.AddWithValue("@LoyaltyNumber", loyaltyNumber);
                transactionCommand.Parameters.AddWithValue("@TransactionDate", DateTime.Now);
                transactionCommand.Parameters.AddWithValue("@TotalAmount", lblSubTotal.Text);
                transactionCommand.Parameters.AddWithValue("@Discount", lblDiscount.Text);
                transactionCommand.Parameters.AddWithValue("@NetTotal", lblTotal.Text);

                string paymentMethod = rdbtnCard.Checked ? "Card" : "Cash";
                transactionCommand.Parameters.AddWithValue("@PaymentMethod", paymentMethod);

                transactionCommand.ExecuteNonQuery();

                // Get the last inserted transaction ID
                long lastInsertedBillNumber = transactionCommand.LastInsertedId;

                // Update loyalty points
                if (!string.IsNullOrEmpty(txtLoyaltyNum.Text))
                {
                    decimal transactionAmount = Convert.ToDecimal(lblTotal.Text);
                    int loyaltyPointsToAdd = Convert.ToInt32(transactionAmount * 0.05m);

                    string loyaltyQuery = "SELECT points FROM customer_table WHERE loyalty_number = @LoyaltyNumber";
                    MySqlCommand loyaltyCommand = new MySqlCommand(loyaltyQuery, mysqlConnection);
                    loyaltyCommand.Parameters.AddWithValue("@LoyaltyNumber", txtLoyaltyNum.Text);
                    int currentPoints = Convert.ToInt32(loyaltyCommand.ExecuteScalar());

                    int newPoints = currentPoints + loyaltyPointsToAdd;

                    // Update loyalty points in the database
                    string updatePointsQuery = "UPDATE customer_table SET points = @Points WHERE loyalty_number = @LoyaltyNumber";
                    MySqlCommand updatePointsCommand = new MySqlCommand(updatePointsQuery, mysqlConnection);
                    updatePointsCommand.Parameters.AddWithValue("@Points", newPoints);
                    updatePointsCommand.Parameters.AddWithValue("@LoyaltyNumber", txtLoyaltyNum.Text);
                    updatePointsCommand.ExecuteNonQuery();
                }

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

                // Update the no_of_items in the stocks_table for each item in the cart
                foreach (var item in cartItems)
                {
                    // Retrieve the current stock quantity for the item
                    string stockQuery = "SELECT no_of_items FROM stocks_table WHERE barcode = @Barcode";
                    MySqlCommand stockCommand = new MySqlCommand(stockQuery, mysqlConnection);
                    stockCommand.Parameters.AddWithValue("@Barcode", item.Barcode);
                    int currentStock = Convert.ToInt32(stockCommand.ExecuteScalar());

                    // Subtract the quantity sold from the current stock
                    int newStock = currentStock - item.Quantity;

                    // Update the no_of_items in the stocks_table
                    string updateStockQuery = "UPDATE stocks_table SET no_of_items = @NewStock WHERE barcode = @Barcode";
                    MySqlCommand updateStockCommand = new MySqlCommand(updateStockQuery, mysqlConnection);
                    updateStockCommand.Parameters.AddWithValue("@NewStock", newStock);
                    updateStockCommand.Parameters.AddWithValue("@Barcode", item.Barcode);
                    updateStockCommand.ExecuteNonQuery(); // Execute update query
                }

                //MessageBox.Show("Transaction recorded successfully!");

                BillPreview billPreviewForm = new BillPreview(lastInsertedBillNumber);
                billPreviewForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                mysqlConnection.Close(); // Close the database connection
            }

        }

        private void txtLoyaltyNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdbtnCash_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbtnCard_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnCard.Checked)
            {
                CardPayment cardPaymentForm = new CardPayment();
                cardPaymentForm.ShowDialog();
            }
        }
    }
}
