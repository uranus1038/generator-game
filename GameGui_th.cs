
public class GameGui_th
{
    public static string getMessage(int nMessage)
    {
        string result = string.Empty;
        switch (nMessage)
        {
            case 00: result = "��觵�� : ����͹�������зҧ��� � \n���ҧ�Ǵ����㹷�ȷҧ����˹�"; break;
            case 01: result = "��ش�ӷҧ�ӷҧ : ����áԨ����ͧ��㹺����"; break;
            case 02: result = "����� : �����س������Ǣ�������� 30 �Թҷ�"; break;
            case 03: result = "��觵��"; break;
            case 04: result = "��ش�ӷҧ�ӷҧ"; break;
            case 05: result = "�����"; break;
            default: return result;
        }
        return result;
    }
}
