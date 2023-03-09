

public class LobbyGui_eng 
{
    public static string getMessage(int nMessage)
    {
        string result = null;
        switch (nMessage)
        {
            case 00: result = "PLAY"; break;
            case 01: result = "OPTION"; break;
            case 02: result = "QUIT"; break;
            case 03: result = "Create"; break;
            case 04: result = "Back"; break;
            case 05: result = "Loading Data "; break;
            case 06: result = "Connecting"; break;
            default: return result;
        }
        return result;
    }

}
