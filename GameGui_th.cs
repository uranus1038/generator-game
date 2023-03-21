
public class GameGui_th
{
    public static string getMessage(int nMessage)
    {
        string result = string.Empty;
        switch (nMessage)
        {
            case 00: result = "พุ่งตัว : เคลื่อนที่ในระยะทางสั้น ๆ \nอย่างรวดเร็วในทิศทางที่กำหนด"; break;
            case 01: result = "สมุดนำทางนำทาง : ดูภารกิจที่ต้องทำในบทนั้น"; break;
            case 02: result = "สเปรย์ : ทำให้คุณวิ่งเร็วขึ้นเป็นเวลา 30 วินาที"; break;
            case 03: result = "พุ่งตัว"; break;
            case 04: result = "สมุดนำทางนำทาง"; break;
            case 05: result = "สเปรย์"; break;
            default: return result;
        }
        return result;
    }
}
