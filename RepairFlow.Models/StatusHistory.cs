namespace RepairFlow.Models
{
    public class StatusHistory
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public Device Device { get; set; } = null!;
        public RepairStatus OldStatus { get; set; }
        public RepairStatus NewStatus { get; set; }
        public DateTime ChangedAt { get; set; } = DateTime.Now;
        public string? Note { get; set; }
    }
}
