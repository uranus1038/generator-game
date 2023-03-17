

public class LobbyGui_eng 
{
    public static string getMessage(int nMessage)
    {
        string result = string.Empty;
        switch (nMessage)
        {
            case 00: result = "PLAY"; break;
            case 01: result = "OPTION"; break;
            case 02: result = "QUIT"; break;
            case 03: result = "Create"; break;
            case 04: result = "Back"; break;
            case 05: result = "Loading Data "; break;
            case 06: result = "Connecting"; break;
            case 07: result = "Server not found"; break;
            case 08: result = "Create Room"; break;
            case 09: result = "Mutiplayer"; break;
            case 10: result = "Join"; break;
            case 11:
                if (UMI.Network.API.UMIData.getStringPlayerData(2) == "male")
                {
                    result = "Character gender : male";
                }
                else
                {
                    result = "Character gender : female";
                }
                ; break;
            case 12: result = "Mode : Normal"; break;
            case 13: result = "Type : Adventure , Puzzle"; break;
            case 14: result = "Support connect ip fowarding ,"; break;
            case 15: result = "LAN , VPN , HAMACHI"; break;
            case 16: result = "IP"; break;
            case 17: result = "You are kicked from party!"; break;
            case 18: result = "Server Disconnect"; break;
            case 19: result = "Ready"; break;
            case 20: result = "Wait"; break;
            case 21: result = "CANCEL"; break;
            case 22: result = "START"; break;
            case 23: result = "READY"; break;
            case 24: result = "Server is full"; break;
            default: return result;
        }
        return result;
    }

}
