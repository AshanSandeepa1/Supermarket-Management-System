using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket_Management_System
{
    public partial class UpdateInventory : Form
    {
        private Form previousForm;
        private MySqlConnection mysqlConnection;
        public UpdateInventory(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
            mysqlConnection = new MySqlConnection("server=127.0.0.1; user=root; database=supermarket_mgmt_system; password=");
        }

        private void UpdateInventory_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNewStock_Click(object sender, EventArgs e)
        {
            string barcode = txtBarcode.Text;
            string itemName = txtItemName.Text;
            decimal unitPrice = Convert.ToDecimal(txtUnitPrice.Text);
            int quantity = Convert.ToInt32(txtQuantity.Text);

            string query = "INSERT INTO stocks_table (barcode, item_name, unit_price, no_of_items) VALUES (@Barcode, @ItemName, @UnitPrice, @Quantity)";

            using (MySqlCommand command = new MySqlCommand(query, mysqlConnection))
            {
                command.Parameters.AddWithValue("@Barcode", barcode);
                command.Parameters.AddWithValue("@ItemName", itemName);
                command.Parameters.AddWithValue("@UnitPrice", unitPrice);
                command.Parameters.AddWithValue("@Quantity", quantity);

                try
                {
                    mysqlConnection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("New item added successfully.");
                        populateUpdateDGV();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add new item.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    mysqlConnection.Close();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string barcode = txtBarcode.Text;
            string itemName = txtItemName.Text;
            decimal unitPrice = Convert.ToDecimal(txtUnitPrice.Text);
            int quantity = Convert.ToInt32(txtQuantity.Text);

            string query = "UPDATE stocks_table SET item_name = @ItemName, unit_price = @UnitPrice, no_of_items = @Quantity WHERE barcode = @Barcode";

            using (MySqlCommand command = new MySqlCommand(query, mysqlConnection))
            {
                command.Parameters.AddWithValue("@ItemName", itemName);
                command.Parameters.AddWithValue("@UnitPrice", unitPrice);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@Barcode", barcode);

                try
                {
                    mysqlConnection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Item updated successfully.");
                        populateUpdateDGV();
                    }
                    else
                    {
                        MessageBox.Show("Error occured please check the Barcode is correct.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    mysqlConnection.Close();
                }
            }
        }

        private void txtBranchID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            mysqlConnection.Open();
            populateUpdateDGV();
            mysqlConnection.Close();
        }

        private void populateUpdateDGV()
        {
            string barcode = txtBarcode.Text;
            string query = "SELECT stock_ID, item_name, unit_price, no_of_items FROM stocks_table WHERE barcode = @Barcode";

            using (MySqlCommand command = new MySqlCommand(query, mysqlConnection))
            {
                command.Parameters.AddWithValue("@Barcode", barcode);

                try
                {
                    //mysqlConnection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Populate text fields
                        txtItemName.Text = reader["item_name"].ToString();
                        txtUnitPrice.Text = reader["unit_price"].ToString();
                        txtQuantity.Text = reader["no_of_items"].ToString();

                        dgvStocks.Rows.Clear();
                        dgvStocks.Rows.Add(reader["stock_ID"], barcode, reader["item_name"], reader["unit_price"], reader["no_of_items"]);
                    }
                    else
                    {
                        MessageBox.Show("No item found with the entered barcode.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    //mysqlConnection.Close();
                }
            }
        }

        private void txtStockID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (previousForm != null)
            {
                previousForm.Show();
            }
            else
            {
                this.Close();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = "";
            txtItemName.Text = "";
            txtUnitPrice.Text = "";
            txtQuantity.Text = "";
        }
    }
}
