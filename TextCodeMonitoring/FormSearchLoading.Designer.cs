namespace TextCodeMonitoring {
    partial class FormSearchLoading {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( ) {
            this.progressBarSearchLoading = new System.Windows.Forms.ProgressBar();
            this.lblSearchLoading = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBarSearchLoading
            // 
            this.progressBarSearchLoading.Location = new System.Drawing.Point(12, 16);
            this.progressBarSearchLoading.Name = "progressBarSearchLoading";
            this.progressBarSearchLoading.Size = new System.Drawing.Size(375, 23);
            this.progressBarSearchLoading.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarSearchLoading.TabIndex = 0;
            // 
            // lblSearchLoading
            // 
            this.lblSearchLoading.AutoSize = true;
            this.lblSearchLoading.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchLoading.Location = new System.Drawing.Point(187, 46);
            this.lblSearchLoading.Name = "lblSearchLoading";
            this.lblSearchLoading.Size = new System.Drawing.Size(0, 14);
            this.lblSearchLoading.TabIndex = 1;
            // 
            // FormSearchLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 65);
            this.Controls.Add(this.lblSearchLoading);
            this.Controls.Add(this.progressBarSearchLoading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSearchLoading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ProgressBar progressBarSearchLoading;
        public System.Windows.Forms.Label lblSearchLoading;
    }
}