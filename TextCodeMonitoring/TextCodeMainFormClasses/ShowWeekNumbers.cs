using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace TextCodeMonitoring.TextCodeMainFormClasses {
    class ShowWeekNumbers {
        public void ShowWeekNumberEntries(DataGridView dgvWeekNumber, DataGridView dgvProjectOrName ) {
            dgvWeekNumber.DataSource = null;
            dgvWeekNumber.Columns.Clear( );
            MySqlCommand cmd = new MySqlCommand( );
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection( );
            cmd.CommandText = "SELECT * FROM textcodedb.textedtextcode WHERE ForeignKey='" + dgvProjectOrName.CurrentRow.Cells[ "PrimaryID" ].Value.ToString( ) + "' ORDER BY DateTo DESC";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter( );
            dataAdapter.SelectCommand = cmd;
            DataTable dtable = new DataTable( );
            dataAdapter.Fill( dtable );

            dgvWeekNumber.DataSource = dtable;
            BindingSource bsource = new BindingSource( );
            bsource.DataSource = dtable;
            ColumnConfigurationClass config = new ColumnConfigurationClass( );
            config.WeekNumber( dgvWeekNumber );
            dgvWeekNumber.Update( );
        }
    }
}
