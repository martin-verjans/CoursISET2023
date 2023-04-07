using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SevenBugs
{
    public partial class FileExtensionsExplorerForm : Form
    {
        private FolderExplorerBuilder explorerBuilder;

        private ExtensionStatistics Statistics => explorerBuilder.Statistics;
        private string SelectedFolder => fbdRootFolderChoice.SelectedPath;

        public FileExtensionsExplorerForm()
        {
            InitializeComponent();
        }

        private void btnChooseFolder_Click(object sender, EventArgs e)
        {
            if (fbdRootFolderChoice.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            lblCurrentFolder.Text = $"Dossier actuel : {SelectedFolder}";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedFolder))
            {
                MessageBox.Show("Vous devez sélectionner un dossier");
                return;
            }

            ExtensionStatistics stats = new ExtensionStatistics();
            explorerBuilder = new FolderExplorerBuilder(stats);
            explorerBuilder.BuildAndStart(SelectedFolder);
            updateStatisticsTimer.Start();
        }

        private void updateStatisticsTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                RefreshFileListbox();
                RefreshStatisticsLabels();
                CheckIfTimerShouldStop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du refresh: " + ex.Message, ex.GetType().ToString());
            }
        }

        private void RefreshFileListbox()
        {
            lbFileList.Items.Clear();
            foreach (KeyValuePair<string, int> fileExtension in Statistics)
            {
                lbFileList.Items.Add($"Extension <{fileExtension.Key}> : {fileExtension.Value}");
            }
        }

        private void RefreshStatisticsLabels()
        {
            UpdateLabel(lblRunningThreadCount, $"{Statistics.FoldersToExplore}");
            UpdateLabel(lblExceptionCount, $"{Statistics.FolderExceptions}");
        }

        private void UpdateLabel(Label toUpdate, string text)
        {
            toUpdate.Text = text;
        }

        private void CheckIfTimerShouldStop()
        {
            if (Statistics.FoldersToExplore <= 0)
            {
                updateStatisticsTimer.Stop();
            }
        }
    }
}
