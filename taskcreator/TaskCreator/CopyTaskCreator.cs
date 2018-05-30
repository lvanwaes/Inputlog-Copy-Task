using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace GUI.Tools.Copytask_Creator
{
    public partial class CopyTaskCreator : Form
    {
        public static string FileDirectory;
        public static string Title;

        private readonly IEnumerable<string> _keyboardLayouts;
        private bool _isExisting;

        private static object[] Languages => new object[]
        {
            "EN", "NL", "CA", "CY", "FR", "FI", "DA", "DE", "ES", "GR", "IT", "NB", "NN", "PL", "PT", "SE", "SV",
            "TR", "Other"
        };

        private static string[] KeyboardLayouts => new string[]
        {
            "AZERTY", "QWERTY", "QWERTZ"
        };
 
        public CopyTaskCreator()
        {
            InitializeComponent();
            LanguageComboBox.Items.AddRange(Languages);
            LanguageComboBox.SelectedItem = "EN";
            _keyboardLayouts = KeyboardLayouts;
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            var task = new TaskControl();
            LayoutTask(task);
        }

        private void LayoutTask(TaskControl task)
        {
            task.SuspendLayout();
            TasksPanel.Controls.Add(task);
            TasksPanel.ScrollControlIntoView(task);
            task.ResumeLayout();
            task.Width = TasksPanel.ClientSize.Width - 10;
        }

        /// <summary>
        ///     Creates new or overwrites existing xml document with all tasks defined by the user.
        /// </summary>
        private void SaveButtonClick(object sender, EventArgs e)
        {
            SaveCopyTask();
        }

        public XElement ToXml()
        {
            var copyTask = new XElement("copytask");
            copyTask.Add(new XElement("title", txtGeneralTitle.Text));
            copyTask.Add(new XElement("description", txtGeneralDescription.Text));
            copyTask.Add(new XElement("language", LanguageComboBox.SelectedItem));

            var lang = LanguageComboBox.SelectedItem != null ? LanguageComboBox.SelectedItem.ToString().ToLower() : "en";

            try
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);
            }
            catch (Exception e)
            {
                // Ignore exception, don't change culture.
            }

            var instructions = new XElement("general_instructions", txtGeneralInstructions.Text);

            copyTask.Add(instructions);

            // Add keyboard layout node
            var layouts = new XElement("layouts");
            copyTask.Add(layouts);

            // Fill up node with keyboard choices
            foreach (var layout in _keyboardLayouts)
            {
                layouts.Add(new XElement("layout", layout));
            }

            var taskControls = TasksPanel.Controls.OfType<TaskControl>().ToList();

            foreach (var taskControl in taskControls)
            {
                var task = taskControl.ToXml();
                copyTask.Add(task);
            }

            return copyTask;
        }

        private void BtnLoadTaskClick(object sender, EventArgs e)
        {
            OpenCopyTask();
        }

        private void OpenCopyTask()
        {
            // Create an instance of the open file dialog box.
            var ofd = new OpenFileDialog
            {
                Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*",
                FilterIndex = 1,
                Multiselect = false
            };

            // Set filter options and filter index.

            // Call the ShowDialog method to show the dialog box.
            var dialogResult = ofd.ShowDialog();

            // Process input if the user clicked OK.
            if (dialogResult == DialogResult.OK)
            {
                ClearAllFields();

                StreamReader inputReader = null;
                try
                {
                    // Open the selected file to read.
                    var tasksXML = new XmlDocument();
                    inputReader = new StreamReader(ofd.FileName, Encoding.UTF8);
                    tasksXML.Load(inputReader);

                    FileDirectory = Path.GetDirectoryName(ofd.FileName);

                    txtGeneralInstructions.Text = XMLUtil.GetChildNodeValue(tasksXML["copytask"], "general_instructions");
                    txtGeneralTitle.Text = XMLUtil.GetChildNodeValue(tasksXML["copytask"], "title");
                    txtGeneralDescription.Text = XMLUtil.GetChildNodeValue(tasksXML["copytask"], "description");
                    LanguageComboBox.SelectedItem = XMLUtil.GetChildNodeValue(tasksXML["copytask"], "language");

                    var taskNodes = tasksXML.DocumentElement.SelectNodes("task");

                    // Create a TaskControl object for each task node in xml document and add it to the taskspanel.
                    if (taskNodes != null)
                    {
                        foreach (XmlNode node in taskNodes)
                        {
                            var task = new TaskControl(node);
                            TasksPanel.Controls.Add(task);
                            TasksPanel.ScrollControlIntoView(task);
                            task.Width = TasksPanel.ClientSize.Width - 10;
                        }

                        _isExisting = true;
                    }
                }
                finally
                {
                    inputReader?.Close();
                }
            }
        }

        private void SaveCopyTask()
        {
            if (!ValidateTitles())
                return;

            var fbd = new FolderBrowserDialog();

            if (FileDirectory == null)
            {
                FileDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "InputLog");
            }

            fbd.SelectedPath = FileDirectory;
            fbd.Description = "Please select the folder where you wish to save the copy task.";

            Title = "copytask";
            if (txtGeneralTitle.Text != "")
                Title = txtGeneralTitle.Text;

            var fileName = Title + ".txt";

            if (_isExisting || fbd.ShowDialog() == DialogResult.OK)
            {
                FileDirectory = _isExisting ? FileDirectory : fbd.SelectedPath;

                var tempDir = new DirectoryInfo(FileDirectory);
                if (!tempDir.Exists)
                {
                    tempDir.Create();
                }

                var filePath = FileDirectory + "\\" + fileName;

                var copyTask = ToXml();

                File.WriteAllText(filePath, copyTask.ToString());
                StreamWriter targetFileWriter = null;
                try
                {
                    targetFileWriter = new StreamWriter(filePath, false, Encoding.UTF8);
                    targetFileWriter.Write(copyTask.ToString());
                }
                finally
                {
                    if (targetFileWriter != null)
                    {
                        targetFileWriter.Close();
                    }
                }
                var shortName = Path.GetFileName(fileName);
                MessageBox.Show("Copy task \'" + shortName + "\' saved to folder " + Path.GetDirectoryName(filePath));
                _isExisting = true;
            }
        }

        /// <summary>
        ///     Save As - for a copy task. Allows the user to select
        ///     a different name than for the copy task.
        /// </summary>
        private void SaveCopyTaskAs()
        {
            if (!ValidateTitles())
            {
                return;
            }

            // If a path is not already set, set it to MyDocuments/Inputlog
            if (FileDirectory == null)
            {
                FileDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "InputLog");
            }


            var sfd = new SaveFileDialog
                      {
                          RestoreDirectory = true,
                          CheckPathExists = true,
                          DefaultExt = "txt",
                          Filter = "CopyTask Files (*.txt)|*.txt|All Files(*.*)|*.*",
                          OverwritePrompt = true,
                          InitialDirectory = FileDirectory
                      };

            // If SaveAs = ok, transform this task to XML, then write it to the chosen file.
            StreamWriter targetFileWriter = null;
            try
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var targetFileStream = sfd.OpenFile();
                    targetFileWriter = new StreamWriter(targetFileStream, Encoding.UTF8);
                    var copyTaskContent = ToXml().ToString();
                    targetFileWriter.Write(copyTaskContent);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Saving document failed: unexpected error caught [" + e.GetType() + "]",
                    "Error", MessageBoxButtons.OK );
            }
            finally
            {
                if (targetFileWriter != null)
                {
                    targetFileWriter.Close();
                }
            }

            // At this point the file is an 'already existing file'.
            _isExisting = true;
        }

        private bool ValidateTitles()
        {
            var allTasks = TasksPanel.Controls.OfType<TaskControl>().ToList();
            var validated = true;
            foreach (var task in allTasks)
            {
                if (task.Title() == string.Empty)
                    validated = false;
                var allTitles = allTasks.Select(t => t.Title()).Distinct().ToList();
                if (allTitles.Count != allTasks.Count)
                {
                    validated = false;
                }
            }

            if (!validated)
                MessageBox.Show( "Each task is required to have a title, and this title must be unique." +
                                 " Please review the titles you have given to your tasks.");

            return validated;
        }

        private void TasksPanelSizeChanged(object sender, EventArgs e)
        {
            TasksPanel.SuspendLayout();

            var taskControls = TasksPanel.Controls.
                OfType<TaskControl>().ToList();

            foreach (var task in taskControls)
            {
                task.Width = TasksPanel.ClientSize.Width - 10;
            }

            TasksPanel.ResumeLayout();
        }

        private void AddTextBlockButtonClick(object sender, EventArgs e)
        {
            var task = new TaskControl();
            task.SetInformational();

            LayoutTask(task);
        }

        private void AddExampleButtonClick(object sender, EventArgs e)
        {
            var task = new TaskControl();
            task.SetExample();

            LayoutTask(task);
        }

        private void AddPracticeButton_Click(object sender, EventArgs e)
        {
            var task = new TaskControl();
            task.SetPractice();
            LayoutTask(task);
        }

        //private async void sendToServer()
        //{
        //    saveCopyTask();

        //    bool connected = false, cancelled = false;
        //    while (!connected && !cancelled)
        //    {
        //        DialogResult dr = Credentials.CredentialsDialog();
        //        if (dr == DialogResult.OK)
        //        {
        //            connected = await ServerConnection.checkCredentials(Properties.Settings.Default.username, Properties.Settings.Default.password);
        //            if (!connected)
        //            {
        //                var result = MessageBox.Show("Please check if you entered your username and password correctly.", "Wrong credentials", MessageBoxButtons.OKCancel);
        //                if (result == DialogResult.Cancel)
        //                {
        //                    cancelled = true;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            cancelled = true;
        //        }
        //    }
        //    if (connected)
        //    {
        //        //zip directory
        //        string startPath = fileDirectory;
        //        string zipPath = fileDirectory + ".zip";

        //        for (int i = 1; File.Exists(zipPath); i++)
        //        {
        //            zipPath = fileDirectory + "_" + i + ".zip";
        //        }

        //        ZipFile.CreateFromDirectory(startPath, zipPath, CompressionLevel.Fastest, true);


        //        var serverFileName = await ServerConnection.uploadCopyTask(Properties.Settings.Default.username, Properties.Settings.Default.password, zipPath, title);
        //        if (serverFileName != "")
        //        {
        //            MessageBox.Show("Copy task was successfully sent to server. You will now be redirected to a web page to finish the process.");

        //            File.Delete(zipPath);

        //            Process.Start("http://localhost:18477/Copy/Manage?creator=" + Properties.Settings.Default.username + "&task=" + serverFileName);

        //        }
        //    }
        //}

        private void BtnServerClick(object sender, EventArgs e)
        {
            //sendToServer();
        }

        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            SaveCopyTask();
        }

        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            OpenCopyTask();
        }

        private void SaveAsToolStripMenuItemClick(object sender, EventArgs e)
        {
            SaveCopyTaskAs();
        }

        private void SendToServerToolStripMenuItemClick(object sender, EventArgs e)
        {
            //sendToServer();
        }

        private void NewCopyTaskToolStripMenuItemClick(object sender, EventArgs e)
        {
            NewCopyTask();
        }

        private void NewCopyTask()
        {
            var response = MessageBox.Show("Do you wish to save your current copy task?", "Save copy task",
                MessageBoxButtons.YesNoCancel);

            switch (response)
            {
                case DialogResult.Cancel:
                    return;
                case DialogResult.Yes:
                    SaveCopyTask();
                    break;
                case DialogResult.No:
                    break;
            }

            ClearAllFields();
            _isExisting = false;
        }

        private void ClearAllFields()
        {
            // Remove all current TaskControls from the copytask form.
            TasksPanel.Controls.OfType<TaskControl>().ToList().ForEach(b =>{Controls.Remove(b);b.Dispose();});

            //Clear all other fields;
            txtGeneralTitle.Text = "";
            txtGeneralDescription.Text = "";
            txtGeneralInstructions.Text = "";
            LanguageComboBox.SelectedIndex = -1;
        }
    }
}