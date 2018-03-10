using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Blockchain
{
    public class DataItem
    {
        #region Fields

        private readonly Dictionary<string, object> properties = new Dictionary<string, object>();

        #endregion

        #region Properties

        public object this[string propertyName]
        {
            get
            {
                if (properties.ContainsKey(propertyName))
                    return properties[propertyName];
                else
                    return null;
            }
            set
            {
                if (properties.ContainsKey(propertyName))
                    properties[propertyName] = value;
                else
                    properties.Add(propertyName, value);
            }
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            if (this.properties!= null && this.properties.Count > 0)
            {
                return string.Join(",", this.properties.Values);
            }
            return base.ToString();
        }

        #endregion
    }
}
