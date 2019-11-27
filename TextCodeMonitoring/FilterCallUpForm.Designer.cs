namespace TextCodeMonitoring {
    partial class FilterCallUpForm {
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblProject = new System.Windows.Forms.Label();
            this.TxtProjectFilter = new System.Windows.Forms.TextBox();
            this.LblSetNumberCallUps = new System.Windows.Forms.Label();
            this.NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.NumericUpDown);
            this.panel1.Controls.Add(this.LblSetNumberCallUps);
            this.panel1.Controls.Add(this.TxtProjectFilter);
            this.panel1.Controls.Add(this.LblProject);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 113);
            this.panel1.TabIndex = 0;
            // 
            // LblProject
            // 
            this.LblProject.AutoSize = true;
            this.LblProject.BackColor = System.Drawing.Color.Transparent;
            this.LblProject.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProject.ForeColor = System.Drawing.Color.Ivory;
            this.LblProject.Location = new System.Drawing.Point(4, 3);
            this.LblProject.Name = "LblProject";
            this.LblProject.Size = new System.Drawing.Size(116, 18);
            this.LblProject.TabIndex = 0;
            this.LblProject.Text = "Filter Project :";
            // 
            // TxtProjectFilter
            // 
            this.TxtProjectFilter.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TxtProjectFilter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProjectFilter.Location = new System.Drawing.Point(6, 24);
            this.TxtProjectFilter.Multiline = true;
            this.TxtProjectFilter.Name = "TxtProjectFilter";
            this.TxtProjectFilter.Size = new System.Drawing.Size(350, 29);
            this.TxtProjectFilter.TabIndex = 1;
            // 
            // LblSetNumberCallUps
            // 
            this.LblSetNumberCallUps.AutoSize = true;
            this.LblSetNumberCallUps.BackColor = System.Drawing.Color.Transparent;
            this.LblSetNumberCallUps.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSetNumberCallUps.ForeColor = System.Drawing.Color.Ivory;
            this.LblSetNumberCallUps.Location = new System.Drawing.Point(4, 63);
            this.LblSetNumberCallUps.Name = "LblSetNumberCallUps";
            this.LblSetNumberCallUps.Size = new System.Drawing.Size(199, 18);
            this.LblSetNumberCallUps.TabIndex = 2;
            this.LblSetNumberCallUps.Text = "Set number of Call-up/\'s :";
            // 
            // NumericUpDown
            // 
            this.NumericUpDown.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericUpDown.Location = new System.Drawing.Point(9, 84);
            this.NumericUpDown.Name = "NumericUpDown";
            this.NumericUpDown.Size = new System.Drawing.Size(51, 22);
            this.NumericUpDown.TabIndex = 3;
            this.NumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumericUpDown.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button1.Location = new System.Drawing.Point(197, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 26);
            this.button1.TabIndex = 4;
            this.button1.Text = "Filter";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.Cyan;
            this.checkBox1.Location = new System.Drawing.Point(72, 86);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(66, 18);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Enable";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Maroon;
            this.button2.Location = new System.Drawing.Point(284, 128);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 26);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // FilterCallUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(398, 157);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FilterCallUpForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown NumericUpDown;
        private System.Windows.Forms.Label LblSetNumberCallUps;
        private System.Windows.Forms.TextBox TxtProjectFilter;
        private System.Windows.Forms.Label LblProject;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
    }
}