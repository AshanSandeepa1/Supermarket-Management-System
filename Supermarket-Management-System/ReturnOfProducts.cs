using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Supermarket_Management_System
{
    public partial class ReturnOfProducts : Form
    {
        private Form previousForm;
        private MySqlConnection mysqlConnection;
        public ReturnOfProducts(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
            mysqlConnection = new MySqlConnection("server=127.0.0.1; user=root; database=supermarket_mgmt_system; password=");
        }

        private void ReturnOfProducts_Load(object sender, EventArgs e)
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

        private void btnReturnProduct_Click(object sender, EventArgs e)
        {
            string barcode = txtBarcode.Text;
            int quantityToReturn;

            if (!string.IsNullOrEmpty(txtQuantity.Text))
            {
                quantityToReturn = Convert.ToInt32(txtQuantity.Text);

                DialogResult result = MessageBox.Show($"Are you sure to return {quantityToReturn} of item with barcode {barcode}?", "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    UpdateStock(barcode, quantityToReturn);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void UpdateStock(string barcode, int quantityToReturn)
        {
            string query = "UPDATE stocks_table SET no_of_items = no_of_items - @QuantityToReturn WHERE barcode = @Barcode";

            using (MySqlCommand command = new MySqlCommand(query, mysqlConnection))
            {
                command.Parameters.AddWithValue("@QuantityToReturn", quantityToReturn);
                command.Parameters.AddWithValue("@Barcode", barcode);

                try
                {
                    mysqlConnection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product returned successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to return product. Please check the barcode and try again.");
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
    }
}
