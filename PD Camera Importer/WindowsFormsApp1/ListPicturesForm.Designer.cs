
namespace PDCam
{
    partial class ListPicturesForm
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
            this.pictureLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.importBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureLayout
            // 
            this.pictureLayout.AutoScroll = true;
            this.pictureLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureLayout.Location = new System.Drawing.Point(0, 0);
            this.pictureLayout.Name = "pictureLayout";
            this.pictureLayout.Size = new System.Drawing.Size(870, 732);
            this.pictureLayout.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.cancelBtn);
            this.panel1.Controls.Add(this.importBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 694);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 38);
            this.panel1.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(650, 38);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            // 
            // importBtn
            // 
            this.importBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.importBtn.Location = new System.Drawing.Point(760, 0);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(110, 38);
            this.importBtn.TabIndex = 2;
            this.importBtn.Text = "Import!";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.cancelBtn.Location = new System.Drawing.Point(650, 0);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(110, 38);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // ListPicturesForm
            // 
            this.AcceptButton = this.importBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(870, 732);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureLayout);
            this.Name = "ListPicturesForm";
            this.Text = "PD Camera Importer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosed);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pictureLayout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button cancelBtn;
    }
}

