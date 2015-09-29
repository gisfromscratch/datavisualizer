using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeMap.Runtime.Viewer.Model
{
    /// <summary>
    /// Represents an attribute.
    /// </summary>
    internal class Attribute
    {
        public string Name { get; set; }

        public IList<AttributeValue> AttributeValues { get; set; }

        public long Count
        {
            get
            {
                return (null != AttributeValues) ? AttributeValues.Count : 0;
            }
        }
    }
}
