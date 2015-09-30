using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeMap.Runtime.Viewer.Model
{
    /// <summary>
    /// Represents a result for reporting data statistics.
    /// </summary>
    internal class DataStatisticsResult
    {
        /// <summary>
        /// The table name of this result.
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// The attribute name of this result.
        /// </summary>
        public string AttributeName { get; set; }

        /// <summary>
        /// The number of all values.
        /// </summary>
        public long Count { get; set; }

        /// <summary>
        /// The number of the unique values.
        /// </summary>
        public long UniqueValueCount { get; set; }
    }
}
