using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Threading;
using System.Web.Script.Serialization;
using System.Web.Script.Serialization;
using btc.implementacao;
using btc.interfaces;

namespace btc.implementacao
{
    public abstract class WebRequestBIT : IWebRequestBIT
    {
        public string GetResponse(string url)
        {
            var request = WebRequest.Create(url);

            request.Credentials = CredentialCache.DefaultCredentials;

            using (var response = request.GetResponse())
            {
                var dataStream = response.GetResponseStream();

                using (var reader = new StreamReader(dataStream))
                {
                    var responseFromServer = reader.ReadToEnd();

                    if (string.IsNullOrEmpty(responseFromServer))
                        throw new ArgumentException("Endereço não localizado");

                    return responseFromServer;
                }
            }

        }
    }
}
