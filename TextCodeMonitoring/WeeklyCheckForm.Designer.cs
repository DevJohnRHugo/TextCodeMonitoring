namespace TextCodeMonitoring {
    partial class WeeklyCheckForm {
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeeklyCheckForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvWeeklyTextMonitoring = new System.Windows.Forms.DataGridView();
            this.contextMenuStripCALLUPPrint = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.generateCallupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCallupRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvMissingWeekNumbers = new System.Windows.Forms.DataGridView();
            this.printDocumentWeeklyTextMonitoring = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialogWeeklyTextcodeMonitoring = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeeklyTextMonitoring)).BeginInit();
            this.contextMenuStripCALLUPPrint.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMissingWeekNumbers)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1326, 33);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SkyBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1322, 29);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvWeeklyTextMonitoring
            // 
            this.dgvWeeklyTextMonitoring.AllowUserToAddRows = false;
            this.dgvWeeklyTextMonitoring.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWeeklyTextMonitoring.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWeeklyTextMonitoring.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvWeeklyTextMonitoring.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgvWeeklyTextMonitoring.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.CadetBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWeeklyTextMonitoring.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWeeklyTextMonitoring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWeeklyTextMonitoring.ContextMenuStrip = this.contextMenuStripCALLUPPrint;
            this.dgvWeeklyTextMonitoring.EnableHeadersVisualStyles = false;
            this.dgvWeeklyTextMonitoring.GridColor = System.Drawing.Color.LightSlateGray;
            this.dgvWeeklyTextMonitoring.Location = new System.Drawing.Point(4, 41);
            this.dgvWeeklyTextMonitoring.Name = "dgvWeeklyTextMonitoring";
            this.dgvWeeklyTextMonitoring.RowHeadersWidth = 23;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWeeklyTextMonitoring.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWeeklyTextMonitoring.Size = new System.Drawing.Size(1322, 270);
            this.dgvWeeklyTextMonitoring.TabIndex = 2;
            this.dgvWeeklyTextMonitoring.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvWeeklyTextMonitoring_CellMouseDown);
            // 
            // contextMenuStripCALLUPPrint
            // 
            this.contextMenuStripCALLUPPrint.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.contextMenuStripCALLUPPrint.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateCallupToolStripMenuItem,
            this.viewCallupRecordToolStripMenuItem});
            this.contextMenuStripCALLUPPrint.Name = "contextMenuStrip1";
            this.contextMenuStripCALLUPPrint.Size = new System.Drawing.Size(193, 48);
            // 
            // generateCallupToolStripMenuItem
            // 
            this.generateCallupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previewToolStripMenuItem,
            this.printToolStripMenuItem});
            this.generateCallupToolStripMenuItem.Image = global::TextCodeMonitoring.Properties.Resources.Generate_tables_24;
            this.generateCallupToolStripMenuItem.Name = "generateCallupToolStripMenuItem";
            this.generateCallupToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.generateCallupToolStripMenuItem.Text = "Generate Call-up";
            // 
            // previewToolStripMenuItem
            // 
            this.previewToolStripMenuItem.Image = global::TextCodeMonitoring.Properties.Resources.document_print_preview_png128;
            this.previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            this.previewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.previewToolStripMenuItem.Text = "Preview";
            this.previewToolStripMenuItem.Click += new System.EventHandler(this.previewToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = global::TextCodeMonitoring.Properties.Resources.emblem_print_png128;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // viewCallupRecordToolStripMenuItem
            // 
            this.viewCallupRecordToolStripMenuItem.Image = global::TextCodeMonitoring.Properties.Resources.Windows_View_Detail_128;
            this.viewCallupRecordToolStripMenuItem.Name = "viewCallupRecordToolStripMenuItem";
            this.viewCallupRecordToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.viewCallupRecordToolStripMenuItem.Text = "View Call-up record";
            this.viewCallupRecordToolStripMenuItem.Click += new System.EventHandler(this.viewCallupRecordToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(2, 314);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1326, 33);
            this.panel2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.LightCyan;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(8, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1306, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "Missing Week-#/\'s";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SkyBlue;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1322, 29);
            this.label5.TabIndex = 0;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvMissingWeekNumbers
            // 
            this.dgvMissingWeekNumbers.AllowUserToAddRows = false;
            this.dgvMissingWeekNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMissingWeekNumbers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMissingWeekNumbers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMissingWeekNumbers.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgvMissingWeekNumbers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.CadetBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMissingWeekNumbers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMissingWeekNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMissingWeekNumbers.EnableHeadersVisualStyles = false;
            this.dgvMissingWeekNumbers.GridColor = System.Drawing.Color.LightSlateGray;
            this.dgvMissingWeekNumbers.Location = new System.Drawing.Point(4, 351);
            this.dgvMissingWeekNumbers.Name = "dgvMissingWeekNumbers";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvMissingWeekNumbers.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMissingWeekNumbers.RowHeadersWidth = 23;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvMissingWeekNumbers.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMissingWeekNumbers.Size = new System.Drawing.Size(1322, 270);
            this.dgvMissingWeekNumbers.TabIndex = 4;
            // 
            // printDocumentWeeklyTextMonitoring
            // 
            this.printDocumentWeeklyTextMonitoring.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentWeeklyTextMonitoring_PrintPage);
            // 
            // printPreviewDialogWeeklyTextcodeMonitoring
            // 
            this.printPreviewDialogWeeklyTextcodeMonitoring.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialogWeeklyTextcodeMonitoring.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialogWeeklyTextcodeMonitoring.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialogWeeklyTextcodeMonitoring.Enabled = true;
            this.printPreviewDialogWeeklyTextcodeMonitoring.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialogWeeklyTextcodeMonitoring.Icon")));
            this.printPreviewDialogWeeklyTextcodeMonitoring.Name = "printPreviewDialogWeeklyTextcodeMonitoring";
            this.printPreviewDialogWeeklyTextcodeMonitoring.Visible = false;
            this.printPreviewDialogWeeklyTextcodeMonitoring.Load += new System.EventHandler(this.printPreviewDialogWeeklyTextcodeMonitoring_Load);
            this.printPreviewDialogWeeklyTextcodeMonitoring.Click += new System.EventHandler(this.printPreviewDialogWeeklyTextcodeMonitoring_Click);
            // 
            // WeeklyCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1330, 626);
            this.Controls.Add(this.dgvMissingWeekNumbers);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvWeeklyTextMonitoring);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "WeeklyCheckForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text Code Weekly Monitoring";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeeklyTextMonitoring)).EndInit();
            this.contextMenuStripCALLUPPrint.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMissingWeekNumbers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dgvWeeklyTextMonitoring;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DataGridView dgvMissingWeekNumbers;
        private System.Drawing.Printing.PrintDocument printDocumentWeeklyTextMonitoring;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialogWeeklyTextcodeMonitoring;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCALLUPPrint;
        private System.Windows.Forms.ToolStripMenuItem generateCallupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCallupRecordToolStripMenuItem;
    }
}