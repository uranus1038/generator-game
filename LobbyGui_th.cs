
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
            case 03: result = "���ҧ��ͧ"; break;
            case 04: result = "��͹��Ѻ"; break;
            case 05: result = "���ѧ��Ŵ������"; break;
            case 06: result = "���ѧ���͵��"; break;
            default: return result; 
        }
        return result; 
    }
}
