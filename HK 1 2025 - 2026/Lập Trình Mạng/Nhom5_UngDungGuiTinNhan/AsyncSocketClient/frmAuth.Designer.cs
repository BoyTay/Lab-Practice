namespace AsyncSocketClient
{
    partial class frmAuth
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
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.tabAuth = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabLogin = new System.Windows.Forms.TabPage();
            this.lblLoginStatus = new System.Windows.Forms.Label();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.txtLoginPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtLoginUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabRegister = new System.Windows.Forms.TabPage();
            this.lblRegisterStatus = new System.Windows.Forms.Label();
            this.btnRegister = new Guna.UI2.WinForms.Guna2Button();
            this.txtRegisterConfirm = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRegisterPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRegisterUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.tabAuth.SuspendLayout();
            this.tabLogin.SuspendLayout();
            this.tabRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 12;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // tabAuth
            // 
            this.tabAuth.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabAuth.Controls.Add(this.tabLogin);
            this.tabAuth.Controls.Add(this.tabRegister);
            this.tabAuth.ItemSize = new System.Drawing.Size(130, 40);
            this.tabAuth.Location = new System.Drawing.Point(20, 70);
            this.tabAuth.Name = "tabAuth";
            this.tabAuth.SelectedIndex = 0;
            this.tabAuth.Size = new System.Drawing.Size(460, 380);
            this.tabAuth.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tabAuth.TabButtonHoverState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.tabAuth.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabAuth.TabButtonHoverState.ForeColor = System.Drawing.Color.Black;
            this.tabAuth.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabAuth.TabButtonIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.tabAuth.TabButtonIdleState.FillColor = System.Drawing.Color.White;
            this.tabAuth.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabAuth.TabButtonIdleState.ForeColor = System.Drawing.Color.Gray;
            this.tabAuth.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabAuth.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tabAuth.TabButtonSelectedState.FillColor = System.Drawing.Color.White;
            this.tabAuth.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabAuth.TabButtonSelectedState.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.tabAuth.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.tabAuth.TabButtonSize = new System.Drawing.Size(130, 40);
            this.tabAuth.TabIndex = 0;
            this.tabAuth.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            // 
            // tabLogin
            // 
            this.tabLogin.Controls.Add(this.lblLoginStatus);
            this.tabLogin.Controls.Add(this.btnLogin);
            this.tabLogin.Controls.Add(this.txtLoginPassword);
            this.tabLogin.Controls.Add(this.txtLoginUsername);
            this.tabLogin.Controls.Add(this.label2);
            this.tabLogin.Controls.Add(this.label1);
            this.tabLogin.Location = new System.Drawing.Point(134, 4);
            this.tabLogin.Name = "tabLogin";
            this.tabLogin.Padding = new System.Windows.Forms.Padding(15);
            this.tabLogin.Size = new System.Drawing.Size(322, 372);
            this.tabLogin.TabIndex = 0;
            this.tabLogin.Text = "Đăng nhập";
            this.tabLogin.UseVisualStyleBackColor = true;
            // 
            // lblLoginStatus
            // 
            this.lblLoginStatus.AutoSize = true;
            this.lblLoginStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblLoginStatus.Location = new System.Drawing.Point(18, 220);
            this.lblLoginStatus.Name = "lblLoginStatus";
            this.lblLoginStatus.Size = new System.Drawing.Size(0, 25);
            this.lblLoginStatus.TabIndex = 5;
            // 
            // btnLogin
            // 
            this.btnLogin.BorderRadius = 8;
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(21, 250);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(280, 45);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.BorderRadius = 8;
            this.txtLoginPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLoginPassword.DefaultText = "";
            this.txtLoginPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLoginPassword.Location = new System.Drawing.Point(21, 160);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.PasswordChar = '•';
            this.txtLoginPassword.PlaceholderText = "Nhập mật khẩu";
            this.txtLoginPassword.SelectedText = "";
            this.txtLoginPassword.Size = new System.Drawing.Size(280, 36);
            this.txtLoginPassword.TabIndex = 1;
            // 
            // txtLoginUsername
            // 
            this.txtLoginUsername.BorderRadius = 8;
            this.txtLoginUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLoginUsername.DefaultText = "";
            this.txtLoginUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLoginUsername.Location = new System.Drawing.Point(21, 80);
            this.txtLoginUsername.Name = "txtLoginUsername";
            this.txtLoginUsername.PlaceholderText = "Nhập tên đăng nhập";
            this.txtLoginUsername.SelectedText = "";
            this.txtLoginUsername.Size = new System.Drawing.Size(280, 36);
            this.txtLoginUsername.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập";
            // 
            // tabRegister
            // 
            this.tabRegister.Controls.Add(this.lblRegisterStatus);
            this.tabRegister.Controls.Add(this.btnRegister);
            this.tabRegister.Controls.Add(this.txtRegisterConfirm);
            this.tabRegister.Controls.Add(this.label5);
            this.tabRegister.Controls.Add(this.txtRegisterPassword);
            this.tabRegister.Controls.Add(this.label4);
            this.tabRegister.Controls.Add(this.txtRegisterUsername);
            this.tabRegister.Controls.Add(this.label3);
            this.tabRegister.Location = new System.Drawing.Point(134, 4);
            this.tabRegister.Name = "tabRegister";
            this.tabRegister.Padding = new System.Windows.Forms.Padding(15);
            this.tabRegister.Size = new System.Drawing.Size(322, 372);
            this.tabRegister.TabIndex = 1;
            this.tabRegister.Text = "Đăng ký";
            this.tabRegister.UseVisualStyleBackColor = true;
            // 
            // lblRegisterStatus
            // 
            this.lblRegisterStatus.AutoSize = true;
            this.lblRegisterStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblRegisterStatus.Location = new System.Drawing.Point(18, 260);
            this.lblRegisterStatus.Name = "lblRegisterStatus";
            this.lblRegisterStatus.Size = new System.Drawing.Size(0, 25);
            this.lblRegisterStatus.TabIndex = 7;
            // 
            // btnRegister
            // 
            this.btnRegister.BorderRadius = 8;
            this.btnRegister.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRegister.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRegister.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRegister.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(21, 290);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(280, 45);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtRegisterConfirm
            // 
            this.txtRegisterConfirm.BorderRadius = 8;
            this.txtRegisterConfirm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRegisterConfirm.DefaultText = "";
            this.txtRegisterConfirm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRegisterConfirm.Location = new System.Drawing.Point(21, 210);
            this.txtRegisterConfirm.Name = "txtRegisterConfirm";
            this.txtRegisterConfirm.PasswordChar = '•';
            this.txtRegisterConfirm.PlaceholderText = "Nhập lại mật khẩu";
            this.txtRegisterConfirm.SelectedText = "";
            this.txtRegisterConfirm.Size = new System.Drawing.Size(280, 36);
            this.txtRegisterConfirm.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(237, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Xác nhận mật khẩu mới";
            // 
            // txtRegisterPassword
            // 
            this.txtRegisterPassword.BorderRadius = 8;
            this.txtRegisterPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRegisterPassword.DefaultText = "";
            this.txtRegisterPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRegisterPassword.Location = new System.Drawing.Point(21, 140);
            this.txtRegisterPassword.Name = "txtRegisterPassword";
            this.txtRegisterPassword.PasswordChar = '•';
            this.txtRegisterPassword.PlaceholderText = "Mật khẩu";
            this.txtRegisterPassword.SelectedText = "";
            this.txtRegisterPassword.Size = new System.Drawing.Size(280, 36);
            this.txtRegisterPassword.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mật khẩu";
            // 
            // txtRegisterUsername
            // 
            this.txtRegisterUsername.BorderRadius = 8;
            this.txtRegisterUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRegisterUsername.DefaultText = "";
            this.txtRegisterUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRegisterUsername.Location = new System.Drawing.Point(21, 70);
            this.txtRegisterUsername.Name = "txtRegisterUsername";
            this.txtRegisterUsername.PlaceholderText = "Tên đăng nhập";
            this.txtRegisterUsername.SelectedText = "";
            this.txtRegisterUsername.Size = new System.Drawing.Size(280, 36);
            this.txtRegisterUsername.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên đăng ký";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(129)))));
            this.lblTitle.Location = new System.Drawing.Point(24, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(228, 25);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Xin chào! Hãy đăng nhập";
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 8;
            this.btnClose.FillColor = System.Drawing.Color.IndianRed;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(394, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 32);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAuth
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 480);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tabAuth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAuth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAuth";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAuth_FormClosing);
            this.tabAuth.ResumeLayout(false);
            this.tabLogin.ResumeLayout(false);
            this.tabLogin.PerformLayout();
            this.tabRegister.ResumeLayout(false);
            this.tabRegister.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2TabControl tabAuth;
        private System.Windows.Forms.TabPage tabLogin;
        private System.Windows.Forms.TabPage tabRegister;
        private Guna.UI2.WinForms.Guna2TextBox txtLoginPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtLoginUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLoginStatus;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private System.Windows.Forms.Label lblRegisterStatus;
        private Guna.UI2.WinForms.Guna2Button btnRegister;
        private Guna.UI2.WinForms.Guna2TextBox txtRegisterConfirm;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtRegisterPassword;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtRegisterUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}
