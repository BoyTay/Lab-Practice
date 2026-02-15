namespace Lab4_Basic_Command
{
    partial class BillListForm
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
            this.lbBillDates = new System.Windows.Forms.ListBox();
            this.dgvBillDetails = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // lbBillDates
            // 
            this.lbBillDates.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbBillDates.FormattingEnabled = true;
            this.lbBillDates.ItemHeight = 25;
            this.lbBillDates.Location = new System.Drawing.Point(0, 0);
            this.lbBillDates.Name = "lbBillDates";
            this.lbBillDates.Size = new System.Drawing.Size(263, 450);
            this.lbBillDates.TabIndex = 0;
            this.lbBillDates.SelectedIndexChanged += new System.EventHandler(this.lbBillDates_SelectedIndexChanged);
            // 
            // dgvBillDetails
            // 
            this.dgvBillDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvBillDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBillDetails.Location = new System.Drawing.Point(263, 0);
            this.dgvBillDetails.Name = "dgvBillDetails";
            this.dgvBillDetails.RowTemplate.Height = 33;
            this.dgvBillDetails.Size = new System.Drawing.Size(345, 450);
            this.dgvBillDetails.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "Tên món";
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Quantity";
            this.Column2.HeaderText = "Số lượng";
            this.Column2.Name = "Column2";
            // 
            // BillListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(608, 450);
            this.Controls.Add(this.dgvBillDetails);
            this.Controls.Add(this.lbBillDates);
            this.Name = "BillListForm";
            this.Text = "BillListForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbBillDates;
        private System.Windows.Forms.DataGridView dgvBillDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}