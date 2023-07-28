namespace WindowsFormsApp
{
    partial class Form1
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolComboBoxDatasetsSelection = new System.Windows.Forms.ToolStripComboBox();
            this.toolPreviousDataset = new System.Windows.Forms.ToolStripButton();
            this.toolNextDataset = new System.Windows.Forms.ToolStripButton();
            this.toolPreviousPositiveDataSet = new System.Windows.Forms.ToolStripButton();
            this.toolNextPositiveDataSet = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadHomeTeamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadAwayTeamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shootingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passingToMostForwardTeammateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.propertyGrid_fieldscene = new System.Windows.Forms.PropertyGrid();
            this.listBox_logging = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.defendMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripSeparator1,
            this.toolComboBoxDatasetsSelection,
            this.toolPreviousDataset,
            this.toolNextDataset,
            this.toolPreviousPositiveDataSet,
            this.toolNextPositiveDataSet});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(861, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::WindowsFormsApp.Properties.Resources.OpenDocumentGroup;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolLoadHomeTeam";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::WindowsFormsApp.Properties.Resources.OpenDocumentGroup;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolLoadAwayTeam";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::WindowsFormsApp.Properties.Resources.SaveAll;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "toolSaveAll";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolComboBoxDatasetsSelection
            // 
            this.toolComboBoxDatasetsSelection.Name = "toolComboBoxDatasetsSelection";
            this.toolComboBoxDatasetsSelection.Size = new System.Drawing.Size(121, 25);
            this.toolComboBoxDatasetsSelection.SelectedIndexChanged += new System.EventHandler(this.toolComboBoxDatasetsSelection_SelectedIndexChanged);
            // 
            // toolPreviousDataset
            // 
            this.toolPreviousDataset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPreviousDataset.Image = global::WindowsFormsApp.Properties.Resources.Previous;
            this.toolPreviousDataset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPreviousDataset.Name = "toolPreviousDataset";
            this.toolPreviousDataset.Size = new System.Drawing.Size(23, 22);
            this.toolPreviousDataset.Text = "toolPreviousDataset";
            this.toolPreviousDataset.Click += new System.EventHandler(this.toolPreviousDataset_Click);
            // 
            // toolNextDataset
            // 
            this.toolNextDataset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNextDataset.Image = global::WindowsFormsApp.Properties.Resources.Next;
            this.toolNextDataset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNextDataset.Name = "toolNextDataset";
            this.toolNextDataset.Size = new System.Drawing.Size(23, 22);
            this.toolNextDataset.Text = "toolNextDataset";
            this.toolNextDataset.Click += new System.EventHandler(this.toolNextDataset_Click);
            // 
            // toolPreviousPositiveDataSet
            // 
            this.toolPreviousPositiveDataSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPreviousPositiveDataSet.Image = global::WindowsFormsApp.Properties.Resources.PreviousBookmark;
            this.toolPreviousPositiveDataSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPreviousPositiveDataSet.Name = "toolPreviousPositiveDataSet";
            this.toolPreviousPositiveDataSet.Size = new System.Drawing.Size(23, 22);
            this.toolPreviousPositiveDataSet.Click += new System.EventHandler(this.toolPreviousPositiveDataSet_Click);
            // 
            // toolNextPositiveDataSet
            // 
            this.toolNextPositiveDataSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNextPositiveDataSet.Image = global::WindowsFormsApp.Properties.Resources.NextBookmark;
            this.toolNextPositiveDataSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNextPositiveDataSet.Name = "toolNextPositiveDataSet";
            this.toolNextPositiveDataSet.Size = new System.Drawing.Size(23, 22);
            this.toolNextPositiveDataSet.Click += new System.EventHandler(this.toolNextPositiveDataSet_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.trainToolStripMenuItem,
            this.datasetToolStripMenuItem,
            this.networkToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(861, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadHomeTeamToolStripMenuItem,
            this.loadAwayTeamToolStripMenuItem,
            this.saveAllToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadHomeTeamToolStripMenuItem
            // 
            this.loadHomeTeamToolStripMenuItem.Name = "loadHomeTeamToolStripMenuItem";
            this.loadHomeTeamToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.loadHomeTeamToolStripMenuItem.Text = "Load Home Team";
            // 
            // loadAwayTeamToolStripMenuItem
            // 
            this.loadAwayTeamToolStripMenuItem.Name = "loadAwayTeamToolStripMenuItem";
            this.loadAwayTeamToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.loadAwayTeamToolStripMenuItem.Text = "Load Away Team";
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.saveAllToolStripMenuItem.Text = "Save All";
            // 
            // trainToolStripMenuItem
            // 
            this.trainToolStripMenuItem.Name = "trainToolStripMenuItem";
            this.trainToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.trainToolStripMenuItem.Text = "Train";
            // 
            // datasetToolStripMenuItem
            // 
            this.datasetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.simulateToolStripMenuItem,
            this.annotateToolStripMenuItem});
            this.datasetToolStripMenuItem.Name = "datasetToolStripMenuItem";
            this.datasetToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.datasetToolStripMenuItem.Text = "Dataset";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // simulateToolStripMenuItem
            // 
            this.simulateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shootingMenuItem,
            this.passingToMostForwardTeammateToolStripMenuItem,
            this.defendMenuItem});
            this.simulateToolStripMenuItem.Name = "simulateToolStripMenuItem";
            this.simulateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.simulateToolStripMenuItem.Text = "Simulate";
            // 
            // shootingMenuItem
            // 
            this.shootingMenuItem.Name = "shootingMenuItem";
            this.shootingMenuItem.Size = new System.Drawing.Size(259, 22);
            this.shootingMenuItem.Text = "Shooting";
            this.shootingMenuItem.Click += new System.EventHandler(this.shootingMenuItem_Click);
            // 
            // passingToMostForwardTeammateToolStripMenuItem
            // 
            this.passingToMostForwardTeammateToolStripMenuItem.Name = "passingToMostForwardTeammateToolStripMenuItem";
            this.passingToMostForwardTeammateToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.passingToMostForwardTeammateToolStripMenuItem.Text = "Passing to most forward teammate";
            this.passingToMostForwardTeammateToolStripMenuItem.Click += new System.EventHandler(this.passingToMostForwardTeammateToolStripMenuItem_Click);
            // 
            // annotateToolStripMenuItem
            // 
            this.annotateToolStripMenuItem.Name = "annotateToolStripMenuItem";
            this.annotateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.annotateToolStripMenuItem.Text = "Annotate";
            // 
            // networkToolStripMenuItem
            // 
            this.networkToolStripMenuItem.Name = "networkToolStripMenuItem";
            this.networkToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.networkToolStripMenuItem.Text = "Network";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBox_logging);
            this.splitContainer1.Size = new System.Drawing.Size(861, 431);
            this.splitContainer1.SplitterDistance = 285;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(861, 285);
            this.splitContainer2.SplitterDistance = 188;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.splitContainer3.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer3_Panel1_Paint);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.propertyGrid_fieldscene);
            this.splitContainer3.Size = new System.Drawing.Size(669, 285);
            this.splitContainer3.SplitterDistance = 480;
            this.splitContainer3.TabIndex = 0;
            // 
            // propertyGrid_fieldscene
            // 
            this.propertyGrid_fieldscene.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid_fieldscene.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid_fieldscene.Name = "propertyGrid_fieldscene";
            this.propertyGrid_fieldscene.Size = new System.Drawing.Size(170, 279);
            this.propertyGrid_fieldscene.TabIndex = 0;
            // 
            // listBox_logging
            // 
            this.listBox_logging.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_logging.FormattingEnabled = true;
            this.listBox_logging.Location = new System.Drawing.Point(12, 2);
            this.listBox_logging.Name = "listBox_logging";
            this.listBox_logging.Size = new System.Drawing.Size(837, 121);
            this.listBox_logging.TabIndex = 0;
            // 
            // defendMenuItem
            // 
            this.defendMenuItem.Name = "defendMenuItem";
            this.defendMenuItem.Size = new System.Drawing.Size(259, 22);
            this.defendMenuItem.Text = "Defend";
            this.defendMenuItem.Click += new System.EventHandler(this.defendMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 480);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Galaxy Football - Robot Brain";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListBox listBox_logging;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem loadHomeTeamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadAwayTeamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datasetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem annotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolPreviousDataset;
        private System.Windows.Forms.ToolStripButton toolNextDataset;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripMenuItem shootingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem passingToMostForwardTeammateToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolComboBoxDatasetsSelection;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PropertyGrid propertyGrid_fieldscene;
        private System.Windows.Forms.ToolStripMenuItem networkToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolPreviousPositiveDataSet;
        private System.Windows.Forms.ToolStripButton toolNextPositiveDataSet;
        private System.Windows.Forms.ToolStripMenuItem defendMenuItem;
    }
}

