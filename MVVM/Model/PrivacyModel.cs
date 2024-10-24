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
using System.Windows.Input;
using Newtonsoft.Json;

using System.Net;

using System.Windows.Shell;
using Twixer.MVVM.Model.Register;
namespace Twixer.MVVM.Model
{
    internal class PrivacyModel
    {
        IPrivacySerializer serializer;
        public void SetMicrosoftTelemetry(int value)
        {
            PrivacyRegister register = new PrivacyRegister();
            register.DisableMicrosoftTelemetry(value);
            
        }

        public void SetEventLogProcessing(int value)
        {
            PrivacyRegister register = new PrivacyRegister();
            register.DisableEventLogProcessing(value);

        }

        public void SetUpdates(int value)
        {
            PrivacyRegister register = new PrivacyRegister();
            register.DisableUpdates(value);
        }

        public void SetCollectionHandwrittenInput(int value)
        {
            PrivacyRegister register = new PrivacyRegister();
            register.DisableCollectionHandwrittenInput(value);
        }


    }
    
}
