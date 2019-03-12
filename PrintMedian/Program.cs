using System;
using System.IO;
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
            Console.WriteLine("Please enter the file path of CSV file excluding the file name to read: ");
            string flPath = Console.ReadLine();

            bool isfilepathvalid = false;
            bool isfilenamevalid = false;

            do
            {
                if (flPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                {
                    Console.WriteLine("File path is invalid, please enter the file path of CSV file excluding the file name to read: ");
                    flPath = Console.ReadLine();
                    isfilepathvalid = false;
                }
                else
                {
                    isfilepathvalid = true;
                }
            } while (!isfilepathvalid);

            Console.WriteLine("Please enter the CSV file name: ");
            string flName = Console.ReadLine();
            do
            {
                if (flName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
                {
                    Console.WriteLine("File name is invalid, please enter valid CSV file name to read: ");
                    flName = Console.ReadLine();
                    isfilenamevalid = false;
                }
                else
                {
                    isfilenamevalid = true;
                }
            } while (!isfilenamevalid);

            //string filePath = System.Configuration.ConfigurationManager.AppSettings["filePath"];
            //string fileName = System.Configuration.ConfigurationManager.AppSettings["fileName"];

            //Setting the Application Settings for Filepath and Filename.
            ConfigurationManager.AppSettings.Set("filePath", flPath);
            ConfigurationManager.AppSettings.Set("fileName", flName);

            string filePath = flPath + "\\" + flName +".csv";

            List<CsvRow> csvData = PrintMedian.Utility.readCSVFile(filePath);

            double median = PrintMedian.Utility.calCSVFileMedian(csvData);

            PrintMedian.Utility.printonConsole(csvData, median, flName);

        }
    }
}
