
public class GameGui_eng
{
    public static string getMessage(int nMessage)
    {
        string result = string.Empty;
        switch (nMessage)
        {
            case 00: result = "Dash : quickly move a short distance -\nin a specific direction"; break;
            case 01: result = "Guide book : View the tasks -\nin the chapter."; break;
            case 02: result = "Spray : Makes you run -\nfaster for 30 seconds."; break;
            case 03: result = "Dash"; break;
            case 04: result = "Guide book"; break;
            case 05: result = "Spray"; break;
            default: return result;
        }
        return result;
    }
}
