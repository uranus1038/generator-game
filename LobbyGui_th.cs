
public class LobbyGui_th
{
    public static string getMessage(int nMessage)
    {
        string result = null;
        switch(nMessage)
        {
            case 00: result = "���"; break;
            case 01:  result= "������͡";  break;
            case 02: result = "�͡��"; break;
            default: return result; 
        }
        return result; 
    }
}
