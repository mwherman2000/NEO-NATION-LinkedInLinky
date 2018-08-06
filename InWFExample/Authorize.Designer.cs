namespace InWFExample
{
    partial class Authorize
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
            this.webBrowserVerifier = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowserVerifier
            // 
            this.webBrowserVerifier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserVerifier.Location = new System.Drawing.Point(0, 0);
            this.webBrowserVerifier.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.webBrowserVerifier.MinimumSize = new System.Drawing.Size(27, 25);
            this.webBrowserVerifier.Name = "webBrowserVerifier";
            this.webBrowserVerifier.Size = new System.Drawing.Size(896, 470);
            this.webBrowserVerifier.TabIndex = 0;
            this.webBrowserVerifier.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowserVerifier.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            this.webBrowserVerifier.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
            this.webBrowserVerifier.LocationChanged += new System.EventHandler(this.webBrowser1_LocationChanged);
            // 
            // Authorize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 470);
            this.Controls.Add(this.webBrowserVerifier);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Authorize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verifier";
            this.Load += new System.EventHandler(this.Verifier_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserVerifier;
    }
}