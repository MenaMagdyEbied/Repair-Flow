namespace RepairFlow.Models
{
    public class DeviceSparePart
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public Device Device { get; set; } = null!;
        public int SparePartId { get; set; }
        public SparePart SparePart { get; set; } = null!;
        public int  QuantityUsed { get; set; } = 1;
        public decimal UnitPrice { get; set; }
        public DateTime UsedAt { get; set; } = DateTime.Now;
    }
}
