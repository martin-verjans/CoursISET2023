using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SevenBugs
{
    /// <summary>
    /// This class retains the statistics
    /// It is possible to access it from multiple thread
    /// Everything here must be thread safe when writing
    /// </summary>
    internal class ExtensionStatistics : IEnumerable<KeyValuePair<string, int>>
    {
        private int folderExceptions;
        private int foldersToExplore;
        
        private readonly Dictionary<string, int> files = new Dictionary<string, int>();
        private readonly object dictionaryLock = new object();

        public int FolderExceptions => folderExceptions;
        public int FoldersToExplore => foldersToExplore;

        public void AddFileExtension(string extension)
        {
            lock (dictionaryLock)
            {
                SafeAddFileExtension(extension);
            }
        }

        private void SafeAddFileExtension(string extension)
        {
            if (!files.ContainsKey(extension))
            {
                files.Add(extension, 0);
            }
            files[extension]++;
        }

        public void SignalFolderException()
        {
            Interlocked.Increment(ref folderExceptions);
        }

        public void IncrementFoldersToExplore()
        {
            Interlocked.Increment(ref foldersToExplore);
        }

        public void DecrementFolderToExplore()
        {
            Interlocked.Decrement(ref foldersToExplore);
        }

        /*
         * 
         * The following methods allow us to iterate through the dictionary, 
         * however, if we iterate while adding stuff the iterator will throw an exception
         * The ToArray() method will create a copy of the dictionary before we send the enumerator.
         * 
         * The call to AsEnumerable ensures that we will send back a generic Enumerator.
         * If we don't call it, an excpetion is thrown because ToArray().GetEnumerator() returns
         * an ArrayEnumerator, which is not compatible directly with a generic one.
         * 
         */
        public IEnumerator<KeyValuePair<string, int>> GetEnumerator()
        {
            lock (dictionaryLock)
            {
                return files.ToArray().AsEnumerable().GetEnumerator();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
