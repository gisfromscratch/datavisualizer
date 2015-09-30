using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeMap.Runtime.Viewer.Model
{
    /// <summary>
    /// Represents a table having statistics.
    /// </summary>
    internal class TableItem
    {
        public string TableName { get; set; }

        public long RowCount { get; set; }

        public IList<DataStatisticsResult> StatisticsResults { get; set; }
    }
}
