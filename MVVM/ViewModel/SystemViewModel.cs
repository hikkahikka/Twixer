using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twixer.MVVM.ViewModel
{
    internal class SystemViewModel
    {
        public int GetRandomValue()
        {
            
            Random r = new Random();
            return r.Next(0, 100);
        }
    }
}
