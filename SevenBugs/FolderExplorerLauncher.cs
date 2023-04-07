using System.Threading;

namespace SevenBugs
{
    /// <summary>
    /// This class launches a explorer on a given folder in a separate thread (from the Threadpool)
    /// </summary>
    internal class FolderExplorerBuilder
    {
        public ExtensionStatistics Statistics { get; }

        public FolderExplorerBuilder(ExtensionStatistics statistics)
        {
            Statistics = statistics;
        }

        public void BuildAndStart(string folderName)
        {
            FolderExplorer explorer = new FolderExplorer(this, folderName);
            Statistics.IncrementFoldersToExplore();
            ThreadPool.QueueUserWorkItem(StartExploration, explorer);
        }

        private void StartExploration(object state)
        {
            FolderExplorer explorer = (FolderExplorer)state;
            explorer.Start();
        }
    }
}
