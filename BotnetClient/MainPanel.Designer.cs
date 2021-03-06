
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPanel));
            this.logContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.viewMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logListView = new MetroFramework.Controls.MetroListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logContextMenu.SuspendLayout();
            this.SuspendLayout();
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
            // logListView
            // 
            this.logListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.logListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.logListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.logListView.FullRowSelect = true;
            this.logListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.logListView.Location = new System.Drawing.Point(20, 30);
            this.logListView.Name = "logListView";
            this.logListView.OwnerDraw = true;
            this.logListView.Size = new System.Drawing.Size(690, 301);
            this.logListView.Style = MetroFramework.MetroColorStyle.Blue;
            this.logListView.TabIndex = 3;
            this.logListView.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.logListView.UseCompatibleStateImageBehavior = false;
            this.logListView.UseSelectable = true;
            this.logListView.View = System.Windows.Forms.View.Details;
            this.logListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.connectionLogListView_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Log Item";
            this.columnHeader1.Width = 670;
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 351);
            this.Controls.Add(this.logListView);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 250);
            this.Name = "MainPanel";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainPanel_FormClosing);
            this.Resize += new System.EventHandler(this.MainPanel_Resize);
            this.logContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroContextMenu logContextMenu;
        private System.Windows.Forms.ToolStripMenuItem viewMessageToolStripMenuItem;
        private MetroFramework.Controls.MetroListView logListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

