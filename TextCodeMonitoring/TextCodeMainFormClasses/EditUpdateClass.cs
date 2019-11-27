using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;


namespace TextCodeMonitoring.TextCodeMainFormClasses {
    class EditUpdateClass {
        MySqlConnection con = new MySqlConnection( "datasource=localhost;port=3306;user=root;password=engineering1105;database=textcodedb" );
        public void EditProjectOrName(DataGridView dgvProjectOrName ) {
            
            try
            {                
                string CurrentCellName = dgvProjectOrName.CurrentCell.OwningColumn.Name; /*Get the Current Cell/Column Name pass it to a string variable CurrentCellName*/

                MySqlCommand cmd = new MySqlCommand( );
                cmd.Connection = con;
                con.Open( );
                cmd.CommandText = "UPDATE projects SET " + CurrentCellName + "='" + dgvProjectOrName.CurrentRow.Cells[ CurrentCellName ].Value.ToString( ).Replace( "'", "''" ) + "' WHERE PrimaryID='" + dgvProjectOrName.CurrentRow.Cells[ "PrimaryID" ].Value.ToString( ).Replace( "'", "''" ) + "' ";
                cmd.ExecuteNonQuery( );

                cmd.CommandText = "UPDATE details SET "+CurrentCellName+"='" + dgvProjectOrName.CurrentRow.Cells[ CurrentCellName ].Value.ToString( ).Replace( "'", "''" ) + "' WHERE ForeignKey='" + dgvProjectOrName.CurrentRow.Cells[ "PrimaryID" ].Value.ToString( ).Replace( "'", "''" ) + "' ";
                cmd.ExecuteNonQuery( );
            }
            finally
            {
                con.Close( );
            }
        }
        public void EditCheckerBodegeroAssigned( DataGridView dgvCheckerBodegeroAssigned ) {
            try
            {  
                string CurrentCellName = dgvCheckerBodegeroAssigned.CurrentCell.OwningColumn.Name; /*Get the Current Cell/Column Name pass it to a string variable CurrentCellName*/
               
                MySqlCommand cmd = new MySqlCommand( );
                cmd.Connection = con;
                con.Open( );
                cmd.CommandText = "UPDATE details SET " + CurrentCellName + "='" + dgvCheckerBodegeroAssigned.CurrentRow.Cells[ CurrentCellName ].Value.ToString( ).Replace( "'", "''" ) + "' WHERE PrimaryID='" + dgvCheckerBodegeroAssigned.CurrentRow.Cells[ "PrimaryID" ].Value.ToString( ).Replace( "'", "''" ) + "' ";
                cmd.ExecuteNonQuery( );

                if( CurrentCellName == "Project" )
                {
                   cmd.CommandText = "UPDATE projects SET " + CurrentCellName + "='" + dgvCheckerBodegeroAssigned.CurrentRow.Cells[ CurrentCellName ].Value.ToString( ).Replace( "'", "''" ) + "' WHERE PrimaryID='" + dgvCheckerBodegeroAssigned.CurrentRow.Cells[ "ForeignKey" ].Value.ToString( ).Replace( "'", "''" ) + "' ";
                   cmd.ExecuteNonQuery( );
                }
            
            }
            finally
            {
                con.Close( );
            }
        }
        public void EditCheckerBodegeroAccounts( DataGridView dgvCheckerBodegeroAccounts ) {
            try
            {
                string CurrentCellName = dgvCheckerBodegeroAccounts.CurrentCell.OwningColumn.Name; /*Get the Current Cell/Column Name pass it to a string variable CurrentCellName*/

                MySqlCommand cmd = new MySqlCommand( );
                cmd.Connection = con;
                con.Open( );

                cmd.CommandText = "UPDATE checkerbodegeroaccounts SET " + CurrentCellName + "='" + dgvCheckerBodegeroAccounts.CurrentRow.Cells[ CurrentCellName ].Value.ToString( ).Replace( "'", "''" ) + "' WHERE PrimaryID='" + dgvCheckerBodegeroAccounts.CurrentRow.Cells[ "PrimaryID" ].Value.ToString( ).Replace( "'", "''" ) + "' ";
                cmd.ExecuteNonQuery( );                
            }
            finally
            {
                con.Close( );
            }
        }
        public string GetImagePath( ) {
            string ImagePath = "";
            if( TextCodeMainFormClasses.SelectImage.ImagePath == null )
            {
                ImagePath = @"C:\Users\Pj\My Programming\Programs Developed\Office\c# Projects\TextCodeMonitoring\TextCodeMonitoring\bin\Debug\icon-person-64.png";
            }
            else
            {
                ImagePath = TextCodeMainFormClasses.SelectImage.ImagePath;
            }
            return ImagePath;
        }
        public void ChangePicure(DataGridView dgvCheckerBodegeroAccounts ) {
            try
            {  
                byte[ ] Image = null;
                FileStream filestream = new FileStream( GetImagePath( ), FileMode.Open, FileAccess.Read );
                BinaryReader binaryreader = new BinaryReader( filestream );
                Image = binaryreader.ReadBytes( ( int )filestream.Length );

                MySqlCommand cmd = new MySqlCommand( );
                cmd.Connection = con;
                con.Open( );
                cmd.CommandText = "UPDATE checkerbodegeroaccounts SET Picture=@Image WHERE PrimaryID='" + dgvCheckerBodegeroAccounts.CurrentRow.Cells[ "PrimaryID" ].Value.ToString( ) + "'";
                cmd.Parameters.Add( new MySqlParameter( "@Image", Image ) );
                cmd.ExecuteNonQuery( );
            }
            finally
            {
                con.Close( );
            }
            
        }

