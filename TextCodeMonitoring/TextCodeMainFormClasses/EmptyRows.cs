using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace TextCodeMonitoring.TextCodeMainFormClasses {
    class EmptyRows {
        public void WeekNumber( DataGridView dgvWeekNumber ) {
            try
            {
                dgvWeekNumber.Columns.Add( "WeekNumber", "Week-#" );
                dgvWeekNumber.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                int height;
                height = dgvWeekNumber.Height;
                for( int i = 0 ; i <= height - 420 ; i++ )  // add  empty rows
                {
                    DataTable dtable = new DataTable( );
                    DataRow dr = dtable.NewRow( );
                    dtable.Rows.Add( dr );

                    dgvWeekNumber.Rows.Add( dtable );
                    BindingSource bsource = new BindingSource( );
                    bsource.DataSource = dtable;
                }
            }
            catch( Exception ex )
            {

                MessageBox.Show( "Error! : " + ex.Message, "ERROR!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error );
            }
        }
        public void HistoryPenaltyCallup( DataGridView dgvHistoryPenaltyCallup ) {
            try
            {
                dgvHistoryPenaltyCallup.Columns.Add( "PrimaryID", "PrimaryID" );
                dgvHistoryPenaltyCallup.Columns.Add( "Name", "Name" );
                dgvHistoryPenaltyCallup.Columns.Add( "Project", "Project" );
                dgvHistoryPenaltyCallup.Columns.Add( "WeekNumber", "Week-#/'s" );
                dgvHistoryPenaltyCallup.Columns.Add( "WeekCount", "Week Count" );
                dgvHistoryPenaltyCallup.Columns.Add( "Remarks", "Remarks" );
                dgvHistoryPenaltyCallup.Columns.Add( "DateOfCallUp", "Date" );
                dgvHistoryPenaltyCallup.Columns[ "DateOfCallUp" ].HeaderText = "Date of Call-up";

                int height;
                height = dgvHistoryPenaltyCallup.Height;
                for( int i = 0 ; i <= height - 90 ; i++ )  // add  empty rows
                {
                    DataTable dtable = new DataTable( );
                    DataRow dr = dtable.NewRow( );
                    dtable.Rows.Add( dr );

                    dgvHistoryPenaltyCallup.Rows.Add( dtable );
                    BindingSource bsource = new BindingSource( );
                    bsource.DataSource = dtable;
                    ColumnConfigurationClass configure = new ColumnConfigurationClass( );
                    configure.PenaltyColumnSizes( dgvHistoryPenaltyCallup );
                }
            }
            catch( Exception ex )
            {

                MessageBox.Show( "Error! : " + ex.Message, "ERROR!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error );
            }
        }
        public void CheckerBodegeroAssigned( DataGridView dgvCheckerBodegeroAssigned ) {
            dgvCheckerBodegeroAssigned.Columns.Add( "Project", "Project" );
            dgvCheckerBodegeroAssigned.Columns.Add( "Name", "Name");
            dgvCheckerBodegeroAssigned.Columns.Add( "WeekNumber","Week-#");
            dgvCheckerBodegeroAssigned.Columns.Add( "DateFrom","Dcov. From");
            dgvCheckerBodegeroAssigned.Columns.Add( "DateTo","Dcov. To");
            dgvCheckerBodegeroAssigned.Columns.Add( "DateTexted","Date of report");
            dgvCheckerBodegeroAssigned.Columns.Add( "Designation", "Designation");
            dgvCheckerBodegeroAssigned.Columns.Add( "ContactNumber", "Contact-#" );
            dgvCheckerBodegeroAssigned.Columns.Add( "TextCodeOrHardCopy", "Type of report" );
            dgvCheckerBodegeroAssigned.Columns.Add( "Remarks","Remarks");

            int height;
            height = dgvCheckerBodegeroAssigned.Height;
            for( int i = 0 ; i <= height -110 ; i++ )  // add  empty rows
            {
                DataTable dtable = new DataTable( );
                DataRow dr = dtable.NewRow( );
                dtable.Rows.Add( dr );

                dgvCheckerBodegeroAssigned.Rows.Add( dtable );
                BindingSource bsource = new BindingSource( );
                bsource.DataSource = dtable;
                ColumnConfigurationClass configure = new ColumnConfigurationClass( );
                configure.CheckerBodegeroAssignedColumnSizes( dgvCheckerBodegeroAssigned );
            }
             
        }
        public void CheckerBodegeroAccounts( DataGridView dgvCheckerBodegeroAccounts ) {
            dgvCheckerBodegeroAccounts.Columns.Add( "PrimaryID", "PrimaryID" );
            dgvCheckerBodegeroAccounts.Columns.Add( "ForeignKey", "ForeignKey" );
            dgvCheckerBodegeroAccounts.Columns.Add( "Picture", "Picture" );
            dgvCheckerBodegeroAccounts.Columns.Add( "Name", "Name" );
            dgvCheckerBodegeroAccounts.Columns.Add( "Designation", "Designation" );
            dgvCheckerBodegeroAccounts.Columns.Add( "ContactNumber", "Contact-#" );
            dgvCheckerBodegeroAccounts.Columns.Add( "Remarks", "Remarks" );

            int height;
            height = dgvCheckerBodegeroAccounts.Height;
            for( int i = 0 ; i <= height - 120 ; i++ )  // add  empty rows
            {
                DataTable dtable = new DataTable( );
                DataRow dr = dtable.NewRow( );
                dtable.Rows.Add( dr );

                dgvCheckerBodegeroAccounts.Rows.Add( dtable );
                BindingSource bsource = new BindingSource( );
                bsource.DataSource = dtable;
                ColumnConfigurationClass configure = new ColumnConfigurationClass( );
                configure.CheckerBodegeroAccounts( dgvCheckerBodegeroAccounts );
            }
        }
    }
}
