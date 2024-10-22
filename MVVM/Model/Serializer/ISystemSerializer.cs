using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twixer.MVVM.Model
{
    internal interface ISystemSerializer
    {
        public SystemData DeserializeSystem();

        public void SerializeSystem(SystemData data);

    }
}
