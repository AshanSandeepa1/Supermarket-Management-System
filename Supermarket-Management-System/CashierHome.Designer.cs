namespace Supermarket_Management_System
{
    partial class CashierHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashierHome));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.btnViewInventory = new System.Windows.Forms.Button();
            this.btnCustData = new System.Windows.Forms.Button();
            this.btnBillTracker = new System.Windows.Forms.Button();
            this.btnReturnProducts = new System.Windows.Forms.Button();
            this.btnAddLoyaltyData = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 59);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Supermarket_Management_System.Properties.Resources.businessman_clipart_salesman_41;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(635, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUser.Location = new System.Drawing.Point(700, 16);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(58, 29);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "John";
            this.lblUser.Click += new System.EventHandler(this.lblUser_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Pink;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(40, 387);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(121, 39);
            this.btnBack.TabIndex = 17;
            this.btnBack.Text = "Back";
            this.btnBack.UseCompatibleTextRendering = true;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.BackColor = System.Drawing.Color.YellowGreen;
            this.btnCreateOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateOrder.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateOrder.Location = new System.Drawing.Point(90, 126);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(189, 81);
            this.btnCreateOrder.TabIndex = 19;
            this.btnCreateOrder.Text = "Create Order";
            this.btnCreateOrder.UseCompatibleTextRendering = true;
            this.btnCreateOrder.UseVisualStyleBackColor = false;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnViewInventory
            // 
            this.btnViewInventory.BackColor = System.Drawing.Color.Orange;
            this.btnViewInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewInventory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnViewInventory.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewInventory.Location = new System.Drawing.Point(318, 126);
            this.btnViewInventory.Name = "btnViewInventory";
            this.btnViewInventory.Size = new System.Drawing.Size(189, 81);
            this.btnViewInventory.TabIndex = 20;
            this.btnViewInventory.Text = "View Inventory";
            this.btnViewInventory.UseCompatibleTextRendering = true;
            this.btnViewInventory.UseVisualStyleBackColor = false;
            this.btnViewInventory.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCustData
            // 
            this.btnCustData.BackColor = System.Drawing.Color.Orange;
            this.btnCustData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCustData.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustData.Location = new System.Drawing.Point(540, 126);
            this.btnCustData.Name = "btnCustData";
            this.btnCustData.Size = new System.Drawing.Size(189, 81);
            this.btnCustData.TabIndex = 21;
            this.btnCustData.Text = "View Customer Data";
            this.btnCustData.UseCompatibleTextRendering = true;
            this.btnCustData.UseVisualStyleBackColor = false;
            this.btnCustData.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnBillTracker
            // 
            this.btnBillTracker.BackColor = System.Drawing.Color.Pink;
            this.btnBillTracker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBillTracker.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBillTracker.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBillTracker.Location = new System.Drawing.Point(540, 235);
            this.btnBillTracker.Name = "btnBillTracker";
            this.btnBillTracker.Size = new System.Drawing.Size(189, 81);
            this.btnBillTracker.TabIndex = 24;
            this.btnBillTracker.Text = "Bill Tracker";
            this.btnBillTracker.UseCompatibleTextRendering = true;
            this.btnBillTracker.UseVisualStyleBackColor = false;
            this.btnBillTracker.Click += new System.EventHandler(this.btnBillTracker_Click);
            // 
            // btnReturnProducts
            // 
            this.btnReturnProducts.BackColor = System.Drawing.Color.Tomato;
            this.btnReturnProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReturnProducts.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnProducts.Location = new System.Drawing.Point(318, 235);
            this.btnReturnProducts.Name = "btnReturnProducts";
            this.btnReturnProducts.Size = new System.Drawing.Size(189, 81);
            this.btnReturnProducts.TabIndex = 23;
            this.btnReturnProducts.Text = "Return of Products";
            this.btnReturnProducts.UseCompatibleTextRendering = true;
            this.btnReturnProducts.UseVisualStyleBackColor = false;
            this.btnReturnProducts.Click += new System.EventHandler(this.btnReturnProducts_Click);
            // 
            // btnAddLoyaltyData
            // 
            this.btnAddLoyaltyData.BackColor = System.Drawing.Color.MediumPurple;
            this.btnAddLoyaltyData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddLoyaltyData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddLoyaltyData.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLoyaltyData.Location = new System.Drawing.Point(90, 235);
            this.btnAddLoyaltyData.Name = "btnAddLoyaltyData";
            this.btnAddLoyaltyData.Size = new System.Drawing.Size(189, 81);
            this.btnAddLoyaltyData.TabIndex = 22;
            this.btnAddLoyaltyData.Text = "Add Loyalty Data";
            this.btnAddLoyaltyData.UseCompatibleTextRendering = true;
            this.btnAddLoyaltyData.UseVisualStyleBackColor = false;
            this.btnAddLoyaltyData.Click += new System.EventHandler(this.btnAddLoyaltyData_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Red;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogout.ForeColor = System.Drawing.Color.Transparent;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.Location = new System.Drawing.Point(727, 387);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(40, 40);
            this.btnLogout.TabIndex = 18;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // CashierHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBillTracker);
            this.Controls.Add(this.btnReturnProducts);
            this.Controls.Add(this.btnAddLoyaltyData);
            this.Controls.Add(this.btnCustData);
            this.Controls.Add(this.btnViewInventory);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CashierHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CashierHome";
            this.Load += new System.EventHandler(this.CashierHome_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button btnViewInventory;
        private System.Windows.Forms.Button btnCustData;
        private System.Windows.Forms.Button btnBillTracker;
        private System.Windows.Forms.Button btnReturnProducts;
        private System.Windows.Forms.Button btnAddLoyaltyData;
    }
}