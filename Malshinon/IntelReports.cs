using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class IntelReport
    {
        public int Id { get; private set; }
        public int ReporterId { get; private set; }
        public int TargetId { get; private set; }
        public string Text { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public bool GoodReport { get; private set; }
        public IntelReport(int id, int reporterId, int targetId, string text)
        {
            SetId(id);
            SetReporterId(reporterId);
            SetTargetId(targetId);
            SetText(text);
            SetTime();
            SetGoodReport(); 
        }
        public void SetId(int id)
        {
            Id = id;
        }
        public void SetReporterId(int id) {ReporterId = id;}
        public void SetTargetId(int id) { TargetId = id;}
        public void SetText(string text) { Text = text; }
        public void SetTime() { TimeStamp = DateTime.Now; }
        public void SetGoodReport() {if (ReporterId > 0 && TargetId > 0 && Text.Length > 4) GoodReport = true;else GoodReport = false;}

    }
}
