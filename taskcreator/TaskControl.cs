using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace GUI.Tools.Copytask_Creator
{
    public partial class TaskControl : UserControl
    {
        private LinkLabel.Link ImageLink;
        private bool IsChanged = false;
        private bool IsExample;
        private bool IsPractice;
        private bool IsInformational;
        private bool MContainsAudio = false;
        private bool MContainsImage;


        public TaskControl()
        {
            InitializeComponent();
        }

        public TaskControl(XmlNode node) : this()
        {
            var info = XMLUtil.GetAttributeValue(node, "informational");
            if (info == "true")
            {
                SetInformational();
            }

            var synthesize = XMLUtil.GetAttributeValue(node, "synthesize");
            if (synthesize == "true")
            {
                IncludeInSynthesis = true;
            }

            var image = XMLUtil.GetAttributeValue(node, "image");
            if (image != "")
            {
                ContainsImage = true;

                ImageLink = new LinkLabel.Link {LinkData = CopyTaskCreator.FileDirectory + "\\" + image};
                linkImage.Text = image;
                linkImage.Links.Add(ImageLink);
            }

            //var audio = XMLUtil.GetAttributeValue(node, "audio");
            //if(audio != "")
            //{
            //    containsAudio = true;
            //    myPlayer.URL = CopyTaskCreator.fileDirectory + "\\" + audio;
            //    myPlayer.Ctlcontrols.stop();
            //}


            TitleTextField.Text = XMLUtil.GetAttributeValue(node, "title");
            InstructionsTextField.Text = XMLUtil.GetChildNodeValue(node, "instructions");

            TargetTextField.Text = XMLUtil.GetChildNodeValue(node, "target");

            if (node.Attributes != null)
            {
                var attr = node.Attributes["timelimit"];
                if (attr != null)
                {
                    cbTimeLimit.Checked = true;
                    nudTimeLimit.Value = decimal.Parse(attr.Value);
                }

                var unlimited = node.Attributes["unlimited"];
                if (unlimited != null)
                {
                    cbUnlimited.Checked = true;
                    cbRepetition.Visible = false;
                    lblTimes.Visible = false;
                    nudRepetitionFrequency.Visible = false;
                }
                else
                {
                    try
                    {
                        var repetition = decimal.Parse(node.Attributes["repetition"].Value);
                        if (repetition > 1)
                        {
                            cbRepetition.Checked = true;
                        }

                        nudRepetitionFrequency.Value = decimal.Parse(node.Attributes["repetition"].Value);
                    }
                    catch (Exception)
                    {
                        // No action required. This simply means there is no attribute set.
                    }
                }
                try
                {
                    IsExample = bool.Parse(node.Attributes["example"].Value);
                    SetExample();
                }
                catch (Exception) { /* do nothing, just don't set attribute */ };
                try
                {
                    IsPractice = bool.Parse(node.Attributes["practice"].Value);
                    SetPractice();
                }
                catch (Exception) { /* do nothing, just don't set attribute */ };
            }
        }

        public bool ContainsImage
        {
            get { return MContainsImage; }
            set
            {
                MContainsImage = value;
                linkImage.Visible = value;
                removeImage.Visible = value;
            }
        }

        public bool ContainsAudio
        {
            get { return MContainsAudio; }
            set
            {
                //m_containsAudio = value;
                //myPlayer.Visible = value;
                //removeAudio.Visible = value;
            }
        }

        public bool IncludeInSynthesis
        {
            get { return cbSynthesis.Checked; }
            set { cbSynthesis.Checked = value; }
        }

        public string Title()
        {
            return TitleTextField.Text;
        }

        private void PictCloseClick(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
            Dispose();
        }

        public void SetInformational()
        {
            IsInformational = true;
            TargetTextField.Visible = false;
            targetLbl.Visible = false;
            nudRepetitionFrequency.Visible = false;
            linkImage.Visible = false;
            btnChooseImage.Visible = false;
            cbRepetition.Visible = false;
            cbTimeLimit.Visible = false;
            InstructionsTextField.Multiline = true;
            InstructionsTextField.Size = new Size(540, 80);
            lblInstructions.Text = "Text";
            lblType.Text = "Text Block";
            cbUnlimited.Visible = false;
            cbSynthesis.Visible = false;
            IsPractice = false;
            //this.BackColor = Color.RosyBrown;
        }

        public void SetExample()
        {
            IsExample = true;
            lblType.Text = "Example";
            cbSynthesis.Visible = false;
            IsPractice = false;
            //this.BackColor = Color.SandyBrown;
        }

        internal void SetPractice()
        {
            IsPractice = true;
            lblType.Text = "Practice Block";
            IncludeInSynthesis = false;
            cbSynthesis.Visible = false;
            IsExample = false;
        }

        /// <summary>
        ///     Return whether this task is an actual task that should be executed or not.
        ///     A task is not an 'actual task' when it is either informational or 'an example'.
        /// </summary>
        /// <returns>
        ///     True if this task is an actual task, false if
        ///     it is a dummy task
        /// </returns>
        public bool IsActualTask()
        {
            return !(IsInformational || IsExample);
        }

        /// <summary>
        ///     Returns the subtask as an XElement. If an image or sound has been linked to the task, these files are copied to a
        ///     temporary folder.
        /// </summary>
        /// <returns></returns>
        public XElement ToXml()
        {
            var task = new XElement("task", new XAttribute("title", TitleTextField.Text),
                new XElement("instructions", InstructionsTextField.Text), new XElement("target", TargetTextField.Text));

            if (IsInformational)
            {
                task.Add(new XAttribute("informational", "true"));
            }

            if (IncludeInSynthesis)
            {
                task.Add(new XAttribute("synthesize", "true"));
            }

            if (ContainsImage)
            {
                var filePath = CopyTaskCreator.FileDirectory + "\\" + linkImage.Text;
                if (!File.Exists(filePath))
                    File.Copy(ImageLink.LinkData.ToString(), filePath);
                task.Add(new XAttribute("image", linkImage.Text));
            }

            //if (containsAudio)
            //{
            //    var audioFileName = Path.GetFileName(myPlayer.URL);
            //    var filePath = CopyTaskCreator.fileDirectory + "\\" + audioFileName;
            //    if(!filePath.Equals(myPlayer.URL) && !File.Exists(filePath))
            //        File.Copy(myPlayer.URL, filePath);
            //    task.Add(new XAttribute("audio", audioFileName));
            //}

            if (cbUnlimited.Checked)
            {
                task.Add(new XAttribute("unlimited", "true"));
            }
            else if (cbRepetition.Checked)
            {
                task.Add(new XAttribute("repetition", nudRepetitionFrequency.Value));
            }

            if (cbTimeLimit.Checked)
            {
                task.Add(new XAttribute("timelimit", nudTimeLimit.Value));
            }

            if (IsExample)
            {
                task.Add(new XAttribute("example", "true"));
            }

            if (IsPractice)
            {
                task.Add(new XAttribute("practice", "true"));
            }

            return task;
        }

        private void RepetitionCheckedChanged(object sender, EventArgs e)
        {
            nudRepetitionFrequency.Visible = cbRepetition.Checked;
            lblTimes.Visible = cbRepetition.Checked;
        }

        private void MoveUpClick(object sender, EventArgs e)
        {
            var parent = Parent;

            parent.Controls.SetChildIndex(this, parent.Controls.IndexOf(this) - 1);
        }

        private void MoveDownClick(object sender, EventArgs e)
        {
            var parent = Parent;

            parent.Controls.SetChildIndex(this, parent.Controls.IndexOf(this) + 1);
        }

        private void LinkImageLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var lnk = (LinkLabel) sender;
            lnk.Links[lnk.Links.IndexOf(e.Link)].Visited = true;
            Process.Start(e.Link.LinkData.ToString());
        }

        private void BtnChooseImageClick(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
                      {
                          Filter = "Image Files (*.*)|*.*",
                          FilterIndex = 1,
                          Multiselect = false
                      };
            var dialogResult = ofd.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                if (ImageLink != null)
                {
                    linkImage.Links.Remove(ImageLink);
                }
                ImageLink = new LinkLabel.Link {LinkData = ofd.FileName};
                linkImage.Text = Path.GetFileName(ofd.FileName);
                linkImage.Links.Add(ImageLink);

                ContainsImage = true;
            }
        }

        private void BtnChooseSoundClick(object sender, EventArgs e)
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "Audio Files (*.*)|*.*";
            //ofd.FilterIndex = 1;
            //ofd.Multiselect = false;
            //var dialogResult = ofd.ShowDialog();

            //if (dialogResult == DialogResult.OK)
            //{
            //    myPlayer.URL = ofd.FileName;
            //    containsAudio = true;
            //}
        }

        private void RemoveAudioClick(object sender, EventArgs e)
        {
            //myPlayer.URL = "";
            //containsAudio = false;
        }

        private void RemoveImageClick(object sender, EventArgs e)
        {
            ContainsImage = false;
        }

        private void CbTimeLimitCheckedChanged(object sender, EventArgs e)
        {
            nudTimeLimit.Visible = cbTimeLimit.Checked;
            lblSeconds.Visible = cbTimeLimit.Checked;
        }

        private void CbUnlimitedCheckedChanged(object sender, EventArgs e)
        {
            cbRepetition.Visible = !cbUnlimited.Checked;
            if (cbUnlimited.Checked)
            {
                lblTimes.Visible = false;
                nudRepetitionFrequency.Visible = false;
            }
            else
            {
                if (cbRepetition.Checked)
                {
                    lblTimes.Visible = true;
                    nudRepetitionFrequency.Visible = true;
                }
            }
        }

    }
}