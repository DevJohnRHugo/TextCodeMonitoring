using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace TextCodeMonitoring.TextCodeMainFormClasses {
    class ShowCheckerBodegeroAssigned {
        public void ShowAssignedCheckerBodegero( DataGridView dgvCheckerBodegeroAssigned, DataGridView dgvProjectOrName ) {
            dgvCheckerBodegeroAssigned.DataSource = null;
            dgvCheckerBodegeroAssigned.Columns.Clear( );
            MySqlCommand cmd = new MySqlCommand( );
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection( );
            cmd.CommandText = "SELECT  PrimaryID,ForeignKey,Project,Name,Designation,ContactNumber,WeekNumber,DateTexted,DateFrom,DateTo,TextCodeOrHardCopy,Remarks,Picture FROM textcodedb.details WHERE ForeignKey='" + dgvProjectOrName.CurrentRow.Cells[ "PrimaryID" ].Value.ToString( ) + "' ORDER BY DateTo DESC";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter( );
            dataAdapter.SelectCommand = cmd;
            DataTable dtable = new DataTable( );
            dataAdapter.Fill( dtable );

            dgvCheckerBodegeroAssigned.DataSource = dtable;
            BindingSource bsource = new BindingSource( );
            bsource.DataSource = dtable;

            ColumnConfigurationClass config = new ColumnConfigurationClass( );
            config.CheckerBodegeroAssigned( dgvCheckerBodegeroAssigned );

            config.CheckerBodegeroAssignedColumnSizes( dgvCheckerBodegeroAssigned );
            dgvCheckerBodegeroAssigned.Update( );
        }
    }
}
