using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using MathNet.Numerics.Statistics;

namespace PrintMedian
{
    public static class Utility
    {
        public static List<CsvRow> readCSVFile(string filepath)
        {
            List<CsvRow> csvData = new List<CsvRow>();

            using (var reader = new StreamReader(filepath))
            {
                //Skip the header Row
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    CsvRow row = new CsvRow();
                    row.MeterPointCode = int.Parse(values[0]);
                    row.SerialNumber = values[1];
                    row.PlantCode = values[2];
                    row.RowDateTime = values[3];
                    row.DataValue = double.Parse(values[5]);
                    row.Status = values[7];
                    row.Units = values[6];

                    csvData.Add(row);
                }
            }

            return csvData;
        }

        public static double calCSVFileMedian(List<CsvRow> csvdata)
        {
            var data = csvdata.Select(l => l.DataValue).ToList();

            //using Open source Nuget Package - MathNet.Numerics
            double median = data.Median();
            return median;
        }

        public static void printonConsole(List<CsvRow> csvdata,double mdn, string fileName)
        {
            double mdn2cmp = 0.2 * mdn;
            var data = csvdata.Select(l => l.DataValue).ToList();
            var query = from e in csvdata
                        where (e.DataValue > mdn2cmp) || (e.DataValue < mdn2cmp)
                        select e;

            foreach (var item in query) Console.WriteLine(fileName+", "+item.RowDateTime.ToString()+", "+item.DataValue+", "+mdn);
            Console.ReadLine();
        }
    }
}
