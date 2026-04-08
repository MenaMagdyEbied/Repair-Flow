using RepairFlow.BLL.Services.Interfaces;
using RepairFlow.Models;
using System.Net;

namespace RepairFlow.BLL.Services
{
    public class WhatsAppService : IWhatsAppService
    {
        public string GenerateWhatsAppUrl(Device device)
        {
            if (device?.Customer == null) return string.Empty;

            var statusStr = MapStatusToArabic(device.Status);

            var message = $"مرحباً، هذه رسالة من مركز الصيانة RepairFlow\n" +
                          $"رقم الإيصال: {device.ReceiptNumber}\n" +
                          $"الجهاز: {device.DeviceName} • {device.Model}\n" +
                          $"الحالة: {statusStr}\n" +
                          $"شكراً لتعاملكم معنا 🔧";
            
            var phone = device.Customer.Phone.Trim().Replace(" ", "");
            if (phone.StartsWith("0")) phone = "2" + phone; 

            return $"https://wa.me/{phone}?text={WebUtility.UrlEncode(message)}";
        }

        private static string MapStatusToArabic(RepairStatus status) => status switch
        {
            RepairStatus.NewArrival => "وارد جديد",
            RepairStatus.UnderInspection => "قيد الفحص",
            RepairStatus.UnderRepair => "تحت الإصلاح",
            RepairStatus.Ready  => "جاهز",
            RepairStatus.Delivered => "تم التسليم",
            _   => "—"
        };
    }
}
