public class C001_TheDoorWasOpened_th
{
    public static string getMessage(int nMessage)
    {
        string result = string.Empty;
        switch (nMessage)
        {
            case 100: result = "������ͷ���˹�ѹ !?"; break;
            default: return result;
        }
        return result;
    }
}
