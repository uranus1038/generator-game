
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
            default: return result;
        }
        return result;
    }
}
