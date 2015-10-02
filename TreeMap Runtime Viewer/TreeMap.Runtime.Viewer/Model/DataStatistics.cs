using Esri.ArcGISRuntime.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeMap.Runtime.Viewer.Model
{
    /// <summary>
    /// Represents data statistics for an attribute.
    /// </summary>
    internal class DataStatistics
    {
        /// <summary>
        /// Calculates the data statistics for a geodatabase table.
        /// </summary>
        /// <param name="table">The geodatabase table which statistics should be gathered.</param>
        /// <param name="field">The field which statistics should be gathered.</param>
        /// <returns>The calculated data statistics.</returns>
        internal async Task<DataStatisticsResult> CalculateStatistics(FeatureTable table, FieldInfo field)
        {
            var result = new DataStatisticsResult { TableName = table.Name, AttributeName = field.Alias };
            result.Count = table.RowCount;
            var filter = new QueryFilter { WhereClause = @"1=1" };
            var features = await table.QueryAsync(filter);
            var uniqueValues = new HashSet<object>();
            foreach (var feature in features)
            {
                var attributes = feature.Attributes;
                if (attributes.ContainsKey(field.Name))
                {
                    var value = attributes[field.Name];
                    if (!uniqueValues.Contains(value))
                    {
                        uniqueValues.Add(value);
                    }
                }
            }
            result.UniqueValueCount = uniqueValues.Count;
            return result;
        }
    }
}
