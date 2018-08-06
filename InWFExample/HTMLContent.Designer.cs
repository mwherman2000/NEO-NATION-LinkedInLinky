namespace InWFExample
{
    partial class HTMLContent
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
            this.webBrowserHTMLContent = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowserHTMLContent
            // 
            this.webBrowserHTMLContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserHTMLContent.Location = new System.Drawing.Point(0, 0);
            this.webBrowserHTMLContent.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserHTMLContent.Name = "webBrowserHTMLContent";
            this.webBrowserHTMLContent.Size = new System.Drawing.Size(800, 450);
            this.webBrowserHTMLContent.TabIndex = 0;
            // 
            // HTMLContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.webBrowserHTMLContent);
            this.Name = "HTMLContent";
            this.Text = "HTMLContent";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserHTMLContent;
    }
}