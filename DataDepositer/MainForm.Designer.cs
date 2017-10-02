namespace DataDepositer
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.openFileDialogButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonSetUser = new System.Windows.Forms.Button();
            this.btnStartProcess = new System.Windows.Forms.Button();
            this.tbFileDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelFileName = new System.Windows.Forms.Label();
            this.bgwNetwork = new System.ComponentModel.BackgroundWorker();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnViewStorage = new System.Windows.Forms.Button();
            this.timerNetworkCheck = new System.Windows.Forms.Timer(this.components);
            this.timerResolver = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "\"\"";
            this.openFileDialog.Title = "Select File For Crypt & Store";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Data Depositor (c)";
            this.notifyIcon.BalloonTipTitle = "Data Depositor (c)";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Click to open DataDepositor...";
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // openFileDialogButton
            // 
            this.openFileDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openFileDialogButton.Location = new System.Drawing.Point(12, 526);
            this.openFileDialogButton.Name = "openFileDialogButton";
            this.openFileDialogButton.Size = new System.Drawing.Size(103, 23);
            this.openFileDialogButton.TabIndex = 0;
            this.openFileDialogButton.Text = "Open File";
            this.openFileDialogButton.UseVisualStyleBackColor = true;
            this.openFileDialogButton.Click += new System.EventHandler(this.openFileDialogButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "User name :";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(107, 13);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(105, 13);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "USER NOT DEFINE";
            // 
            // buttonSetUser
            // 
            this.buttonSetUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetUser.Location = new System.Drawing.Point(180, 525);
            this.buttonSetUser.Name = "buttonSetUser";
            this.buttonSetUser.Size = new System.Drawing.Size(92, 23);
            this.buttonSetUser.TabIndex = 3;
            this.buttonSetUser.Text = "Set User";
            this.buttonSetUser.UseVisualStyleBackColor = true;
            this.buttonSetUser.Click += new System.EventHandler(this.buttonSetUser_Click);
            // 
            // btnStartProcess
            // 
            this.btnStartProcess.Location = new System.Drawing.Point(16, 418);
            this.btnStartProcess.Name = "btnStartProcess";
            this.btnStartProcess.Size = new System.Drawing.Size(256, 48);
            this.btnStartProcess.TabIndex = 4;
            this.btnStartProcess.Text = "Start Process";
            this.btnStartProcess.UseVisualStyleBackColor = true;
            this.btnStartProcess.Click += new System.EventHandler(this.btnStartProcess_Click);
            // 
            // tbFileDescription
            // 
            this.tbFileDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFileDescription.Location = new System.Drawing.Point(16, 295);
            this.tbFileDescription.MaxLength = 256;
            this.tbFileDescription.Multiline = true;
            this.tbFileDescription.Name = "tbFileDescription";
            this.tbFileDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbFileDescription.Size = new System.Drawing.Size(256, 100);
            this.tbFileDescription.TabIndex = 5;
            this.tbFileDescription.Text = "Enter file descryption here ...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "File Description (max 256 symbols) :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "File name:";
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(19, 235);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(107, 13);
            this.labelFileName.TabIndex = 8;
            this.labelFileName.Text = "NO FILE SELECTED";
            // 
            // bgwNetwork
            // 
            this.bgwNetwork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwNetwork_DoWork);
            this.bgwNetwork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwNetwork_RunWorkerCompleted);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.IncludeSubdirectories = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.Image = global::DataDepositer.Properties.Resources.Control_Panel_icon_25x25;
            this.btnSettings.Location = new System.Drawing.Point(137, 525);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(25, 25);
            this.btnSettings.TabIndex = 9;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnViewStorage
            // 
            this.btnViewStorage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewStorage.Location = new System.Drawing.Point(16, 487);
            this.btnViewStorage.Name = "btnViewStorage";
            this.btnViewStorage.Size = new System.Drawing.Size(256, 23);
            this.btnViewStorage.TabIndex = 10;
            this.btnViewStorage.TabStop = false;
            this.btnViewStorage.Text = "View Storage";
            this.btnViewStorage.UseVisualStyleBackColor = true;
            this.btnViewStorage.Click += new System.EventHandler(this.btnViewStorage_Click);
            // 
            // timerNetworkCheck
            // 
            this.timerNetworkCheck.Enabled = true;
            this.timerNetworkCheck.Interval = 10000;
            this.timerNetworkCheck.Tick += new System.EventHandler(this.timerNetworkCheck_Tick);
            // 
            // timerResolver
            // 
            this.timerResolver.Interval = 100000;
            this.timerResolver.Tick += new System.EventHandler(this.timerResolver_Tick);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 561);
            this.Controls.Add(this.btnViewStorage);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFileDescription);
            this.Controls.Add(this.btnStartProcess);
            this.Controls.Add(this.buttonSetUser);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.openFileDialogButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Depositor (c)";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button openFileDialogButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonSetUser;
        private System.Windows.Forms.Button btnStartProcess;
        private System.Windows.Forms.TextBox tbFileDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelFileName;
        private System.ComponentModel.BackgroundWorker bgwNetwork;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnViewStorage;
        private System.Windows.Forms.Timer timerNetworkCheck;
        private System.Windows.Forms.Timer timerResolver;
    }
}

