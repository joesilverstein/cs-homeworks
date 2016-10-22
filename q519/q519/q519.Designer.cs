namespace q519
{
    partial class q519
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.symbolTextBox = new System.Windows.Forms.TextBox();
            this.graphButton = new System.Windows.Forms.Button();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Symbol: ";
            // 
            // symbolTextBox
            // 
            this.symbolTextBox.Location = new System.Drawing.Point(67, 12);
            this.symbolTextBox.Name = "symbolTextBox";
            this.symbolTextBox.Size = new System.Drawing.Size(100, 20);
            this.symbolTextBox.TabIndex = 1;
            // 
            // graphButton
            // 
            this.graphButton.Location = new System.Drawing.Point(214, 11);
            this.graphButton.Name = "graphButton";
            this.graphButton.Size = new System.Drawing.Size(122, 23);
            this.graphButton.TabIndex = 2;
            this.graphButton.Text = "Graph Historical Prices";
            this.graphButton.UseVisualStyleBackColor = true;
            this.graphButton.Click += new System.EventHandler(this.graphButton_Click);
            // 
            // graphPanel
            // 
            this.graphPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphPanel.Location = new System.Drawing.Point(12, 48);
            this.graphPanel.MaximumSize = new System.Drawing.Size(850, 350);
            this.graphPanel.MinimumSize = new System.Drawing.Size(850, 350);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(850, 350);
            this.graphPanel.TabIndex = 4;
            this.graphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphPanel_Paint);
            // 
            // q519
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 411);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.graphButton);
            this.Controls.Add(this.symbolTextBox);
            this.Controls.Add(this.label1);
            this.Name = "q519";
            this.Text = "Quest 519 -- Joseph Silverstein";
            this.Load += new System.EventHandler(this.q519_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox symbolTextBox;
        private System.Windows.Forms.Button graphButton;
        private System.Windows.Forms.Panel graphPanel;
    }
}

