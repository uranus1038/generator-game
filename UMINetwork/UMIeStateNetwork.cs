// Receive from server
public enum YUMIServerPackets
{
    resServer = 1,
    resSpawnPlayer,
    resPlayerPosition
  , resPlayerRotation,
    resDisconnect,
    
}

// Receive from client
public enum YUMIClientPackets
{
    getRespon = 1,
    reqPlayerMovement,
    reqDisconnect,   
    reqSpawnPlayer  ,

}