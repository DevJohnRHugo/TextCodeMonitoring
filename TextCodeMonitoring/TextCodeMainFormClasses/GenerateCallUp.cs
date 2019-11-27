using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using TextCodeMonitoring.DataBaseConnection;
using System.Windows.Forms;

namespace TextCodeMonitoring.TextCodeMainFormClasses {
    class GenerateCallUp {
        public void InsertPenaltyRecord(DataGridView dgvWeeklyTextMonitoring ) {

            int WeekFrom = 0;
            int WeekTo = 0;

            if( dgvWeeklyTextMonitoring.CurrentRow.Cells[ "LastWeekTexted" ].Value.ToString( ).Contains( "Hard Copy" ) )
            {
                WeekFrom = Convert.ToInt32( dgvWeeklyTextMonitoring.CurrentRow.Cells[ "LastWeekTexted" ].Value.ToString( ).Remove( 1 ) );
                WeekTo = Convert.ToInt32( dgvWeeklyTextMonitoring.CurrentRow.Cells[ "NumWeeks" ].Value.ToString( ) );
            }
            else
            {
                WeekFrom = Convert.ToInt32( dgvWeeklyTextMonitoring.CurrentRow.Cells[ "LastWeekTexted" ].Value.ToString( ) ) + 1;
                WeekTo = Convert.ToInt32( dgvWeeklyTextMonitoring.CurrentRow.Cells[ "NumWeeks" ].Value.ToString( ) ) + Convert.ToInt32( dgvWeeklyTextMonitoring.CurrentRow.Cells[ "LastWeekTexted" ].Value.ToString( ) );
            }

            MySqlCommand cmd = new MySqlCommand( );
            cmd.Connection = DataBaseConnectionSourcePath.GetConnection( );
            cmd.CommandText = "INSERT INTO textcodedb.calluppenalty(Project,Name,WeekNumber,WeekCount,DateOfCallup) values"
                + " ('"+dgvWeeklyTextMonitoring.CurrentRow.Cells["Project"].Value.ToString()+ "', '" + dgvWeeklyTextMonitoring.CurrentRow.Cells[ "Name" ].Value.ToString( ) + "',"
                + " '" + WeekFrom+"-"+WeekTo + "','" + dgvWeeklyTextMonitoring.CurrentRow.Cells[ "NumWeeks" ].Value.ToString( ) + "',"
                + " '" + DateTime.Now.ToString( " MMMM   d, yyyy " ) + "')";
            cmd.ExecuteNonQuery( );
        }
    }
}
