using RepairFlow.BLL.Services.Interfaces;
using RepairFlow.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;

namespace RepairFlow.BLL.Services
{
    public class BackupService : IBackupService
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        public void Backup(string filePath, List<Device> devices)
        {
            var json = JsonSerializer.Serialize(devices, Options);
            File.WriteAllText(filePath, json, Encoding.UTF8);
        }

        public List<Device> Restore(string filePath)
        {
            if (!File.Exists(filePath)) return new List<Device>();

            var json = File.ReadAllText(filePath, Encoding.UTF8);
            return JsonSerializer.Deserialize<List<Device>>(json, Options) ?? new List<Device>();
        }
    }
}
