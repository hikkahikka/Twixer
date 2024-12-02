using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twixer.MVVM.Model
{
    internal struct SystemData
    {
        public bool StatusSecurityNotification { get; set; }
        public bool StatusDefenderWindows { get; set; }
        public bool StatusUAC {  get; set; }
        public bool StatusTaskManager {  get; set; }
        public bool StatusMemoryDiagnostics { get; set; }
        public bool StatusCortana {  get; set; }
        public bool StatusCache { get; set; }
        
    }
    
}
