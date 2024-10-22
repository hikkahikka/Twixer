using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Twixer.MVVM.Model
{
    internal class Serializer : IPrivacySerializer, IInfoAboutSystemSerializer, ISystemSerializer
    {
        public InfoAboutSystemData DeserializeInfoAboutSystem(string json)
        {
            InfoAboutSystemData data = JsonConvert.DeserializeObject<InfoAboutSystemData>(json);       
            return data;
        }
        public string SerializeInfoAboutSystem(InfoAboutSystemData data)
        {
            string json = JsonConvert.SerializeObject(data);
            return json;
        }


        public PrivacyData DeserializePrivacy()
        {
            throw new NotImplementedException();
        }
        public void SerializePrivacy(PrivacyData data)
        {
            throw new NotImplementedException();
        }

        public SystemData DeserializeSystem()
        {
            throw new NotImplementedException();
        }
        public void SerializeSystem(SystemData data)
        {
            throw new NotImplementedException();
        }
    }
}
