
namespace BotnetClient
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.logListView = new MetroFramework.Controls.MetroListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.logContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.viewMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroPanel1.SuspendLayout();
            this.logContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.logListView);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(845, 420);
            this.metroPanel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // logListView
            // 
            this.logListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.logListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.logListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.logListView.FullRowSelect = true;
            this.logListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.logListView.Location = new System.Drawing.Point(3, 28);
            this.logListView.Name = "logListView";
            this.logListView.OwnerDraw = true;
            this.logListView.Size = new System.Drawing.Size(839, 383);
            this.logListView.Style = MetroFramework.MetroColorStyle.Blue;
            this.logListView.TabIndex = 3;
            this.logListView.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.logListView.UseCompatibleStateImageBehavior = false;
            this.logListView.UseCustomBackColor = true;
            this.logListView.UseSelectable = true;
            this.logListView.UseStyleColors = true;
            this.logListView.View = System.Windows.Forms.View.Details;
            this.logListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.connectionLogListView_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Log Item";
            this.columnHeader1.Width = 750;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Location = new System.Drawing.Point(3, 6);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(839, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Connection Log";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // logContextMenu
            // 
            this.logContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewMessageToolStripMenuItem});
            this.logContextMenu.Name = "logContextMenu";
            this.logContextMenu.Size = new System.Drawing.Size(149, 26);
            // 
            // viewMessageToolStripMenuItem
            // 
            this.viewMessageToolStripMenuItem.Name = "viewMessageToolStripMenuItem";
            this.viewMessageToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.viewMessageToolStripMenuItem.Text = "View Message";
            this.viewMessageToolStripMenuItem.Click += new System.EventHandler(this.viewMessageToolStripMenuItem_Click);
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 500);
            this.Controls.Add(this.metroPanel1);
            this.Name = "MainPanel";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Client Panel";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainPanel_FormClosing);
            this.metroPanel1.ResumeLayout(false);
            this.logContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroListView logListView;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private MetroFramework.Controls.MetroContextMenu logContextMenu;
        private System.Windows.Forms.ToolStripMenuItem viewMessageToolStripMenuItem;
    }
}

