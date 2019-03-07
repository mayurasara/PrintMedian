using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrintMedian;


namespace PrintMedianUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testMedianVal()
        {
            List<CsvRow> lst = new List<CsvRow>();

            lst = PrintMedian.Utility.readCSVFile("D:\\Projects\\Sample files\\TOU_212621145_20150911T022358.csv");

            Double dbl = PrintMedian.Utility.calCSVFileMedian(lst);

            Assert.AreEqual(409646.7, dbl);

            List<CsvRow> lst1 = new List<CsvRow>();
            lst1 = PrintMedian.Utility.readCSVFile("D:\\Projects\\Sample files\\TOU_212621147_20150911T022240.csv");

            Double dbl1 = PrintMedian.Utility.calCSVFileMedian(lst1);

            Assert.AreEqual(378331.6, dbl1);

            List<CsvRow> lst2 = new List<CsvRow>();
            lst2 = PrintMedian.Utility.readCSVFile("D:\\Projects\\Sample files\\TOU_214667141_20150901T040057.csv");

            Double dbl2 = PrintMedian.Utility.calCSVFileMedian(lst2);

            Assert.AreEqual(0.146
, dbl2);


        }

        [TestMethod]
        public void testReadCsv()
        {
            List<CsvRow> lst = new List<CsvRow>();

            lst = PrintMedian.Utility.readCSVFile("D:\\Projects\\Sample files\\TOU_212621145_20150911T022358.csv");
            var data = lst.Select(l => l.DataValue).ToList();
            Assert.AreEqual(409646.7, Double.Parse(data.First().ToString()));
        }

    }

}
