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
using System.IO;


namespace Supermarket_Management_System
{
    public partial class Reports : Form
    {
        private Form previousForm;
        private MySqlConnection mysqlConnection;
        public Reports(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
            mysqlConnection = new MySqlConnection("server=127.0.0.1; user=root; database=supermarket_mgmt_system; password=");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Session.EndSession();

            if (previousForm != null && !previousForm.IsDisposed)
            {
                previousForm.Show();
            }
            else
            {
                Application.Exit();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
                Session.EndSession();
            }
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string reportType = cmbReportType.SelectedItem.ToString();

            if (reportType == "Stock Inventory")
            {
                dateTimePickerFrom.Enabled = false;
                dateTimePickerTo.Enabled = false;
            }
            else
            {
                dateTimePickerFrom.Enabled = true;
                dateTimePickerTo.Enabled = true;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string reportType = cmbReportType.SelectedItem.ToString();
            DateTime fromDate = dateTimePickerFrom.Value;
            DateTime toDate = dateTimePickerTo.Value;

            try
            {
                mysqlConnection.Open();

                // Construct the SQL query based on the selected report type and date range
                string query = "";
                switch (reportType)
                {
                    case "Transactions":
                        query = "SELECT * FROM transactions WHERE transactionDate BETWEEN @FromDate AND @ToDate";
                        break;
                    case "Stock Inventory":
                        query = "SELECT * FROM stocks_table";
                        break;
                    case "Customer Data":
                        query = "SELECT * FROM customer_table WHERE registered_date BETWEEN @FromDate AND @ToDate";
                        break;
                }

                MySqlCommand command = new MySqlCommand(query, mysqlConnection);
                command.Parameters.AddWithValue("@FromDate", fromDate);
                command.Parameters.AddWithValue("@ToDate", toDate);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvReports.DataSource = dt;
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Show save file dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Open the file to write
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                {
                    // Write headers
                    for (int i = 0; i < dgvReports.Columns.Count; i++)
                    {
                        sw.Write(dgvReports.Columns[i].HeaderText);
                        if (i < dgvReports.Columns.Count - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.WriteLine();

                    // Write data
                    foreach (DataGridViewRow row in dgvReports.Rows)
                    {
                        for (int i = 0; i < dgvReports.Columns.Count; i++)
                        {
                            sw.Write(row.Cells[i].Value);
                            if (i < dgvReports.Columns.Count - 1)
                            {
                                sw.Write(",");
                            }
                        }
                        sw.WriteLine();
                    }
                }

                MessageBox.Show("Data exported successfully!");
            }
        }
    }
}
