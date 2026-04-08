using RepairFlow.BLL.Services.Interfaces;
using RepairFlow.Models;
using System.Windows.Forms;
using System;
using System.Drawing;
using QRCoder;

namespace RepairFlow.BLL.Services
{
    public class PrintService : IPrintService
    {
        public void PrintReceipt(Device device)
        {
            PerformPrintAction(device, false);
        }

        public void PreviewReceipt(Device device)
        {
            PerformPrintAction(device, true);
        }

        private void PerformPrintAction(Device device, bool isPreview)
        {
            try
            {
                string html = GenerateReceiptHtml(device);
                
                if (isPreview)
                {
                    ShowCustomPreview(html);
                }
                else
                {
                    var browser = new WebBrowser();
                    browser.ScrollBarsEnabled = false;
                    browser.DocumentText = "<html></html>"; 
                    browser.DocumentCompleted += (s, e) =>
                    {
                        var b = (WebBrowser)s;
                        b.Document.Write(html);
                        b.Refresh();
                        b.Print();
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء الطباعة:\n" + ex.Message, "خطأ");
            }
        }

        private void ShowCustomPreview(string html)
        {
            using (var form = new Form())
            {
                // REVERTED: Back to the professional "Large/Full" preview you liked
                form.Text = "معاينة الإيصال - Repair Flow";
                form.Size = new Size(500, 900); 
                form.StartPosition = FormStartPosition.CenterScreen;
                form.BackColor = Color.FromArgb(240, 240, 240); // Lighter background for the old template look

                var browser = new WebBrowser
                {
                    Dock = DockStyle.Fill,
                    IsWebBrowserContextMenuEnabled = false,
                    ScrollBarsEnabled = true, 
                    AllowWebBrowserDrop = false
                };
                
                var btnPrint = new Button
                {
                    Text = "تأكيد والطباعة الآن (Print)",
                    Dock = DockStyle.Bottom,
                    Height = 60,
                    BackColor = Color.FromArgb(46, 204, 113),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };

                btnPrint.FlatAppearance.BorderSize = 0;
                btnPrint.Click += (s, e) => {
                    browser.Print();
                    form.Close();
                };

                browser.DocumentText = "<html></html>";
                browser.DocumentCompleted += (s, e) => {
                    browser.Document.Write(html);
                    if (browser.Document?.Body != null) {
                        browser.Document.Body.Style = "zoom:100%";
                    }
                };

                form.Controls.Add(browser);
                form.Controls.Add(btnPrint);
                form.ShowDialog();
            }
        }

        private string GenerateReceiptHtml(Device device)
        {
            string dateStr = device.ReceivedAt.ToString("yyyy/MM/dd");
            string deliveryStr = device.DeliveredAt?.ToString("yyyy/MM/dd") ?? "لم يتم";
            string statusAr = MapStatusToArabic(device.Status);
            string costStr = device.RepairCost?.ToString("0") ?? "0";
            
            // Generate QR Code
            string qrBase64 = "";
            try {
                using var qrGenerator = new QRCodeGenerator();
                using var qrCodeData = qrGenerator.CreateQrCode(device.Id.ToString(), QRCodeGenerator.ECCLevel.Q);
                using var qrCode = new PngByteQRCode(qrCodeData);
                byte[] qrAsBytArray = qrCode.GetGraphic(20);
                qrBase64 = Convert.ToBase64String(qrAsBytArray);
            } catch { }

            return $@"
<!DOCTYPE html>
<html dir='rtl' lang='ar'>
<head>
    <meta charset='UTF-8'>
    <style>
        * {{ margin: 0; padding: 0; box-sizing: border-box; }}
        body {{ 
            background: #f0f0f0; 
            padding: 20px 0;
            font-family: 'Segoe UI', Arial, sans-serif;
        }}
        .receipt-container {{ 
            width: 285px; 
            margin: 0 auto; 
            background: #fff; 
            padding: 15px;
            color: #000;
        }}
        .center {{ text-align: center; }}
        .header h1 {{ font-size: 18px; font-weight: bold; margin-bottom: 2px; }}
        .header p {{ font-size: 13px; padding-bottom: 5px; border-bottom: 1.5px solid #000; margin-bottom: 5px; }}
        
        table {{ width: 100%; border-collapse: collapse; margin-bottom: 5px; }}
        td {{ padding: 6px 0; vertical-align: middle; }}
        
        .label {{ font-size: 13px; text-align: right; color: #333; width: 40%; white-space: nowrap; }}
        .value {{ font-size: 13px; text-align: left; font-weight: bold; padding-left: 2px; }}
        
        .dotted-border {{ border-bottom: 1px dotted #000; }}
        .solid-border {{ border-bottom: 1.5px solid #000; }}
        
        .qr-section {{ margin-top: 15px; text-align: center; border-top: 1.5px solid #000; padding-top: 15px; }}
        .qr-image {{ width: 100px; height: 100px; margin: 0 auto 5px auto; display: block; }}
        .footer-text {{ font-size: 12px; font-weight: bold; margin-top: 5px; }}
        .timestamp {{ font-size: 11px; color: #666; margin-top: 2px; }}

        @media print {{
            body {{ background: white; padding: 0; }}
            .receipt-container {{ width: 285px; margin: 0; padding: 10px; }}
        }}
    </style>
</head>
<body>
    <div class='receipt-container'>
        <div class='center header'>
            <h1>Repair Flow</h1>
            <p>إيصال صيانة</p>
        </div>

        <table>
            <tr class='solid-border'><td class='label'>رقم الإيصال</td><td class='value'>{device.ReceiptNumber}</td></tr>
            
            <tr><td class='label'>العميل</td><td class='value'>{device.Customer?.Name}</td></tr>
            <tr class='solid-border'><td class='label'>الهاتف</td><td class='value'>{device.Customer?.Phone}</td></tr>
            
            <tr><td class='label'>الجهاز</td><td class='value'>{device.DeviceName}</td></tr>
            <tr><td class='label'>الموديل</td><td class='value'>{device.Model}</td></tr>
            <tr><td class='label'>العطل</td><td class='value'>{device.Fault}</td></tr>
            <tr class='solid-border'><td class='label'>المرفقات</td><td class='value'>{device.Accessories ?? "لا يوجد"}</td></tr>
            
            <tr><td class='label'>الاستلام</td><td class='value'>{dateStr}</td></tr>
            <tr class='solid-border'><td class='label'>التسليم</td><td class='value'>{deliveryStr}</td></tr>
            
            <tr><td class='label'>التكلفة</td><td class='value'>{costStr} ج</td></tr>
            <tr class='solid-border'><td class='label'>الحالة</td><td class='value'>{statusAr}</td></tr>
        </table>

        <div class='qr-section'>
            <img src='data:image/png;base64,{qrBase64}' class='qr-image'/>
            <div class='footer-text'>شكراً لتعاملكم معنا</div>
            <div class='timestamp'>{DateTime.Now:yyyy/MM/dd HH:mm}</div>
        </div>
    </div>
</body>
</html>";
        }

        private string MapStatusToArabic(RepairStatus status) => status switch
        {
            RepairStatus.NewArrival => "وارد جديد",
            RepairStatus.UnderInspection => "قيد الفحص",
            RepairStatus.UnderRepair  => "تحت الإصلاح",
            RepairStatus.Ready  => "جاهز",
            RepairStatus.Delivered  => "تم التسليم",
            _ => "غير معروف"
        };
    }
}
