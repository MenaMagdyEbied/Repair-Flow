using RepairFlow.BLL.Services.Interfaces;
using RepairFlow.DAL.Repositories;
using RepairFlow.Models;

namespace RepairFlow.BLL.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashRepo;

        public DashboardService(IDashboardRepository dashRepo)
        {
            _dashRepo = dashRepo;
        }

        public DashboardStats GetDashboardStats()
        {
            return new DashboardStats
            {
                // بطاقات الإحصائيات
                AverageRepairDays    = Math.Round(_dashRepo.GetAverageRepairDays(), 1),
                TotalRevenue         = _dashRepo.GetTotalRevenue(),
                DeliveredCount       = _dashRepo.CountByStatus(RepairStatus.Delivered),
                TotalReceipts        = _dashRepo.CountAll(),

                // توزيع الحالات
                NewArrivalCount      = _dashRepo.CountByStatus(RepairStatus.NewArrival),
                UnderInspectionCount = _dashRepo.CountByStatus(RepairStatus.UnderInspection),
                UnderRepairCount     = _dashRepo.CountByStatus(RepairStatus.UnderRepair),
                ReadyCount           = _dashRepo.CountByStatus(RepairStatus.Ready),

                // الرسوم البيانية
                MonthlyRevenues      = _dashRepo.GetMonthlyRevenues(6),
                TopDevices           = _dashRepo.GetTopDevices(5),

                // جدول الإيصالات الأخيرة
                RecentReceipts       = _dashRepo.GetRecentReceipts(10),

                // المخزون
                TotalSparePartsCount = _dashRepo.GetTotalSparePartsCount(),
                LowStockCount        = _dashRepo.GetLowStockCount(),
                OutOfStockCount      = _dashRepo.GetOutOfStockCount(),
                TotalInventoryValue  = _dashRepo.GetTotalInventoryValue(),
            };
        }
    }
}
