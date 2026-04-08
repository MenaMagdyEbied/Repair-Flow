using RepairFlow.Models;

namespace RepairFlow.BLL.Services.Interfaces
{
    public interface IWhatsAppService
    {
        string GenerateWhatsAppUrl(Device device);
    }
}
