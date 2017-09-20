namespace DataDepositer
{
    partial class StorageForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.tabControlStorage = new System.Windows.Forms.TabControl();
            this.tpLocalList = new System.Windows.Forms.TabPage();
            this.tpSendList = new System.Windows.Forms.TabPage();
            this.tpAssembleList = new System.Windows.Forms.TabPage();
            this.lvSend = new System.Windows.Forms.ListView();
            this.lvAssemble = new System.Windows.Forms.ListView();
            this.lvLocal = new System.Windows.Forms.ListView();
            this.columnNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnOriginName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnChunksTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControlStorage.SuspendLayout();
            this.tpLocalList.SuspendLayout();
            this.tpSendList.SuspendLayout();
            this.tpAssembleList.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlStorage
            // 
            this.tabControlStorage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlStorage.Controls.Add(this.tpLocalList);
            this.tabControlStorage.Controls.Add(this.tpSendList);
            this.tabControlStorage.Controls.Add(this.tpAssembleList);
            this.tabControlStorage.Location = new System.Drawing.Point(0, 0);
            this.tabControlStorage.Name = "tabControlStorage";
            this.tabControlStorage.SelectedIndex = 0;
            this.tabControlStorage.Size = new System.Drawing.Size(781, 561);
            this.tabControlStorage.TabIndex = 0;
            // 
            // tpLocalList
            // 
            this.tpLocalList.Controls.Add(this.lvLocal);
            this.tpLocalList.Location = new System.Drawing.Point(4, 22);
            this.tpLocalList.Name = "tpLocalList";
            this.tpLocalList.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocalList.Size = new System.Drawing.Size(773, 535);
            this.tpLocalList.TabIndex = 0;
            this.tpLocalList.Text = "Local Storage";
            this.tpLocalList.UseVisualStyleBackColor = true;
            // 
            // tpSendList
            // 
            this.tpSendList.Controls.Add(this.lvSend);
            this.tpSendList.Location = new System.Drawing.Point(4, 22);
            this.tpSendList.Name = "tpSendList";
            this.tpSendList.Padding = new System.Windows.Forms.Padding(3);
            this.tpSendList.Size = new System.Drawing.Size(773, 535);
            this.tpSendList.TabIndex = 1;
            this.tpSendList.Text = "Send List";
            this.tpSendList.UseVisualStyleBackColor = true;
            // 
            // tpAssembleList
            // 
            this.tpAssembleList.Controls.Add(this.lvAssemble);
            this.tpAssembleList.Location = new System.Drawing.Point(4, 22);
            this.tpAssembleList.Name = "tpAssembleList";
            this.tpAssembleList.Size = new System.Drawing.Size(773, 535);
            this.tpAssembleList.TabIndex = 2;
            this.tpAssembleList.Text = "Assemble List";
            this.tpAssembleList.UseVisualStyleBackColor = true;
            // 
            // lvSend
            // 
            this.lvSend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSend.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNumber,
            this.columnFilename,
            this.columnOriginName,
            this.columnChunksTotal});
            this.lvSend.FullRowSelect = true;
            this.lvSend.GridLines = true;
            this.lvSend.Location = new System.Drawing.Point(0, 0);
            this.lvSend.Name = "lvSend";
            this.lvSend.Size = new System.Drawing.Size(770, 480);
            this.lvSend.TabIndex = 0;
            this.lvSend.UseCompatibleStateImageBehavior = false;
            this.lvSend.SelectedIndexChanged += new System.EventHandler(this.lvSend_SelectedIndexChanged);
            // 
            // lvAssemble
            // 
            this.lvAssemble.Location = new System.Drawing.Point(0, 0);
            this.lvAssemble.Name = "lvAssemble";
            this.lvAssemble.Size = new System.Drawing.Size(770, 480);
            this.lvAssemble.TabIndex = 0;
            this.lvAssemble.UseCompatibleStateImageBehavior = false;
            // 
            // lvLocal
            // 
            this.lvLocal.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvLocal.Location = new System.Drawing.Point(0, 0);
            this.lvLocal.Name = "lvLocal";
            this.lvLocal.Size = new System.Drawing.Size(770, 480);
            this.lvLocal.TabIndex = 0;
            this.lvLocal.UseCompatibleStateImageBehavior = false;
            this.lvLocal.SelectedIndexChanged += new System.EventHandler(this.lvLocal_SelectedIndexChanged);
            // 
            // StorageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabControlStorage);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "StorageForm";
            this.ShowIcon = false;
            this.Text = "DataDepositor Storage";
            this.tabControlStorage.ResumeLayout(false);
            this.tpLocalList.ResumeLayout(false);
            this.tpSendList.ResumeLayout(false);
            this.tpAssembleList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlStorage;
        private System.Windows.Forms.TabPage tpLocalList;
        private System.Windows.Forms.TabPage tpSendList;
        private System.Windows.Forms.TabPage tpAssembleList;
        private System.Windows.Forms.ListView lvLocal;
        private System.Windows.Forms.ListView lvSend;
        private System.Windows.Forms.ListView lvAssemble;
        private System.Windows.Forms.ColumnHeader columnNumber;
        private System.Windows.Forms.ColumnHeader columnFilename;
        private System.Windows.Forms.ColumnHeader columnOriginName;
        private System.Windows.Forms.ColumnHeader columnChunksTotal;
    }
}