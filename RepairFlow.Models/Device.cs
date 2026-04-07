namespace RepairFlow.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string ReceiptNumber { get; set; } = string.Empty;
        public string DeviceName { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Fault { get; set; } = string.Empty;
        public string? Accessories { get; set; }

        public RepairStatus Status { get; set; } = RepairStatus.NewArrival;
        public DateTime ReceivedAt { get; set; } = DateTime.Now;
        public DateTime? DeliveredAt { get; set; }

        public decimal? RepairCost { get; set; }
        public decimal? PaidAmount { get; set; }
        public int WarrantyMonths { get; set; } = 0;

        // FK
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        // Navigation
        public ICollection<DeviceSparePart> DeviceSpareParts { get; set; } = new List<DeviceSparePart>();
        public ICollection<StatusHistory>   StatusHistories  { get; set; } = new List<StatusHistory>();
    }
}
