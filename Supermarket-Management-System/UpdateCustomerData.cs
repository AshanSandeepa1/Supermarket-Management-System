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
    public partial class UpdateCustomerData : Form
    {

        private Form previousForm;
        private MySqlConnection mysqlConnection;
        public UpdateCustomerData(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
            mysqlConnection = new MySqlConnection("server=127.0.0.1; user=root; database=supermarket_mgmt_system; password=");
        }

        private void UpdateCustomerData_Load(object sender, EventArgs e)
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
            string loyaltyNumber = txtLoyaltyNum.Text;
            string query = "SELECT * FROM customer_table WHERE loyalty_number = @LoyaltyNumber";

            using (MySqlCommand command = new MySqlCommand(query, mysqlConnection))
            {
                command.Parameters.AddWithValue("@LoyaltyNumber", loyaltyNumber);

                try
                {
                    mysqlConnection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtLoyaltyNumView.Text = reader["loyalty_number"].ToString();
                            txtName.Text = reader["name"].ToString();
                            txtNIC.Text = reader["NIC"].ToString();
                            txtContactNum.Text = reader["contact_num"].ToString();
                            txtRegDate.Text = reader["registered_date"].ToString();
                            txtloyaltypoints.Text = reader["points"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Customer not found!");
                            ClearTextBoxes();
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
        private void ClearTextBoxes()
        {
            txtLoyaltyNumView.Clear();
            txtName.Clear();
            txtNIC.Clear();
            txtContactNum.Clear();
            txtRegDate.Clear();
            txtloyaltypoints.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string nic = txtNIC.Text;
            string contactNumber = txtContactNum.Text;
            string loyaltyNumber = txtLoyaltyNum.Text;
            string loyaltyPoints = txtloyaltypoints.Text;

            string query = "UPDATE customer_table SET name = @Name, NIC = @NIC, contact_num = @ContactNumber, points = @LoyaltyPoints WHERE loyalty_number = @LoyaltyNumber";

            using (MySqlCommand command = new MySqlCommand(query, mysqlConnection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@NIC", nic);
                command.Parameters.AddWithValue("@ContactNumber", contactNumber);
                command.Parameters.AddWithValue("@LoyaltyNumber", loyaltyNumber);
                command.Parameters.AddWithValue("@LoyaltyPoints", loyaltyPoints);

                try
                {
                    mysqlConnection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer data updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("No rows updated.");
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
