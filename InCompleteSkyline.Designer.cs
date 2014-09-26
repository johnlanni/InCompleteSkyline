namespace InCompleteSkylineUI
{
    partial class mainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.datasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseDatasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mutliSetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.divideDatasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alogrithrimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alg1 = new System.Windows.Forms.ToolStripMenuItem();
            this.alg2 = new System.Windows.Forms.ToolStripMenuItem();
            this.alg3 = new System.Windows.Forms.ToolStripMenuItem();
            this.algorithmComparisonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.demonstrateRealDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nBAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DrawPanel = new System.Windows.Forms.Panel();
            this.PdrawButton = new System.Windows.Forms.Button();
            this.PsaveButton = new System.Windows.Forms.Button();
            this.EditText = new System.Windows.Forms.RichTextBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.savebmpdialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datasetToolStripMenuItem,
            this.alogrithrimToolStripMenuItem,
            this.algorithmComparisonToolStripMenuItem,
            this.demonstrateRealDataToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(824, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // datasetToolStripMenuItem
            // 
            this.datasetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseDatasetToolStripMenuItem,
            this.divideDatasetToolStripMenuItem});
            this.datasetToolStripMenuItem.Name = "datasetToolStripMenuItem";
            this.datasetToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
            this.datasetToolStripMenuItem.Text = "Dataset";
            // 
            // chooseDatasetToolStripMenuItem
            // 
            this.chooseDatasetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singleSetToolStripMenuItem,
            this.mutliSetsToolStripMenuItem});
            this.chooseDatasetToolStripMenuItem.Name = "chooseDatasetToolStripMenuItem";
            this.chooseDatasetToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.chooseDatasetToolStripMenuItem.Text = "Choose Datasets";
            // 
            // singleSetToolStripMenuItem
            // 
            this.singleSetToolStripMenuItem.Name = "singleSetToolStripMenuItem";
            this.singleSetToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.singleSetToolStripMenuItem.Text = "Single Set";
            this.singleSetToolStripMenuItem.Click += new System.EventHandler(this.singleSetToolStripMenuItem_Click);
            // 
            // mutliSetsToolStripMenuItem
            // 
            this.mutliSetsToolStripMenuItem.Name = "mutliSetsToolStripMenuItem";
            this.mutliSetsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.mutliSetsToolStripMenuItem.Text = "Mutli Sets";
            this.mutliSetsToolStripMenuItem.Click += new System.EventHandler(this.mutliSetsToolStripMenuItem_Click);
            // 
            // divideDatasetToolStripMenuItem
            // 
            this.divideDatasetToolStripMenuItem.Name = "divideDatasetToolStripMenuItem";
            this.divideDatasetToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.divideDatasetToolStripMenuItem.Text = "Divide Dataset";
            this.divideDatasetToolStripMenuItem.Click += new System.EventHandler(this.divideDatasetToolStripMenuItem_Click);
            // 
            // alogrithrimToolStripMenuItem
            // 
            this.alogrithrimToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alg1,
            this.alg2,
            this.alg3});
            this.alogrithrimToolStripMenuItem.Name = "alogrithrimToolStripMenuItem";
            this.alogrithrimToolStripMenuItem.Size = new System.Drawing.Size(116, 21);
            this.alogrithrimToolStripMenuItem.Text = "Single Algorithm";
            // 
            // alg1
            // 
            this.alg1.CheckOnClick = true;
            this.alg1.Name = "alg1";
            this.alg1.Size = new System.Drawing.Size(246, 22);
            this.alg1.Text = "Bitmap_based_skyline_variant";
            this.alg1.Click += new System.EventHandler(this.bitmapbasedskylinevariantToolStripMenuItem_Click);
            // 
            // alg2
            // 
            this.alg2.CheckOnClick = true;
            this.alg2.Name = "alg2";
            this.alg2.Size = new System.Drawing.Size(246, 22);
            this.alg2.Text = "Bucket";
            this.alg2.Click += new System.EventHandler(this.bucketToolStripMenuItem_Click);
            // 
            // alg3
            // 
            this.alg3.Name = "alg3";
            this.alg3.Size = new System.Drawing.Size(246, 22);
            this.alg3.Text = "VP_based_skyline_variant";
            this.alg3.Click += new System.EventHandler(this.vPbasedskylinevariantToolStripMenuItem_Click);
            // 
            // algorithmComparisonToolStripMenuItem
            // 
            this.algorithmComparisonToolStripMenuItem.Name = "algorithmComparisonToolStripMenuItem";
            this.algorithmComparisonToolStripMenuItem.Size = new System.Drawing.Size(152, 21);
            this.algorithmComparisonToolStripMenuItem.Text = "Algorithm Comparison";
            this.algorithmComparisonToolStripMenuItem.Click += new System.EventHandler(this.algorithmComparisonToolStripMenuItem_Click);
            // 
            // demonstrateRealDataToolStripMenuItem
            // 
            this.demonstrateRealDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nBAToolStripMenuItem,
            this.movieToolStripMenuItem});
            this.demonstrateRealDataToolStripMenuItem.Name = "demonstrateRealDataToolStripMenuItem";
            this.demonstrateRealDataToolStripMenuItem.Size = new System.Drawing.Size(169, 21);
            this.demonstrateRealDataToolStripMenuItem.Text = "Demonstrate Real Results";
            this.demonstrateRealDataToolStripMenuItem.Click += new System.EventHandler(this.demonstrateRealDataToolStripMenuItem_Click);
            // 
            // nBAToolStripMenuItem
            // 
            this.nBAToolStripMenuItem.Name = "nBAToolStripMenuItem";
            this.nBAToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.nBAToolStripMenuItem.Text = "NBA";
            // 
            // movieToolStripMenuItem
            // 
            this.movieToolStripMenuItem.Name = "movieToolStripMenuItem";
            this.movieToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.movieToolStripMenuItem.Text = "Movie";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // DrawPanel
            // 
            this.DrawPanel.BackColor = System.Drawing.Color.White;
            this.DrawPanel.Location = new System.Drawing.Point(292, 42);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(520, 360);
            this.DrawPanel.TabIndex = 1;
            this.DrawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.chart_Paint);
            // 
            // PdrawButton
            // 
            this.PdrawButton.Enabled = false;
            this.PdrawButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PdrawButton.Location = new System.Drawing.Point(544, 424);
            this.PdrawButton.Name = "PdrawButton";
            this.PdrawButton.Size = new System.Drawing.Size(104, 33);
            this.PdrawButton.TabIndex = 2;
            this.PdrawButton.Text = "Draw";
            this.PdrawButton.UseVisualStyleBackColor = true;
            this.PdrawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // PsaveButton
            // 
            this.PsaveButton.Enabled = false;
            this.PsaveButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PsaveButton.Location = new System.Drawing.Point(708, 424);
            this.PsaveButton.Name = "PsaveButton";
            this.PsaveButton.Size = new System.Drawing.Size(104, 33);
            this.PsaveButton.TabIndex = 3;
            this.PsaveButton.Text = "Save";
            this.PsaveButton.UseVisualStyleBackColor = true;
            this.PsaveButton.Click += new System.EventHandler(this.PsaveButton_Click);
            // 
            // EditText
            // 
            this.EditText.BackColor = System.Drawing.Color.White;
            this.EditText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EditText.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EditText.Location = new System.Drawing.Point(12, 42);
            this.EditText.Name = "EditText";
            this.EditText.ReadOnly = true;
            this.EditText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.EditText.Size = new System.Drawing.Size(251, 360);
            this.EditText.TabIndex = 4;
            this.EditText.Text = "The algorithm is not running.";
            this.EditText.TextChanged += new System.EventHandler(this.EditText_TextChanged);
            // 
            // stopButton
            // 
            this.stopButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stopButton.Location = new System.Drawing.Point(159, 424);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(104, 33);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "Run";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // fbd
            // 
            this.fbd.Description = "Choose the directory of the dataset";
            this.fbd.ShowNewFolderButton = false;
            // 
            // savebmpdialog
            // 
            this.savebmpdialog.Filter = "JPEG File|*.jpeg|BMP File|*.bmp";
            this.savebmpdialog.RestoreDirectory = true;
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(824, 482);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.EditText);
            this.Controls.Add(this.PsaveButton);
            this.Controls.Add(this.PdrawButton);
            this.Controls.Add(this.DrawPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(840, 520);
            this.Name = "mainWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InCompleteSkyline";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel DrawPanel;
        private System.Windows.Forms.Button PdrawButton;
        private System.Windows.Forms.Button PsaveButton;
        private System.Windows.Forms.RichTextBox EditText;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ToolStripMenuItem datasetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseDatasetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singleSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem divideDatasetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mutliSetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alogrithrimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algorithmComparisonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alg1;
        private System.Windows.Forms.ToolStripMenuItem alg2;
        private System.Windows.Forms.ToolStripMenuItem alg3;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.ToolStripMenuItem demonstrateRealDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nBAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movieToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog savebmpdialog;

    }
}

