namespace AsyncSocketClient
{
    partial class frmClient
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
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.btnDisconnect = new Guna.UI2.WinForms.Guna2Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabBroadcast = new System.Windows.Forms.TabPage();
            this.btnSendBroadcast = new Guna.UI2.WinForms.Guna2Button();
            this.txtBroadcastMessage = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabDirectMessage = new System.Windows.Forms.TabPage();
            this.btnSendDM = new Guna.UI2.WinForms.Guna2Button();
            this.txtDMMessage = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDMRecipient = new Guna.UI2.WinForms.Guna2TextBox();
            this.lstOnlineUsers = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabServer = new System.Windows.Forms.TabPage();
            this.btnSendServer = new Guna.UI2.WinForms.Guna2Button();
            this.txtServerMessage = new Guna.UI2.WinForms.Guna2TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabGroup = new System.Windows.Forms.TabPage();
            this.btnSendGroupMsg = new Guna.UI2.WinForms.Guna2Button();
            this.txtGroupMessage = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnLeaveGroup = new Guna.UI2.WinForms.Guna2Button();
            this.btnJoinGroup = new Guna.UI2.WinForms.Guna2Button();
            this.btnCreateGroup = new Guna.UI2.WinForms.Guna2Button();
            this.txtGroupName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lstGroups = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panelMessages = new System.Windows.Forms.Panel();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.panelTitleBar.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabBroadcast.SuspendLayout();
            this.tabDirectMessage.SuspendLayout();
            this.tabServer.SuspendLayout();
            this.tabGroup.SuspendLayout();
            this.panelMessages.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1000, 40);
            this.panelTitleBar.TabIndex = 0;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            this.panelTitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseMove);
            this.panelTitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseUp);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(15, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(98, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Client Chat";
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            this.lblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseMove);
            this.lblTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseUp);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblCurrentUser);
            this.panelTop.Controls.Add(this.btnDisconnect);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 40);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 80);
            this.panelTop.TabIndex = 0;
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCurrentUser.Location = new System.Drawing.Point(22, 29);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(202, 20);
            this.lblCurrentUser.TabIndex = 16;
            this.lblCurrentUser.Text = "Đang đăng nhập: (chưa có)";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BorderRadius = 8;
            this.btnDisconnect.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDisconnect.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDisconnect.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDisconnect.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDisconnect.FillColor = System.Drawing.Color.IndianRed;
            this.btnDisconnect.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDisconnect.ForeColor = System.Drawing.Color.White;
            this.btnDisconnect.Location = new System.Drawing.Point(720, 17);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(120, 36);
            this.btnDisconnect.TabIndex = 0;
            this.btnDisconnect.Text = "Đăng xuất";
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.tabControl);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMain.Location = new System.Drawing.Point(500, 120);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(500, 522);
            this.panelMain.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabBroadcast);
            this.tabControl.Controls.Add(this.tabDirectMessage);
            this.tabControl.Controls.Add(this.tabServer);
            this.tabControl.Controls.Add(this.tabGroup);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(500, 522);
            this.tabControl.TabIndex = 0;
            // 
            // tabBroadcast
            // 
            this.tabBroadcast.Controls.Add(this.btnSendBroadcast);
            this.tabBroadcast.Controls.Add(this.txtBroadcastMessage);
            this.tabBroadcast.Controls.Add(this.label6);
            this.tabBroadcast.Location = new System.Drawing.Point(4, 24);
            this.tabBroadcast.Name = "tabBroadcast";
            this.tabBroadcast.Padding = new System.Windows.Forms.Padding(3);
            this.tabBroadcast.Size = new System.Drawing.Size(492, 494);
            this.tabBroadcast.TabIndex = 0;
            this.tabBroadcast.Text = "📢 Broadcast";
            this.tabBroadcast.UseVisualStyleBackColor = true;
            // 
            // btnSendBroadcast
            // 
            this.btnSendBroadcast.BorderRadius = 8;
            this.btnSendBroadcast.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendBroadcast.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendBroadcast.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendBroadcast.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendBroadcast.Enabled = false;
            this.btnSendBroadcast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSendBroadcast.ForeColor = System.Drawing.Color.White;
            this.btnSendBroadcast.Location = new System.Drawing.Point(20, 88);
            this.btnSendBroadcast.Name = "btnSendBroadcast";
            this.btnSendBroadcast.Size = new System.Drawing.Size(450, 40);
            this.btnSendBroadcast.TabIndex = 2;
            this.btnSendBroadcast.Text = "Gửi tin nhắn tới tất cả";
            this.btnSendBroadcast.Click += new System.EventHandler(this.btnSendBroadcast_Click);
            // 
            // txtBroadcastMessage
            // 
            this.txtBroadcastMessage.BorderRadius = 8;
            this.txtBroadcastMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBroadcastMessage.DefaultText = "";
            this.txtBroadcastMessage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBroadcastMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBroadcastMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBroadcastMessage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBroadcastMessage.FocusedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.txtBroadcastMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBroadcastMessage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBroadcastMessage.Location = new System.Drawing.Point(20, 40);
            this.txtBroadcastMessage.Name = "txtBroadcastMessage";
            this.txtBroadcastMessage.PlaceholderText = "Nhập tin nhắn broadcast...";
            this.txtBroadcastMessage.SelectedText = "";
            this.txtBroadcastMessage.Size = new System.Drawing.Size(450, 36);
            this.txtBroadcastMessage.TabIndex = 1;
            this.txtBroadcastMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBroadcastMessage_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(222, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Gửi tin nhắn tới tất cả người dùng:";
            // 
            // tabDirectMessage
            // 
            this.tabDirectMessage.Controls.Add(this.btnSendDM);
            this.tabDirectMessage.Controls.Add(this.txtDMMessage);
            this.tabDirectMessage.Controls.Add(this.txtDMRecipient);
            this.tabDirectMessage.Controls.Add(this.lstOnlineUsers);
            this.tabDirectMessage.Controls.Add(this.label12);
            this.tabDirectMessage.Controls.Add(this.label7);
            this.tabDirectMessage.Controls.Add(this.label8);
            this.tabDirectMessage.Location = new System.Drawing.Point(4, 24);
            this.tabDirectMessage.Name = "tabDirectMessage";
            this.tabDirectMessage.Padding = new System.Windows.Forms.Padding(3);
            this.tabDirectMessage.Size = new System.Drawing.Size(492, 494);
            this.tabDirectMessage.TabIndex = 1;
            this.tabDirectMessage.Text = "💬 Tin nhắn trực tiếp";
            this.tabDirectMessage.UseVisualStyleBackColor = true;
            // 
            // btnSendDM
            // 
            this.btnSendDM.BorderRadius = 8;
            this.btnSendDM.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendDM.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendDM.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendDM.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendDM.Enabled = false;
            this.btnSendDM.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSendDM.ForeColor = System.Drawing.Color.White;
            this.btnSendDM.Location = new System.Drawing.Point(20, 433);
            this.btnSendDM.Name = "btnSendDM";
            this.btnSendDM.Size = new System.Drawing.Size(450, 40);
            this.btnSendDM.TabIndex = 4;
            this.btnSendDM.Text = "Gửi tin nhắn";
            this.btnSendDM.Click += new System.EventHandler(this.btnSendDM_Click);
            // 
            // txtDMMessage
            // 
            this.txtDMMessage.BorderRadius = 8;
            this.txtDMMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDMMessage.DefaultText = "";
            this.txtDMMessage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDMMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDMMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDMMessage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDMMessage.FocusedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.txtDMMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDMMessage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDMMessage.Location = new System.Drawing.Point(20, 380);
            this.txtDMMessage.Name = "txtDMMessage";
            this.txtDMMessage.PlaceholderText = "Nhập tin nhắn...";
            this.txtDMMessage.SelectedText = "";
            this.txtDMMessage.Size = new System.Drawing.Size(450, 36);
            this.txtDMMessage.TabIndex = 3;
            this.txtDMMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDMMessage_KeyDown);
            // 
            // txtDMRecipient
            // 
            this.txtDMRecipient.BorderRadius = 8;
            this.txtDMRecipient.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDMRecipient.DefaultText = "";
            this.txtDMRecipient.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDMRecipient.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDMRecipient.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDMRecipient.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDMRecipient.FocusedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.txtDMRecipient.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDMRecipient.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDMRecipient.Location = new System.Drawing.Point(20, 305);
            this.txtDMRecipient.Name = "txtDMRecipient";
            this.txtDMRecipient.PlaceholderText = "Nhập tên người nhận...";
            this.txtDMRecipient.SelectedText = "";
            this.txtDMRecipient.Size = new System.Drawing.Size(450, 32);
            this.txtDMRecipient.TabIndex = 2;
            // 
            // lstOnlineUsers
            // 
            this.lstOnlineUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOnlineUsers.FormattingEnabled = true;
            this.lstOnlineUsers.ItemHeight = 16;
            this.lstOnlineUsers.Location = new System.Drawing.Point(20, 50);
            this.lstOnlineUsers.Name = "lstOnlineUsers";
            this.lstOnlineUsers.Size = new System.Drawing.Size(450, 212);
            this.lstOnlineUsers.TabIndex = 2;
            this.lstOnlineUsers.SelectedIndexChanged += new System.EventHandler(this.lstOnlineUsers_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(20, 286);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(259, 15);
            this.label12.TabIndex = 5;
            this.label12.Text = "Hoặc nhập tên người nhận (offline cũng được):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(266, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Chọn người nhận đang online (tuỳ chọn):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 355);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Tin nhắn:";
            // 
            // tabServer
            // 
            this.tabServer.Controls.Add(this.btnSendServer);
            this.tabServer.Controls.Add(this.txtServerMessage);
            this.tabServer.Controls.Add(this.label13);
            this.tabServer.Location = new System.Drawing.Point(4, 24);
            this.tabServer.Name = "tabServer";
            this.tabServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabServer.Size = new System.Drawing.Size(492, 494);
            this.tabServer.TabIndex = 3;
            this.tabServer.Text = "📨 Nhắn server";
            this.tabServer.UseVisualStyleBackColor = true;
            // 
            // btnSendServer
            // 
            this.btnSendServer.BorderRadius = 8;
            this.btnSendServer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendServer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendServer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendServer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendServer.Enabled = false;
            this.btnSendServer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSendServer.ForeColor = System.Drawing.Color.White;
            this.btnSendServer.Location = new System.Drawing.Point(20, 132);
            this.btnSendServer.Name = "btnSendServer";
            this.btnSendServer.Size = new System.Drawing.Size(450, 40);
            this.btnSendServer.TabIndex = 2;
            this.btnSendServer.Text = "Gửi tới server";
            this.btnSendServer.Click += new System.EventHandler(this.btnSendServer_Click);
            // 
            // txtServerMessage
            // 
            this.txtServerMessage.BorderRadius = 8;
            this.txtServerMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtServerMessage.DefaultText = "";
            this.txtServerMessage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtServerMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtServerMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtServerMessage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtServerMessage.Enabled = false;
            this.txtServerMessage.FocusedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.txtServerMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtServerMessage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtServerMessage.Location = new System.Drawing.Point(20, 80);
            this.txtServerMessage.Name = "txtServerMessage";
            this.txtServerMessage.PlaceholderText = "Nhập tin nhắn riêng tới server...";
            this.txtServerMessage.SelectedText = "";
            this.txtServerMessage.Size = new System.Drawing.Size(450, 36);
            this.txtServerMessage.TabIndex = 1;
            this.txtServerMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtServerMessage_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(20, 39);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(305, 17);
            this.label13.TabIndex = 0;
            this.label13.Text = "Gửi tin nhắn riêng để trao đổi với admin/server:";
            // 
            // tabGroup
            // 
            this.tabGroup.Controls.Add(this.btnSendGroupMsg);
            this.tabGroup.Controls.Add(this.txtGroupMessage);
            this.tabGroup.Controls.Add(this.btnLeaveGroup);
            this.tabGroup.Controls.Add(this.btnJoinGroup);
            this.tabGroup.Controls.Add(this.btnCreateGroup);
            this.tabGroup.Controls.Add(this.txtGroupName);
            this.tabGroup.Controls.Add(this.lstGroups);
            this.tabGroup.Controls.Add(this.label9);
            this.tabGroup.Controls.Add(this.label10);
            this.tabGroup.Controls.Add(this.label11);
            this.tabGroup.Location = new System.Drawing.Point(4, 24);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroup.Size = new System.Drawing.Size(492, 494);
            this.tabGroup.TabIndex = 2;
            this.tabGroup.Text = "👥 Nhóm chat";
            this.tabGroup.UseVisualStyleBackColor = true;
            // 
            // btnSendGroupMsg
            // 
            this.btnSendGroupMsg.BorderRadius = 8;
            this.btnSendGroupMsg.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendGroupMsg.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendGroupMsg.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendGroupMsg.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendGroupMsg.Enabled = false;
            this.btnSendGroupMsg.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSendGroupMsg.ForeColor = System.Drawing.Color.White;
            this.btnSendGroupMsg.Location = new System.Drawing.Point(20, 435);
            this.btnSendGroupMsg.Name = "btnSendGroupMsg";
            this.btnSendGroupMsg.Size = new System.Drawing.Size(450, 40);
            this.btnSendGroupMsg.TabIndex = 9;
            this.btnSendGroupMsg.Text = "Gửi tin nhắn tới nhóm";
            this.btnSendGroupMsg.Click += new System.EventHandler(this.btnSendGroupMsg_Click);
            // 
            // txtGroupMessage
            // 
            this.txtGroupMessage.BorderRadius = 8;
            this.txtGroupMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGroupMessage.DefaultText = "";
            this.txtGroupMessage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtGroupMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtGroupMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGroupMessage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGroupMessage.FocusedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.txtGroupMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGroupMessage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGroupMessage.Location = new System.Drawing.Point(20, 385);
            this.txtGroupMessage.Name = "txtGroupMessage";
            this.txtGroupMessage.PlaceholderText = "Nhập tin nhắn...";
            this.txtGroupMessage.SelectedText = "";
            this.txtGroupMessage.Size = new System.Drawing.Size(450, 36);
            this.txtGroupMessage.TabIndex = 8;
            this.txtGroupMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGroupMessage_KeyDown);
            // 
            // btnLeaveGroup
            // 
            this.btnLeaveGroup.BorderRadius = 8;
            this.btnLeaveGroup.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLeaveGroup.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLeaveGroup.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLeaveGroup.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLeaveGroup.Enabled = false;
            this.btnLeaveGroup.FillColor = System.Drawing.Color.IndianRed;
            this.btnLeaveGroup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLeaveGroup.ForeColor = System.Drawing.Color.White;
            this.btnLeaveGroup.Location = new System.Drawing.Point(326, 91);
            this.btnLeaveGroup.Name = "btnLeaveGroup";
            this.btnLeaveGroup.Size = new System.Drawing.Size(150, 36);
            this.btnLeaveGroup.TabIndex = 7;
            this.btnLeaveGroup.Text = "Rời nhóm";
            this.btnLeaveGroup.Click += new System.EventHandler(this.btnLeaveGroup_Click);
            // 
            // btnJoinGroup
            // 
            this.btnJoinGroup.BorderRadius = 8;
            this.btnJoinGroup.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnJoinGroup.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnJoinGroup.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnJoinGroup.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnJoinGroup.Enabled = false;
            this.btnJoinGroup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnJoinGroup.ForeColor = System.Drawing.Color.White;
            this.btnJoinGroup.Location = new System.Drawing.Point(164, 92);
            this.btnJoinGroup.Name = "btnJoinGroup";
            this.btnJoinGroup.Size = new System.Drawing.Size(150, 36);
            this.btnJoinGroup.TabIndex = 6;
            this.btnJoinGroup.Text = "Tham gia nhóm";
            this.btnJoinGroup.Click += new System.EventHandler(this.btnJoinGroup_Click);
            // 
            // btnCreateGroup
            // 
            this.btnCreateGroup.BorderRadius = 8;
            this.btnCreateGroup.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCreateGroup.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCreateGroup.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCreateGroup.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCreateGroup.Enabled = false;
            this.btnCreateGroup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCreateGroup.ForeColor = System.Drawing.Color.White;
            this.btnCreateGroup.Location = new System.Drawing.Point(20, 91);
            this.btnCreateGroup.Name = "btnCreateGroup";
            this.btnCreateGroup.Size = new System.Drawing.Size(137, 36);
            this.btnCreateGroup.TabIndex = 5;
            this.btnCreateGroup.Text = "Tạo nhóm";
            this.btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
            // 
            // txtGroupName
            // 
            this.txtGroupName.BorderRadius = 8;
            this.txtGroupName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGroupName.DefaultText = "";
            this.txtGroupName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtGroupName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtGroupName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGroupName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGroupName.FocusedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.txtGroupName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGroupName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGroupName.Location = new System.Drawing.Point(20, 50);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.PlaceholderText = "Nhập tên nhóm...";
            this.txtGroupName.SelectedText = "";
            this.txtGroupName.Size = new System.Drawing.Size(456, 36);
            this.txtGroupName.TabIndex = 4;
            // 
            // lstGroups
            // 
            this.lstGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstGroups.FormattingEnabled = true;
            this.lstGroups.ItemHeight = 16;
            this.lstGroups.Location = new System.Drawing.Point(20, 150);
            this.lstGroups.Name = "lstGroups";
            this.lstGroups.Size = new System.Drawing.Size(450, 212);
            this.lstGroups.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "Nhóm đã tham gia:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 366);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Tin nhắn:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(20, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Tên nhóm:";
            // 
            // panelMessages
            // 
            this.panelMessages.Controls.Add(this.rtbMessages);
            this.panelMessages.Controls.Add(this.label3);
            this.panelMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMessages.Location = new System.Drawing.Point(0, 120);
            this.panelMessages.Name = "panelMessages";
            this.panelMessages.Size = new System.Drawing.Size(500, 522);
            this.panelMessages.TabIndex = 2;
            // 
            // rtbMessages
            // 
            this.rtbMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMessages.Location = new System.Drawing.Point(0, 22);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.ReadOnly = true;
            this.rtbMessages.Size = new System.Drawing.Size(500, 500);
            this.rtbMessages.TabIndex = 1;
            this.rtbMessages.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
            this.label3.Size = new System.Drawing.Size(87, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tin nhắn:";
            // 
            // btnExit
            // 
            this.btnExit.BorderRadius = 8;
            this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExit.FillColor = System.Drawing.Color.IndianRed;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(860, 57);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 36);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1000, 642);
            this.Controls.Add(this.panelMessages);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmClient";
            this.Text = "Client Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClient_FormClosing);
            this.Load += new System.EventHandler(this.frmClient_Load);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabBroadcast.ResumeLayout(false);
            this.tabBroadcast.PerformLayout();
            this.tabDirectMessage.ResumeLayout(false);
            this.tabDirectMessage.PerformLayout();
            this.tabServer.ResumeLayout(false);
            this.tabServer.PerformLayout();
            this.tabGroup.ResumeLayout(false);
            this.tabGroup.PerformLayout();
            this.panelMessages.ResumeLayout(false);
            this.panelMessages.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblCurrentUser;
        private Guna.UI2.WinForms.Guna2Button btnDisconnect;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabBroadcast;
        private Guna.UI2.WinForms.Guna2Button btnSendBroadcast;
        private Guna.UI2.WinForms.Guna2TextBox txtBroadcastMessage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabDirectMessage;
        private Guna.UI2.WinForms.Guna2Button btnSendDM;
        private Guna.UI2.WinForms.Guna2TextBox txtDMMessage;
        private System.Windows.Forms.ListBox lstOnlineUsers;
        private Guna.UI2.WinForms.Guna2TextBox txtDMRecipient;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabServer;
        private Guna.UI2.WinForms.Guna2Button btnSendServer;
        private Guna.UI2.WinForms.Guna2TextBox txtServerMessage;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tabGroup;
        private Guna.UI2.WinForms.Guna2Button btnSendGroupMsg;
        private Guna.UI2.WinForms.Guna2TextBox txtGroupMessage;
        private Guna.UI2.WinForms.Guna2Button btnLeaveGroup;
        private Guna.UI2.WinForms.Guna2Button btnJoinGroup;
        private Guna.UI2.WinForms.Guna2Button btnCreateGroup;
        private Guna.UI2.WinForms.Guna2TextBox txtGroupName;
        private System.Windows.Forms.ListBox lstGroups;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panelMessages;
        private System.Windows.Forms.RichTextBox rtbMessages;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitle;
    }
}
