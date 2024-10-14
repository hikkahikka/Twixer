using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Twixer.MVVM.Model
{
    internal class Serializer : IPrivacySerializer, IInfoAboutSystemSerializer, ISystemSerializer
    {
        public InfoAboutSystemData DeserializeInfoAboutSystem()
        {
            throw new NotImplementedException();
        }

        public PrivacyData DeserializePrivacy()
        {
            throw new NotImplementedException();
        }

        public SystemData DeserializeSystem()
        {
            throw new NotImplementedException();
        }

        public void SerializeInfoAboutSystem(InfoAboutSystemData data)
        {
            

        }

        public void SerializePrivacy(PrivacyData data)
        {
            throw new NotImplementedException();
        }

        public void SerializeSystem(SystemData data)
        {
            throw new NotImplementedException();
        }
    }
}
