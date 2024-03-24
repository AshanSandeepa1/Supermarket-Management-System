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
    public partial class EditCartItems : Form
    {
        public EditCartItems(string barcode, string itemName, int quantity, decimal price)
        {
            InitializeComponent();

            // Populate text boxes with data from the selected row
            txtBarcode.Text = barcode;
            txtItem.Text = itemName;
            txtQuantity.Text = quantity.ToString();
            txtPrice.Text = price.ToString();
        }
        // Define an event to notify the parent form when editing is done
        public event EventHandler<ItemEditedEventArgs> ItemEdited;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void EditCartItems_Load(object sender, EventArgs e)
        {

        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            // Get the edited data from the text boxes
            string barcode = txtBarcode.Text;
            string itemName = txtItem.Text;
            int quantity = Convert.ToInt32(txtQuantity.Text);
            decimal price = Convert.ToDecimal(txtPrice.Text);

            // Trigger the ItemEdited event and pass the edited data
            ItemEdited?.Invoke(this, new ItemEditedEventArgs(barcode, itemName, quantity, price));

            // Close the form
            this.Close();
        }
    }
}
