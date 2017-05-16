using btc.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace btc.implementacao
{
    public abstract class Serialize : ISerialize
    {

        public void SerializeJSON()
        {
            throw new NotImplementedException();
        }

        public object DeserializeJSON<TEntity>(string json)
        {
            var oJS = new JavaScriptSerializer();

            var oRootObject = Activator.CreateInstance<TEntity>();

            return oRootObject = oJS.Deserialize<TEntity>(json);
        }

    }
}
