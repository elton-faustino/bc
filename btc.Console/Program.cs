using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Threading;
using System.Web.Script.Serialization;
using System.Web.Script.Serialization;
using btc.implementacao;
using btc.interfaces;

namespace btc.ConsoleApp
{
    class Program 
    {
        static void Main(string[] args)
        {
            double mybtc = 0.0;

            while (true)
            {
                var consulta = new Inject(new BaseWeb(), new BaseSerialize());

                //var responseFromServer = consulta.GetResponse("http://api.coindesk.com/v1/bpi/currentprice.json");
                var responseFromServer = consulta.GetResponse("https://www.mercadobitcoin.net/api/ticker/");

                var oRootObject = new RootObject();

                oRootObject = (RootObject)consulta.DeserializeJSON<RootObject>(responseFromServer);

                //Console.WriteLine(oRootObject.bpi.usd.rate_float);
                Console.WriteLine(string.Format("Buy: {0}", Double.Parse( oRootObject.ticker.buy) * mybtc));
                Console.WriteLine(string.Format("Sell: {0}", Double.Parse(oRootObject.ticker.sell) * mybtc));
            }

        }
    }

    public class Inject
    {
        private IWebRequestBIT _webRequest;
        private ISerialize _serialize;

        public Inject(BaseWeb webRequest, BaseSerialize serialize)
        {
            _webRequest = webRequest;
            _serialize = serialize;
        }

        public object DeserializeJSON<TEntity>(string json)
        {
            return _serialize.DeserializeJSON<TEntity>(json);
        }

        public string GetResponse(string url)
        {
           return  _webRequest.GetResponse(url);
        }
    }

    public class BaseWeb : WebRequestBIT
    {
    }

    public class BaseSerialize : Serialize
    {

    }

    public class RootObject
    {
        //public bpi bpi { get; set; }
        public ticker ticker { get; set; }
    }

    public class ticker
    {
        public string buy { get; set; }

        public string sell { get; set; }

        public string high { get; set; }

        public string low { get; set; }
    }

    public class bpi
    {
        public USD usd { get; set; }
    }

    public class USD
    {
        public string code { get; set; }

        public string symbol { get; set; }

        public string rate { get; set; }

        public string description { get; set; }

        public string rate_float { get; set; }
    }

}
