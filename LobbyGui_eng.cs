

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
            default: return result;
        }
        return result;
    }

}
