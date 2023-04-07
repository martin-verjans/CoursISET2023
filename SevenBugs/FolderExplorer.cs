using System.IO;

namespace SevenBugs
{
    /// <summary>
    /// This class explores a given folder by exploring the inside files and folders
    /// </summary>
    internal class FolderExplorer
    {
        private readonly string folderName;
        private readonly FolderExplorerBuilder builder;

        private ExtensionStatistics Statistics => builder.Statistics;

        public FolderExplorer(FolderExplorerBuilder builder, string folderName)
        {
            this.builder = builder;
            this.folderName = folderName;
        }

        internal void Start()
        {
            try
            {
                ExploreFolders();
                ExploreFiles();
            }
            catch
            {
                Statistics.SignalFolderException();
            }
            finally
            {
                Statistics.DecrementFolderToExplore();
            }
        }

        private void ExploreFolders()
        {
            foreach (string folder in Directory.EnumerateDirectories(folderName))
            {
                builder.BuildAndStart(folder);
            }
        }

        private void ExploreFiles()
        {
            FilesInFolderExplorer explorer = new FilesInFolderExplorer(Statistics, folderName);
            explorer.StartExploration();
        }
    }
}
