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
using MySql.Data.MySqlClient;

namespace Supermarket_Management_System
{
    public partial class ViewInventory : Form
    {
        private Form previousForm;
        private MySqlConnection mysqlConnection;
        public ViewInventory(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
            mysqlConnection = new MySqlConnection("server=127.0.0.1; user=root; database=supermarket_mgmt_system; password=");
            PopulateStocksDataGridView();
        }

        private void PopulateStocksDataGridView()
        {
            try
            {
                mysqlConnection.Open();
                string query = "SELECT barcode, item_name, unit_price, no_of_items FROM stocks_table";
                MySqlCommand command = new MySqlCommand(query, mysqlConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvStocks.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    dgvStocks.Rows.Add(row.ItemArray);
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

        private void ViewInventory_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
           // string barcode = txtBarcode.Text;
           // SearchAndFillDataGridView(barcode);
        }

        private void txtBranchID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string barcode = txtBarcode.Text.Trim();

            try
            {
                mysqlConnection.Open();
                string query = "SELECT barcode, item_name, unit_price, no_of_items FROM stocks_table WHERE barcode = @barcode";
                MySqlCommand command = new MySqlCommand(query, mysqlConnection);
                command.Parameters.AddWithValue("@barcode", barcode);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvStocks.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    dgvStocks.Rows.Add(row.ItemArray);
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
      /*  private void SearchAndFillDataGridView(string barcode)
        {
            try
            {
                mysqlConnection.Open();

                string query = "SELECT barcode, item_name, unit_price, no_of_items FROM stocks_table WHERE barcode LIKE @barcode";
                MySqlCommand command = new MySqlCommand(query, mysqlConnection);
                command.Parameters.AddWithValue("@barcode", "%" + barcode + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dgvStocks.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                mysqlConnection.Close();
            }
        } */

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
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
    }
}
