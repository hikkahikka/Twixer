using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twixer.MVVM.Model
{
    internal interface IInfoAboutSystemSerializer
    {
        public InfoAboutSystemData DeserializeInfoAboutSystem(string json_path);

        public string SerializeInfoAboutSystem(InfoAboutSystemData data);

    }
}
