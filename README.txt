HOW TO OPEN:
  1. Open THIS folder: RepairFlow-Final
  2. Double-click: RepairFlow.sln
  3. Build → Rebuild Solution  (Ctrl+Shift+B)
  4. Run (F5)

IMPORTANT - If you see errors about:
  - AddDeviceWithCustomer
  - GetAllWithCustomers  
  - GetNextReceiptNumber
  
  → You opened the WRONG project (the old ZIP version).
  → Close that solution and open RepairFlow.sln from THIS folder.

REQUIREMENTS:
  - Visual Studio 2022+
  - .NET 8 SDK (net8.0-windows)
  - SQL Server (LocalDB or full)
  - Connection string: AppDbContext.cs
    Server=.;Database=RepairFlowDB;Trusted_Connection=True;TrustServerCertificate=True;

DATABASE:
  - Migrations run automatically on startup via Program.cs
  - Seed data (sample customers, devices, spare parts) added automatically

ARCHITECTURE:
  RepairFlow.Models  → Entities (Device, Customer, SparePart, etc.)
  RepairFlow.DAL     → Repositories + EF Core (interfaces: IDeviceRepository, etc.)
  RepairFlow.BLL     → Services + Interfaces (IDeviceService, IPrintService, etc.)
  RepairFlow.UI      → WinForms UI (MainForm, ReciptForm)
