using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Supermarket_Management_System
{
    public partial class Cart : Form
    {
        private Form previousForm; // Reference to the previous form
        private MySqlConnection mysqlConnection;
        public Cart(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm; // Assign the previous form

            // Initialize SqlConnection with your connection string
            mysqlConnection = new MySqlConnection("server=127.0.0.1; user=root; database=supermarket_mgmt_system; password=");

            // Subscribe to RowsAdded or removed or edited event
            dataGridView1.RowsAdded += dataGridView1_RowsAdded;
            dataGridView1.RowsRemoved += dataGridView1_RowsRemoved;
        }

        // Method to fetch item details from the db based on barcode
        private void FetchItemDetails(string barcode)
        {
            try
            {
                // Open the database connection
                mysqlConnection.Open();

                // SQL query to fetch item details based on barcode
                string query = "SELECT item_name, unit_price FROM stocks_table WHERE barcode = @Barcode";
                MySqlCommand command = new MySqlCommand(query, mysqlConnection);
                command.Parameters.AddWithValue("@Barcode", barcode);

                MySqlDataReader reader = command.ExecuteReader(); //execute command

                if (reader.Read())
                {
                    // Retrieve item details
                    string itemName = reader["item_name"].ToString();
                    decimal price = Convert.ToDecimal(reader["unit_price"]);

                    // Add the item to DataGridView
                    dataGridView1.Rows.Add(barcode, itemName, 1, price, "Edit", "Delete");
                    txtBarcode.Clear(); //clear text if success
                }
                else
                {
                    MessageBox.Show("Item not found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the database connection
                mysqlConnection.Close();
            }
        }

        private void EditForm_ItemEdited(object sender, ItemEditedEventArgs e)
        {
            // Update the corresponding row in the DataGridView with the edited data
            // You need to identify the row based on the barcode or any other unique identifier
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["clmBarcode"].Value.ToString() == e.Barcode)
                {
                    row.Cells["clmItemName"].Value = e.ItemName;
                    row.Cells["clmQuantity"].Value = e.Quantity;
                    row.Cells["clmPrice"].Value = e.Price;
                    break;
                }
            }
            UpdateTotal(); //update total after edited
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Cart_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in a valid row (not the header row)
            if (e.RowIndex >= 0)
            {
                // Check which column was clicked
                if (e.ColumnIndex == 4) // Edit column
                {
                    // Get the data from the selected row
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    string barcode = selectedRow.Cells["clmBarcode"].Value.ToString();
                    string itemName = selectedRow.Cells["clmItemName"].Value.ToString();
                    int quantity = Convert.ToInt32(selectedRow.Cells["clmQuantity"].Value);
                    decimal price = Convert.ToDecimal(selectedRow.Cells["clmPrice"].Value);

                    // Open the EditCartItems form
                    EditCartItems editForm = new EditCartItems(barcode, itemName, quantity, price);
                    editForm.ItemEdited += EditForm_ItemEdited; // Subscribe to the event
                    editForm.ShowDialog();
                }
                else if (e.ColumnIndex == 5) // Delete column
                {
                    // Delete the selected row from the DataGridView
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateTotal();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateTotal();
        }

        private decimal UpdateTotal()
        {
            // Calculate total value of items
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["clmPrice"].Value != null) // Ensure there's a value in the Price column
                {
                    // Calculate the value of each item (price * quantity) and add it to the total
                    total += Convert.ToDecimal(row.Cells["clmPrice"].Value) * Convert.ToInt32(row.Cells["clmQuantity"].Value);
                }
            }

            // Update lblTotal label with the calculated total value
            lblTotal.Text = total.ToString("0.00"); // Format to display only two decimal places
            return total;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = txtBarcode.Text + 1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBarcode.Clear();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = txtBarcode.Text + 2;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = txtBarcode.Text + 3;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = txtBarcode.Text + 4;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = txtBarcode.Text + 5;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = txtBarcode.Text + 6;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = txtBarcode.Text + 7;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = txtBarcode.Text + 8;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = txtBarcode.Text + 9;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = txtBarcode.Text + 0;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            // Fetch item details based on entered barcode
            string barcode = txtBarcode.Text.Trim();
            if (!string.IsNullOrEmpty(barcode))
            {
                FetchItemDetails(barcode);
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Get the total value
            decimal total = UpdateTotal();

            // Open Checkout form and pass total value
            Checkout checkoutForm = new Checkout(total, this);
            checkoutForm.Show();
        }
    }
}
