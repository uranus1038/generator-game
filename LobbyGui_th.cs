
public class LobbyGui_th
{
    public static string getMessage(int nMessage)
    {
        string result = null;
        switch (nMessage)
        {
            case 00: result = "���"; break;
            case 01: result = "������͡"; break;
            case 02: result = "�͡��"; break;
            case 03: result = "���ҧ��ͧ"; break;
            case 04: result = "��͹��Ѻ"; break;
            case 05: result = "���ѧ��Ŵ������"; break;
            case 06: result = "���ѧ���͵��"; break;
            case 07: result = "��辺�Կ�����"; break;
            case 08: result = "���ҧ��ͧ"; break;
            case 09: result = "������¤�"; break;
            case 10: result = "�������"; break;
            case 11:
                if (UMI.Network.API.UMIData.getStringPlayerData(2) == "male")
                {
                    result = "����Ф��� : �����";
                }
                else
                {
                    result = "����Ф��� : ���˭ԧ";
                }
                break;
            case 12: result = "Mode : Normal"; break;
            case 13: result = "Type : Adventure , Puzzle"; break;
            case 14: result = "�ͧ�Ѻ�����������Ẻ ip fowarding ,"; break;
            case 15: result = "LAN , VPN , HAMACHI"; break;
            case 16: result = "IP"; break;
            case 17: result = "�س�١�ԭ�͡�ҡ�ҵ��!"; break;
            case 18: result = "�١�Ѵ�͡�ҡ�Կ�����"; break;
            case 19: result = "�����"; break;
            case 20: result = "��"; break;
            case 21: result = "¡��ԡ"; break;
            case 22: result = "�������"; break;
            case 23: result = "�����"; break;
            case 24: result = "�Կ��������"; break;
            default: return result;
        }
        return result;
    }
}
