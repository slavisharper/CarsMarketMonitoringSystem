namespace CarsMarketMonitoringSystem.Data.Excel
{
    using Ionic.Zip;

    public static class ZipManipulator
    {
        internal static void ExtractZip(string zipPath, string unpackedPath)
        {
            string zipToUnpack = zipPath;
            string unpackDirectory = unpackedPath;
            using (ZipFile zip1 = ZipFile.Read(zipToUnpack))
            { 
                foreach (ZipEntry e in zip1)
                {
                    e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }
    }
}
