using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Twixer.MVVM.Model.Register;

namespace Twixer.MVVM.Model
{
    internal class SystemModel
    {
        public SystemData GetSystemData()
        {
            throw new NotImplementedException();
        }
        public void SetSecurityNotification(int value) { }
        public void SetDefenderWindows(int value) { }
        public void SetUAC(int value) { }
        public void SetTaskManager(int value) { }
        public void SetMemoryDiagnostics(int value) { }
        public void SetCortana(int value) { }
        public void SetCache (int value) { }
        


    }
}
