using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twixer.MVVM.Model
{
    internal class InfoAboutSystemModel
    {
        public int GetRandomValue()
        {
            Random r = new();
            return r.Next(0, 100);
        }
    }
}
