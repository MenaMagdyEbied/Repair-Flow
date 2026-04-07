using Microsoft.EntityFrameworkCore;
using RepairFlow.DAL;

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

            Application.Run(new Forms.MainForm());
        }
    }
}
