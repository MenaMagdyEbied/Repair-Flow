using RepairFlow.Models;
using System.Drawing.Printing;

namespace RepairFlow.BLL.Services.Interfaces
{
    public interface IPrintService
    {
        void PrintReceipt(Device device, string savePath);
        void PreviewReceipt(Device device, string savePath);
    }
}
