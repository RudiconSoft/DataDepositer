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
            this.tabControlStorage = new System.Windows.Forms.TabControl();
            this.tpLocalList = new System.Windows.Forms.TabPage();
            this.tpSendList = new System.Windows.Forms.TabPage();
            this.tpAssembleList = new System.Windows.Forms.TabPage();
            this.tabControlStorage.SuspendLayout();
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
            this.tpSendList.Location = new System.Drawing.Point(4, 22);
            this.tpSendList.Name = "tpSendList";
            this.tpSendList.Padding = new System.Windows.Forms.Padding(3);
            this.tpSendList.Size = new System.Drawing.Size(773, 485);
            this.tpSendList.TabIndex = 1;
            this.tpSendList.Text = "Send List";
            this.tpSendList.UseVisualStyleBackColor = true;
            // 
            // tpAssembleList
            // 
            this.tpAssembleList.Location = new System.Drawing.Point(4, 22);
            this.tpAssembleList.Name = "tpAssembleList";
            this.tpAssembleList.Size = new System.Drawing.Size(773, 485);
            this.tpAssembleList.TabIndex = 2;
            this.tpAssembleList.Text = "Assemble List";
            this.tpAssembleList.UseVisualStyleBackColor = true;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlStorage;
        private System.Windows.Forms.TabPage tpLocalList;
        private System.Windows.Forms.TabPage tpSendList;
        private System.Windows.Forms.TabPage tpAssembleList;
    }
}