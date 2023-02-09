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
        private static TcpListener UMITCPListener;
        // Data
        private static NetworkStream stream; 
        // Client
        private static  TcpClient UMIClient ;
        //receive
        protected static string userName = "GOD`U"; 

        private void Awake()
        {
            hInst = this; 
        }

        protected virtual void UMIReceive() { }

        public static void UMISartHost(int maxPlayer, int port)
        {
            UMI.Log("UMI::SUSSESSED()::SERVER_STRAT->"+port);
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
            
            for(int i =0 ; i < UMIMaxPlayer; i++)
            {
                TcpClient client = UMITCPListener.AcceptTcpClient();
                Thread UMITCPHandlerThread = new Thread(new ParameterizedThreadStart(UMITCPHandler));
                // index client
                UMITCPHandlerThread.Start(client);
                // Retrieve the client's IP address
                IPAddress clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address;
                UMI.Log("UMI::CLIENTCONNECT()::IPADDRESS->"+clientIP.ToString());
            }
        }
        // Receive
        private static void UMITCPHandler(object client)
        {
            UMIClient = (TcpClient)client;
            stream = UMIClient.GetStream();
            Byte[]message = new byte[1024] ;
            stream.Read(message, 0, message.Length);
            Debug.Log(Encoding.ASCII.GetString(message));
            UMITCPSend(stream,UMIClient);
        }

        //Send

        private static void UMITCPSend(NetworkStream stream , TcpClient client)
        {
            string isConnect = "8";
            byte[] message = Encoding.ASCII.GetBytes(isConnect);
            stream.Write(message, 0, message.Length);
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