using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Earthquake.Graph.Sample.Model
{
    /// <summary>
    /// Represents an earthquake which should be visualize in a graph.
    /// </summary>
    internal class EarthquakeInfo
    {
        /// <summary>
        /// The datetime when this earthquake occurred.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The magnitude of this earthquake.
        /// </summary>
        public double Magnitude { get; set; }
    }
}
