namespace UMI.Network.Server
{
    // Update Data Player
    class UMIGameLogic 
    {
        public static void UMIUpdate()
        {
            foreach (UMIServerManager client in UMIServer.clients.Values)
            {
                if (client.player != null)
                {
                    client.player.UMIUpdate();
                }
            }
           
        }
    }
}