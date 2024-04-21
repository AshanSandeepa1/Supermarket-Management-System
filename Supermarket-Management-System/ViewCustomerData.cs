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
    public partial class ViewCustomerData : Form
    {
        private Form previousForm;
        private MySqlConnection mysqlConnection;
        public ViewCustomerData(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
            mysqlConnection = new MySqlConnection("server=127.0.0.1; user=root; database=supermarket_mgmt_system; password=");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ViewCustomerData_Load(object sender, EventArgs e)
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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string loyaltyNumber = txtLoyaltyNum.Text.Trim();
            string name = txtName.Text.Trim();
            string nic = txtNIC.Text.Trim();
            string contactNumber = txtContactNum.Text.Trim();

            string query = "SELECT loyalty_number, name, NIC, contact_num, points, registered_date FROM customer_table WHERE 1=1";


            if (!string.IsNullOrEmpty(loyaltyNumber))
            {
                query += " AND loyalty_number LIKE @LoyaltyNumber";
            }

            if (!string.IsNullOrEmpty(name))
            {
                query += " AND name LIKE @Name";
            }

            if (!string.IsNullOrEmpty(nic))
            {
                query += " AND NIC LIKE @NIC";
            }

            if (!string.IsNullOrEmpty(contactNumber))
            {
                query += " AND contact_num LIKE @ContactNumber";
            }

            //search results
            using (MySqlCommand command = new MySqlCommand(query, mysqlConnection))
            {

                if (!string.IsNullOrEmpty(loyaltyNumber))
                {
                    command.Parameters.AddWithValue("@LoyaltyNumber", "%" + loyaltyNumber + "%");
                }

                if (!string.IsNullOrEmpty(name))
                {
                    command.Parameters.AddWithValue("@Name", "%" + name + "%");
                }

                if (!string.IsNullOrEmpty(nic))
                {
                    command.Parameters.AddWithValue("@NIC", "%" + nic + "%");
                }

                if (!string.IsNullOrEmpty(contactNumber))
                {
                    command.Parameters.AddWithValue("@ContactNumber", "%" + contactNumber + "%");
                }

                //retrieve the search results
                try
                {
                    mysqlConnection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dgvCustomerData.Rows.Clear();
                        while (reader.Read())
                        {
                            dgvCustomerData.Rows.Add(
                                reader["loyalty_number"].ToString(),
                                reader["name"].ToString(),
                                reader["NIC"].ToString(),
                                reader["contact_num"].ToString(),
                                reader["points"].ToString(),
                                reader["registered_date"].ToString()
                            );
                        }
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

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            LoyaltyCustomerReg addCustomer = new LoyaltyCustomerReg();
            addCustomer.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateCustomerData updateCustomer = new UpdateCustomerData(this);
            updateCustomer.ShowDialog();
        }
    }
}
