using RepairFlow.Models;

namespace RepairFlow.BLL.Services.Interfaces
{
    public interface IBackupService
    {
        void Backup(string filePath, List<Device> devices);
        List<Device> Restore(string filePath);
    }
}
