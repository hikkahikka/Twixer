﻿using Microsoft.Win32;
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

namespace Twixer.MVVM.Model
{
    internal class InstallAppsModel
    {
        public void InstallPascal()
        {
            System.Diagnostics.Process.Start(@"https://pascalabc.net/downloads/PascalABCNETSetup.exe");

        }

        public void InstallPython()
        {
            System.Diagnostics.Process.Start(@"https://www.python.org/ftp/python/3.11.2/python-3.11.2-amd64.exe");

        }

        public void InstallKuMir()
        {
            System.Diagnostics.Process.Start(@"https://www.niisi.ru/kumir/kumir2-2.1.0-rc11-install.exe");

        }

        public void InstallKompas()
        {
            System.Diagnostics.Process.Start(@"https://s10887.cdn.ngenix.net/download/sduser371/KOMPAS/v21/x64/KOMPAS-3D_Viewer_v21_x64.zip");

        }

        public void InstallScratch()
        {
            System.Diagnostics.Process.Start(@"https://downloads.scratch.mit.edu/desktop/Scratch%20Setup.exe");

        }
    }
       
    
}
