namespace LinkedInBrowser1
{
    partial class MainForm
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
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCurrentUrl = new System.Windows.Forms.TextBox();
            this.btnDownloadAll = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoading = new System.Windows.Forms.Button();
            this.btnDownloadOne = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.webB = new System.Windows.Forms.WebBrowser();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtAddress.Location = new System.Drawing.Point(0, 0);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(1383, 22);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.Text = "http://www.microsoft.com";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtStatus);
            this.panel1.Controls.Add(this.txtCurrentUrl);
            this.panel1.Controls.Add(this.btnDownloadAll);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnLoading);
            this.panel1.Controls.Add(this.btnDownloadOne);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1383, 104);
            this.panel1.TabIndex = 2;
            // 
            // txtCurrentUrl
            // 
            this.txtCurrentUrl.Location = new System.Drawing.Point(0, 21);
            this.txtCurrentUrl.Name = "txtCurrentUrl";
            this.txtCurrentUrl.Size = new System.Drawing.Size(1383, 22);
            this.txtCurrentUrl.TabIndex = 7;
            // 
            // btnDownloadAll
            // 
            this.btnDownloadAll.Location = new System.Drawing.Point(230, 57);
            this.btnDownloadAll.Name = "btnDownloadAll";
            this.btnDownloadAll.Size = new System.Drawing.Size(113, 33);
            this.btnDownloadAll.TabIndex = 6;
            this.btnDownloadAll.Text = "Download All";
            this.btnDownloadAll.UseVisualStyleBackColor = true;
            this.btnDownloadAll.Click += new System.EventHandler(this.btnDownloadAll_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(360, 57);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 33);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoading
            // 
            this.btnLoading.Location = new System.Drawing.Point(479, 57);
            this.btnLoading.Name = "btnLoading";
            this.btnLoading.Size = new System.Drawing.Size(95, 33);
            this.btnLoading.TabIndex = 4;
            this.btnLoading.Text = "Loading";
            this.btnLoading.UseVisualStyleBackColor = true;
            this.btnLoading.Click += new System.EventHandler(this.btnLoading_Click);
            // 
            // btnDownloadOne
            // 
            this.btnDownloadOne.Location = new System.Drawing.Point(118, 57);
            this.btnDownloadOne.Name = "btnDownloadOne";
            this.btnDownloadOne.Size = new System.Drawing.Size(97, 33);
            this.btnDownloadOne.TabIndex = 3;
            this.btnDownloadOne.Text = "Download 1";
            this.btnDownloadOne.UseVisualStyleBackColor = true;
            this.btnDownloadOne.Click += new System.EventHandler(this.btnDownloadOne_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(12, 57);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(91, 33);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // webB
            // 
            this.webB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webB.Location = new System.Drawing.Point(0, 104);
            this.webB.MinimumSize = new System.Drawing.Size(20, 20);
            this.webB.Name = "webB";
            this.webB.Size = new System.Drawing.Size(1383, 644);
            this.webB.TabIndex = 3;
            this.webB.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webB_DocumentCompleted);
            this.webB.FileDownload += new System.EventHandler(this.webB_FileDownload);
            this.webB.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webB_Navigated);
            this.webB.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webB_Navigating);
            this.webB.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.webB_ProgressChanged);
            this.webB.LocationChanged += new System.EventHandler(this.webB_LocationChanged);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(601, 57);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(755, 22);
            this.txtStatus.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 748);
            this.Controls.Add(this.webB);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Linky";
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.WebBrowser webB;
        private System.Windows.Forms.Button btnDownloadOne;
        private System.Windows.Forms.Button btnLoading;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDownloadAll;
        private System.Windows.Forms.TextBox txtCurrentUrl;
        private System.Windows.Forms.TextBox txtStatus;
    }
}

