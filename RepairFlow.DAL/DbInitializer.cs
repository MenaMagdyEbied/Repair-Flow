using RepairFlow.Models;

namespace RepairFlow.DAL
{
    public static class DbInitializer
    {
        private const decimal ProfitMargin = 1.20m;

        private static decimal Sell(decimal purchase)
            => Math.Round(purchase * ProfitMargin, 0);

        public static void Seed(AppDbContext context)
        {
           
            if (!context.Customers.Any())
            {
                var customers = new List<Customer>
                {
                    new() { Name = "أحمد محمد علي",   Phone = "01501234567" },
                    new() { Name = "محمد إبراهيم",     Phone = "01500950666" },
                    new() { Name = "إبراهيم السيد",    Phone = "01111047409" },
                    new() { Name = "خالد عبد الرحمن",  Phone = "01211879522" },
                    new() { Name = "مريم خالد",        Phone = "01219985463" },
                    new() { Name = "أمير أحمد حسن",    Phone = "01005678901" },
                    new() { Name = "سارة محمود",       Phone = "01098765432" },
                    new() { Name = "عمر فاروق",        Phone = "01123456789" },
                    new() { Name = "ياسمين علي",       Phone = "01234567890" },
                    new() { Name = "حسام الدين",       Phone = "01345678901" },
                    new() { Name = "نورهان سامي",      Phone = "01456789012" },
                    new() { Name = "طارق عبد الله",    Phone = "01567890123" },
                    new() { Name = "منى حسن",          Phone = "01678901234" },
                    new() { Name = "كريم صلاح",        Phone = "01789012345" },
                    new() { Name = "دينا رمضان",       Phone = "01890123456" },
                    new() { Name = "محمود عاطف",       Phone = "01901234567" },
                    new() { Name = "رنا سعيد",         Phone = "01012345678" },
                    new() { Name = "وليد جمال",        Phone = "01187654321" },
                    new() { Name = "إسراء أحمد",       Phone = "01276543210" },
                    new() { Name = "شريف حسين",        Phone = "01365432109" },
                };
                context.Customers.AddRange(customers);
                context.SaveChanges();
            }

            // Seed spare parts only when the table is empty. Previously the code
            // re-inserted any missing seeded items on every startup which caused
            // user deletions/edits to be reverted when the app restarted.
            if (!context.SpareParts.Any())
            {
                var allParts = GetAllSpareParts();
                context.SpareParts.AddRange(allParts);
                context.SaveChanges();
            }

            if (!context.Devices.Any())
            {
                var customers = context.Customers.ToList();

                var devices = new List<Device>
                {
                    new() { ReceiptNumber="SR-2603-001", DeviceName="Samsung", Model="S24 Ultra",   Fault="شاشة مكسورة",         Accessories="كابل",    Status=RepairStatus.NewArrival,      ReceivedAt=new DateTime(2026,3,5,8,30,0),   CustomerId=customers[0].Id },
                    new() { ReceiptNumber="SR-2603-002", DeviceName="iPhone",  Model="15 Pro Max",  Fault="بطارية تنتهي سريعاً", Accessories="لا يوجد", Status=RepairStatus.NewArrival,      ReceivedAt=new DateTime(2026,3,5,10,0,0),   CustomerId=customers[1].Id },
                    new() { ReceiptNumber="SR-2603-003", DeviceName="Huawei",  Model="P60 Pro",     Fault="لا يشحن",              Accessories="لا يوجد", Status=RepairStatus.UnderInspection, ReceivedAt=new DateTime(2026,3,4,9,0,0),    CustomerId=customers[2].Id },
                    new() { ReceiptNumber="SR-2603-004", DeviceName="Samsung", Model="A55",         Fault="شاشة مكسورة",         Accessories="كابل شحن",Status=RepairStatus.UnderRepair,     ReceivedAt=new DateTime(2026,3,3,9,0,0),    CustomerId=customers[3].Id },
                    new() { ReceiptNumber="SR-2603-005", DeviceName="iPhone",  Model="14 Pro",      Fault="ميكروفون لا يعمل",    Accessories="لا يوجد", Status=RepairStatus.Ready,           ReceivedAt=new DateTime(2026,2,28,9,0,0),   RepairCost=1200, WarrantyMonths=3, CustomerId=customers[4].Id },
                    new() { ReceiptNumber="SR-2603-006", DeviceName="Oppo",    Model="Reno 10",     Fault="بوردة محترقة",         Accessories="لا يوجد", Status=RepairStatus.Delivered,       ReceivedAt=new DateTime(2026,2,20,9,0,0),   DeliveredAt=new DateTime(2026,2,25,10,0,0), RepairCost=900,  PaidAmount=900,  WarrantyMonths=3, CustomerId=customers[5].Id },
                    new() { ReceiptNumber="SR-2603-007", DeviceName="Realme",  Model="12 Pro",      Fault="شاشة مكسورة",         Accessories="لا يوجد", Status=RepairStatus.Delivered,       ReceivedAt=new DateTime(2026,2,18,10,0,0),  DeliveredAt=new DateTime(2026,2,23,9,0,0),  RepairCost=840,  PaidAmount=840,  WarrantyMonths=3, CustomerId=customers[6].Id },
                    new() { ReceiptNumber="SR-2603-008", DeviceName="Infinix", Model="Note 40 Pro", Fault="لا يعمل",              Accessories="كابل",    Status=RepairStatus.Delivered,       ReceivedAt=new DateTime(2026,2,15,11,0,0),  DeliveredAt=new DateTime(2026,2,19,12,0,0), RepairCost=720,  PaidAmount=720,  WarrantyMonths=1, CustomerId=customers[7].Id },
                    new() { ReceiptNumber="SR-2603-009", DeviceName="Sony",    Model="Xperia 5 V",  Fault="شاشة مكسورة",         Accessories="لا يوجد", Status=RepairStatus.Delivered,       ReceivedAt=new DateTime(2026,2,10,9,0,0),   DeliveredAt=new DateTime(2026,2,16,10,0,0), RepairCost=3000, PaidAmount=3000, WarrantyMonths=6, CustomerId=customers[8].Id },
                    new() { ReceiptNumber="SR-2603-010", DeviceName="Samsung", Model="S23",         Fault="كاميرا لا تعمل",      Accessories="لا يوجد", Status=RepairStatus.Delivered,       ReceivedAt=new DateTime(2026,1,20,9,0,0),   DeliveredAt=new DateTime(2026,1,25,10,0,0), RepairCost=960,  PaidAmount=960,  WarrantyMonths=3, CustomerId=customers[9].Id },
                };
                context.Devices.AddRange(devices);
                context.SaveChanges();
            }
        }

     
        private static List<SparePart> GetAllSpareParts() => new()
        {
            new() { Code="SAM-S24U-SCR",   Name="Samsung S24 Ultra — شاشة",        Type="Samsung — شاشات",    Quantity=3,  AlertThreshold=2, PurchasePrice=2500, SellingPrice=Sell(2500) },
            new() { Code="SAM-S24-SCR",    Name="Samsung S24 — شاشة",              Type="Samsung — شاشات",    Quantity=4,  AlertThreshold=2, PurchasePrice=1800, SellingPrice=Sell(1800) },
            new() { Code="SAM-S23U-SCR",   Name="Samsung S23 Ultra — شاشة",        Type="Samsung — شاشات",    Quantity=3,  AlertThreshold=2, PurchasePrice=2200, SellingPrice=Sell(2200) },
            new() { Code="SAM-S23-SCR",    Name="Samsung S23 — شاشة",              Type="Samsung — شاشات",    Quantity=5,  AlertThreshold=2, PurchasePrice=1600, SellingPrice=Sell(1600) },
            new() { Code="SAM-S22-SCR",    Name="Samsung S22 — شاشة",              Type="Samsung — شاشات",    Quantity=4,  AlertThreshold=2, PurchasePrice=1400, SellingPrice=Sell(1400) },
            new() { Code="SAM-A55-SCR",    Name="Samsung A55 — شاشة",              Type="Samsung — شاشات",    Quantity=6,  AlertThreshold=3, PurchasePrice=900,  SellingPrice=Sell(900)  },
            new() { Code="SAM-A54-SCR",    Name="Samsung A54 — شاشة",              Type="Samsung — شاشات",    Quantity=7,  AlertThreshold=3, PurchasePrice=850,  SellingPrice=Sell(850)  },
            new() { Code="SAM-A34-SCR",    Name="Samsung A34 — شاشة",              Type="Samsung — شاشات",    Quantity=5,  AlertThreshold=3, PurchasePrice=700,  SellingPrice=Sell(700)  },
            new() { Code="SAM-A15-SCR",    Name="Samsung A15 — شاشة",              Type="Samsung — شاشات",    Quantity=8,  AlertThreshold=3, PurchasePrice=450,  SellingPrice=Sell(450)  },
            new() { Code="SAM-A05-SCR",    Name="Samsung A05 — شاشة",              Type="Samsung — شاشات",    Quantity=6,  AlertThreshold=3, PurchasePrice=380,  SellingPrice=Sell(380)  },

            new() { Code="SAM-S24U-BAT",   Name="Samsung S24 Ultra — بطارية",      Type="Samsung — بطاريات",  Quantity=5,  AlertThreshold=3, PurchasePrice=350,  SellingPrice=Sell(350)  },
            new() { Code="SAM-S24-BAT",    Name="Samsung S24 — بطارية",            Type="Samsung — بطاريات",  Quantity=6,  AlertThreshold=3, PurchasePrice=280,  SellingPrice=Sell(280)  },
            new() { Code="SAM-S23-BAT",    Name="Samsung S23 — بطارية",            Type="Samsung — بطاريات",  Quantity=7,  AlertThreshold=3, PurchasePrice=250,  SellingPrice=Sell(250)  },
            new() { Code="SAM-A55-BAT",    Name="Samsung A55 — بطارية",            Type="Samsung — بطاريات",  Quantity=8,  AlertThreshold=3, PurchasePrice=180,  SellingPrice=Sell(180)  },
            new() { Code="SAM-A54-BAT",    Name="Samsung A54 — بطارية",            Type="Samsung — بطاريات",  Quantity=10, AlertThreshold=3, PurchasePrice=170,  SellingPrice=Sell(170)  },
            new() { Code="SAM-A34-BAT",    Name="Samsung A34 — بطارية",            Type="Samsung — بطاريات",  Quantity=10, AlertThreshold=3, PurchasePrice=150,  SellingPrice=Sell(150)  },
            new() { Code="SAM-A15-BAT",    Name="Samsung A15 — بطارية",            Type="Samsung — بطاريات",  Quantity=12, AlertThreshold=4, PurchasePrice=120,  SellingPrice=Sell(120)  },

            new() { Code="SAM-S24U-BRD",   Name="Samsung S24 Ultra — بوردة",       Type="Samsung — بورد",     Quantity=2,  AlertThreshold=1, PurchasePrice=3500, SellingPrice=Sell(3500) },
            new() { Code="SAM-S23-BRD",    Name="Samsung S23 — بوردة",             Type="Samsung — بورد",     Quantity=2,  AlertThreshold=1, PurchasePrice=2800, SellingPrice=Sell(2800) },
            new() { Code="SAM-A55-BRD",    Name="Samsung A55 — بوردة",             Type="Samsung — بورد",     Quantity=3,  AlertThreshold=1, PurchasePrice=1500, SellingPrice=Sell(1500) },
            new() { Code="SAM-A54-CHG",    Name="Samsung A54 — شاحن داخلي",        Type="Samsung — شواحن",    Quantity=8,  AlertThreshold=3, PurchasePrice=200,  SellingPrice=Sell(200)  },
            new() { Code="SAM-A15-CHG",    Name="Samsung A15 — شاحن داخلي",        Type="Samsung — شواحن",    Quantity=10, AlertThreshold=4, PurchasePrice=150,  SellingPrice=Sell(150)  },
            new() { Code="SAM-S23-CAM",    Name="Samsung S23 — كاميرا خلفية",      Type="Samsung — كاميرات",  Quantity=3,  AlertThreshold=2, PurchasePrice=800,  SellingPrice=Sell(800)  },
            new() { Code="SAM-A55-CAM",    Name="Samsung A55 — كاميرا خلفية",      Type="Samsung — كاميرات",  Quantity=4,  AlertThreshold=2, PurchasePrice=500,  SellingPrice=Sell(500)  },
            new() { Code="SAM-A54-SPK",    Name="Samsung A54 — سماعة داخلية",      Type="Samsung — سماعات",   Quantity=10, AlertThreshold=4, PurchasePrice=80,   SellingPrice=Sell(80)   },
            new() { Code="SAM-A15-SPK",    Name="Samsung A15 — سماعة داخلية",      Type="Samsung — سماعات",   Quantity=12, AlertThreshold=4, PurchasePrice=60,   SellingPrice=Sell(60)   },

            new() { Code="IPH-15PM-SCR",   Name="iPhone 15 Pro Max — شاشة",        Type="iPhone — شاشات",     Quantity=2,  AlertThreshold=1, PurchasePrice=4500, SellingPrice=Sell(4500) },
            new() { Code="IPH-15P-SCR",    Name="iPhone 15 Pro — شاشة",            Type="iPhone — شاشات",     Quantity=2,  AlertThreshold=1, PurchasePrice=3800, SellingPrice=Sell(3800) },
            new() { Code="IPH-15-SCR",     Name="iPhone 15 — شاشة",                Type="iPhone — شاشات",     Quantity=3,  AlertThreshold=2, PurchasePrice=3000, SellingPrice=Sell(3000) },
            new() { Code="IPH-14PM-SCR",   Name="iPhone 14 Pro Max — شاشة",        Type="iPhone — شاشات",     Quantity=3,  AlertThreshold=2, PurchasePrice=3500, SellingPrice=Sell(3500) },
            new() { Code="IPH-14P-SCR",    Name="iPhone 14 Pro — شاشة",            Type="iPhone — شاشات",     Quantity=3,  AlertThreshold=2, PurchasePrice=2800, SellingPrice=Sell(2800) },
            new() { Code="IPH-14-SCR",     Name="iPhone 14 — شاشة",                Type="iPhone — شاشات",     Quantity=4,  AlertThreshold=2, PurchasePrice=2200, SellingPrice=Sell(2200) },
            new() { Code="IPH-13PM-SCR",   Name="iPhone 13 Pro Max — شاشة",        Type="iPhone — شاشات",     Quantity=4,  AlertThreshold=2, PurchasePrice=2500, SellingPrice=Sell(2500) },
            new() { Code="IPH-13-SCR",     Name="iPhone 13 — شاشة",                Type="iPhone — شاشات",     Quantity=5,  AlertThreshold=2, PurchasePrice=1800, SellingPrice=Sell(1800) },
            new() { Code="IPH-12-SCR",     Name="iPhone 12 — شاشة",                Type="iPhone — شاشات",     Quantity=5,  AlertThreshold=2, PurchasePrice=1500, SellingPrice=Sell(1500) },
            new() { Code="IPH-11-SCR",     Name="iPhone 11 — شاشة",                Type="iPhone — شاشات",     Quantity=6,  AlertThreshold=3, PurchasePrice=1200, SellingPrice=Sell(1200) },
            new() { Code="IPH-XS-SCR",     Name="iPhone XS — شاشة",                Type="iPhone — شاشات",     Quantity=5,  AlertThreshold=2, PurchasePrice=1000, SellingPrice=Sell(1000) },

            new() { Code="IPH-15PM-BAT",   Name="iPhone 15 Pro Max — بطارية",      Type="iPhone — بطاريات",   Quantity=5,  AlertThreshold=3, PurchasePrice=600,  SellingPrice=Sell(600)  },
            new() { Code="IPH-15-BAT",     Name="iPhone 15 — بطارية",              Type="iPhone — بطاريات",   Quantity=6,  AlertThreshold=3, PurchasePrice=500,  SellingPrice=Sell(500)  },
            new() { Code="IPH-14PM-BAT",   Name="iPhone 14 Pro Max — بطارية",      Type="iPhone — بطاريات",   Quantity=6,  AlertThreshold=3, PurchasePrice=550,  SellingPrice=Sell(550)  },
            new() { Code="IPH-14-BAT",     Name="iPhone 14 — بطارية",              Type="iPhone — بطاريات",   Quantity=7,  AlertThreshold=3, PurchasePrice=450,  SellingPrice=Sell(450)  },
            new() { Code="IPH-13-BAT",     Name="iPhone 13 — بطارية",              Type="iPhone — بطاريات",   Quantity=8,  AlertThreshold=3, PurchasePrice=400,  SellingPrice=Sell(400)  },
            new() { Code="IPH-12-BAT",     Name="iPhone 12 — بطارية",              Type="iPhone — بطاريات",   Quantity=8,  AlertThreshold=3, PurchasePrice=350,  SellingPrice=Sell(350)  },
            new() { Code="IPH-11-BAT",     Name="iPhone 11 — بطارية",              Type="iPhone — بطاريات",   Quantity=10, AlertThreshold=3, PurchasePrice=300,  SellingPrice=Sell(300)  },
            new() { Code="IPH-XS-BAT",     Name="iPhone XS — بطارية",              Type="iPhone — بطاريات",   Quantity=8,  AlertThreshold=3, PurchasePrice=280,  SellingPrice=Sell(280)  },

            new() { Code="IPH-15P-CAM",    Name="iPhone 15 Pro — كاميرا خلفية",    Type="iPhone — كاميرات",   Quantity=2,  AlertThreshold=1, PurchasePrice=2000, SellingPrice=Sell(2000) },
            new() { Code="IPH-14-CAM",     Name="iPhone 14 — كاميرا خلفية",        Type="iPhone — كاميرات",   Quantity=3,  AlertThreshold=2, PurchasePrice=1500, SellingPrice=Sell(1500) },
            new() { Code="IPH-14-CHG",     Name="iPhone 14 — شاحن داخلي",          Type="iPhone — شواحن",     Quantity=8,  AlertThreshold=3, PurchasePrice=400,  SellingPrice=Sell(400)  },
            new() { Code="IPH-13-CHG",     Name="iPhone 13 — شاحن داخلي",          Type="iPhone — شواحن",     Quantity=8,  AlertThreshold=3, PurchasePrice=350,  SellingPrice=Sell(350)  },
            new() { Code="IPH-13-SPK",     Name="iPhone 13 — سماعة داخلية",        Type="iPhone — سماعات",    Quantity=10, AlertThreshold=4, PurchasePrice=200,  SellingPrice=Sell(200)  },
            new() { Code="IPH-12-SPK",     Name="iPhone 12 — سماعة داخلية",        Type="iPhone — سماعات",    Quantity=10, AlertThreshold=4, PurchasePrice=180,  SellingPrice=Sell(180)  },
            new() { Code="IPH-15-MIC",     Name="iPhone 15 — ميكروفون",            Type="iPhone — ميكروفون",  Quantity=8,  AlertThreshold=3, PurchasePrice=250,  SellingPrice=Sell(250)  },
            new() { Code="IPH-14-MIC",     Name="iPhone 14 — ميكروفون",            Type="iPhone — ميكروفون",  Quantity=8,  AlertThreshold=3, PurchasePrice=220,  SellingPrice=Sell(220)  },

            new() { Code="HW-P60P-SCR",    Name="Huawei P60 Pro — شاشة",           Type="Huawei — شاشات",     Quantity=3,  AlertThreshold=2, PurchasePrice=2000, SellingPrice=Sell(2000) },
            new() { Code="HW-P50-SCR",     Name="Huawei P50 — شاشة",               Type="Huawei — شاشات",     Quantity=3,  AlertThreshold=2, PurchasePrice=1600, SellingPrice=Sell(1600) },
            new() { Code="HW-Y90-SCR",     Name="Huawei Y90 — شاشة",               Type="Huawei — شاشات",     Quantity=5,  AlertThreshold=3, PurchasePrice=600,  SellingPrice=Sell(600)  },
            new() { Code="HW-Y70-SCR",     Name="Huawei Y70 — شاشة",               Type="Huawei — شاشات",     Quantity=5,  AlertThreshold=3, PurchasePrice=500,  SellingPrice=Sell(500)  },
            new() { Code="HW-P60P-BAT",    Name="Huawei P60 Pro — بطارية",         Type="Huawei — بطاريات",   Quantity=5,  AlertThreshold=3, PurchasePrice=400,  SellingPrice=Sell(400)  },
            new() { Code="HW-Y90-BAT",     Name="Huawei Y90 — بطارية",             Type="Huawei — بطاريات",   Quantity=8,  AlertThreshold=3, PurchasePrice=200,  SellingPrice=Sell(200)  },
            new() { Code="HW-Y70-BAT",     Name="Huawei Y70 — بطارية",             Type="Huawei — بطاريات",   Quantity=8,  AlertThreshold=3, PurchasePrice=180,  SellingPrice=Sell(180)  },
            new() { Code="HW-P50-CHG",     Name="Huawei P50 — شاحن داخلي",         Type="Huawei — شواحن",     Quantity=7,  AlertThreshold=3, PurchasePrice=250,  SellingPrice=Sell(250)  },

            new() { Code="OPP-R17-SCR",    Name="Oppo Reno 17 — شاشة",             Type="Oppo — شاشات",       Quantity=4,  AlertThreshold=2, PurchasePrice=900,  SellingPrice=Sell(900)  },
            new() { Code="OPP-R10-SCR",    Name="Oppo Reno 10 — شاشة",             Type="Oppo — شاشات",       Quantity=5,  AlertThreshold=2, PurchasePrice=750,  SellingPrice=Sell(750)  },
            new() { Code="OPP-A98-SCR",    Name="Oppo A98 — شاشة",                 Type="Oppo — شاشات",       Quantity=5,  AlertThreshold=3, PurchasePrice=550,  SellingPrice=Sell(550)  },
            new() { Code="OPP-A78-SCR",    Name="Oppo A78 — شاشة",                 Type="Oppo — شاشات",       Quantity=6,  AlertThreshold=3, PurchasePrice=450,  SellingPrice=Sell(450)  },
            new() { Code="OPP-R17-BAT",    Name="Oppo Reno 17 — بطارية",           Type="Oppo — بطاريات",     Quantity=7,  AlertThreshold=3, PurchasePrice=220,  SellingPrice=Sell(220)  },
            new() { Code="OPP-A98-BAT",    Name="Oppo A98 — بطارية",               Type="Oppo — بطاريات",     Quantity=8,  AlertThreshold=3, PurchasePrice=180,  SellingPrice=Sell(180)  },
            new() { Code="OPP-A78-CHG",    Name="Oppo A78 — شاحن داخلي",           Type="Oppo — شواحن",       Quantity=10, AlertThreshold=4, PurchasePrice=150,  SellingPrice=Sell(150)  },
            new() { Code="OPP-R10-CAM",    Name="Oppo Reno 10 — كاميرا خلفية",     Type="Oppo — كاميرات",     Quantity=4,  AlertThreshold=2, PurchasePrice=600,  SellingPrice=Sell(600)  },

            new() { Code="RLM-12P-SCR",    Name="Realme 12 Pro — شاشة",            Type="Realme — شاشات",     Quantity=5,  AlertThreshold=2, PurchasePrice=700,  SellingPrice=Sell(700)  },
            new() { Code="RLM-11-SCR",     Name="Realme 11 — شاشة",                Type="Realme — شاشات",     Quantity=6,  AlertThreshold=3, PurchasePrice=550,  SellingPrice=Sell(550)  },
            new() { Code="RLM-C67-SCR",    Name="Realme C67 — شاشة",               Type="Realme — شاشات",     Quantity=7,  AlertThreshold=3, PurchasePrice=400,  SellingPrice=Sell(400)  },
            new() { Code="RLM-C55-SCR",    Name="Realme C55 — شاشة",               Type="Realme — شاشات",     Quantity=7,  AlertThreshold=3, PurchasePrice=350,  SellingPrice=Sell(350)  },
            new() { Code="RLM-12P-BAT",    Name="Realme 12 Pro — بطارية",          Type="Realme — بطاريات",   Quantity=8,  AlertThreshold=3, PurchasePrice=200,  SellingPrice=Sell(200)  },
            new() { Code="RLM-C67-BAT",    Name="Realme C67 — بطارية",             Type="Realme — بطاريات",   Quantity=10, AlertThreshold=4, PurchasePrice=150,  SellingPrice=Sell(150)  },
            new() { Code="RLM-C55-CHG",    Name="Realme C55 — شاحن داخلي",         Type="Realme — شواحن",     Quantity=10, AlertThreshold=4, PurchasePrice=120,  SellingPrice=Sell(120)  },
            new() { Code="RLM-11-BAT",     Name="Realme 11 — بطارية",              Type="Realme — بطاريات",   Quantity=8,  AlertThreshold=3, PurchasePrice=170,  SellingPrice=Sell(170)  },

            new() { Code="INF-N40P-SCR",   Name="Infinix Note 40 Pro — شاشة",      Type="Infinix — شاشات",    Quantity=5,  AlertThreshold=3, PurchasePrice=600,  SellingPrice=Sell(600)  },
            new() { Code="INF-N40-SCR",    Name="Infinix Note 40 — شاشة",          Type="Infinix — شاشات",    Quantity=6,  AlertThreshold=3, PurchasePrice=450,  SellingPrice=Sell(450)  },
            new() { Code="INF-HOT40-SCR",  Name="Infinix Hot 40 — شاشة",           Type="Infinix — شاشات",    Quantity=7,  AlertThreshold=3, PurchasePrice=350,  SellingPrice=Sell(350)  },
            new() { Code="INF-SMART8-SCR", Name="Infinix Smart 8 — شاشة",          Type="Infinix — شاشات",    Quantity=8,  AlertThreshold=3, PurchasePrice=280,  SellingPrice=Sell(280)  },
            new() { Code="INF-N40P-BAT",   Name="Infinix Note 40 Pro — بطارية",    Type="Infinix — بطاريات",  Quantity=8,  AlertThreshold=3, PurchasePrice=180,  SellingPrice=Sell(180)  },
            new() { Code="INF-HOT40-BAT",  Name="Infinix Hot 40 — بطارية",         Type="Infinix — بطاريات",  Quantity=10, AlertThreshold=4, PurchasePrice=140,  SellingPrice=Sell(140)  },
            new() { Code="INF-SMART8-BAT", Name="Infinix Smart 8 — بطارية",        Type="Infinix — بطاريات",  Quantity=12, AlertThreshold=4, PurchasePrice=120,  SellingPrice=Sell(120)  },
            new() { Code="INF-N40-CHG",    Name="Infinix Note 40 — شاحن داخلي",    Type="Infinix — شواحن",    Quantity=10, AlertThreshold=4, PurchasePrice=130,  SellingPrice=Sell(130)  },
            new() { Code="INF-HOT40-SPK",  Name="Infinix Hot 40 — سماعة داخلية",   Type="Infinix — سماعات",   Quantity=10, AlertThreshold=4, PurchasePrice=70,   SellingPrice=Sell(70)   },

            new() { Code="SNY-XP5V-SCR",   Name="Sony Xperia 5 V — شاشة",          Type="Sony — شاشات",       Quantity=2,  AlertThreshold=1, PurchasePrice=2500, SellingPrice=Sell(2500) },
            new() { Code="SNY-XP1V-SCR",   Name="Sony Xperia 1 V — شاشة",          Type="Sony — شاشات",       Quantity=2,  AlertThreshold=1, PurchasePrice=3500, SellingPrice=Sell(3500) },
            new() { Code="SNY-XP10V-SCR",  Name="Sony Xperia 10 V — شاشة",         Type="Sony — شاشات",       Quantity=3,  AlertThreshold=2, PurchasePrice=1200, SellingPrice=Sell(1200) },
            new() { Code="SNY-XP5V-BAT",   Name="Sony Xperia 5 V — بطارية",        Type="Sony — بطاريات",     Quantity=4,  AlertThreshold=2, PurchasePrice=500,  SellingPrice=Sell(500)  },
            new() { Code="SNY-XP10V-BAT",  Name="Sony Xperia 10 V — بطارية",       Type="Sony — بطاريات",     Quantity=5,  AlertThreshold=3, PurchasePrice=350,  SellingPrice=Sell(350)  },
            new() { Code="SNY-XP1V-BRD",   Name="Sony Xperia 1 V — بوردة",         Type="Sony — بورد",        Quantity=1,  AlertThreshold=1, PurchasePrice=3000, SellingPrice=Sell(3000) },

            new() { Code="GEN-USBC-CHG",   Name="بورت شحن USB-C عام",              Type="قطع عامة — شواحن",   Quantity=20, AlertThreshold=5, PurchasePrice=80,   SellingPrice=Sell(80)   },
            new() { Code="GEN-LGHT-CHG",   Name="بورت شحن Lightning",              Type="قطع عامة — شواحن",   Quantity=15, AlertThreshold=5, PurchasePrice=100,  SellingPrice=Sell(100)  },
            new() { Code="GEN-FLEX-BTN",   Name="فليكس أزرار صوت عام",             Type="قطع عامة — فليكسات", Quantity=20, AlertThreshold=5, PurchasePrice=50,   SellingPrice=Sell(50)   },
            new() { Code="GEN-GLASS-BCK",  Name="زجاج خلفي عام",                   Type="قطع عامة — هيكل",    Quantity=15, AlertThreshold=5, PurchasePrice=120,  SellingPrice=Sell(120)  },
            new() { Code="GEN-ADHESIVE",   Name="لاصق شاشة",                       Type="قطع عامة — مستلزمات",Quantity=30, AlertThreshold=10,PurchasePrice=25,   SellingPrice=Sell(25)   },
            new() { Code="GEN-TEMPER",     Name="زجاج حماية تركيب",                Type="قطع عامة — مستلزمات",Quantity=50, AlertThreshold=10,PurchasePrice=20,   SellingPrice=Sell(20)   },
            new() { Code="GEN-SCREWSET",   Name="طقم مسامير إصلاح",                Type="قطع عامة — مستلزمات",Quantity=25, AlertThreshold=5, PurchasePrice=35,   SellingPrice=Sell(35)   },
            new() { Code="GEN-THERMAL",    Name="معجون حراري",                      Type="قطع عامة — مستلزمات",Quantity=20, AlertThreshold=5, PurchasePrice=45,   SellingPrice=Sell(45)   },
        };
    }
}
