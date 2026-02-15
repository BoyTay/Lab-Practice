namespace AsyncSocketServer
{
    partial class frmServer
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
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.btnStopServer = new Guna.UI2.WinForms.Guna2Button();
            this.btnStartServer = new Guna.UI2.WinForms.Guna2Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lstClients = new System.Windows.Forms.ListBox();
            this.lblClientCount = new System.Windows.Forms.Label();
            this.lblSelectedClient = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnSendToClient = new Guna.UI2.WinForms.Guna2Button();
            this.txtClientMessage = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSendAll = new Guna.UI2.WinForms.Guna2Button();
            this.txtBroadcast = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTitleBar.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelBottom.SuspendLayout();
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
            this.lblTitle.Size = new System.Drawing.Size(104, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Server Chat";
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            this.lblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseMove);
            this.lblTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseUp);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnExit);
            this.panelTop.Controls.Add(this.btnStopServer);
            this.panelTop.Controls.Add(this.btnStartServer);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 40);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 70);
            this.panelTop.TabIndex = 0;
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
            this.btnExit.Location = new System.Drawing.Point(440, 15);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(136, 45);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStopServer
            // 
            this.btnStopServer.BorderRadius = 8;
            this.btnStopServer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStopServer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStopServer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStopServer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStopServer.Enabled = false;
            this.btnStopServer.FillColor = System.Drawing.Color.IndianRed;
            this.btnStopServer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStopServer.ForeColor = System.Drawing.Color.White;
            this.btnStopServer.Location = new System.Drawing.Point(221, 15);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(180, 45);
            this.btnStopServer.TabIndex = 13;
            this.btnStopServer.Text = "🛑 Dừng Server";
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // btnStartServer
            // 
            this.btnStartServer.BorderRadius = 8;
            this.btnStartServer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStartServer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStartServer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStartServer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStartServer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStartServer.ForeColor = System.Drawing.Color.White;
            this.btnStartServer.Location = new System.Drawing.Point(20, 15);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(180, 45);
            this.btnStartServer.TabIndex = 12;
            this.btnStartServer.Text = "🚀 Khởi động Server";
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.splitContainer);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 110);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1000, 340);
            this.panelMain.TabIndex = 1;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panelLeft);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelRight);
            this.splitContainer.Size = new System.Drawing.Size(1000, 340);
            this.splitContainer.SplitterDistance = 400;
            this.splitContainer.TabIndex = 0;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.lstClients);
            this.panelLeft.Controls.Add(this.lblClientCount);
            this.panelLeft.Controls.Add(this.lblSelectedClient);
            this.panelLeft.Controls.Add(this.label4);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(400, 340);
            this.panelLeft.TabIndex = 0;
            // 
            // lstClients
            // 
            this.lstClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstClients.FormattingEnabled = true;
            this.lstClients.ItemHeight = 16;
            this.lstClients.Location = new System.Drawing.Point(0, 72);
            this.lstClients.Name = "lstClients";
            this.lstClients.Size = new System.Drawing.Size(400, 260);
            this.lstClients.TabIndex = 2;
            this.lstClients.SelectedIndexChanged += new System.EventHandler(this.lstClients_SelectedIndexChanged);
            // 
            // lblClientCount
            // 
            this.lblClientCount.AutoSize = true;
            this.lblClientCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblClientCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientCount.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblClientCount.Location = new System.Drawing.Point(0, 42);
            this.lblClientCount.Name = "lblClientCount";
            this.lblClientCount.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.lblClientCount.Size = new System.Drawing.Size(265, 25);
            this.lblClientCount.TabIndex = 1;
            this.lblClientCount.Text = "Tổng số tài khoản: 0 | Đã đăng nhập: 0";
            // 
            // lblSelectedClient
            // 
            this.lblSelectedClient.AutoSize = true;
            this.lblSelectedClient.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSelectedClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedClient.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSelectedClient.Location = new System.Drawing.Point(0, 22);
            this.lblSelectedClient.Name = "lblSelectedClient";
            this.lblSelectedClient.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
            this.lblSelectedClient.Size = new System.Drawing.Size(124, 20);
            this.lblSelectedClient.TabIndex = 3;
            this.lblSelectedClient.Text = "Chưa chọn client";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
            this.label4.Size = new System.Drawing.Size(146, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Danh sách Client:";
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.rtbLog);
            this.panelRight.Controls.Add(this.label5);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(596, 340);
            this.panelRight.TabIndex = 0;
            // 
            // rtbLog
            // 
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLog.Location = new System.Drawing.Point(0, 22);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(596, 318);
            this.rtbLog.TabIndex = 1;
            this.rtbLog.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
            this.label5.Size = new System.Drawing.Size(78, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nhật ký:";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnSendToClient);
            this.panelBottom.Controls.Add(this.txtClientMessage);
            this.panelBottom.Controls.Add(this.label6);
            this.panelBottom.Controls.Add(this.btnSendAll);
            this.panelBottom.Controls.Add(this.txtBroadcast);
            this.panelBottom.Controls.Add(this.label1);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 450);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1000, 150);
            this.panelBottom.TabIndex = 2;
            // 
            // btnSendToClient
            // 
            this.btnSendToClient.BorderRadius = 8;
            this.btnSendToClient.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendToClient.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendToClient.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendToClient.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendToClient.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSendToClient.ForeColor = System.Drawing.Color.White;
            this.btnSendToClient.Location = new System.Drawing.Point(850, 98);
            this.btnSendToClient.Name = "btnSendToClient";
            this.btnSendToClient.Size = new System.Drawing.Size(130, 40);
            this.btnSendToClient.TabIndex = 18;
            this.btnSendToClient.Text = "💬 Gửi tới Client";
            this.btnSendToClient.Click += new System.EventHandler(this.btnSendToClient_Click);
            // 
            // txtClientMessage
            // 
            this.txtClientMessage.BorderRadius = 8;
            this.txtClientMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtClientMessage.DefaultText = "";
            this.txtClientMessage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtClientMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtClientMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtClientMessage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtClientMessage.FocusedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.txtClientMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtClientMessage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtClientMessage.Location = new System.Drawing.Point(20, 100);
            this.txtClientMessage.Name = "txtClientMessage";
            this.txtClientMessage.PlaceholderText = "Nhập tin nhắn gửi tới client...";
            this.txtClientMessage.SelectedText = "";
            this.txtClientMessage.Size = new System.Drawing.Size(820, 36);
            this.txtClientMessage.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(283, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Gửi tới client đã chọn (click vào danh sách):";
            // 
            // btnSendAll
            // 
            this.btnSendAll.BorderRadius = 8;
            this.btnSendAll.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendAll.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendAll.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendAll.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendAll.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSendAll.ForeColor = System.Drawing.Color.White;
            this.btnSendAll.Location = new System.Drawing.Point(850, 28);
            this.btnSendAll.Name = "btnSendAll";
            this.btnSendAll.Size = new System.Drawing.Size(130, 40);
            this.btnSendAll.TabIndex = 14;
            this.btnSendAll.Text = "📢 Gửi Broadcast";
            this.btnSendAll.Click += new System.EventHandler(this.btnSendAll_Click);
            // 
            // txtBroadcast
            // 
            this.txtBroadcast.BorderRadius = 8;
            this.txtBroadcast.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBroadcast.DefaultText = "";
            this.txtBroadcast.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBroadcast.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBroadcast.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBroadcast.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBroadcast.FocusedState.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.txtBroadcast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBroadcast.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBroadcast.Location = new System.Drawing.Point(20, 30);
            this.txtBroadcast.Name = "txtBroadcast";
            this.txtBroadcast.PlaceholderText = "Nhập nội dung broadcast...";
            this.txtBroadcast.SelectedText = "";
            this.txtBroadcast.Size = new System.Drawing.Size(820, 36);
            this.txtBroadcast.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gửi tới tất cả client:";
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmServer";
            this.Text = "Server Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServer_FormClosing);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private System.Windows.Forms.Panel panelTop;
        private Guna.UI2.WinForms.Guna2Button btnStopServer;
        private Guna.UI2.WinForms.Guna2Button btnStartServer;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.ListBox lstClients;
        private System.Windows.Forms.Label lblClientCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelBottom;
        private Guna.UI2.WinForms.Guna2Button btnSendAll;
        private Guna.UI2.WinForms.Guna2TextBox txtBroadcast;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnSendToClient;
        private Guna.UI2.WinForms.Guna2TextBox txtClientMessage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSelectedClient;
        private Guna.UI2.WinForms.Guna2Button btnExit;
    }
}
