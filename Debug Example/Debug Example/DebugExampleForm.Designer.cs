namespace Debug_Example
{
    partial class DebugExampleForm
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
            this.lbDebug = new System.Windows.Forms.ListBox();
            this.btnAssertSuccess = new System.Windows.Forms.Button();
            this.btnAssertFail = new System.Windows.Forms.Button();
            this.cbConditionalAssert = new System.Windows.Forms.CheckBox();
            this.btnConditionalAssert = new System.Windows.Forms.Button();
            this.lblDebugMessage = new System.Windows.Forms.Label();
            this.tbDebugMessage = new System.Windows.Forms.TextBox();
            this.btnSendDebugMessage = new System.Windows.Forms.Button();
            this.btnSendConditonnalMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbDebug
            // 
            this.lbDebug.FormattingEnabled = true;
            this.lbDebug.ItemHeight = 20;
            this.lbDebug.Location = new System.Drawing.Point(12, 12);
            this.lbDebug.Name = "lbDebug";
            this.lbDebug.Size = new System.Drawing.Size(702, 204);
            this.lbDebug.TabIndex = 0;
            // 
            // btnAssertSuccess
            // 
            this.btnAssertSuccess.Location = new System.Drawing.Point(12, 222);
            this.btnAssertSuccess.Name = "btnAssertSuccess";
            this.btnAssertSuccess.Size = new System.Drawing.Size(301, 64);
            this.btnAssertSuccess.TabIndex = 1;
            this.btnAssertSuccess.Text = "Assert Success";
            this.btnAssertSuccess.UseVisualStyleBackColor = true;
            this.btnAssertSuccess.Click += new System.EventHandler(this.btnAssertSuccess_Click);
            // 
            // btnAssertFail
            // 
            this.btnAssertFail.Location = new System.Drawing.Point(12, 292);
            this.btnAssertFail.Name = "btnAssertFail";
            this.btnAssertFail.Size = new System.Drawing.Size(301, 64);
            this.btnAssertFail.TabIndex = 2;
            this.btnAssertFail.Text = "Assert Fail";
            this.btnAssertFail.UseVisualStyleBackColor = true;
            this.btnAssertFail.Click += new System.EventHandler(this.btnAssertFail_Click);
            // 
            // cbConditionalAssert
            // 
            this.cbConditionalAssert.AutoSize = true;
            this.cbConditionalAssert.Location = new System.Drawing.Point(12, 362);
            this.cbConditionalAssert.Name = "cbConditionalAssert";
            this.cbConditionalAssert.Size = new System.Drawing.Size(301, 24);
            this.cbConditionalAssert.TabIndex = 3;
            this.cbConditionalAssert.Text = "Check for Conditional Assert Success";
            this.cbConditionalAssert.UseVisualStyleBackColor = true;
            // 
            // btnConditionalAssert
            // 
            this.btnConditionalAssert.Location = new System.Drawing.Point(12, 392);
            this.btnConditionalAssert.Name = "btnConditionalAssert";
            this.btnConditionalAssert.Size = new System.Drawing.Size(301, 64);
            this.btnConditionalAssert.TabIndex = 4;
            this.btnConditionalAssert.Text = "Conditional Assert";
            this.btnConditionalAssert.UseVisualStyleBackColor = true;
            this.btnConditionalAssert.Click += new System.EventHandler(this.btnConditionalAssert_Click);
            // 
            // lblDebugMessage
            // 
            this.lblDebugMessage.AutoSize = true;
            this.lblDebugMessage.Location = new System.Drawing.Point(545, 244);
            this.lblDebugMessage.Name = "lblDebugMessage";
            this.lblDebugMessage.Size = new System.Drawing.Size(169, 20);
            this.lblDebugMessage.TabIndex = 5;
            this.lblDebugMessage.Text = "Enter Debug message";
            // 
            // tbDebugMessage
            // 
            this.tbDebugMessage.Location = new System.Drawing.Point(413, 267);
            this.tbDebugMessage.Name = "tbDebugMessage";
            this.tbDebugMessage.Size = new System.Drawing.Size(301, 26);
            this.tbDebugMessage.TabIndex = 6;
            this.tbDebugMessage.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tbDebugMessage_PreviewKeyDown);
            // 
            // btnSendDebugMessage
            // 
            this.btnSendDebugMessage.Location = new System.Drawing.Point(413, 299);
            this.btnSendDebugMessage.Name = "btnSendDebugMessage";
            this.btnSendDebugMessage.Size = new System.Drawing.Size(301, 64);
            this.btnSendDebugMessage.TabIndex = 7;
            this.btnSendDebugMessage.Text = "Send Debug Message";
            this.btnSendDebugMessage.UseVisualStyleBackColor = true;
            this.btnSendDebugMessage.Click += new System.EventHandler(this.btnSendDebugMessage_Click);
            // 
            // btnSendConditonnalMessage
            // 
            this.btnSendConditonnalMessage.Location = new System.Drawing.Point(413, 369);
            this.btnSendConditonnalMessage.Name = "btnSendConditonnalMessage";
            this.btnSendConditonnalMessage.Size = new System.Drawing.Size(301, 64);
            this.btnSendConditonnalMessage.TabIndex = 8;
            this.btnSendConditonnalMessage.Text = "Send Condtional Message";
            this.btnSendConditonnalMessage.UseVisualStyleBackColor = true;
            this.btnSendConditonnalMessage.Click += new System.EventHandler(this.btnSendConditionnalMessage_Click);
            // 
            // DebugExampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 475);
            this.Controls.Add(this.btnSendConditonnalMessage);
            this.Controls.Add(this.btnSendDebugMessage);
            this.Controls.Add(this.tbDebugMessage);
            this.Controls.Add(this.lblDebugMessage);
            this.Controls.Add(this.btnConditionalAssert);
            this.Controls.Add(this.cbConditionalAssert);
            this.Controls.Add(this.btnAssertFail);
            this.Controls.Add(this.btnAssertSuccess);
            this.Controls.Add(this.lbDebug);
            this.Name = "DebugExampleForm";
            this.Text = "Debug Examples";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebugExampleForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DebugExampleForm_FormClosed);
            this.Load += new System.EventHandler(this.DebugExampleForm_Load);
            this.Shown += new System.EventHandler(this.DebugExampleForm_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DebugExampleForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbDebug;
        private System.Windows.Forms.Button btnAssertSuccess;
        private System.Windows.Forms.Button btnAssertFail;
        private System.Windows.Forms.CheckBox cbConditionalAssert;
        private System.Windows.Forms.Button btnConditionalAssert;
        private System.Windows.Forms.Label lblDebugMessage;
        private System.Windows.Forms.TextBox tbDebugMessage;
        private System.Windows.Forms.Button btnSendDebugMessage;
        private System.Windows.Forms.Button btnSendConditonnalMessage;
    }
}

