public enum YUMIServerPackets
{
    welcome = 1,
    spawnPlayer,
    playerPosition
  , playerRotation,
    disConnectSv,
    hello , 
}

/// <summary>Sent from client to server.</summary>
public enum YUMIClientPackets
{
    welcomeReceived = 1,
    playerMovement,
    disConnectClient

}