namespace RepairFlow.Models
{  
    public class SparePart
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;  
        public string Name { get; set; } = string.Empty;  
        public string Type { get; set; } = string.Empty;  
        public int Quantity { get; set; } = 0; 
        public int AlertThreshold { get; set; } = 15;   
        public decimal PurchasePrice { get; set; } = 0;  
        public decimal SellingPrice { get; set; } = 0;   
        public decimal ProfitPerUnit => SellingPrice - PurchasePrice;
        public decimal TotalStockValue => PurchasePrice * Quantity;

        public StockStatus StockStatus => Quantity == 0 ? StockStatus.OutOfStock :
            Quantity < AlertThreshold  ? StockStatus.LowStock : StockStatus.Available;
        // Navigation
        public ICollection<DeviceSparePart> DeviceSpareParts { get; set; } = new List<DeviceSparePart>();
    }

    public enum StockStatus
    {
        Available  = 0,   
        LowStock   = 1,   
        OutOfStock = 2,   
    }
}
