using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Supermarket_Management_System
{
    public partial class Login : Form
    {
        // Connection string to MySQL database
        private string mysqlCon = "server=127.0.0.1; user=root; database=supermarket_mgmt_system; password=";

        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            logout();
        }

        public void logout()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem.ToString();



            // Query to check user credentials
            string query = "SELECT role FROM login_users WHERE username = @username AND password = @password AND role = @role";

            // Create MySQL connection and command
            using (MySqlConnection mysqlConnection = new MySqlConnection(mysqlCon))
            {
                MySqlCommand command = new MySqlCommand(query, mysqlConnection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@role", role);

                try
                {
                    mysqlConnection.Open();
                    object result = command.ExecuteScalar();

                    // If result is not null, login successful
                    if (result != null)
                    {
                        //MessageBox.Show("Login successful!");

                        // Redirect user based on role
                        if (role == "Manager")
                        {
                            OpenManagerHomeScreen(username);
                        }
                        else if (role == "Cashier")
                        {
                            OpenCashierHomeScreen(username);
                        }
                        else if (role == "Stock Keeper")
                        {
                            OpenStockKeeperHomeScreen(username);
                        }

                        // Hide the login form
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username, password, or role!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    // Close the database connection
                    mysqlConnection.Close();
                }

            }
        }

        private void btnBillTrack_Click(object sender, EventArgs e)
        {
            OpenBillTrackerScreen();
        }

        private void OpenBillTrackerScreen()
        {
            // Create an instance of BillTracker and pass 'this' as the previousForm parameter, and hide this form
            BillTracker BillTrackerScreen = new BillTracker(this);
            BillTrackerScreen.Show();
            this.Hide();
        }
        private void OpenManagerHomeScreen(string username)
        {
            ManagerHome managerHomeScreen = new ManagerHome(username, this);
            managerHomeScreen.Show();
        }
        private void OpenCashierHomeScreen(string username)
        {
            CashierHome cashierHomeScreen = new CashierHome(username, this);
            cashierHomeScreen.Show();
        }
        private void OpenStockKeeperHomeScreen(string username)
        {
            StockKeeperHome stockkeeperHomeScreen = new StockKeeperHome(username, this);
            stockkeeperHomeScreen.Show();
        }
    }
}
