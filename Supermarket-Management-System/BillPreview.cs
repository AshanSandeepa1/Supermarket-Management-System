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
using System.Drawing.Printing;
using System.Drawing.Imaging;


namespace Supermarket_Management_System
{
    public partial class BillPreview : Form
    {
        private long billNumber;
        private MySqlConnection mysqlConnection;
        public BillPreview(long billNumber)
        {
            InitializeComponent();
            this.billNumber = billNumber;
            mysqlConnection = new MySqlConnection("server=127.0.0.1; user=root; database=supermarket_mgmt_system; password=");
            PopulateBillDetails(billNumber);
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            dataGridView1.ClearSelection();
        }

        private void PopulateBillDetails(long billNumber)
        {
            try
            {
                mysqlConnection.Open();

                string query = "SELECT * FROM transactions WHERE billNumber = @BillNumber";
                MySqlCommand command = new MySqlCommand(query, mysqlConnection);
                command.Parameters.AddWithValue("@BillNumber", billNumber);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblBillNum.Text = reader["billNumber"].ToString();
                        lblDate.Text = reader["transactionDate"].ToString();
                        lblNetTotal.Text = reader["netTotal"].ToString();
                        lblDiscounts.Text = reader["discount"].ToString();
                        lblPaymentMethod.Text = reader["paymentMethod"].ToString();
                    }
                }

                string itemQuery = "SELECT itemName, quantity, unitPrice, totalItemPrice FROM transaction_items WHERE billNumber = @BillNumber";
                MySqlCommand itemCommand = new MySqlCommand(itemQuery, mysqlConnection);
                itemCommand.Parameters.AddWithValue("@BillNumber", billNumber);

                dataGridView1.Rows.Clear();

                using (MySqlDataReader reader = itemCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(
                            reader["itemName"].ToString(),
                            reader["quantity"].ToString(),
                            reader["unitPrice"].ToString(),
                            reader["totalItemPrice"].ToString()
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private Bitmap memoryimg; // Bitmap to store print image
        private PrintDocument printDocument1;

        private void Print()
        {
            try
            {
                // Create printer settings
                PrinterSettings ps = new PrinterSettings();

                // Get print area
                GetPrintArea(panelPrint);

                // Set up print preview dialog
                printPreviewDialog1.Document = printDocument1;

                // Show print preview dialog
                printPreviewDialog1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void GetPrintArea(Control ctrl)
        {
            // Capture the control itself
            memoryimg = new Bitmap(ctrl.Width, ctrl.Height);
            ctrl.DrawToBitmap(memoryimg, new Rectangle(0, 0, ctrl.Width, ctrl.Height));

            // Loop through child controls and capture them recursively
            foreach (Control child in ctrl.Controls)
            {
                GetPrintArea(child);
            }
        }


        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                // Draw image on print page
                Rectangle pageArea = e.PageBounds;
                e.Graphics.DrawImage(memoryimg, new Rectangle((pageArea.Width - panelPrint.Width) / 2, 0, panelPrint.Width, panelPrint.Height));

                // Check if there are more pages to print
                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void label2_Click2(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            GetPrintArea(panelPrint);
            Print();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if a session is active
            if (Session.IsSessionActive())
            {
                // Redirect to the appropriate homepage based on the user's role
                if (Session.Role == "Manager")
                {
                    OpenManagerHomeScreen(Session.Username);
                }
                else if (Session.Role == "Cashier")
                {
                    OpenCashierHomeScreen(Session.Username);
                }
                else if (Session.Role == "Stock Keeper")
                {
                    OpenStockKeeperHomeScreen(Session.Username);
                }
            }
            else
            {
                //MessageBox.Show("Please log in again to continue.", "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OpenLoginScreen();
            }
        }
        private void OpenLoginScreen()
        {
            Login loginScreen = new Login();
            loginScreen.Show();
            this.Close();
        }

        private void OpenManagerHomeScreen(string username)
        {
            ManagerHome managerHomeScreen = new ManagerHome(username, this);
            managerHomeScreen.Show();
            this.Close();
        }

        private void OpenCashierHomeScreen(string username)
        {
            CashierHome cashierHomeScreen = new CashierHome(username, this);
            cashierHomeScreen.Show();
            this.Close();
        }

        private void OpenStockKeeperHomeScreen(string username)
        {
            StockKeeperHome stockkeeperHomeScreen = new StockKeeperHome(username, this);
            stockkeeperHomeScreen.Show();
            this.Close();
        }
    }
}
