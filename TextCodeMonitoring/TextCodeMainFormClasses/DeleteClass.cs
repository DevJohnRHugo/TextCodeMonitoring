using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace TextCodeMonitoring.TextCodeMainFormClasses {
    class DeleteClass {
        DataGridView dgvCheckerBodegeroAccounts;
        DataGridView dgvCheckerBodegeroAssigned;
        DataGridView dgvHistoryPenaltyCallup;
        DataGridView dgvWeekNumber;
        DataGridView dgvProjectOrName;

        public DataGridView GetdgvCheckerBodegeroAccounts {
            get; set;
        }

        public DataGridView GetdgvCheckerBodegeroAssigned {
            get; set;
        }

        public DataGridView GetdgvHistoryPenaltyCallup {
            get; set;
        }

        public DataGridView GetdgvWeekNumber {
            get; set;
        }

        public DataGridView GetProjectOrName {
            get; set;
        }

        public DeleteClass( ) {
        }
        public DeleteClass(DataGridView _dgvCheckerBodegeroAccounts) {
            dgvCheckerBodegeroAccounts = _dgvCheckerBodegeroAccounts;
            dgvCheckerBodegeroAssigned = _dgvCheckerBodegeroAccounts;
            dgvHistoryPenaltyCallup = _dgvCheckerBodegeroAccounts;
            dgvWeekNumber = _dgvCheckerBodegeroAccounts;
            dgvProjectOrName = _dgvCheckerBodegeroAccounts;
        }  

        public void DeleteCheckerBodegeroAccount( ) {
            MySqlCommand cmd = new MySqlCommand( );
            try
            {
                
                cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection( );
                if( dgvCheckerBodegeroAccounts.Focused )
                {
                    //cmd.CommandText = "DELETE FROM textcodedb.textedtextcode WHERE='" + dgvCheckerBodegeroAccounts.CurrentRow.Cells[ "PrimaryID" ].Value.ToString( ) + "'";
                    //cmd.ExecuteNonQuery( );
                    MessageBox.Show( "dgvCheckerBodegeroAccounts" );
                }
                else if( dgvCheckerBodegeroAssigned.Focused )
                {
                    //cmd.CommandText = "DELETE FROM textcodedb.textedtextcode WHERE='" + dgvCheckerBodegeroAssigned.CurrentRow.Cells[ "PrimaryID" ].Value.ToString( ) + "'";
                    //cmd.ExecuteNonQuery( );
                    MessageBox.Show( "dgvCheckerBodegeroAssigned" );
                }
                else if( dgvHistoryPenaltyCallup.Focused )
                {
                    //cmd.CommandText = "DELETE FROM textcodedb.textedtextcode WHERE='" + dgvHistoryPenaltyCallup.CurrentRow.Cells[ "PrimaryID" ].Value.ToString( ) + "'";
                    //cmd.ExecuteNonQuery( );
                    MessageBox.Show( "dgvHistoryPenaltyCallup" );
                }
                else if( dgvWeekNumber.Focused )
                {
                    //cmd.CommandText = "DELETE FROM textcodedb.textedtextcode WHERE='" + dgvWeekNumber.CurrentRow.Cells[ "PrimaryID" ].Value.ToString( ) + "'";
                    //cmd.ExecuteNonQuery( );
                    MessageBox.Show( "dgvWeekNumber" );
                }
                else if( dgvProjectOrName.Focused )
                {
                    //cmd.CommandText = "DELETE FROM textcodedb.textedtextcode WHERE='" + dgvProjectOrName.CurrentRow.Cells[ "PrimaryID" ].Value.ToString( ) + "'";
                    //cmd.ExecuteNonQuery( );
                    MessageBox.Show( "dgvProjectOrName" );
                }
            }
            finally
            {
                cmd.Connection.Close( );
            }

            
        }
    }
}
