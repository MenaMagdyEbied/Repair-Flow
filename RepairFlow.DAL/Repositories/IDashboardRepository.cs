using RepairFlow.Models;

namespace RepairFlow.DAL.Repositories
{
    public interface IDashboardRepository
    {
        /// <summary>إجمالي الإيرادات من الأجهزة المسلَّمة</summary>
        decimal GetTotalRevenue();

        /// <summary>عدد الأجهزة حسب الحالة</summary>
        int CountByStatus(RepairStatus status);

        /// <summary>إجمالي عدد الأجهزة</summary>
        int CountAll();

        /// <summary>متوسط وقت الإصلاح بالأيام</summary>
        double GetAverageRepairDays();

        /// <summary>الإيرادات الشهرية لآخر N شهر</summary>
        List<MonthlyRevenue> GetMonthlyRevenues(int months = 6);

        /// <summary>أكثر أنواع الأجهزة التي خضعت للصيانة</summary>
        List<DeviceTypeCount> GetTopDevices(int top = 5);

        /// <summary>آخر N إيصال مُضاف</summary>
        List<RecentReceipt> GetRecentReceipts(int count = 10);

        // ── المخزون ─────────────────────────────────────────────
        int     GetTotalSparePartsCount();
        int     GetLowStockCount();
        int     GetOutOfStockCount();
        decimal GetTotalInventoryValue();
    }
}
