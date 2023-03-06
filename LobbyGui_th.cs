
public class LobbyGui_th
{
    public static string getMessage(int nMessage)
    {
        string result = null;
        switch(nMessage)
        {
            case 00: result = "เล่น"; break;
            case 01:  result= "ตัวเลือก";  break;
            case 02: result = "ออกเกม"; break;
            default: return result; 
        }
        return result; 
    }
}
