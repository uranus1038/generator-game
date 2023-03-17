
public class LobbyGui_th
{
    public static string getMessage(int nMessage)
    {
        string result = null;
        switch (nMessage)
        {
            case 00: result = "เล่น"; break;
            case 01: result = "ตัวเลือก"; break;
            case 02: result = "ออกเกม"; break;
            case 03: result = "สร้างห้อง"; break;
            case 04: result = "ย้อนกลับ"; break;
            case 05: result = "กำลังโหลดข้อมูล"; break;
            case 06: result = "กำลังเชื่อต่อ"; break;
            case 07: result = "ไม่พบเซิฟเวอร์"; break;
            case 08: result = "สร้างห้อง"; break;
            case 09: result = "เล่นหลายคน"; break;
            case 10: result = "เข้าร่วม"; break;
            case 11:
                if (UMI.Network.API.UMIData.getStringPlayerData(2) == "male")
                {
                    result = "ตัวละครเพศ : ผู้ชาย";
                }
                else
                {
                    result = "ตัวละครเพศ : ผู้หญิง";
                }
                break;
            case 12: result = "Mode : Normal"; break;
            case 13: result = "Type : Adventure , Puzzle"; break;
            case 14: result = "รองรับการเชื่อมต่อแบบ ip fowarding ,"; break;
            case 15: result = "LAN , VPN , HAMACHI"; break;
            case 16: result = "IP"; break;
            case 17: result = "คุณถูกเชิญออกจากปาตี้!"; break;
            case 18: result = "ถูกตัดออกจากเซิฟเวอร์"; break;
            case 19: result = "พร้อม"; break;
            case 20: result = "รอ"; break;
            case 21: result = "ยกเลิก"; break;
            case 22: result = "เริ่มเกม"; break;
            case 23: result = "พร้อม"; break;
            case 24: result = "เซิฟเวอร์เต็ม"; break;
            default: return result;
        }
        return result;
    }
}
