using Microsoft.EntityFrameworkCore;
using RepairFlow.Models;

namespace RepairFlow.DAL.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly AppDbContext _context;

        public DashboardRepository(AppDbContext context)
        {
            _context = context;
        }

        // ────────────────────────────────────────────────────────
        //  إجمالي الإيرادات
        // ────────────────────────────────────────────────────────
        public decimal GetTotalRevenue()
        {
            return _context.Devices
                .Where(d => d.Status == RepairStatus.Delivered && d.RepairCost.HasValue)
                .Sum(d => (decimal?)d.RepairCost) ?? 0m;
        }

        // ────────────────────────────────────────────────────────
        //  عدد الأجهزة
        // ────────────────────────────────────────────────────────
        public int CountByStatus(RepairStatus status)
            => _context.Devices.Count(d => d.Status == status);

        public int CountAll()
            => _context.Devices.Count();

        // ────────────────────────────────────────────────────────
        //  متوسط وقت الإصلاح
        // ────────────────────────────────────────────────────────
        public double GetAverageRepairDays()
        {
            // نجلب الأجهزة المسلَّمة التي عندها تاريخ استلام وتسليم
            var days = _context.Devices
                .Where(d => d.Status == RepairStatus.Delivered && d.DeliveredAt.HasValue)
                .Select(d => EF.Functions.DateDiffDay(d.ReceivedAt, d.DeliveredAt!.Value))
                .ToList();

            return days.Count == 0 ? 0 : days.Average();
        }

        // ────────────────────────────────────────────────────────
        //  الإيرادات الشهرية (آخر N شهر)
        // ────────────────────────────────────────────────────────
        public List<MonthlyRevenue> GetMonthlyRevenues(int months = 6)
        {
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
                                .AddMonths(-(months - 1));

            // نجلب من DB مجمَّعة حسب السنة والشهر
            var raw = _context.Devices
                .Where(d => d.Status == RepairStatus.Delivered
                         && d.DeliveredAt.HasValue
                         && d.DeliveredAt!.Value >= startDate
                         && d.RepairCost.HasValue)
                .GroupBy(d => new
                {
                    Year  = d.DeliveredAt!.Value.Year,
                    Month = d.DeliveredAt!.Value.Month
                })
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    Revenue = g.Sum(d => d.RepairCost!.Value)
                })
                .ToList();

            // نبني قائمة كاملة لكل الأشهر (حتى لو ما فيش إيراد)
            var result = new List<MonthlyRevenue>();
            for (int i = 0; i < months; i++)
            {
                var date  = startDate.AddMonths(i);
                var found = raw.FirstOrDefault(r => r.Year == date.Year && r.Month == date.Month);
                result.Add(new MonthlyRevenue
                {
                    MonthLabel = GetArabicMonthName(date.Month, date.Year),
                    Revenue    = found?.Revenue ?? 0m
                });
            }

            return result;
        }

        // ────────────────────────────────────────────────────────
        //  أكثر الأجهزة صيانة
        // ────────────────────────────────────────────────────────
        public List<DeviceTypeCount> GetTopDevices(int top = 5)
        {
            return _context.Devices
                .GroupBy(d => d.DeviceName)
                .Select(g => new DeviceTypeCount
                {
                    DeviceName = g.Key,
                    Count      = g.Count()
                })
                .OrderByDescending(x => x.Count)
                .Take(top)
                .ToList();
        }

        // ────────────────────────────────────────────────────────
        //  آخر الإيصالات
        // ────────────────────────────────────────────────────────
        public List<RecentReceipt> GetRecentReceipts(int count = 10)
        {
            return _context.Devices
                .Include(d => d.Customer)
                .OrderByDescending(d => d.ReceivedAt)
                .Take(count)
                .Select(d => new RecentReceipt
                {
                    ReceiptNumber = d.ReceiptNumber,
                    CustomerName  = d.Customer.Name,
                    CustomerPhone = d.Customer.Phone,
                    DeviceName    = d.DeviceName,
                    StatusArabic  = MapStatusToArabic(d.Status),
                    ReceivedAt    = d.ReceivedAt,
                    RepairCost    = d.RepairCost
                })
                .ToList();
        }

        // ────────────────────────────────────────────────────────
        //  المخزون
        // ────────────────────────────────────────────────────────
        public int GetTotalSparePartsCount()
            => _context.SpareParts.Count();

        public int GetLowStockCount()
            => _context.SpareParts
               .Count(p => p.Quantity > 0 && p.Quantity < p.AlertThreshold);

        public int GetOutOfStockCount()
            => _context.SpareParts.Count(p => p.Quantity == 0);

        public decimal GetTotalInventoryValue()
            => _context.SpareParts
               .Sum(p => (decimal?)(p.PurchasePrice * p.Quantity)) ?? 0m;

        // ────────────────────────────────────────────────────────
        //  Helpers
        // ────────────────────────────────────────────────────────
        private static string MapStatusToArabic(RepairStatus status) => status switch
        {
            RepairStatus.NewArrival      => "وارد جديد",
            RepairStatus.UnderInspection => "قيد الفحص",
            RepairStatus.UnderRepair     => "تحت الإصلاح",
            RepairStatus.Ready           => "جاهز",
            RepairStatus.Delivered       => "تم التسليم",
            _                            => "غير معروف"
        };

        private static string GetArabicMonthName(int month, int year)
        {
            string[] names =
            {
                "يناير","فبراير","مارس","أبريل","مايو","يونيو",
                "يوليو","أغسطس","سبتمبر","أكتوبر","نوفمبر","ديسمبر"
            };
            return $"{names[month - 1]} {year}";
        }
    }
}
