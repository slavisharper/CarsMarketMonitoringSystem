
namespace CarsMarketMonitoringSystem.Data.Xml
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml;
    using System.IO;
    using Models;

    public static class XmlParser
    {
        const string SalesSchemaPath = @"Xml\Schemas\ExpensesSchema.xsd";

        public static IEnumerable<Expense> LoadExpensesData(string filePath)
        {
            var salesXml = XElement.Load(filePath);
            ValidateXml(salesXml, SalesSchemaPath);

            var expenseTags = salesXml.Descendants("Expense");
            List<Expense> expensesParsed = new List<Expense>(expenseTags.Count());

            foreach (var expense in expenseTags)
            {
                var expenceId = GetTagValueOrNull(expense, "ExpenseId");
                var manufacturerId = GetTagValueOrNull(expense, "ManufacturerId");
                var expenses = GetTagValueOrNull(expense, "ExpenseValue");
                var month = GetTagValueOrNull(expense, "Month");

                expensesParsed.Add(new Expense()
                {
                    ExpenseId = int.Parse(expenceId),
                    ManufacturerId = int.Parse(manufacturerId),
                    Expenses = decimal.Parse(expenses),
                    Month = DateTime.Parse(month)
                });
            }

            return expensesParsed;
        }

        private static void ValidateXml(XElement xmlData, string schemaFile)
        {
            XmlTextReader reader = new XmlTextReader(schemaFile);
            XmlSchema schema = XmlSchema.Read(reader,
                (sender, args) => { throw new ArgumentException("Could not read schema", args.Exception); });

            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(schema);

            XDocument document = new XDocument(xmlData);
            document.Validate(schemas, (sender, args) =>
                {
                    throw new ArgumentException("The supplied XElement is not in the valid format", args.Exception);
                }, true);
        }

        private static string GetTagValueOrNull(XElement xml, string tagName, bool isRequired = true)
        {
            var tag = isRequired ? xml.Descendants(tagName).Single() :
                xml.Descendants(tagName).FirstOrDefault();

            return tag != null ? tag.Value : null; 
        }
    }
}
