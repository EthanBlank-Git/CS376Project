
namespace BotnetHost
{
    partial class MainPanel
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
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
            this.serverPortLabel = new MetroFramework.Controls.MetroLabel();
            this.serverIPLabel = new MetroFramework.Controls.MetroLabel();
            this.serverIPV4Label = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.serverToggle = new MetroFramework.Controls.MetroToggle();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.restartClientsBtn = new MetroFramework.Controls.MetroButton();
            this.applySettingsBtn = new MetroFramework.Controls.MetroButton();
            this.attackingToggle = new MetroFramework.Controls.MetroToggle();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.updateStatusLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.socketsLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.socketsTrackBar = new MetroFramework.Controls.MetroTrackBar();
            this.useSSLToggle = new MetroFramework.Controls.MetroToggle();
            this.delayLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.delayTrackBar = new MetroFramework.Controls.MetroTrackBar();
            this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.clientListView = new MetroFramework.Controls.MetroListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.activityLogListView = new MetroFramework.Controls.MetroListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.logContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.viewLogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.metroPanel2.SuspendLayout();
            this.metroPanel4.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.logContextMenu.SuspendLayout();
            this.clientContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = null;
            // 
            // metroPanel2
            // 
            this.metroPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel2.Controls.Add(this.metroPanel4);
            this.metroPanel2.Controls.Add(this.metroPanel3);
            this.metroPanel2.Controls.Add(this.metroLabel3);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(883, 63);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(247, 463);
            this.metroPanel2.TabIndex = 3;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroPanel4
            // 
            this.metroPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel4.Controls.Add(this.serverPortLabel);
            this.metroPanel4.Controls.Add(this.serverIPLabel);
            this.metroPanel4.Controls.Add(this.serverIPV4Label);
            this.metroPanel4.Controls.Add(this.metroLabel10);
            this.metroPanel4.Controls.Add(this.serverToggle);
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel4.HorizontalScrollbarSize = 10;
            this.metroPanel4.Location = new System.Drawing.Point(3, 312);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(239, 145);
            this.metroPanel4.TabIndex = 18;
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 10;
            // 
            // serverPortLabel
            // 
            this.serverPortLabel.Location = new System.Drawing.Point(3, 117);
            this.serverPortLabel.Margin = new System.Windows.Forms.Padding(0);
            this.serverPortLabel.Name = "serverPortLabel";
            this.serverPortLabel.Size = new System.Drawing.Size(231, 23);
            this.serverPortLabel.TabIndex = 23;
            this.serverPortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.serverPortLabel.UseStyleColors = true;
            // 
            // serverIPLabel
            // 
            this.serverIPLabel.Location = new System.Drawing.Point(3, 70);
            this.serverIPLabel.Margin = new System.Windows.Forms.Padding(0);
            this.serverIPLabel.Name = "serverIPLabel";
            this.serverIPLabel.Size = new System.Drawing.Size(231, 23);
            this.serverIPLabel.TabIndex = 21;
            this.serverIPLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.serverIPLabel.UseStyleColors = true;
            // 
            // serverIPV4Label
            // 
            this.serverIPV4Label.Location = new System.Drawing.Point(3, 94);
            this.serverIPV4Label.Margin = new System.Windows.Forms.Padding(0);
            this.serverIPV4Label.Name = "serverIPV4Label";
            this.serverIPV4Label.Size = new System.Drawing.Size(231, 23);
            this.serverIPV4Label.TabIndex = 19;
            this.serverIPV4Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.serverIPV4Label.UseStyleColors = true;
            // 
            // metroLabel10
            // 
            this.metroLabel10.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel10.Location = new System.Drawing.Point(-1, 0);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(239, 25);
            this.metroLabel10.TabIndex = 11;
            this.metroLabel10.Text = "Server Status\r\n";
            this.metroLabel10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // serverToggle
            // 
            this.serverToggle.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.serverToggle.Checked = true;
            this.serverToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.serverToggle.Location = new System.Drawing.Point(55, 33);
            this.serverToggle.Margin = new System.Windows.Forms.Padding(8);
            this.serverToggle.Name = "serverToggle";
            this.serverToggle.Size = new System.Drawing.Size(128, 28);
            this.serverToggle.TabIndex = 5;
            this.serverToggle.Text = "On";
            this.serverToggle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.serverToggle.UseSelectable = true;
            this.serverToggle.CheckedChanged += new System.EventHandler(this.serverToggle_CheckedChanged);
            this.serverToggle.Click += new System.EventHandler(this.settingsChanged);
            // 
            // metroPanel3
            // 
            this.metroPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel3.Controls.Add(this.restartClientsBtn);
            this.metroPanel3.Controls.Add(this.applySettingsBtn);
            this.metroPanel3.Controls.Add(this.attackingToggle);
            this.metroPanel3.Controls.Add(this.metroLabel5);
            this.metroPanel3.Controls.Add(this.updateStatusLabel);
            this.metroPanel3.Controls.Add(this.metroLabel6);
            this.metroPanel3.Controls.Add(this.socketsLabel);
            this.metroPanel3.Controls.Add(this.metroLabel11);
            this.metroPanel3.Controls.Add(this.socketsTrackBar);
            this.metroPanel3.Controls.Add(this.useSSLToggle);
            this.metroPanel3.Controls.Add(this.delayLabel);
            this.metroPanel3.Controls.Add(this.metroLabel9);
            this.metroPanel3.Controls.Add(this.metroLabel8);
            this.metroPanel3.Controls.Add(this.metroLabel7);
            this.metroPanel3.Controls.Add(this.delayTrackBar);
            this.metroPanel3.Controls.Add(this.metroTextBox2);
            this.metroPanel3.Controls.Add(this.metroLabel4);
            this.metroPanel3.Controls.Add(this.metroTextBox1);
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(3, 26);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(239, 280);
            this.metroPanel3.TabIndex = 6;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // restartClientsBtn
            // 
            this.restartClientsBtn.Location = new System.Drawing.Point(3, 196);
            this.restartClientsBtn.Name = "restartClientsBtn";
            this.restartClientsBtn.Size = new System.Drawing.Size(230, 23);
            this.restartClientsBtn.TabIndex = 21;
            this.restartClientsBtn.Text = "Restart Clients";
            this.restartClientsBtn.UseSelectable = true;
            this.restartClientsBtn.Click += new System.EventHandler(this.restartClientsBtn_Click);
            // 
            // applySettingsBtn
            // 
            this.applySettingsBtn.Location = new System.Drawing.Point(3, 225);
            this.applySettingsBtn.Name = "applySettingsBtn";
            this.applySettingsBtn.Size = new System.Drawing.Size(230, 23);
            this.applySettingsBtn.TabIndex = 20;
            this.applySettingsBtn.Text = "Apply Settings";
            this.applySettingsBtn.UseSelectable = true;
            this.applySettingsBtn.Click += new System.EventHandler(this.settingsChanged);
            // 
            // attackingToggle
            // 
            this.attackingToggle.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.attackingToggle.Location = new System.Drawing.Point(97, 145);
            this.attackingToggle.Name = "attackingToggle";
            this.attackingToggle.Size = new System.Drawing.Size(136, 23);
            this.attackingToggle.TabIndex = 19;
            this.attackingToggle.Text = "Off";
            this.attackingToggle.UseSelectable = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.Location = new System.Drawing.Point(3, 251);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(149, 23);
            this.metroLabel5.TabIndex = 16;
            this.metroLabel5.Text = "Pending Update:";
            this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // updateStatusLabel
            // 
            this.updateStatusLabel.Location = new System.Drawing.Point(152, 251);
            this.updateStatusLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.updateStatusLabel.Name = "updateStatusLabel";
            this.updateStatusLabel.Size = new System.Drawing.Size(81, 23);
            this.updateStatusLabel.TabIndex = 17;
            this.updateStatusLabel.Text = "True";
            this.updateStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.updateStatusLabel.UseStyleColors = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.Location = new System.Drawing.Point(3, 145);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(88, 23);
            this.metroLabel6.TabIndex = 18;
            this.metroLabel6.Text = "Attacking:";
            this.metroLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // socketsLabel
            // 
            this.socketsLabel.Location = new System.Drawing.Point(189, 87);
            this.socketsLabel.Name = "socketsLabel";
            this.socketsLabel.Size = new System.Drawing.Size(44, 23);
            this.socketsLabel.TabIndex = 15;
            this.socketsLabel.Text = "8";
            this.socketsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel11
            // 
            this.metroLabel11.Location = new System.Drawing.Point(3, 87);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(88, 23);
            this.metroLabel11.TabIndex = 14;
            this.metroLabel11.Text = "Sockets:";
            this.metroLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // socketsTrackBar
            // 
            this.socketsTrackBar.BackColor = System.Drawing.Color.Transparent;
            this.socketsTrackBar.LargeChange = 2;
            this.socketsTrackBar.Location = new System.Drawing.Point(97, 87);
            this.socketsTrackBar.Maximum = 25;
            this.socketsTrackBar.Minimum = 1;
            this.socketsTrackBar.Name = "socketsTrackBar";
            this.socketsTrackBar.Size = new System.Drawing.Size(86, 23);
            this.socketsTrackBar.TabIndex = 13;
            this.socketsTrackBar.Value = 8;
            this.socketsTrackBar.ValueChanged += new System.EventHandler(this.updateTrackBars);
            // 
            // useSSLToggle
            // 
            this.useSSLToggle.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.useSSLToggle.Location = new System.Drawing.Point(97, 116);
            this.useSSLToggle.Name = "useSSLToggle";
            this.useSSLToggle.Size = new System.Drawing.Size(136, 23);
            this.useSSLToggle.TabIndex = 12;
            this.useSSLToggle.Text = "Off";
            this.useSSLToggle.UseSelectable = true;
            // 
            // delayLabel
            // 
            this.delayLabel.Location = new System.Drawing.Point(189, 58);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(44, 23);
            this.delayLabel.TabIndex = 9;
            this.delayLabel.Text = "15000";
            this.delayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel9
            // 
            this.metroLabel9.Location = new System.Drawing.Point(3, 116);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(88, 23);
            this.metroLabel9.TabIndex = 8;
            this.metroLabel9.Text = "Use SSL:";
            this.metroLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel8
            // 
            this.metroLabel8.Location = new System.Drawing.Point(3, 58);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(88, 23);
            this.metroLabel8.TabIndex = 8;
            this.metroLabel8.Text = "Delay (ms):";
            this.metroLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel7
            // 
            this.metroLabel7.Location = new System.Drawing.Point(3, 32);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(88, 23);
            this.metroLabel7.TabIndex = 7;
            this.metroLabel7.Text = "Port:";
            this.metroLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // delayTrackBar
            // 
            this.delayTrackBar.BackColor = System.Drawing.Color.Transparent;
            this.delayTrackBar.Location = new System.Drawing.Point(97, 58);
            this.delayTrackBar.Maximum = 30000;
            this.delayTrackBar.Minimum = 250;
            this.delayTrackBar.Name = "delayTrackBar";
            this.delayTrackBar.Size = new System.Drawing.Size(86, 23);
            this.delayTrackBar.TabIndex = 7;
            this.delayTrackBar.Value = 15000;
            this.delayTrackBar.ValueChanged += new System.EventHandler(this.updateTrackBars);
            // 
            // metroTextBox2
            // 
            // 
            // 
            // 
            this.metroTextBox2.CustomButton.Image = null;
            this.metroTextBox2.CustomButton.Location = new System.Drawing.Point(114, 1);
            this.metroTextBox2.CustomButton.Name = "";
            this.metroTextBox2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox2.CustomButton.TabIndex = 1;
            this.metroTextBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox2.CustomButton.UseSelectable = true;
            this.metroTextBox2.CustomButton.Visible = false;
            this.metroTextBox2.Lines = new string[] {
        "12345"};
            this.metroTextBox2.Location = new System.Drawing.Point(97, 32);
            this.metroTextBox2.MaxLength = 32767;
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.PasswordChar = '\0';
            this.metroTextBox2.PromptText = "Port";
            this.metroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox2.SelectedText = "";
            this.metroTextBox2.SelectionLength = 0;
            this.metroTextBox2.SelectionStart = 0;
            this.metroTextBox2.ShortcutsEnabled = true;
            this.metroTextBox2.Size = new System.Drawing.Size(136, 23);
            this.metroTextBox2.TabIndex = 6;
            this.metroTextBox2.Text = "12345";
            this.metroTextBox2.UseSelectable = true;
            this.metroTextBox2.WaterMark = "Port";
            this.metroTextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.Location = new System.Drawing.Point(3, 3);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(88, 23);
            this.metroLabel4.TabIndex = 3;
            this.metroLabel4.Text = "IP:";
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(114, 1);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.Lines = new string[] {
        "localhost"};
            this.metroTextBox1.Location = new System.Drawing.Point(97, 3);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.PromptText = "IP Address";
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(136, 23);
            this.metroTextBox1.TabIndex = 2;
            this.metroTextBox1.Text = "localhost";
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMark = "IP Address";
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.Location = new System.Drawing.Point(3, 4);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(239, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Botnet Settings";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.clientListView);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.activityLogListView);
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(23, 63);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(858, 463);
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // clientListView
            // 
            this.clientListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.clientListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.clientListView.FullRowSelect = true;
            this.clientListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.clientListView.Location = new System.Drawing.Point(4, 26);
            this.clientListView.Name = "clientListView";
            this.clientListView.OwnerDraw = true;
            this.clientListView.Size = new System.Drawing.Size(849, 261);
            this.clientListView.TabIndex = 7;
            this.clientListView.UseCompatibleStateImageBehavior = false;
            this.clientListView.UseSelectable = true;
            this.clientListView.View = System.Windows.Forms.View.Details;
            this.clientListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clientListView_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Client";
            this.columnHeader1.Width = 840;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(4, 4);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(117, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Client Connections";
            // 
            // activityLogListView
            // 
            this.activityLogListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.activityLogListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.activityLogListView.FullRowSelect = true;
            this.activityLogListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.activityLogListView.Location = new System.Drawing.Point(4, 312);
            this.activityLogListView.Name = "activityLogListView";
            this.activityLogListView.OwnerDraw = true;
            this.activityLogListView.Size = new System.Drawing.Size(849, 145);
            this.activityLogListView.TabIndex = 5;
            this.activityLogListView.UseCompatibleStateImageBehavior = false;
            this.activityLogListView.UseSelectable = true;
            this.activityLogListView.View = System.Windows.Forms.View.Details;
            this.activityLogListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.activityLogListView_MouseDown);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Log Item";
            this.columnHeader2.Width = 830;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(4, 290);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(79, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Activity Log:";
            // 
            // logContextMenu
            // 
            this.logContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewLogMenuItem});
            this.logContextMenu.Name = "clientContextMenu";
            this.logContextMenu.Size = new System.Drawing.Size(171, 26);
            // 
            // viewLogMenuItem
            // 
            this.viewLogMenuItem.Name = "viewLogMenuItem";
            this.viewLogMenuItem.Size = new System.Drawing.Size(170, 22);
            this.viewLogMenuItem.Text = "View Full Message";
            this.viewLogMenuItem.Click += new System.EventHandler(this.viewLogMenuItem_Click);
            // 
            // clientContextMenu
            // 
            this.clientContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disconnectToolStripMenuItem,
            this.restartToolStripMenuItem});
            this.clientContextMenu.Name = "clientContextMenu";
            this.clientContextMenu.Size = new System.Drawing.Size(134, 48);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 549);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Name = "MainPanel";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Host Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainPanel_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel4.ResumeLayout(false);
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.logContextMenu.ResumeLayout(false);
            this.clientContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroListView activityLogListView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroListView clientListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private MetroFramework.Controls.MetroLabel delayLabel;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTrackBar delayTrackBar;
        private MetroFramework.Controls.MetroToggle serverToggle;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox metroTextBox2;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroToggle useSSLToggle;
        private MetroFramework.Controls.MetroLabel socketsLabel;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroTrackBar socketsTrackBar;
        private MetroFramework.Controls.MetroLabel updateStatusLabel;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroToggle attackingToggle;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroButton applySettingsBtn;
        private MetroFramework.Controls.MetroPanel metroPanel4;
        private MetroFramework.Controls.MetroButton restartClientsBtn;
        private MetroFramework.Controls.MetroLabel serverIPV4Label;
        private MetroFramework.Controls.MetroLabel serverIPLabel;
        private MetroFramework.Controls.MetroLabel serverPortLabel;
        private MetroFramework.Controls.MetroContextMenu logContextMenu;
        private System.Windows.Forms.ToolStripMenuItem viewLogMenuItem;
        private MetroFramework.Controls.MetroContextMenu clientContextMenu;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
    }
}

