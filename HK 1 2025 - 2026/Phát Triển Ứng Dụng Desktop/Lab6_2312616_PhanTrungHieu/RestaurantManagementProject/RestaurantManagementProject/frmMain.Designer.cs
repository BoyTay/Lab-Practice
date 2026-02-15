namespace RestaurantManagementProject
{
    partial class frmMain
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
            this.btnFood = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnBills = new System.Windows.Forms.Button();
            this.btnBillDetails = new System.Windows.Forms.Button();
            this.btnRoleAccount = new System.Windows.Forms.Button();
            this.btnRole = new System.Windows.Forms.Button();
            this.btnAccount = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFood
            // 
            this.btnFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFood.Location = new System.Drawing.Point(50, 70);
            this.btnFood.Name = "btnFood";
            this.btnFood.Size = new System.Drawing.Size(85, 36);
            this.btnFood.TabIndex = 0;
            this.btnFood.Text = "Food";
            this.btnFood.UseVisualStyleBackColor = true;
            this.btnFood.Click += new System.EventHandler(this.btnFood_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategory.Location = new System.Drawing.Point(50, 122);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(85, 36);
            this.btnCategory.TabIndex = 0;
            this.btnCategory.Text = "Category";
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnBills
            // 
            this.btnBills.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBills.Location = new System.Drawing.Point(50, 178);
            this.btnBills.Name = "btnBills";
            this.btnBills.Size = new System.Drawing.Size(85, 36);
            this.btnBills.TabIndex = 0;
            this.btnBills.Text = "Bills";
            this.btnBills.UseVisualStyleBackColor = true;
            this.btnBills.Click += new System.EventHandler(this.btnBills_Click);
            // 
            // btnBillDetails
            // 
            this.btnBillDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBillDetails.Location = new System.Drawing.Point(50, 232);
            this.btnBillDetails.Name = "btnBillDetails";
            this.btnBillDetails.Size = new System.Drawing.Size(85, 36);
            this.btnBillDetails.TabIndex = 0;
            this.btnBillDetails.Text = "Bill Detail";
            this.btnBillDetails.UseVisualStyleBackColor = true;
            this.btnBillDetails.Click += new System.EventHandler(this.btnBillDetails_Click);
            // 
            // btnRoleAccount
            // 
            this.btnRoleAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoleAccount.Location = new System.Drawing.Point(193, 70);
            this.btnRoleAccount.Name = "btnRoleAccount";
            this.btnRoleAccount.Size = new System.Drawing.Size(114, 36);
            this.btnRoleAccount.TabIndex = 0;
            this.btnRoleAccount.Text = "Role Account";
            this.btnRoleAccount.UseVisualStyleBackColor = true;
            this.btnRoleAccount.Click += new System.EventHandler(this.btnRoleAccount_Click);
            // 
            // btnRole
            // 
            this.btnRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRole.Location = new System.Drawing.Point(193, 122);
            this.btnRole.Name = "btnRole";
            this.btnRole.Size = new System.Drawing.Size(114, 36);
            this.btnRole.TabIndex = 0;
            this.btnRole.Text = "Role";
            this.btnRole.UseVisualStyleBackColor = true;
            this.btnRole.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccount.Location = new System.Drawing.Point(193, 178);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(114, 36);
            this.btnAccount.TabIndex = 0;
            this.btnAccount.Text = "Account";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(193, 232);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(114, 36);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.Location = new System.Drawing.Point(46, 27);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(71, 20);
            this.lblCurrentUser.TabIndex = 1;
            this.lblCurrentUser.Text = "Xin chào";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 302);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.btnBillDetails);
            this.Controls.Add(this.btnBills);
            this.Controls.Add(this.btnCategory);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnAccount);
            this.Controls.Add(this.btnRole);
            this.Controls.Add(this.btnRoleAccount);
            this.Controls.Add(this.btnFood);
            this.Name = "frmMain";
            this.Text = "Chức năng";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFood;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnBills;
        private System.Windows.Forms.Button btnBillDetails;
        private System.Windows.Forms.Button btnRoleAccount;
        private System.Windows.Forms.Button btnRole;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblCurrentUser;
    }
}