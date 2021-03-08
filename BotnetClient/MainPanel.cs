using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotnetClient
{
    public partial class MainPanel : MetroFramework.Forms.MetroForm
    {
        Utilities utilities;

        /// <summary>
        /// MainPanel Function, this is the constructor for the window
        /// </summary>
        public MainPanel()
        {
            InitializeComponent();
            utilities = new Utilities(logListView, this);
            utilities.thread = new Thread(() => utilities.clientThread());
            utilities.thread.Start();
        }

        /// <summary>
        /// Override method for form closing, makes sure that the sockets get closed when the program closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            try {
                utilities.socket.Shutdown(SocketShutdown.Both);
            } catch (Exception er) { }
            try
            {
                utilities.socket.Close();
            }
            catch (Exception er) { }
            try
            {
                utilities.thread.Abort();
            }
            catch (Exception er) { }
        }
        /// <summary>
        /// Catcher for clicking list view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connectionLogListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = logListView.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    logContextMenu.Show(Cursor.Position);
                }
            }
        }
        /// <summary>
        /// Catcher for clicking 'view message' on a log item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (logListView.SelectedItems[0] != null)
            {
                MessageBox.Show(logListView.SelectedItems[0].Text, "Log Message");
            }
        }
        /// <summary>
        /// Fix logListView width after form resize and limit minimal window size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainPanel_Resize(object sender, EventArgs e)
        {
            logListView.Columns[0].Width = logListView.Width - 20;
        }
    }
}
