namespace GUI.Tools.Copytask_Creator
{
    partial class TaskControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TargetTextField = new System.Windows.Forms.TextBox();
            this.cbRepetition = new System.Windows.Forms.CheckBox();
            this.targetLbl = new System.Windows.Forms.Label();
            this.nudRepetitionFrequency = new System.Windows.Forms.NumericUpDown();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.InstructionsTextField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TitleTextField = new System.Windows.Forms.TextBox();
            this.lblTimes = new System.Windows.Forms.Label();
            this.linkImage = new System.Windows.Forms.LinkLabel();
            this.btnChooseImage = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.btnChooseSound = new System.Windows.Forms.Button();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.nudTimeLimit = new System.Windows.Forms.NumericUpDown();
            this.cbTimeLimit = new System.Windows.Forms.CheckBox();
            this.cbUnlimited = new System.Windows.Forms.CheckBox();
            this.myToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cbSynthesis = new System.Windows.Forms.CheckBox();
            this.removeImage = new System.Windows.Forms.PictureBox();
            this.removeAudio = new System.Windows.Forms.PictureBox();
            this.moveDown = new System.Windows.Forms.PictureBox();
            this.moveUp = new System.Windows.Forms.PictureBox();
            this.pictClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudRepetitionFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeAudio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictClose)).BeginInit();
            this.SuspendLayout();
            // 
            // TargetTextField
            // 
            this.TargetTextField.AllowDrop = true;
            this.TargetTextField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetTextField.Location = new System.Drawing.Point(124, 129);
            this.TargetTextField.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.TargetTextField.Name = "TargetTextField";
            this.TargetTextField.Size = new System.Drawing.Size(579, 20);
            this.TargetTextField.TabIndex = 12;
            // 
            // cbRepetition
            // 
            this.cbRepetition.AutoSize = true;
            this.cbRepetition.Location = new System.Drawing.Point(36, 166);
            this.cbRepetition.Name = "cbRepetition";
            this.cbRepetition.Size = new System.Drawing.Size(74, 17);
            this.cbRepetition.TabIndex = 13;
            this.cbRepetition.Text = "Repetition";
            this.cbRepetition.UseVisualStyleBackColor = true;
            this.cbRepetition.CheckedChanged += new System.EventHandler(this.RepetitionCheckedChanged);
            // 
            // targetLbl
            // 
            this.targetLbl.AutoSize = true;
            this.targetLbl.Location = new System.Drawing.Point(49, 129);
            this.targetLbl.Name = "targetLbl";
            this.targetLbl.Size = new System.Drawing.Size(40, 13);
            this.targetLbl.TabIndex = 45;
            this.targetLbl.Text = "Prompt";
            // 
            // nudRepetitionFrequency
            // 
            this.nudRepetitionFrequency.Location = new System.Drawing.Point(124, 165);
            this.nudRepetitionFrequency.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudRepetitionFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRepetitionFrequency.Name = "nudRepetitionFrequency";
            this.nudRepetitionFrequency.Size = new System.Drawing.Size(43, 20);
            this.nudRepetitionFrequency.TabIndex = 5;
            this.nudRepetitionFrequency.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudRepetitionFrequency.Visible = false;
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Location = new System.Drawing.Point(49, 53);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(61, 13);
            this.lblInstructions.TabIndex = 47;
            this.lblInstructions.Text = "Instructions";
            // 
            // InstructionsTextField
            // 
            this.InstructionsTextField.AcceptsReturn = true;
            this.InstructionsTextField.AllowDrop = true;
            this.InstructionsTextField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstructionsTextField.Location = new System.Drawing.Point(124, 53);
            this.InstructionsTextField.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.InstructionsTextField.Multiline = true;
            this.InstructionsTextField.Name = "InstructionsTextField";
            this.InstructionsTextField.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InstructionsTextField.Size = new System.Drawing.Size(579, 67);
            this.InstructionsTextField.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Title";
            // 
            // TitleTextField
            // 
            this.TitleTextField.AllowDrop = true;
            this.TitleTextField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleTextField.Location = new System.Drawing.Point(124, 27);
            this.TitleTextField.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.TitleTextField.Name = "TitleTextField";
            this.TitleTextField.Size = new System.Drawing.Size(579, 20);
            this.TitleTextField.TabIndex = 10;
            // 
            // lblTimes
            // 
            this.lblTimes.AutoSize = true;
            this.lblTimes.Location = new System.Drawing.Point(173, 167);
            this.lblTimes.Name = "lblTimes";
            this.lblTimes.Size = new System.Drawing.Size(31, 13);
            this.lblTimes.TabIndex = 55;
            this.lblTimes.Text = "times";
            this.lblTimes.Visible = false;
            // 
            // linkImage
            // 
            this.linkImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkImage.AutoSize = true;
            this.linkImage.Location = new System.Drawing.Point(677, 134);
            this.linkImage.Name = "linkImage";
            this.linkImage.Size = new System.Drawing.Size(55, 13);
            this.linkImage.TabIndex = 57;
            this.linkImage.TabStop = true;
            this.linkImage.Text = "linkLabel1";
            this.linkImage.Visible = false;
            this.linkImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkImageLinkClicked);
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseImage.Location = new System.Drawing.Point(594, 129);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(67, 23);
            this.btnChooseImage.TabIndex = 15;
            this.btnChooseImage.Text = "Add image";
            this.btnChooseImage.UseVisualStyleBackColor = true;
            this.btnChooseImage.Visible = false;
            this.btnChooseImage.Click += new System.EventHandler(this.BtnChooseImageClick);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(49, 7);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(35, 13);
            this.lblType.TabIndex = 59;
            this.lblType.Text = "Task";
            // 
            // btnChooseSound
            // 
            this.btnChooseSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseSound.Location = new System.Drawing.Point(426, 126);
            this.btnChooseSound.Name = "btnChooseSound";
            this.btnChooseSound.Size = new System.Drawing.Size(67, 23);
            this.btnChooseSound.TabIndex = 14;
            this.btnChooseSound.Text = "Add audio";
            this.btnChooseSound.UseVisualStyleBackColor = true;
            this.btnChooseSound.Visible = false;
            this.btnChooseSound.Click += new System.EventHandler(this.BtnChooseSoundClick);
            // 
            // lblSeconds
            // 
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.Location = new System.Drawing.Point(531, 167);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(47, 13);
            this.lblSeconds.TabIndex = 66;
            this.lblSeconds.Text = "seconds";
            this.lblSeconds.Visible = false;
            // 
            // nudTimeLimit
            // 
            this.nudTimeLimit.Location = new System.Drawing.Point(482, 165);
            this.nudTimeLimit.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudTimeLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTimeLimit.Name = "nudTimeLimit";
            this.nudTimeLimit.Size = new System.Drawing.Size(42, 20);
            this.nudTimeLimit.TabIndex = 64;
            this.nudTimeLimit.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudTimeLimit.Visible = false;
            // 
            // cbTimeLimit
            // 
            this.cbTimeLimit.AutoSize = true;
            this.cbTimeLimit.Location = new System.Drawing.Point(409, 166);
            this.cbTimeLimit.Name = "cbTimeLimit";
            this.cbTimeLimit.Size = new System.Drawing.Size(69, 17);
            this.cbTimeLimit.TabIndex = 65;
            this.cbTimeLimit.Text = "Time limit";
            this.cbTimeLimit.UseVisualStyleBackColor = true;
            this.cbTimeLimit.CheckedChanged += new System.EventHandler(this.CbTimeLimitCheckedChanged);
            // 
            // cbUnlimited
            // 
            this.cbUnlimited.AutoSize = true;
            this.cbUnlimited.Location = new System.Drawing.Point(223, 166);
            this.cbUnlimited.Name = "cbUnlimited";
            this.cbUnlimited.Size = new System.Drawing.Size(120, 17);
            this.cbUnlimited.TabIndex = 67;
            this.cbUnlimited.Text = "Unlimited repetitions";
            this.cbUnlimited.UseVisualStyleBackColor = true;
            this.cbUnlimited.CheckedChanged += new System.EventHandler(this.CbUnlimitedCheckedChanged);
            // 
            // cbSynthesis
            // 
            this.cbSynthesis.AutoSize = true;
            this.cbSynthesis.Location = new System.Drawing.Point(124, 7);
            this.cbSynthesis.Name = "cbSynthesis";
            this.cbSynthesis.Size = new System.Drawing.Size(234, 17);
            this.cbSynthesis.TabIndex = 69;
            this.cbSynthesis.Text = "Include task in selected component analysis";
            this.cbSynthesis.UseVisualStyleBackColor = true;
            // 
            // removeImage
            // 
            this.removeImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeImage.Image = global::TaskCreator.Properties.Resources.cross_grey;
            this.removeImage.InitialImage = null;
            this.removeImage.Location = new System.Drawing.Point(738, 132);
            this.removeImage.Name = "removeImage";
            this.removeImage.Size = new System.Drawing.Size(17, 17);
            this.removeImage.TabIndex = 63;
            this.removeImage.TabStop = false;
            this.removeImage.Visible = false;
            this.removeImage.Click += new System.EventHandler(this.RemoveImageClick);
            // 
            // removeAudio
            // 
            this.removeAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeAudio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeAudio.Image = global::TaskCreator.Properties.Resources.cross_grey;
            this.removeAudio.InitialImage = null;
            this.removeAudio.Location = new System.Drawing.Point(565, 132);
            this.removeAudio.Name = "removeAudio";
            this.removeAudio.Size = new System.Drawing.Size(17, 17);
            this.removeAudio.TabIndex = 62;
            this.removeAudio.TabStop = false;
            this.removeAudio.Visible = false;
            this.removeAudio.Click += new System.EventHandler(this.RemoveAudioClick);
            // 
            // moveDown
            // 
            this.moveDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.moveDown.Image = global::TaskCreator.Properties.Resources.down;
            this.moveDown.InitialImage = null;
            this.moveDown.Location = new System.Drawing.Point(3, 175);
            this.moveDown.Name = "moveDown";
            this.moveDown.Size = new System.Drawing.Size(17, 17);
            this.moveDown.TabIndex = 54;
            this.moveDown.TabStop = false;
            this.moveDown.Click += new System.EventHandler(this.MoveDownClick);
            // 
            // moveUp
            // 
            this.moveUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.moveUp.Image = global::TaskCreator.Properties.Resources.up;
            this.moveUp.InitialImage = null;
            this.moveUp.Location = new System.Drawing.Point(3, 3);
            this.moveUp.Name = "moveUp";
            this.moveUp.Size = new System.Drawing.Size(17, 17);
            this.moveUp.TabIndex = 53;
            this.moveUp.TabStop = false;
            this.moveUp.Click += new System.EventHandler(this.MoveUpClick);
            // 
            // pictClose
            // 
            this.pictClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictClose.Image = global::TaskCreator.Properties.Resources.cross_grey;
            this.pictClose.InitialImage = null;
            this.pictClose.Location = new System.Drawing.Point(742, 3);
            this.pictClose.Name = "pictClose";
            this.pictClose.Size = new System.Drawing.Size(17, 17);
            this.pictClose.TabIndex = 52;
            this.pictClose.TabStop = false;
            this.pictClose.Click += new System.EventHandler(this.PictCloseClick);
            // 
            // TaskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cbSynthesis);
            this.Controls.Add(this.cbUnlimited);
            this.Controls.Add(this.lblSeconds);
            this.Controls.Add(this.nudTimeLimit);
            this.Controls.Add(this.cbTimeLimit);
            this.Controls.Add(this.removeImage);
            this.Controls.Add(this.removeAudio);
            this.Controls.Add(this.btnChooseSound);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnChooseImage);
            this.Controls.Add(this.linkImage);
            this.Controls.Add(this.lblTimes);
            this.Controls.Add(this.moveDown);
            this.Controls.Add(this.moveUp);
            this.Controls.Add(this.pictClose);
            this.Controls.Add(this.TitleTextField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InstructionsTextField);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.nudRepetitionFrequency);
            this.Controls.Add(this.targetLbl);
            this.Controls.Add(this.cbRepetition);
            this.Controls.Add(this.TargetTextField);
            this.Name = "TaskControl";
            this.Size = new System.Drawing.Size(762, 195);
            ((System.ComponentModel.ISupportInitialize)(this.nudRepetitionFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeAudio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox TargetTextField;
        private System.Windows.Forms.CheckBox cbRepetition;
        private System.Windows.Forms.Label targetLbl;
        private System.Windows.Forms.NumericUpDown nudRepetitionFrequency;
        private System.Windows.Forms.Label lblInstructions;
        public System.Windows.Forms.TextBox InstructionsTextField;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox TitleTextField;
        private System.Windows.Forms.PictureBox pictClose;
        private System.Windows.Forms.PictureBox moveUp;
        private System.Windows.Forms.PictureBox moveDown;
        private System.Windows.Forms.Label lblTimes;
        private System.Windows.Forms.LinkLabel linkImage;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnChooseSound;
        //private AxWMPLib.AxWindowsMediaPlayer myPlayer;
        private System.Windows.Forms.PictureBox removeAudio;
        private System.Windows.Forms.PictureBox removeImage;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.NumericUpDown nudTimeLimit;
        private System.Windows.Forms.CheckBox cbTimeLimit;
        private System.Windows.Forms.CheckBox cbUnlimited;
        private System.Windows.Forms.ToolTip myToolTip;
        private System.Windows.Forms.CheckBox cbSynthesis;


        
        #region Deleted media player code!
            // myPlayer
            // 
            //this.myPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            //this.myPlayer.Enabled = true;
            //this.myPlayer.Location = new System.Drawing.Point(499, 123);
            //this.myPlayer.Name = "myPlayer";
            //this.myPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("myPlayer.OcxState")));
            //this.myPlayer.Size = new System.Drawing.Size(60, 32);
            //this.myPlayer.TabIndex = 61;
            //this.myPlayer.Visible = false;
            //((System.ComponentModel.ISupportInitialize)(this.myPlayer)).EndInit();
            //this.Controls.Add(this.myPlayer);
            //this.myPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            //((System.ComponentModel.ISupportInitialize)(this.myPlayer)).BeginInit();

        #endregion
    }
}
