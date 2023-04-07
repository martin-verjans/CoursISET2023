namespace SevenBugs
{
    partial class FileExtensionsExplorerForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCurrentFolder = new System.Windows.Forms.Label();
            this.btnChooseFolder = new System.Windows.Forms.Button();
            this.btnStartSearch = new System.Windows.Forms.Button();
            this.lbFileList = new System.Windows.Forms.ListBox();
            this.fbdRootFolderChoice = new System.Windows.Forms.FolderBrowserDialog();
            this.updateStatisticsTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblRunningThreadCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblExceptionCount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCurrentFolder);
            this.groupBox1.Controls.Add(this.btnChooseFolder);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dossier de recherche";
            // 
            // lblCurrentFolder
            // 
            this.lblCurrentFolder.AutoSize = true;
            this.lblCurrentFolder.Location = new System.Drawing.Point(186, 33);
            this.lblCurrentFolder.Name = "lblCurrentFolder";
            this.lblCurrentFolder.Size = new System.Drawing.Size(141, 20);
            this.lblCurrentFolder.TabIndex = 1;
            this.lblCurrentFolder.Text = "Dossier actuel : C:\\";
            // 
            // btnChooseFolder
            // 
            this.btnChooseFolder.Location = new System.Drawing.Point(7, 26);
            this.btnChooseFolder.Name = "btnChooseFolder";
            this.btnChooseFolder.Size = new System.Drawing.Size(173, 34);
            this.btnChooseFolder.TabIndex = 0;
            this.btnChooseFolder.Text = "Choisir le dossier";
            this.btnChooseFolder.UseVisualStyleBackColor = true;
            this.btnChooseFolder.Click += new System.EventHandler(this.btnChooseFolder_Click);
            // 
            // btnStartSearch
            // 
            this.btnStartSearch.Location = new System.Drawing.Point(13, 100);
            this.btnStartSearch.Name = "btnStartSearch";
            this.btnStartSearch.Size = new System.Drawing.Size(180, 48);
            this.btnStartSearch.TabIndex = 1;
            this.btnStartSearch.Text = "Démarrer la recherche";
            this.btnStartSearch.UseVisualStyleBackColor = true;
            this.btnStartSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbFileList
            // 
            this.lbFileList.FormattingEnabled = true;
            this.lbFileList.ItemHeight = 20;
            this.lbFileList.Location = new System.Drawing.Point(203, 100);
            this.lbFileList.Name = "lbFileList";
            this.lbFileList.Size = new System.Drawing.Size(585, 324);
            this.lbFileList.TabIndex = 2;
            // 
            // fbdRootFolderChoice
            // 
            this.fbdRootFolderChoice.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.fbdRootFolderChoice.SelectedPath = "C:\\";
            this.fbdRootFolderChoice.ShowNewFolderButton = false;
            // 
            // updateStatisticsTimer
            // 
            this.updateStatisticsTimer.Interval = 1000;
            this.updateStatisticsTimer.Tick += new System.EventHandler(this.updateStatisticsTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Running Threads :";
            // 
            // lblRunningThreadCount
            // 
            this.lblRunningThreadCount.AutoSize = true;
            this.lblRunningThreadCount.Location = new System.Drawing.Point(12, 197);
            this.lblRunningThreadCount.Name = "lblRunningThreadCount";
            this.lblRunningThreadCount.Size = new System.Drawing.Size(18, 20);
            this.lblRunningThreadCount.TabIndex = 4;
            this.lblRunningThreadCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Exceptions :";
            // 
            // lblExceptionCount
            // 
            this.lblExceptionCount.AutoSize = true;
            this.lblExceptionCount.Location = new System.Drawing.Point(16, 280);
            this.lblExceptionCount.Name = "lblExceptionCount";
            this.lblExceptionCount.Size = new System.Drawing.Size(18, 20);
            this.lblExceptionCount.TabIndex = 6;
            this.lblExceptionCount.Text = "0";
            // 
            // FileExtensionsExplorerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 437);
            this.Controls.Add(this.lblExceptionCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRunningThreadCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbFileList);
            this.Controls.Add(this.btnStartSearch);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "FileExtensionsExplorerForm";
            this.Text = "File Extension Explorer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCurrentFolder;
        private System.Windows.Forms.Button btnChooseFolder;
        private System.Windows.Forms.Button btnStartSearch;
        private System.Windows.Forms.ListBox lbFileList;
        private System.Windows.Forms.FolderBrowserDialog fbdRootFolderChoice;
        private System.Windows.Forms.Timer updateStatisticsTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRunningThreadCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblExceptionCount;
    }
}

