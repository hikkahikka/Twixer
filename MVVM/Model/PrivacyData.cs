using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twixer.MVVM.Model
{
    internal struct PrivacyData
    {
        public bool StatusMicrosoftTelemetry { get; set; }
        public bool StatusDeleteOneDrive { get; set; }
        public bool StatusEventLogProcessing {  get; set; }
        public bool StatusUpdates {  get; set; }
        public bool StatusCollectionHandwrittenInput {  get; set; }
    }
}
