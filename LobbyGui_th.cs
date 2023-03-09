
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
            case 03: result = "สร้างห้อง"; break;
            case 04: result = "ย้อนกลับ"; break;
            case 05: result = "กำลังโหลดข้อมูล"; break;
            case 06: result = "กำลังเชื่อต่อ"; break;
            case 07: result = "ไม่พบเซิฟเวอร์"; break;
            default: return result; 
        }
        return result; 
    }
}
