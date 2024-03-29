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
    public partial class LoyaltyCustomerReg : Form
    {
        private const string connectionString = "server=127.0.0.1; user=root; database=supermarket_mgmt_system; password=";
        public LoyaltyCustomerReg()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            string loyaltyNum = txtLoyaltyNum.Text;
            string name = txtName.Text;
            string nic = txtNIC.Text;
            string contactNum = txtContactNum.Text;

            if (string.IsNullOrWhiteSpace(loyaltyNum) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(nic) || string.IsNullOrWhiteSpace(contactNum))
            {
                MessageBox.Show("Please fill in all fields.");
                return; // Exit the method without proceeding with the database operation
            }

            string query = "INSERT INTO customer_table (loyalty_number, name, NIC, contact_num) " +
                           "VALUES (@LoyaltyNum, @Name, @NIC, @ContactNum)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LoyaltyNum", loyaltyNum);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@NIC", nic);
                    command.Parameters.AddWithValue("@ContactNum", contactNum);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer registered Successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert data!");
                    }
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
