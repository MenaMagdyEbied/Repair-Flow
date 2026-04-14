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

            using (var ctx = new AppDbContext())
            {
                ctx.Database.Migrate();
                DbInitializer.Seed(ctx);
            }

            var dbContext = new AppDbContext();

            var deviceRepo = new DeviceRepository(dbContext);
            var partRepo = new SparePartRepository(dbContext);
            var customerRepo = new CustomerRepository(dbContext);
            var dashboardRepo = new DashboardRepository(dbContext);

            var deviceService = new DeviceService(deviceRepo, partRepo, customerRepo);
            var partService = new SparePartService(partRepo);
            var dashboardService = new DashboardService(dashboardRepo);
            var waService = new WhatsAppService();
            var printService = new PrintService();
            var backupService = new BackupService();

            // Create the login form instance first so we can pass it to MainForm for logout navigation
            Forms.LoginForm? loginForm = null;

            loginForm = new Forms.LoginForm((username) =>
            {
                var mainForm = new Forms.MainForm(
                    deviceService,
                    partService,
                    dashboardService,
                    waService,
                    printService,
                    backupService,
                    loginForm!);

                mainForm.SetLoggedInUser(username);
                mainForm.Show();
            });

            // Show which SQL Server / Database the app will use (helps verify SSMS target)
            try
            {
                using var db = new DAL.AppDbContext();
                var conn = db.Database.GetDbConnection();
                System.Windows.Forms.MessageBox.Show($"App DB target:\nServer = {conn.DataSource}\nDatabase = {conn.Database}", "DB Target", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            catch { }

            Application.Run(loginForm);
            
        }
    }
}
