using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace TextCodeMonitoring.TextCodeMainFormClasses {
    class NewCheckerBodegero {

        public int GetMaxPrimaryKeyNumber( ) {
            /*This is to Get the Max count of Primary Key in the database for placing of numbers*/
            MySqlCommand cmdGetTowCount = new MySqlCommand( );
            cmdGetTowCount.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection( );
            cmdGetTowCount.CommandText = "SELECT MAX(PrimaryID) FROM textcodedb.projects";
            MySqlDataReader readerGetRowCount = cmdGetTowCount.ExecuteReader( );

            int getRowCount = 0;
            while( readerGetRowCount.Read( ) )
            {

            }
            getRowCount = Convert.ToInt32( readerGetRowCount.GetString( 0 ) );
            int GetPrimaryID = 0;
            GetPrimaryID = getRowCount;
            return GetPrimaryID;
            /**/
        }
        public string GetImagePath(PictureBox pictureBoxCheckerBodegero ) {
            string ImagePath = "";
            FileInfo info = new FileInfo( "icon-person-64.png" );
            if( SelectImage.ImagePath==null )
            {
               ImagePath = @"D:\My Files\My Programming\Programs Developed\Office\c# Projects\TextCodeMonitoring\TextCodeMonitoring\Resources\icon-person-64.png";
            }         
            else
            {
               ImagePath = SelectImage.ImagePath;
            }
            return ImagePath;
        }
        public void SaveNewCheckerBodegero(TextBox txtName,TextBox txtDesignation, TextBox txtContactNumber, TextBox txtRemarks, PictureBox pictureBoxCheckerBodegero ) {
            byte[ ] Image = null;
            FileStream filestream = new FileStream(GetImagePath( pictureBoxCheckerBodegero ) , FileMode.Open, FileAccess.Read );            
            BinaryReader binaryreader = new BinaryReader( filestream );
            Image = binaryreader.ReadBytes( ( int )filestream.Length );
            
            MySqlCommand cmdCount = new MySqlCommand( );
            cmdCount.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection( );
            cmdCount.CommandText = "SELECT * FROM textcodedb.checkerbodegeroaccounts WHERE Name='"+txtName.Text.Replace("'","''")+"'";
            MySqlDataReader reader = cmdCount.ExecuteReader( );
           
            int Count = 0;
            while( reader.Read() )
            {
                Count++;
            }
            if( Count==0 )
            {
                MySqlCommand cmdInsert = new MySqlCommand( );
                cmdInsert.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection( );
                cmdInsert.CommandText = "INSERT INTO textcodedb.checkerbodegeroaccounts (ForeignKey,Name,Designation,ContactNumber,Remarks,Picture)values"
                    +"('"+GetMaxPrimaryKeyNumber()+"','"+txtName.Text.Replace("'","''")+"','"+txtDesignation.Text.Replace( "'", "''" ) + "','"+txtContactNumber.Text.Replace( "'", "''" ) + "',"
                    +"'"+txtRemarks.Text.Replace( "'", "''" ) + "',@Image)";
                cmdInsert.Parameters.Add(new MySqlParameter( @"Image", Image ));
                cmdInsert.ExecuteNonQuery( );
            }
        }
    }
}
