namespace NetFileManager
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
            this.tabFiles = new System.Windows.Forms.TabControl();
            this.tpRequest = new System.Windows.Forms.TabPage();
            this.lvRequestFile = new System.Windows.Forms.ListView();
            this.tpSend = new System.Windows.Forms.TabPage();
            this.lvSendFile = new System.Windows.Forms.ListView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bgwP2PResolver = new System.ComponentModel.BackgroundWorker();
            this.btnRecieve = new System.Windows.Forms.Button();
            this.tabFiles.SuspendLayout();
            this.tpRequest.SuspendLayout();
            this.tpSend.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabFiles
            // 
            this.tabFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabFiles.Controls.Add(this.tpRequest);
            this.tabFiles.Controls.Add(this.tpSend);
            this.tabFiles.Controls.Add(this.tabPage1);
            this.tabFiles.Location = new System.Drawing.Point(1, 0);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.SelectedIndex = 0;
            this.tabFiles.Size = new System.Drawing.Size(840, 496);
            this.tabFiles.TabIndex = 0;
            // 
            // tpRequest
            // 
            this.tpRequest.Controls.Add(this.lvRequestFile);
            this.tpRequest.Location = new System.Drawing.Point(4, 22);
            this.tpRequest.Name = "tpRequest";
            this.tpRequest.Padding = new System.Windows.Forms.Padding(3);
            this.tpRequest.Size = new System.Drawing.Size(832, 470);
            this.tpRequest.TabIndex = 0;
            this.tpRequest.Text = "Files For Request";
            this.tpRequest.UseVisualStyleBackColor = true;
            // 
            // lvRequestFile
            // 
            this.lvRequestFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRequestFile.Location = new System.Drawing.Point(3, 3);
            this.lvRequestFile.Name = "lvRequestFile";
            this.lvRequestFile.Size = new System.Drawing.Size(826, 464);
            this.lvRequestFile.TabIndex = 0;
            this.lvRequestFile.UseCompatibleStateImageBehavior = false;
            this.lvRequestFile.View = System.Windows.Forms.View.Details;
            this.lvRequestFile.SelectedIndexChanged += new System.EventHandler(this.lvRequestFile_SelectedIndexChanged);
            // 
            // tpSend
            // 
            this.tpSend.Controls.Add(this.lvSendFile);
            this.tpSend.Location = new System.Drawing.Point(4, 22);
            this.tpSend.Name = "tpSend";
            this.tpSend.Padding = new System.Windows.Forms.Padding(3);
            this.tpSend.Size = new System.Drawing.Size(832, 470);
            this.tpSend.TabIndex = 1;
            this.tpSend.Text = "Files for Send";
            this.tpSend.UseVisualStyleBackColor = true;
            // 
            // lvSendFile
            // 
            this.lvSendFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSendFile.Location = new System.Drawing.Point(3, 3);
            this.lvSendFile.Name = "lvSendFile";
            this.lvSendFile.Size = new System.Drawing.Size(826, 464);
            this.lvSendFile.TabIndex = 1;
            this.lvSendFile.UseCompatibleStateImageBehavior = false;
            this.lvSendFile.View = System.Windows.Forms.View.Details;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnRecieve);
            this.tabPage1.Controls.Add(this.btnStart);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(832, 470);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(171, 61);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(453, 108);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start Send...";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bgwP2PResolver
            // 
            this.bgwP2PResolver.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwP2PResolver_DoWork);
            // 
            // btnRecieve
            // 
            this.btnRecieve.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecieve.Location = new System.Drawing.Point(171, 266);
            this.btnRecieve.Name = "btnRecieve";
            this.btnRecieve.Size = new System.Drawing.Size(453, 109);
            this.btnRecieve.TabIndex = 1;
            this.btnRecieve.Text = "Recieve ...";
            this.btnRecieve.UseVisualStyleBackColor = true;
            this.btnRecieve.Click += new System.EventHandler(this.btnRecieve_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 495);
            this.Controls.Add(this.tabFiles);
            this.Name = "MainForm";
            this.Text = "P2P File Transfer Tester";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.tabFiles.ResumeLayout(false);
            this.tpRequest.ResumeLayout(false);
            this.tpSend.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabFiles;
        private System.Windows.Forms.TabPage tpRequest;
        private System.Windows.Forms.ListView lvRequestFile;
        private System.Windows.Forms.TabPage tpSend;
        private System.Windows.Forms.ListView lvSendFile;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker bgwP2PResolver;
        private System.Windows.Forms.Button btnRecieve;
    }
}

