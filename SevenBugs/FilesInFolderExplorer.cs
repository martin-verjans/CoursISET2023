using System.Collections.Generic;
using System.IO;

namespace SevenBugs
{
    /// <summary>
    /// This class will explore a folder to update statistics about file extensions
    /// </summary>
    internal class FilesInFolderExplorer
    {
        private readonly ExtensionStatistics statistics;
        private readonly string folderName;

        private string DirectoryName => Path.GetDirectoryName(folderName);

        public FilesInFolderExplorer(ExtensionStatistics statistics, string folderName)
        {
            this.statistics = statistics;
            this.folderName = folderName;
        }

        public void StartExploration()
        {
            //The following line might throw an exception but we wouldn't know what to do with it.
            //It will be whoever launched us to deal with it.
            foreach (string File in Directory.EnumerateFiles(DirectoryName))
            {
                statistics.AddFileExtension(GetFileExtension(File));
            }
        }

        private string GetFileExtension(string fileName)
        {
            return Path.GetExtension(fileName);
        }
    }
}
