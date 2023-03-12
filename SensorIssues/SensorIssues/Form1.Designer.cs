namespace SensorIssues
{
    partial class Form1
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
            this.lblSensor1 = new System.Windows.Forms.Label();
            this.lblSensor2 = new System.Windows.Forms.Label();
            this.lblSensor3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSensor1
            // 
            this.lblSensor1.AutoSize = true;
            this.lblSensor1.Location = new System.Drawing.Point(12, 9);
            this.lblSensor1.Name = "lblSensor1";
            this.lblSensor1.Size = new System.Drawing.Size(128, 30);
            this.lblSensor1.TabIndex = 0;
            this.lblSensor1.Text = "Sensor 1 : ";
            // 
            // lblSensor2
            // 
            this.lblSensor2.AutoSize = true;
            this.lblSensor2.Location = new System.Drawing.Point(12, 46);
            this.lblSensor2.Name = "lblSensor2";
            this.lblSensor2.Size = new System.Drawing.Size(128, 30);
            this.lblSensor2.TabIndex = 1;
            this.lblSensor2.Text = "Sensor 2 : ";
            // 
            // lblSensor3
            // 
            this.lblSensor3.AutoSize = true;
            this.lblSensor3.Location = new System.Drawing.Point(12, 86);
            this.lblSensor3.Name = "lblSensor3";
            this.lblSensor3.Size = new System.Drawing.Size(128, 30);
            this.lblSensor3.TabIndex = 2;
            this.lblSensor3.Text = "Sensor 3 : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 121);
            this.Controls.Add(this.lblSensor3);
            this.Controls.Add(this.lblSensor2);
            this.Controls.Add(this.lblSensor1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSensor1;
        private System.Windows.Forms.Label lblSensor2;
        private System.Windows.Forms.Label lblSensor3;
    }
}

