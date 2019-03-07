using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using PrintMedian;
using Microsoft.VisualBasic;

namespace PrintMedian
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = System.Configuration.ConfigurationManager.AppSettings["filePath"];
            string fileName = System.Configuration.ConfigurationManager.AppSettings["fileName"];

            List<CsvRow> csvData = PrintMedian.Utility.readCSVFile(filePath);

            double median = PrintMedian.Utility.calCSVFileMedian(csvData);

            PrintMedian.Utility.printonConsole(csvData, median, fileName);

        }
    }
}
