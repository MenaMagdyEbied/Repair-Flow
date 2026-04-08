using Microsoft.EntityFrameworkCore;
using RepairFlow.Models;

namespace RepairFlow.DAL
{
    public static class SparePartSearchHelper
    {
        public static List<SparePartSearchResult> Search(AppDbContext context, string query)
        {
            query = query.Trim().ToLower();

            var parts = context.SpareParts.AsQueryable();

            if (!string.IsNullOrEmpty(query))
            {
                parts = parts.Where(p =>
                    p.Name.ToLower().Contains(query) ||
                    p.Type.ToLower().Contains(query) ||
                    p.Code.ToLower().Contains(query));
            }

            return parts
                .OrderBy(p => p.Type)
                .ThenBy(p => p.Name)
                .Select(p => new SparePartSearchResult
                {
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name,
                    Type = p.Type,
                    SellingPrice = p.SellingPrice,   
                    Quantity = p.Quantity,
                    IsAvailable = p.Quantity > 0,
                }).ToList();
        }

        public static SparePart? GetById(AppDbContext context, int id)
            => context.SpareParts.Find(id);
        public static List<string> GetBrands(AppDbContext context)
        {
            return context.SpareParts
                .Select(p => p.Type.Contains("—")
                    ? p.Type.Substring(0, p.Type.IndexOf("—")).Trim()
                    : p.Type.Trim())
                .Distinct()
                .OrderBy(b => b)
                .ToList();
        }

        public static List<string> GetPartTypes(AppDbContext context, string brand)
        {
            return context.SpareParts
                .Where(p => p.Type.StartsWith(brand))
                .Select(p => p.Type.Contains("—")
                    ? p.Type.Substring(p.Type.IndexOf("—") + 1).Trim()
                    : p.Type.Trim())
                .Distinct()
                .OrderBy(t => t)
                .ToList();
        }
    }

    public class SparePartSearchResult
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal SellingPrice { get; set; }  
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
        public string AvailabilityText => IsAvailable ? $"متوفر ({Quantity})" : "نافد ⚠";
    }
}
