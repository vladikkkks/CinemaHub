using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Reporting.WinForms;

namespace CinemaHub.Services
{
    public class DirectReportPrinter
    {
        private IList<Stream> _mStreams;

        public void ExportReportToEmf(LocalReport report)
        {
            // Опис специфікації сторінки термопринтера (80 мм ширина, авто-довжина)[cite: 8]
            string deviceInfo = 
                @"<DeviceInfo>
                    <OutputFormat>EMF</OutputFormat>
                    <PageWidth>3.15in</PageWidth>
                    <PageHeight>8.0in</PageHeight>
                    <MarginTop>0.1in</MarginTop>
                    <MarginLeft>0.1in</MarginLeft>
                    <MarginRight>0.1in</MarginRight>
                    <MarginBottom>0.1in</MarginBottom>
                </DeviceInfo>";
            
            Warning[] warnings;
            _mStreams = new List<Stream>();
            
            // Експорт звіту в послідовність EMF (Enhanced Metafile) векторних зображень[cite: 8]
            report.Render("Image", deviceInfo, CreateStreamCallback, out warnings);
        }

        private Stream CreateStreamCallback(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            _mStreams.Add(stream); // Створення потоку для Win32 Spooler[cite: 8]
            return stream;
        }
    }
}