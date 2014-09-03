using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarsMarketMonitoringSystem.Data.Xml;

namespace DistributorsSalesSystem.Data.Tests.XmlImportTests
{
    [TestClass]
    public class XmlParserTests
    {
        [TestMethod]
        public void CanLoadSalesDataFromFile()
        {
            string filePath = @"XmlImportTests/resources/ExpensesXmlData.xml";
            var expensesData = XmlParser.LoadExpensesData(filePath);

            Assert.IsTrue(expensesData.Any());
            Assert.AreEqual(30, expensesData.First().Expenses);
        }
    }
}
