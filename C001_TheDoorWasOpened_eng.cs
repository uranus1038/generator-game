public class C001_TheDoorWasOpened_eng
{
    public static string getMessage(int nMessage)
    {
        string result = string.Empty;
        switch (nMessage)
        {
            case 100: result = "Where is this place !?"; break;
            default: return result;
        }
        return result;
    }
}
