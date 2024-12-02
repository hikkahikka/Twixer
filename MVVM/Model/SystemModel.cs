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
            SystemData data = new SystemData();
            SystemRegister  register = new SystemRegister();
            data.StatusMemoryDiagnostics = register.GetMemoryDiagnostics();
            data.StatusUAC=register.GetUAC();
            data.StatusSecurityNotification = register.GetSecurityNotification();
            data.StatusCortana=register.GetCortana();
            data.StatusTaskManager = register.GetTaskManager();
            data.StatusCache = register.GetCache();
            data.StatusDefenderWindows = register.GetDefenderWindows();
            return data;
        }
        public void SetSecurityNotification(int value) {
            SystemRegister register = new SystemRegister();
            register.DisableSecurityNotification(value);
        }
        public void SetDefenderWindows(int value) {
            SystemRegister register = new SystemRegister();
            register.DisableDefenderWindows(value);
        }
        public void SetUAC(int value) {
            SystemRegister register = new SystemRegister();
            register.DisableUAC(value);
        }
        public void SetTaskManager(int value) {
            SystemRegister register = new SystemRegister();
            register.DisableTaskManager(value);
        }
        public void SetMemoryDiagnostics(int value) {
            SystemRegister register = new SystemRegister();
            register.DisableMemoryDiagnostics(value);
        }
        public void SetCortana(int value)
        {
            SystemRegister register = new SystemRegister();
            register.DisableCortana(value);
        }
        public void SetCache (int value) {
            SystemRegister register = new SystemRegister();
            register.AddCache(value);
        }
        


    }
}
