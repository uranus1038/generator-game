using System;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace UMI.Network
{
    public class UMIClientReport : MonoBehaviour
    {
        //UID
        public static int UID ; 
        //Client
        private static TcpClient client;
        //Data
        private static NetworkStream stream;
        //Connect
        public static void UMIConnect()
        {
            Thread UMIClient = new Thread(new ThreadStart(UMIClientRuntime));
            UMIClient.Start();
            UMISystem.Log("UMI::SUCCESSED()::SERVER_CONNECT");
        }
        //Receive and Send
        private static void UMIClientRuntime()
        {
            client = new TcpClient();

            try
            {
                client.Connect(IPAddress.Parse("127.0.0.1"), 8000);
                stream = client.GetStream();

                string a = "{Message:requastConnect}";
                byte[] message = Encoding.ASCII.GetBytes(a);
                stream.Write(message, 0, message.Length);

                byte[] recevie = new byte[1024];
                stream.Read(recevie, 0, recevie.Length);
                UMISystem.Log(Encoding.ASCII.GetString(recevie));
                byte[] id = new byte[1024];
                stream.Read(id, 0, id.Length);
                UID = int.Parse(Encoding.ASCII.GetString(id));
                UMISystem.Log(UID);
                string isConnect = Encoding.ASCII.GetString(recevie);
                try
                {
                    float isConnected = float.Parse(isConnect);
                }
                catch
                {
                    UMISystem.Log("UMI::ERR()::SERVER_DOWN");
                    UMIDisconnect();
                }


            }
            catch (SocketException ex)
            {
                UMISystem.Log("UMI::ERR()::SERVER_DOWN->" + ex);
            }
        }

        private static void UMIDisconnect()
        {
            client.Close();
            stream.Close();
        }

        private void OnApplicationQuit()
        {
            UMIDisconnect();
        }
    }
}