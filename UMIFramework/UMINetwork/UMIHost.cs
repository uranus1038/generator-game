using System;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UMI.Network
{
    public class UMIHost : MonoBehaviour
    {
        //Construct
        public static UMIHost hInst;
        // MaxPlayer
        public static int UMIMaxPlayer { get; private set; }
        // Port Server
        public static int UMIPort { get; private set; }
        // TCP
        public static int UID;
        private static TcpListener UMITCPListener;
        // Data
        private static NetworkStream stream;
        // Client
        private static TcpClient UMIClient;
        //Player
        private static Dictionary<int, TcpClient> players;
        //receive
        protected static string userName = "GOD`U";
        protected static string gender = "GOD`U";

        private void Awake()
        {
            hInst = this;
            players = new Dictionary<int, TcpClient>(); 
           
        }

        protected virtual void UMIRPCReceive() { }


        // Start Host
        public static void UMISartHost(int maxPlayer, int port)
        {
            UMISystem.Log("UMI::SUSSESSED()::SERVER_STRAT->" + port);
            UMIMaxPlayer = maxPlayer;
            UMIPort = port;
            // Thread call func
            Thread UMITCPServer = new Thread(new ThreadStart(UMIRuntimeHost));
            UMITCPServer.Start();
        }
        private static void UMIRuntimeHost()
        {
            UMITCPListener = new TcpListener(IPAddress.Any, UMIPort);
            UMITCPListener.Start();

            for(int i = 1; i < UMIMaxPlayer; i++)
            {
                try
                {
                    if (players[i] == null)
                    {
                        
                    }

                }
                catch( Exception ex)
                {
                    UMISystem.Log($"{ex}");
                    UID = i;
                    TcpClient client = UMITCPListener.AcceptTcpClient();
                    Thread UMITCPHandlerThread = new Thread(new ParameterizedThreadStart(UMITCPHandler));
                    // Retrieve the client's IP address
                    IPAddress clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address;
                    UMISystem.Log("UMI::CLIENTCONNECT()::IPADDRESS->" + clientIP.ToString());
                    //Add Player 
                    players.Add(i, client);
                    // index client
                    UMITCPHandlerThread.Start(players[i]);
                }
            }
           



        }
        // Receive
        private static void UMITCPHandler(object client)
        {
            UMIClient = (TcpClient)client;
            stream = UMIClient.GetStream();
            Byte[] message = new byte[1024];
            stream.Read(message, 0, message.Length);
            Debug.Log(Encoding.ASCII.GetString(message));
            UMITCPSend(stream, UMIClient);
        }

        //Send  

        private static void UMITCPSend(NetworkStream stream, TcpClient client)
        {
            string isConnect = "8";
            byte[] message = Encoding.ASCII.GetBytes(isConnect);
            stream.Write(message, 0, message.Length);
           
            byte[] id = Encoding.ASCII.GetBytes(UID.ToString());
            stream.Write(id, 0, id.Length);
        }

        private static void UMIDisconnect()
        {
            UMIClient.Close();
            stream.Close();

        }
        private void OnApplicationQuit()
        {
            UMITCPListener.Stop();
            UMIDisconnect();
        }

    }

}