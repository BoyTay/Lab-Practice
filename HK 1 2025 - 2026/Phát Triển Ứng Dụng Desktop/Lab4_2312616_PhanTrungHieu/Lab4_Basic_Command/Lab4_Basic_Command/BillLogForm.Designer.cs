namespace Lab4_Basic_Command
{
    partial class BillLogForm
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
            this.dgvBillLog = new System.Windows.Forms.DataGridView();
            this.lblSoLuongHoaDon = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillLog)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBillLog
            // 
            this.dgvBillLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvBillLog.Location = new System.Drawing.Point(0, 0);
            this.dgvBillLog.Name = "dgvBillLog";
            this.dgvBillLog.RowTemplate.Height = 33;
            this.dgvBillLog.Size = new System.Drawing.Size(644, 279);
            this.dgvBillLog.TabIndex = 0;
            // 
            // lblSoLuongHoaDon
            // 
            this.lblSoLuongHoaDon.AutoSize = true;
            this.lblSoLuongHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuongHoaDon.Location = new System.Drawing.Point(674, 28);
            this.lblSoLuongHoaDon.Name = "lblSoLuongHoaDon";
            this.lblSoLuongHoaDon.Size = new System.Drawing.Size(13, 20);
            this.lblSoLuongHoaDon.TabIndex = 1;
            this.lblSoLuongHoaDon.Text = ".";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaHoaDon";
            this.Column1.HeaderText = "Mã hóa đơn";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TongTien";
            this.Column2.HeaderText = "Tổng tiền";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Thue";
            this.Column3.HeaderText = "Tổng thuế";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "GiamGia";
            this.Column4.HeaderText = "Tổng giảm giá";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "NgayLap";
            this.Column5.HeaderText = "Ngày lập";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "NhanVienLap";
            this.Column6.HeaderText = "Nhân viên lập";
            this.Column6.Name = "Column6";
            // 
            // BillLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(855, 280);
            this.Controls.Add(this.lblSoLuongHoaDon);
            this.Controls.Add(this.dgvBillLog);
            this.Name = "BillLogForm";
            this.Text = "BillLogForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBillLog;
        private System.Windows.Forms.Label lblSoLuongHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}