using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Tictactoe
{
    public class SocketManager
    {
        #region Client

        private Socket client;

        public bool ConnectToServer()
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint iPEnd = new IPEndPoint(IPAddress.Parse(IP), PORT);

            try
            {
                client.Connect(iPEnd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Server

        private Socket server;

        public void CreateServer()
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint iPEnd = new IPEndPoint(IPAddress.Parse(IP), PORT);

            // waiting for clients
            server.Bind(iPEnd);
            server.Listen(10);      // 10 seconds

            // set thread for the only accepted clients 
            var acceptedClient = new Thread(() =>
            {
                client = server.Accept();
            })
            {
                // make sure that our thread run parallel to app, 
                // it is only destroyed when app closes.
                IsBackground = true
            };
            acceptedClient.Start();
        }

        #endregion

        #region Both types

        public string IP = Const.IP;

        public int PORT = Const.PORT;

        private const int BUFFER_SIZE = 1024;

        /// <summary>
        /// SEND command
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Send(object data)
        {
            var byteData = SerializeData(data);
            // client -> server (as client) - players both
            return SendData(client, byteData);
        }

        /// <summary>
        /// RECEIVE command
        /// </summary>
        /// <returns></returns>
        public object Receive()
        {
            byte[] data = new byte[BUFFER_SIZE];
            ReceiveData(client, data);

            return DeserializeData(data);
        }

        /// <summary>
        /// Send data
        /// </summary>
        /// <param name="target">Who sends?</param>
        /// <param name="data">The object</param>
        /// <returns>True if success, else false</returns>
        private bool SendData(Socket target, byte[] data)
        {
            return target.Send(data) == 1 ? true : false;
        }

        /// <summary>
        /// Receive data
        /// </summary>
        /// <param name="target">Who is received?</param>
        /// <param name="data">The object</param>
        /// <returns>True if success, else false</returns>
        private bool ReceiveData(Socket target, byte[] data)
        {
            return target.Receive(data) == 1 ? true : false;
        }

        /// <summary>
        /// Compress an object into byte array
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public byte[] SerializeData(Object sender)
        {
            // Create stream so save data
            var memoryStream = new MemoryStream();

            // Create a binary formatter
            var binaryFormatter = new BinaryFormatter();

            // Format data to byte[]
            binaryFormatter.Serialize(memoryStream, sender);

            return memoryStream.ToArray();
        }

        /// <summary>
        /// Extract the byte array to object
        /// </summary>
        /// <param name="theByteArray"></param>
        /// <returns></returns>
        public object DeserializeData(byte[] theByteArray)
        {
            var memoryStream = new MemoryStream(theByteArray);
            var binaryFormatter = new BinaryFormatter();
            memoryStream.Position = 0;
            return binaryFormatter.Deserialize(memoryStream);
        }

        /// <summary>
        /// Get Local Internet Protocol V4 
        /// </summary>
        /// <param name="_type"></param>
        /// <returns></returns>
        public string GetLocalIPv4(NetworkInterfaceType _type)
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

        #endregion
    }
}
