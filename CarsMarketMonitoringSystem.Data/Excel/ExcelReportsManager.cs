namespace CarsMarketMonitoringSystem.Data.Excel
{
    using CarsMarketMonitoringSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class ExcelReportsManager
    {
        private CarsMarketDbContext context;
        private string extractedFilesPath;

        public ExcelReportsManager(string zipFilePath, string extractedDirectory, CarsMarketDbContext dataBaseContext)
        {
            this.ZipFilePath = zipFilePath;
            this.context = dataBaseContext;
            this.extractedFilesPath = extractedDirectory;
        }

        public string ZipFilePath { get; private set; }

        public void ImportSalesReport()
        {
            ZipManipulator.ExtractZip(ZipFilePath, this.extractedFilesPath);

            var excelFiles = GetAllFiles(this.extractedFilesPath, "xls");

            foreach (var file in excelFiles)
            {
                var parser = new ExcelReportParser(file);
                var sales = parser.GetSalesReports();
                foreach (var sale in sales)
                {
                    this.context.Sales.Add(sale);
                }
            }

            context.SaveChanges();
        }

        private IEnumerable<FileInfo> GetAllFiles(string directoryPath, string fileExtension)
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new ArgumentException("Invalid directory is provided");
            }

            var folderTraverse = new FolderTraverser(directoryPath);
            var paths = folderTraverse.GetFilePaths(fileExtension);
            return paths;
        }
    }
}
