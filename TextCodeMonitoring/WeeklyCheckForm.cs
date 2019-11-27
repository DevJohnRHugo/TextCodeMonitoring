using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using TextCodeMonitoring.TextCodeMainFormClasses;

namespace TextCodeMonitoring {
    public partial class WeeklyCheckForm : Form {
        public WeeklyCheckForm( ) {
            InitializeComponent( );
        }

        private void printDocumentWeeklyTextMonitoring_PrintPage( object sender, System.Drawing.Printing.PrintPageEventArgs e ) {
            //Margins margin = new Margins( 100, 100, 100, 100 );
            //printDocumentWeeklyTextMonitoring.DefaultPageSettings.Margins = margin;
            e.Graphics.DrawString( "ENGINEERING  &  CONSTRUCTION DEPARTMENT", new Font( "Cambria", 14 ), new SolidBrush( Color.Black ), new RectangleF( 200, 50, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height ) );
            e.Graphics.DrawString( "OPERATION SECTION", new Font( "Cambria", 12 ), new SolidBrush( Color.Black ), new RectangleF( 320, 85, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height ) );
            e.Graphics.DrawString( "TEXT CODE CALL-UP", new Font( "Cambria", 12, FontStyle.Bold ), new SolidBrush( Color.Black ), new RectangleF( 320, 120, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height ) );
            e.Graphics.DrawString( "TO :   "+dgvWeeklyTextMonitoring.CurrentRow.Cells["Name"].Value.ToString(), new Font( "Cambria", 11 ), new SolidBrush( Color.Black ), new RectangleF( 105, 180, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height ) );
            e.Graphics.DrawString( "DATE :     " + DateTime.Now.ToString(" MMMM  d, yyyy "), new Font( "Cambria", 11 ), new SolidBrush( Color.Black ), new RectangleF( 550, 180, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height ) );
            e.Graphics.DrawString( "PROJECT :  " + dgvWeeklyTextMonitoring.CurrentRow.Cells[ "Project" ].Value.ToString( ), new Font( "Cambria", 11 ), new SolidBrush( Color.Black ), new RectangleF( 65, 200, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height ) );
            e.Graphics.DrawString( "Tinatawagan ka ng pansin sa hindi mo pagtugon sa Weekly Text Code.", new Font( "Cambria", 11 ), new SolidBrush( Color.Black ), new RectangleF( 65, 260, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height ) );
            
            int WeekFrom = 0;
            int WeekTo = 0;

            if( dgvWeeklyTextMonitoring.CurrentRow.Cells[ "LastWeekTexted" ].Value.ToString( ).Contains( "Hard Copy" ) )
            {                
               WeekFrom=Convert.ToInt32(dgvWeeklyTextMonitoring.CurrentRow.Cells[ "LastWeekTexted" ].Value.ToString( ).Remove( 1 ));
               WeekTo = Convert.ToInt32( dgvWeeklyTextMonitoring.CurrentRow.Cells[ "NumWeeks" ].Value.ToString( ) );
            }
            else
            {
                WeekFrom = Convert.ToInt32( dgvWeeklyTextMonitoring.CurrentRow.Cells[ "LastWeekTexted" ].Value.ToString( ) ) + 1;
                WeekTo = Convert.ToInt32( dgvWeeklyTextMonitoring.CurrentRow.Cells[ "NumWeeks" ].Value.ToString( ) ) + Convert.ToInt32( dgvWeeklyTextMonitoring.CurrentRow.Cells[ "LastWeekTexted" ].Value.ToString( ) );
            }

            int WeekCount = Convert.ToInt32(dgvWeeklyTextMonitoring.CurrentRow.Cells[ "NumWeeks" ].Value.ToString( ));
            if( WeekCount==1 )
            {
                e.Graphics.DrawString( "WEEKS :  " + WeekTo + "  " + "(" + dgvWeeklyTextMonitoring.CurrentRow.Cells[ "NumWeeks" ].Value.ToString( ) + " week" + ")", new Font( "Cambria", 11, FontStyle.Bold ), new SolidBrush( Color.Black ), new RectangleF( 65, 280, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height ) );
            }
            else
            {
                e.Graphics.DrawString( "WEEKS :  " + WeekFrom + "-" + WeekTo + "  " + "(" + dgvWeeklyTextMonitoring.CurrentRow.Cells[ "NumWeeks" ].Value.ToString( ) + " weeks" + ")", new Font( "Cambria", 11, FontStyle.Bold ), new SolidBrush( Color.Black ), new RectangleF( 65, 280, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height ) );
            }
            
            e.Graphics.DrawString( "Nota :  ", new Font( "Cambria", 11, FontStyle.Bold ), new SolidBrush( Color.Black ), new RectangleF( 65, 325, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height ) );
            e.Graphics.DrawString( "I-text kaagad ang Text Code, kung walang signal sa Project ay sa pagluwas sa Distrito magtext.", new Font( "Cambria", 11 ), new SolidBrush( Color.Black ), new RectangleF( 110, 325, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height ) );
            e.Graphics.DrawString( "TEXT CODE  # :  09179814621", new Font( "Cambria", 11, FontStyle.Bold ), new SolidBrush( Color.Black ), new RectangleF( 65, 345, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height ) );

            e.Graphics.DrawString( "Prepared by  : PETER JOHN R. HUGO", new Font( "Cambria", 11 ), new SolidBrush( Color.Black ), new RectangleF( 65, 420, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height ) );
            e.Graphics.DrawString( "Noted by  : JESSIE T. SAGUIGUIT", new Font( "Cambria", 11 ), new SolidBrush( Color.Black ), new RectangleF( 430, 420, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height ) );

        }