        public void ChangePicure2( DataGridView dgvCheckerBodegeroAssigned ) {
            try
            {
                byte[ ] Image = null;
                FileStream filestream = new FileStream( GetImagePath( ), FileMode.Open, FileAccess.Read );
                BinaryReader binaryreader = new BinaryReader( filestream );
                Image = binaryreader.ReadBytes( ( int )filestream.Length );

                MySqlCommand cmd = new MySqlCommand( );
                cmd.Connection = con;
                con.Open( );
                cmd.CommandText = "UPDATE details SET Picture=@Image WHERE PrimaryID='" + dgvCheckerBodegeroAssigned.CurrentRow.Cells[ "PrimaryID" ].Value.ToString( ) + "'";
                cmd.Parameters.Add( new MySqlParameter( "@Image", Image ) );
                cmd.ExecuteNonQuery( );
                
            }
            finally
            {
                con.Close( );
            }

        }
        public void EditWeekEntry( TextBox txtWeekNumberWeekly, DateTimePicker dtpDateTextdWeekly, MaskedTextBox MtxtDateFromWeekly, MaskedTextBox MtxtDateToWeekly, TextBox txtRemarksWeekly, DataGridView dgvWeekNumber ) {
            try
            {
                MySqlCommand cmd = new MySqlCommand( );
                cmd.Connection = con;
                con.Open( );

                cmd.CommandText = "UPDATE textedtextcode SET WeekNumber='" + txtWeekNumberWeekly.Text.Replace( "'", "''" ) + "', DateTexted='" + dtpDateTextdWeekly.Text + "'," +
                   "DateFrom='" + MtxtDateFromWeekly.Text + "',DateTo='" + MtxtDateToWeekly.Text + "', Remarks='" + txtRemarksWeekly.Text.Replace( "'", "''" ) + "' WHERE PrimaryID='" + dgvWeekNumber.CurrentRow.Cells[ "PrimaryID" ].Value.ToString( ).Replace( "'", "''" ) + "' ";
                cmd.ExecuteNonQuery( );
            }
            finally
            {
                con.Close( );
            }
        }
       
        public void EditProjectStatusOngoing(ToolStripMenuItem onGoingToolStripMenuItem, DataGridView dgvProjectOrName ) {
            try
            {
                MySqlCommand cmd = new MySqlCommand( );
                cmd.Connection = con;
                con.Open( );

                cmd.CommandText = "UPDATE projects SET ProjectStatus='" + onGoingToolStripMenuItem.Text.Replace( "'", "''" ) + "' WHERE PrimaryID='" + dgvProjectOrName.CurrentRow.Cells[ "PrimaryID" ].Value.ToString( ).Replace( "'", "''" ) + "' ";
                cmd.ExecuteNonQuery( );
            }
            finally
            {
                con.Close( );
            }
        }
        public void EditProjectStatusFinished(ToolStripMenuItem finishedToolStripMenuItem, DataGridView dgvProjectOrName ) {
            try
            {
                MySqlCommand cmd = new MySqlCommand( );
                cmd.Connection = con;
                con.Open( );

                cmd.CommandText = "UPDATE projects SET ProjectStatus='" + finishedToolStripMenuItem.Text.Replace( "'", "''" ) + "' WHERE PrimaryID='" + dgvProjectOrName.CurrentRow.Cells[ "PrimaryID" ].Value.ToString( ).Replace( "'", "''" ) + "' ";
                cmd.ExecuteNonQuery( );
            }
            finally
            {
                con.Close( );
            }
        }

        public void CallUpRecordsEdit(DataGridView dgvHistoryPenaltyCallup ) {
            try
            {
                string CurrentCellName = dgvHistoryPenaltyCallup.CurrentCell.OwningColumn.Name; /*Get the Current Cell/Column Name pass it to a string variable CurrentCellName*/

                MySqlCommand cmd = new MySqlCommand( );
                cmd.Connection = con;
                con.Open( );

                cmd.CommandText = "UPDATE calluppenalty SET " + CurrentCellName + "='" + dgvHistoryPenaltyCallup.CurrentRow.Cells[ CurrentCellName ].Value.ToString( ).Replace( "'", "''" ) + "' WHERE PrimaryID='" + dgvHistoryPenaltyCallup.CurrentRow.Cells[ "PrimaryID" ].Value.ToString( ).Replace( "'", "''" ) + "' ";
                cmd.ExecuteNonQuery( );
            }
            finally
            {
                con.Close( );
            }
        }
    }
}
