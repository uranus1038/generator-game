// Receive from server
public enum YUMIServerPackets
{
    resServer = 1,
    resSpawnPlayer,
    resPlayerPosition
  , resPlayerRotation,
    resDisconnect,
    resAnimation ,
    resSpawnPlayerLobby,
    resCancelPlayer , 
    resLeaveRoom , 
    resIsFull , 
    resReady , 
    resCancelReady , 
}

// Receive from client
public enum YUMIClientPackets
{
    getRespon = 1,
    reqPlayerMovement,
    reqDisconnect,   
    reqSpawnPlayer  ,
    reqAnimation  , 
    getConnectLobby ,
    reqCancelPlayer , 
    reqLeaveRoom , 
    reqIsFUll ,
    reqReady,
    reqCancelReady,
}