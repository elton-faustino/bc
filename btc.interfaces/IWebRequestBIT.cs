using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btc.interfaces
{
    public interface IWebRequestBIT
    {
        string GetResponse(string url);
    }
}
