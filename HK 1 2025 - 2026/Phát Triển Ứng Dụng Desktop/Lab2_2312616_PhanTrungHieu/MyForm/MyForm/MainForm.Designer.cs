namespace MyForm
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMaHV = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbNam = new System.Windows.Forms.CheckBox();
            this.cbNu = new System.Windows.Forms.CheckBox();
            this.tbHoTen = new System.Windows.Forms.TextBox();
            this.dtpNgayDK = new System.Windows.Forms.DateTimePicker();
            this.cbTinHocA = new System.Windows.Forms.CheckBox();
            this.cbTinHocB = new System.Windows.Forms.CheckBox();
            this.cbTiengAnhA = new System.Windows.Forms.CheckBox();
            this.cbTiengAnhB = new System.Windows.Forms.CheckBox();
            this.lblTienTHA = new System.Windows.Forms.Label();
            this.lblTienTHB = new System.Windows.Forms.Label();
            this.lblTienTAA = new System.Windows.Forms.Label();
            this.lblTienTAB = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbTongTien = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnTinhTien = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(24, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1169, 91);
            this.label1.TabIndex = 4;
            this.label1.Text = "TÍNH TIỀN HỌC TRUNG TÂM ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 29);
            this.label2.TabIndex = 20;
            this.label2.Text = "Mã Học Viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 225);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "Họ Tên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 319);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 29);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ngày Đăng Ký";
            // 
            // cboMaHV
            // 
            this.cboMaHV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cboMaHV.FormattingEnabled = true;
            this.cboMaHV.Location = new System.Drawing.Point(244, 140);
            this.cboMaHV.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cboMaHV.Name = "cboMaHV";
            this.cboMaHV.Size = new System.Drawing.Size(238, 39);
            this.cboMaHV.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(520, 140);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 29);
            this.label5.TabIndex = 1;
            this.label5.Text = "Giới Tính";
            // 
            // cbNam
            // 
            this.cbNam.AutoSize = true;
            this.cbNam.Location = new System.Drawing.Point(662, 142);
            this.cbNam.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbNam.Name = "cbNam";
            this.cbNam.Size = new System.Drawing.Size(88, 29);
            this.cbNam.TabIndex = 1;
            this.cbNam.Text = "Nam";
            this.cbNam.UseVisualStyleBackColor = true;
            // 
            // cbNu
            // 
            this.cbNu.AutoSize = true;
            this.cbNu.Location = new System.Drawing.Point(770, 142);
            this.cbNu.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbNu.Name = "cbNu";
            this.cbNu.Size = new System.Drawing.Size(71, 29);
            this.cbNu.TabIndex = 2;
            this.cbNu.Text = "Nữ";
            this.cbNu.UseVisualStyleBackColor = true;
            // 
            // tbHoTen
            // 
            this.tbHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbHoTen.Location = new System.Drawing.Point(244, 225);
            this.tbHoTen.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbHoTen.Name = "tbHoTen";
            this.tbHoTen.Size = new System.Drawing.Size(722, 44);
            this.tbHoTen.TabIndex = 3;
            // 
            // dtpNgayDK
            // 
            this.dtpNgayDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpNgayDK.Location = new System.Drawing.Point(244, 304);
            this.dtpNgayDK.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dtpNgayDK.Name = "dtpNgayDK";
            this.dtpNgayDK.Size = new System.Drawing.Size(602, 44);
            this.dtpNgayDK.TabIndex = 4;
            // 
            // cbTinHocA
            // 
            this.cbTinHocA.AutoSize = true;
            this.cbTinHocA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.cbTinHocA.Location = new System.Drawing.Point(140, 413);
            this.cbTinHocA.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbTinHocA.Name = "cbTinHocA";
            this.cbTinHocA.Size = new System.Drawing.Size(174, 35);
            this.cbTinHocA.TabIndex = 5;
            this.cbTinHocA.Text = "Tin Học A";
            this.cbTinHocA.UseVisualStyleBackColor = true;
            // 
            // cbTinHocB
            // 
            this.cbTinHocB.AutoSize = true;
            this.cbTinHocB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.cbTinHocB.Location = new System.Drawing.Point(140, 465);
            this.cbTinHocB.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbTinHocB.Name = "cbTinHocB";
            this.cbTinHocB.Size = new System.Drawing.Size(174, 35);
            this.cbTinHocB.TabIndex = 6;
            this.cbTinHocB.Text = "Tin Học B";
            this.cbTinHocB.UseVisualStyleBackColor = true;
            // 
            // cbTiengAnhA
            // 
            this.cbTiengAnhA.AutoSize = true;
            this.cbTiengAnhA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.cbTiengAnhA.Location = new System.Drawing.Point(140, 517);
            this.cbTiengAnhA.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbTiengAnhA.Name = "cbTiengAnhA";
            this.cbTiengAnhA.Size = new System.Drawing.Size(205, 35);
            this.cbTiengAnhA.TabIndex = 7;
            this.cbTiengAnhA.Text = "Tiếng Anh A";
            this.cbTiengAnhA.UseVisualStyleBackColor = true;
            // 
            // cbTiengAnhB
            // 
            this.cbTiengAnhB.AutoSize = true;
            this.cbTiengAnhB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.cbTiengAnhB.Location = new System.Drawing.Point(140, 569);
            this.cbTiengAnhB.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbTiengAnhB.Name = "cbTiengAnhB";
            this.cbTiengAnhB.Size = new System.Drawing.Size(205, 35);
            this.cbTiengAnhB.TabIndex = 8;
            this.cbTiengAnhB.Text = "Tiếng Anh B";
            this.cbTiengAnhB.UseVisualStyleBackColor = true;
            // 
            // lblTienTHA
            // 
            this.lblTienTHA.AutoSize = true;
            this.lblTienTHA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblTienTHA.Location = new System.Drawing.Point(758, 419);
            this.lblTienTHA.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTienTHA.Name = "lblTienTHA";
            this.lblTienTHA.Size = new System.Drawing.Size(201, 36);
            this.lblTienTHA.TabIndex = 7;
            this.lblTienTHA.Text = "300.000 đồng";
            // 
            // lblTienTHB
            // 
            this.lblTienTHB.AutoSize = true;
            this.lblTienTHB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblTienTHB.Location = new System.Drawing.Point(758, 471);
            this.lblTienTHB.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTienTHB.Name = "lblTienTHB";
            this.lblTienTHB.Size = new System.Drawing.Size(201, 36);
            this.lblTienTHB.TabIndex = 7;
            this.lblTienTHB.Text = "500.000 đồng";
            // 
            // lblTienTAA
            // 
            this.lblTienTAA.AutoSize = true;
            this.lblTienTAA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblTienTAA.Location = new System.Drawing.Point(758, 523);
            this.lblTienTAA.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTienTAA.Name = "lblTienTAA";
            this.lblTienTAA.Size = new System.Drawing.Size(201, 36);
            this.lblTienTAA.TabIndex = 7;
            this.lblTienTAA.Text = "400.000 đồng";
            // 
            // lblTienTAB
            // 
            this.lblTienTAB.AutoSize = true;
            this.lblTienTAB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblTienTAB.Location = new System.Drawing.Point(758, 575);
            this.lblTienTAB.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTienTAB.Name = "lblTienTAB";
            this.lblTienTAB.Size = new System.Drawing.Size(201, 36);
            this.lblTienTAB.TabIndex = 7;
            this.lblTienTAB.Text = "600.000 đồng";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(238, 652);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(148, 29);
            this.label10.TabIndex = 13;
            this.label10.Text = "Tổng Tiền: ";
            // 
            // tbTongTien
            // 
            this.tbTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbTongTien.Location = new System.Drawing.Point(480, 646);
            this.tbTongTien.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbTongTien.Name = "tbTongTien";
            this.tbTongTien.Size = new System.Drawing.Size(396, 38);
            this.tbTongTien.TabIndex = 9;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExit.BackgroundImage = global::MyForm.Properties.Resources.grey_gradient_background_1439642315lMp;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.Blue;
            this.btnExit.Location = new System.Drawing.Point(822, 731);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(194, 92);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.BackgroundImage = global::MyForm.Properties.Resources.Picture1;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(436, 721);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(346, 102);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTinhTien.BackgroundImage = global::MyForm.Properties.Resources.grey_gradient_background_1439642315lMp;
            this.btnTinhTien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTinhTien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTinhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.btnTinhTien.ForeColor = System.Drawing.Color.Blue;
            this.btnTinhTien.Location = new System.Drawing.Point(130, 731);
            this.btnTinhTien.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.Size = new System.Drawing.Size(266, 92);
            this.btnTinhTien.TabIndex = 10;
            this.btnTinhTien.Text = "TÍNH TIỀN";
            this.btnTinhTien.UseVisualStyleBackColor = false;
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 865);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnTinhTien);
            this.Controls.Add(this.tbTongTien);
            this.Controls.Add(this.lblTienTAB);
            this.Controls.Add(this.lblTienTAA);
            this.Controls.Add(this.lblTienTHB);
            this.Controls.Add(this.lblTienTHA);
            this.Controls.Add(this.cbTiengAnhB);
            this.Controls.Add(this.cbTiengAnhA);
            this.Controls.Add(this.cbTinHocB);
            this.Controls.Add(this.cbTinHocA);
            this.Controls.Add(this.dtpNgayDK);
            this.Controls.Add(this.tbHoTen);
            this.Controls.Add(this.cbNu);
            this.Controls.Add(this.cbNam);
            this.Controls.Add(this.cboMaHV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMaHV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbNam;
        private System.Windows.Forms.CheckBox cbNu;
        private System.Windows.Forms.TextBox tbHoTen;
        private System.Windows.Forms.DateTimePicker dtpNgayDK;
        private System.Windows.Forms.CheckBox cbTinHocA;
        private System.Windows.Forms.CheckBox cbTinHocB;
        private System.Windows.Forms.CheckBox cbTiengAnhA;
        private System.Windows.Forms.CheckBox cbTiengAnhB;
        private System.Windows.Forms.Label lblTienTHA;
        private System.Windows.Forms.Label lblTienTHB;
        private System.Windows.Forms.Label lblTienTAA;
        private System.Windows.Forms.Label lblTienTAB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbTongTien;
        private System.Windows.Forms.Button btnTinhTien;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExit;
    }
}

