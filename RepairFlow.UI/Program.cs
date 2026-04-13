using Microsoft.EntityFrameworkCore;
using RepairFlow.BLL.Services;
using RepairFlow.DAL;
using RepairFlow.DAL.Repositories;

namespace RepairFlow.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // ── Migrate & Seed ────────────────────────────────────────────────
            using (var ctx = new AppDbContext())
            {
                ctx.Database.Migrate();
                DbInitializer.Seed(ctx);
            }

            // ── Dependency Injection ──────────────────────────────────────────
            var dbContext        = new AppDbContext();

            var deviceRepo       = new DeviceRepository(dbContext);
            var partRepo         = new SparePartRepository(dbContext);
            var customerRepo     = new CustomerRepository(dbContext);
            var dashboardRepo    = new DashboardRepository(dbContext);

            var deviceService    = new DeviceService(deviceRepo, partRepo, customerRepo);
            var partService      = new SparePartService(partRepo);
            var dashboardService = new DashboardService(dashboardRepo);
            var waService        = new WhatsAppService();
            var printService     = new PrintService();
            var backupService    = new BackupService();

            Application.Run(new Forms.MainForm(
                deviceService,
                partService,
                dashboardService,
                waService,
                printService,
                backupService));
        }
    }
}
