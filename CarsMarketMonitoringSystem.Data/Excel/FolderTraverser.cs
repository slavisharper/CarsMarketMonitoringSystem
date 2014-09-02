namespace CarsMarketMonitoringSystem.Data.Excel
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class FolderTraverser
    {
        private DirectoryInfo rootDir;

        public FolderTraverser(string rootDir)
        {
            this.rootDir = new DirectoryInfo(rootDir);
        }

        public List<FileInfo> GetFilePaths(string fileExctenstion = null)
        {
            var foundFiles = new List<FileInfo>();
            string pattern = string.Format("*.{0}", fileExctenstion);
            if (fileExctenstion == null)
            {
                pattern = "*.*";
            }

            this.ExtractFilePaths(this.rootDir, foundFiles, pattern);
            return foundFiles;
        }

        private void ExtractFilePaths(DirectoryInfo dirRoot, List<FileInfo> foundFiles, string pattern) 
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            try
            {
                files = dirRoot.GetFiles(pattern);
                if (files != null)
                {
                    foreach (FileInfo file in files)
                    {
                        foundFiles.Add(file);
                    }
                }

                subDirs = dirRoot.GetDirectories();
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }

            if (subDirs != null)
            {
                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    ExtractFilePaths(dirInfo, foundFiles, pattern);
                }
            }
        }
    }
}
