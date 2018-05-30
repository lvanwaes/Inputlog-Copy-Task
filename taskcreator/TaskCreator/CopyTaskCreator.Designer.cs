namespace GUI.Tools.Copytask_Creator
{
    partial class CopyTaskCreator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopyTaskCreator));
            this.TasksPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.AddButton = new System.Windows.Forms.Button();
            this.lblGeneralTitle = new System.Windows.Forms.Label();
            this.labelGeneralDescription = new System.Windows.Forms.Label();
            this.txtGeneralTitle = new System.Windows.Forms.TextBox();
            this.txtGeneralDescription = new System.Windows.Forms.TextBox();
            this.CompleteButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.labelInstructions = new System.Windows.Forms.Label();
            this.txtGeneralInstructions = new System.Windows.Forms.TextBox();
            this.AddTextBlockButton = new System.Windows.Forms.Button();
            this.AddExampleButton = new System.Windows.Forms.Button();
            this.btnServer = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCopyTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.AddPracticeButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TasksPanel
            // 
            this.TasksPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TasksPanel.AutoScroll = true;
            this.TasksPanel.BackColor = System.Drawing.SystemColors.Control;
            this.TasksPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.TasksPanel.Location = new System.Drawing.Point(0, 226);
            this.TasksPanel.Name = "TasksPanel";
            this.TasksPanel.Size = new System.Drawing.Size(751, 441);
            this.TasksPanel.TabIndex = 0;
            this.TasksPanel.WrapContents = false;
            this.TasksPanel.SizeChanged += new System.EventHandler(this.TasksPanelSizeChanged);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddButton.Image = global::TaskCreator.Properties.Resources.add;
            this.AddButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AddButton.Location = new System.Drawing.Point(3, 680);
            this.AddButton.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(99, 31);
            this.AddButton.TabIndex = 35;
            this.AddButton.Text = "Add task";
            this.AddButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // lblGeneralTitle
            // 
            this.lblGeneralTitle.AutoSize = true;
            this.lblGeneralTitle.Location = new System.Drawing.Point(11, 42);
            this.lblGeneralTitle.Name = "lblGeneralTitle";
            this.lblGeneralTitle.Size = new System.Drawing.Size(76, 13);
            this.lblGeneralTitle.TabIndex = 36;
            this.lblGeneralTitle.Text = "Copy task title:";
            // 
            // labelGeneralDescription
            // 
            this.labelGeneralDescription.AutoSize = true;
            this.labelGeneralDescription.Location = new System.Drawing.Point(11, 71);
            this.labelGeneralDescription.Name = "labelGeneralDescription";
            this.labelGeneralDescription.Size = new System.Drawing.Size(63, 13);
            this.labelGeneralDescription.TabIndex = 37;
            this.labelGeneralDescription.Text = "Description:";
            // 
            // txtGeneralTitle
            // 
            this.txtGeneralTitle.Location = new System.Drawing.Point(133, 39);
            this.txtGeneralTitle.Name = "txtGeneralTitle";
            this.txtGeneralTitle.Size = new System.Drawing.Size(368, 20);
            this.txtGeneralTitle.TabIndex = 1;
            // 
            // txtGeneralDescription
            // 
            this.txtGeneralDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGeneralDescription.Location = new System.Drawing.Point(133, 68);
            this.txtGeneralDescription.Name = "txtGeneralDescription";
            this.txtGeneralDescription.Size = new System.Drawing.Size(605, 20);
            this.txtGeneralDescription.TabIndex = 2;
            // 
            // CompleteButton
            // 
            this.CompleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CompleteButton.Location = new System.Drawing.Point(676, 680);
            this.CompleteButton.Name = "CompleteButton";
            this.CompleteButton.Size = new System.Drawing.Size(75, 31);
            this.CompleteButton.TabIndex = 40;
            this.CompleteButton.Text = "Save to disk";
            this.CompleteButton.UseVisualStyleBackColor = true;
            this.CompleteButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(621, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Language:";
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LanguageComboBox.FormattingEnabled = true;
            this.LanguageComboBox.Location = new System.Drawing.Point(695, 38);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Size = new System.Drawing.Size(43, 21);
            this.LanguageComboBox.TabIndex = 100;
            // 
            // labelInstructions
            // 
            this.labelInstructions.AutoSize = true;
            this.labelInstructions.Location = new System.Drawing.Point(11, 106);
            this.labelInstructions.Name = "labelInstructions";
            this.labelInstructions.Size = new System.Drawing.Size(103, 13);
            this.labelInstructions.TabIndex = 43;
            this.labelInstructions.Text = "General instructions:";
            // 
            // txtGeneralInstructions
            // 
            this.txtGeneralInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGeneralInstructions.Location = new System.Drawing.Point(133, 98);
            this.txtGeneralInstructions.Multiline = true;
            this.txtGeneralInstructions.Name = "txtGeneralInstructions";
            this.txtGeneralInstructions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGeneralInstructions.Size = new System.Drawing.Size(605, 119);
            this.txtGeneralInstructions.TabIndex = 3;
            // 
            // AddTextBlockButton
            // 
            this.AddTextBlockButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddTextBlockButton.Image = global::TaskCreator.Properties.Resources.add;
            this.AddTextBlockButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddTextBlockButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AddTextBlockButton.Location = new System.Drawing.Point(253, 680);
            this.AddTextBlockButton.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.AddTextBlockButton.Name = "AddTextBlockButton";
            this.AddTextBlockButton.Size = new System.Drawing.Size(110, 31);
            this.AddTextBlockButton.TabIndex = 46;
            this.AddTextBlockButton.Text = "Add text block";
            this.AddTextBlockButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddTextBlockButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddTextBlockButton.UseVisualStyleBackColor = true;
            this.AddTextBlockButton.Click += new System.EventHandler(this.AddTextBlockButtonClick);
            // 
            // AddExampleButton
            // 
            this.AddExampleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddExampleButton.Image = global::TaskCreator.Properties.Resources.add;
            this.AddExampleButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddExampleButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AddExampleButton.Location = new System.Drawing.Point(124, 680);
            this.AddExampleButton.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.AddExampleButton.Name = "AddExampleButton";
            this.AddExampleButton.Size = new System.Drawing.Size(107, 31);
            this.AddExampleButton.TabIndex = 47;
            this.AddExampleButton.Text = "Add example";
            this.AddExampleButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddExampleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddExampleButton.UseVisualStyleBackColor = true;
            this.AddExampleButton.Click += new System.EventHandler(this.AddExampleButtonClick);
            // 
            // btnServer
            // 
            this.btnServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnServer.Location = new System.Drawing.Point(543, 680);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(98, 31);
            this.btnServer.TabIndex = 48;
            this.btnServer.Text = "Send to server";
            this.btnServer.UseVisualStyleBackColor = true;
            this.btnServer.Visible = false;
            this.btnServer.Click += new System.EventHandler(this.BtnServerClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(751, 24);
            this.menuStrip1.TabIndex = 101;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCopyTaskToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.sendToServerToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newCopyTaskToolStripMenuItem
            // 
            this.newCopyTaskToolStripMenuItem.Name = "newCopyTaskToolStripMenuItem";
            this.newCopyTaskToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.newCopyTaskToolStripMenuItem.Text = "New copy task";
            this.newCopyTaskToolStripMenuItem.Click += new System.EventHandler(this.NewCopyTaskToolStripMenuItemClick);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.openToolStripMenuItem.Text = "Open copy task...";
            this.openToolStripMenuItem.ToolTipText = "Open existing copy task";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.ToolTipText = "Save changes";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.ToolTipText = "Save copy task to specified location";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItemClick);
            // 
            // sendToServerToolStripMenuItem
            // 
            this.sendToServerToolStripMenuItem.Name = "sendToServerToolStripMenuItem";
            this.sendToServerToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.sendToServerToolStripMenuItem.Text = "Send to server";
            this.sendToServerToolStripMenuItem.ToolTipText = "Submit the copy task to the server";
            this.sendToServerToolStripMenuItem.Visible = false;
            this.sendToServerToolStripMenuItem.Click += new System.EventHandler(this.SendToServerToolStripMenuItemClick);
            // 
            // AddPracticeButton
            // 
            this.AddPracticeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddPracticeButton.Image = global::TaskCreator.Properties.Resources.add;
            this.AddPracticeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddPracticeButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AddPracticeButton.Location = new System.Drawing.Point(385, 680);
            this.AddPracticeButton.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.AddPracticeButton.Name = "AddPracticeButton";
            this.AddPracticeButton.Size = new System.Drawing.Size(110, 31);
            this.AddPracticeButton.TabIndex = 102;
            this.AddPracticeButton.Text = "Add practice";
            this.AddPracticeButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddPracticeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddPracticeButton.UseVisualStyleBackColor = true;
            this.AddPracticeButton.Click += new System.EventHandler(this.AddPracticeButton_Click);
            // 
            // CopyTaskCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(751, 712);
            this.Controls.Add(this.AddPracticeButton);
            this.Controls.Add(this.btnServer);
            this.Controls.Add(this.AddExampleButton);
            this.Controls.Add(this.AddTextBlockButton);
            this.Controls.Add(this.CompleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.txtGeneralInstructions);
            this.Controls.Add(this.labelInstructions);
            this.Controls.Add(this.LanguageComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGeneralDescription);
            this.Controls.Add(this.txtGeneralTitle);
            this.Controls.Add(this.labelGeneralDescription);
            this.Controls.Add(this.lblGeneralTitle);
            this.Controls.Add(this.TasksPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(650, 500);
            this.Name = "CopyTaskCreator";
            this.Text = "Copy Task Creator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel TasksPanel;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label lblGeneralTitle;
        private System.Windows.Forms.Label labelGeneralDescription;
        private System.Windows.Forms.TextBox txtGeneralTitle;
        private System.Windows.Forms.TextBox txtGeneralDescription;
        private System.Windows.Forms.Button CompleteButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox LanguageComboBox;
        private System.Windows.Forms.Label labelInstructions;
        private System.Windows.Forms.TextBox txtGeneralInstructions;
        private System.Windows.Forms.Button AddTextBlockButton;
        private System.Windows.Forms.Button AddExampleButton;
        private System.Windows.Forms.Button btnServer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendToServerToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem newCopyTaskToolStripMenuItem;
        private System.Windows.Forms.Button AddPracticeButton;
    }
}

