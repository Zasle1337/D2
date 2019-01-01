using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2IpWalker
{
    abstract class listener
    {
        public abstract System.Net.IPEndPoint[] GetActiveTcpListeners();

    }
}