        private void printPreviewDialogWeeklyTextcodeMonitoring_Load( object sender, EventArgs e ) {
            
        }               

        private void previewToolStripMenuItem_Click( object sender, EventArgs e ) {
            printPreviewDialogWeeklyTextcodeMonitoring.Document = printDocumentWeeklyTextMonitoring;
            string PrintName = "Text Code Call-up";
            printDocumentWeeklyTextMonitoring.DocumentName = PrintName;
            ToolStripButton b = new ToolStripButton( );
            b.Image = Properties.Resources.emblem_print_png128;
            b.DisplayStyle = ToolStripItemDisplayStyle.Image;
            b.Click += B_Click;
            ( ( ToolStrip )( printPreviewDialogWeeklyTextcodeMonitoring.Controls[ 1 ] ) ).Items.RemoveAt( 0 );
            ( ( ToolStrip )( printPreviewDialogWeeklyTextcodeMonitoring.Controls[ 1 ] ) ).Items.Insert( 0, b );
            b.ToolTipText = "Print Call-up";
            printPreviewDialogWeeklyTextcodeMonitoring.ShowDialog( );


        }

        private void B_Click( object sender, EventArgs e ) {           
            string PrintName = "Text Code Call-up";
            printDocumentWeeklyTextMonitoring.DocumentName = PrintName;
            printDocumentWeeklyTextMonitoring.Print( );
            printDocumentWeeklyTextMonitoring.EndPrint += PrintDocumentWeeklyTextMonitoring_EndPrint;            
        }

        private void PrintDocumentWeeklyTextMonitoring_EndPrint( object sender, PrintEventArgs e ) {
            GenerateCallUp callup = new GenerateCallUp( );
            callup.InsertPenaltyRecord( dgvWeeklyTextMonitoring );
        }

        private void printToolStripMenuItem_Click( object sender, EventArgs e ) {
            PrintDialog Dialog = new PrintDialog( );
            Dialog.Document = printDocumentWeeklyTextMonitoring;
            Dialog.UseEXDialog = true;

            //if( DialogResult.OK == Dialog.ShowDialog( ) )
            //{
                string PrintName = "Text Code Call-up";
                printDocumentWeeklyTextMonitoring.DocumentName = PrintName;
                printDocumentWeeklyTextMonitoring.Print( );

                /* Insert call-up to penalty record */
                GenerateCallUp callup = new GenerateCallUp( );
                callup.InsertPenaltyRecord( dgvWeeklyTextMonitoring );
            //}
        }

        private void printPreviewDialogWeeklyTextcodeMonitoring_Click( object sender, EventArgs e ) {
           
        }

        private void dgvWeeklyTextMonitoring_CellMouseDown( object sender, DataGridViewCellMouseEventArgs e ) {
            if( e.Button == MouseButtons.Right )
            {
                dgvWeeklyTextMonitoring.CurrentCell = dgvWeeklyTextMonitoring.Rows[ e.RowIndex ].Cells[ e.ColumnIndex ];
                dgvWeeklyTextMonitoring.Rows[ e.RowIndex ].Selected = true;
            }
        }

        private void viewCallupRecordToolStripMenuItem_Click( object sender, EventArgs e ) {
            ShowCallUpRecords show = new ShowCallUpRecords( dgvWeeklyTextMonitoring, dgvMissingWeekNumbers );
            show.ShowRecordsByProjectAndChecker( );
        }
    }
}
