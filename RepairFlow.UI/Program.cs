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

            using var context = new AppDbContext();
            context.Database.Migrate();
            DbInitializer.Seed(context);

            var dbContext        = new AppDbContext();
            var dashboardRepo    = new DashboardRepository(dbContext);
            var dashboardService = new DashboardService(dashboardRepo);

          
            Application.Run(new Forms.MainForm(dashboardService));
        }
    }
}
