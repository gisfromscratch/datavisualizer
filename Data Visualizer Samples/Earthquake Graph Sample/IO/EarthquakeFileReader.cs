using Earthquake.Graph.Sample.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Earthquake.Graph.Sample.IO
{
    /// <summary>
    /// Reads the earthquake informations from a CSV file.
    /// </summary>
    internal class EarthquakeFileReader
    {
        /// <summary>
        /// Reads a CSV file asynchronously.
        /// </summary>
        /// <param name="csvFile">The CSV file containing the earthquakes.</param>
        /// <returns>The eartquakes of this CSV file.</returns>
        internal async Task<IEnumerable<EarthquakeInfo>> ReadAsync(FileInfo csvFile)
        {
            return await Task.Run<IEnumerable<EarthquakeInfo>>(() =>
            {
                var earthquakeInfos = new List<EarthquakeInfo>();
                using (var inputStreamReader = new StreamReader(csvFile.OpenRead()))
                {
                    string inputLine;
                    while (null != (inputLine = inputStreamReader.ReadLine()))
                    {
                        if (!string.IsNullOrEmpty(inputLine))
                        {
                            var earthquakeInfo = ReadLine(inputLine);
                            if (null != earthquakeInfo)
                            {
                                earthquakeInfos.Add(earthquakeInfo);
                            }
                        }
                    }
                }
                return earthquakeInfos;
            });
        }

        /// <summary>
        /// Reads a line from a CSV file.
        /// </summary>
        /// <example>
        /// 1898/06/29 18:36:00.00,52.0,172.0,0.0,7.6,ML,0,,,,AK,
        /// </example>
        /// <param name="line">The line representing an earthquake.</param>
        /// <returns>The earthquake or <c>null</c>.</returns>
        private static EarthquakeInfo ReadLine(string line)
        {
            var lineTokens = line.Split(',');
            if (12 != lineTokens.Length)
            {
                return null;
            }

            var earthquakeInfo = new EarthquakeInfo();
            var dateTimeAsText = lineTokens[0];
            DateTime dateTime;
            if (DateTime.TryParse(dateTimeAsText, out dateTime))
            {
                earthquakeInfo.Date = dateTime;
            }

            var magnitudeAsText = lineTokens[4];
            double magnitude;
            if (double.TryParse(magnitudeAsText, NumberStyles.Any, CultureInfo.InvariantCulture, out magnitude))
            {
                earthquakeInfo.Magnitude = magnitude;
            }
            return earthquakeInfo;
        }
    }
}
