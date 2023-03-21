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
    resStartGame ,
}

// Receive from client
public enum YUMIClientPackets
{
    getRespon = 1,
    reqSpawnPlayer  ,
    reqPlayerMovement,
    reqDisconnect,   
    reqAnimation  , 
    getConnectLobby ,
    reqCancelPlayer , 
    reqLeaveRoom , 
    reqIsFUll ,
    reqReady,
    reqCancelReady,
    reqStartGame , 
}