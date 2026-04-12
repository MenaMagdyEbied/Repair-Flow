namespace RepairFlow.Models
{
    /// <summary>
    /// يحتوي على كل البيانات المطلوبة لعرضها في لوحة التحكم (Dashboard)
    /// </summary>
    public class DashboardStats
    {
        // ── بطاقات الإحصائيات ───────────────────────────────────
        /// <summary>متوسط وقت الإصلاح بالأيام (للأجهزة المسلَّمة فقط)</summary>
        public double AverageRepairDays { get; set; }

        /// <summary>إجمالي الإيرادات (RepairCost للأجهزة المسلَّمة)</summary>
        public decimal TotalRevenue { get; set; }

        /// <summary>عدد الأجهزة التي تم تسليمها</summary>
        public int DeliveredCount { get; set; }

        /// <summary>إجمالي عدد الإيصالات</summary>
        public int TotalReceipts { get; set; }

        // ── عدد الأجهزة حسب الحالة ──────────────────────────────
        public int NewArrivalCount      { get; set; }
        public int UnderInspectionCount { get; set; }
        public int UnderRepairCount     { get; set; }
        public int ReadyCount           { get; set; }

        // ── الإيرادات الشهرية (آخر 6 أشهر) ─────────────────────
        public List<MonthlyRevenue> MonthlyRevenues { get; set; } = new();

        // ── أكثر الأجهزة صيانة ──────────────────────────────────
        public List<DeviceTypeCount> TopDevices { get; set; } = new();

        // ── آخر الإيصالات ────────────────────────────────────────
        public List<RecentReceipt> RecentReceipts { get; set; } = new();

        // ── المخزون ──────────────────────────────────────────────
        public int     TotalSparePartsCount { get; set; }
        public int     LowStockCount        { get; set; }
        public int     OutOfStockCount      { get; set; }
        public decimal TotalInventoryValue  { get; set; }
    }

    public class MonthlyRevenue
    {
        public string  MonthLabel { get; set; } = string.Empty;
        public decimal Revenue    { get; set; }
    }

    public class DeviceTypeCount
    {
        public string DeviceName { get; set; } = string.Empty;
        public int    Count      { get; set; }
    }

    public class RecentReceipt
    {
        public string   ReceiptNumber { get; set; } = string.Empty;
        public string   CustomerName  { get; set; } = string.Empty;
        public string   CustomerPhone { get; set; } = string.Empty;
        public string   DeviceName    { get; set; } = string.Empty;
        public string   StatusArabic  { get; set; } = string.Empty;
        public DateTime ReceivedAt    { get; set; }
        public decimal? RepairCost    { get; set; }
    }
}
