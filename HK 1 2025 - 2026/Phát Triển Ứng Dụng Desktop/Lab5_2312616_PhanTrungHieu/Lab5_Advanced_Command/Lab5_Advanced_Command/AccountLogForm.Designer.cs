namespace Lab5_Advanced_Command
{
    partial class AccountLogForm
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
            this.lbDates = new System.Windows.Forms.ListBox();
            this.dgvBills = new System.Windows.Forms.DataGridView();
            this.lblTotalBills = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            this.SuspendLayout();
            // 
            // lbDates
            // 
            this.lbDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDates.FormattingEnabled = true;
            this.lbDates.ItemHeight = 20;
            this.lbDates.Location = new System.Drawing.Point(0, 0);
            this.lbDates.Name = "lbDates";
            this.lbDates.Size = new System.Drawing.Size(144, 284);
            this.lbDates.TabIndex = 0;
            this.lbDates.SelectedIndexChanged += new System.EventHandler(this.lbDates_SelectedIndexChanged);
            // 
            // dgvBills
            // 
            this.dgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBills.Location = new System.Drawing.Point(145, 0);
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.Size = new System.Drawing.Size(683, 284);
            this.dgvBills.TabIndex = 1;
            // 
            // lblTotalBills
            // 
            this.lblTotalBills.AutoSize = true;
            this.lblTotalBills.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBills.Location = new System.Drawing.Point(150, 314);
            this.lblTotalBills.Name = "lblTotalBills";
            this.lblTotalBills.Size = new System.Drawing.Size(21, 20);
            this.lblTotalBills.TabIndex = 2;
            this.lblTotalBills.Text = "...";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(411, 314);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(21, 20);
            this.lblTotalAmount.TabIndex = 2;
            this.lblTotalAmount.Text = "...";
            // 
            // AccountLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(829, 422);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblTotalBills);
            this.Controls.Add(this.dgvBills);
            this.Controls.Add(this.lbDates);
            this.Name = "AccountLogForm";
            this.Text = "AccountLogForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbDates;
        private System.Windows.Forms.DataGridView dgvBills;
        private System.Windows.Forms.Label lblTotalBills;
        private System.Windows.Forms.Label lblTotalAmount;
    }
}