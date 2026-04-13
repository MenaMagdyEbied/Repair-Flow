using RepairFlow.Models;

namespace RepairFlow.BLL.Services.Interfaces
{
    public interface IDashboardService
    {
        /// <summary>
        /// يجلب كل إحصائيات الـ Dashboard من قاعدة البيانات دفعة واحدة
        /// </summary>
        DashboardStats GetDashboardStats();
    }
}
