namespace Thông_tin_sổ_xố_các_miền
{
    partial class frmChinh
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Miền Bắc");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Miền Nam");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Miền Trung");
            this.tvMien = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpNgayDo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTinh = new System.Windows.Forms.TextBox();
            this.dgvHienThi = new System.Windows.Forms.DataGridView();
            this.clTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNgayMoThuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGiaiDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGiai1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGiai2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGiai3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGiai4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGiai5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGiai6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGiai7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGiai8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienThi)).BeginInit();
            this.SuspendLayout();
            // 
            // tvMien
            // 
            this.tvMien.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvMien.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvMien.Location = new System.Drawing.Point(0, 0);
            this.tvMien.Name = "tvMien";
            treeNode1.Name = "nMienBac";
            treeNode1.Text = "Miền Bắc";
            treeNode2.Name = "nMienNam";
            treeNode2.Text = "Miền Nam";
            treeNode3.Name = "nMienTrung";
            treeNode3.Text = "Miền Trung";
            this.tvMien.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.tvMien.Size = new System.Drawing.Size(361, 675);
            this.tvMien.TabIndex = 0;
            this.tvMien.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMien_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ngày muốn dò:";
            // 
            // dtpNgayDo
            // 
            this.dtpNgayDo.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayDo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayDo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayDo.Location = new System.Drawing.Point(156, 90);
            this.dtpNgayDo.Name = "dtpNgayDo";
            this.dtpNgayDo.Size = new System.Drawing.Size(200, 29);
            this.dtpNgayDo.TabIndex = 2;
            this.dtpNgayDo.ValueChanged += new System.EventHandler(this.dtpNgayDo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tỉnh muốn dò:";
            // 
            // txtTinh
            // 
            this.txtTinh.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTinh.Location = new System.Drawing.Point(156, 142);
            this.txtTinh.Name = "txtTinh";
            this.txtTinh.Size = new System.Drawing.Size(200, 29);
            this.txtTinh.TabIndex = 3;
            this.txtTinh.TextChanged += new System.EventHandler(this.txtTinh_TextChanged);
            // 
            // dgvHienThi
            // 
            this.dgvHienThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHienThi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clTinh,
            this.clNgayMoThuong,
            this.clGiaiDB,
            this.clGiai1,
            this.clGiai2,
            this.clGiai3,
            this.clGiai4,
            this.clGiai5,
            this.clGiai6,
            this.clGiai7,
            this.clGiai8});
            this.dgvHienThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHienThi.Location = new System.Drawing.Point(361, 0);
            this.dgvHienThi.Name = "dgvHienThi";
            this.dgvHienThi.RowTemplate.Height = 33;
            this.dgvHienThi.Size = new System.Drawing.Size(1144, 675);
            this.dgvHienThi.TabIndex = 4;
            // 
            // clTinh
            // 
            this.clTinh.HeaderText = "Tỉnh";
            this.clTinh.Name = "clTinh";
            // 
            // clNgayMoThuong
            // 
            this.clNgayMoThuong.HeaderText = "Ngày mở thưởng";
            this.clNgayMoThuong.Name = "clNgayMoThuong";
            // 
            // clGiaiDB
            // 
            this.clGiaiDB.HeaderText = "Giải đặt biệt";
            this.clGiaiDB.Name = "clGiaiDB";
            // 
            // clGiai1
            // 
            this.clGiai1.HeaderText = "Giải nhất";
            this.clGiai1.Name = "clGiai1";
            // 
            // clGiai2
            // 
            this.clGiai2.HeaderText = "Giải 2";
            this.clGiai2.Name = "clGiai2";
            // 
            // clGiai3
            // 
            this.clGiai3.HeaderText = "Giải 3";
            this.clGiai3.Name = "clGiai3";
            // 
            // clGiai4
            // 
            this.clGiai4.HeaderText = "Giải 4";
            this.clGiai4.Name = "clGiai4";
            // 
            // clGiai5
            // 
            this.clGiai5.HeaderText = "Giải 5";
            this.clGiai5.Name = "clGiai5";
            // 
            // clGiai6
            // 
            this.clGiai6.HeaderText = "Giải 6";
            this.clGiai6.Name = "clGiai6";
            // 
            // clGiai7
            // 
            this.clGiai7.HeaderText = "Giải 7";
            this.clGiai7.Name = "clGiai7";
            // 
            // clGiai8
            // 
            this.clGiai8.HeaderText = "Giải 8";
            this.clGiai8.Name = "clGiai8";
            // 
            // frmChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1505, 675);
            this.Controls.Add(this.dgvHienThi);
            this.Controls.Add(this.txtTinh);
            this.Controls.Add(this.dtpNgayDo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvMien);
            this.Name = "frmChinh";
            this.Text = "Thông tin sổ xố các miền";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienThi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvMien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNgayDo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTinh;
        private System.Windows.Forms.DataGridView dgvHienThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNgayMoThuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGiaiDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGiai1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGiai2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGiai3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGiai4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGiai5;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGiai6;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGiai7;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGiai8;
    }
}

