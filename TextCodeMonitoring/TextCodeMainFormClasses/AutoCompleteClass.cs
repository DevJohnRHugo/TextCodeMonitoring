using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.IO;
using TextCodeMonitoring.DataBaseConnection;

namespace TextCodeMonitoring.TextCodeMainFormClasses {
    class AutoCompleteClass {

        private void GetImageAssigned(PictureBox pictureBox2, DataGridView dgvCheckerBodegeroAssigned) {
            MySqlCommand cmd = new MySqlCommand( );
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection( );
            cmd.CommandText = "SELECT Picture FROM textcodedb.details WHERE PrimaryID='" + dgvCheckerBodegeroAssigned.CurrentRow.Cells[ "PrimaryID" ].Value.ToString( ) + "'";
            MySqlDataReader reader;
            reader = cmd.ExecuteReader( );

            while( reader.Read( ) )
            {
                byte[ ] image = ( byte[ ] )( reader[ "Picture" ] );
                MemoryStream MStream = new MemoryStream( image );
                pictureBox2.Image = System.Drawing.Image.FromStream( MStream );
            }
            reader.Close( );
        }

        public void CheckerNameComplete(TextBox txtNameNewEntry ) {
            txtNameNewEntry.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNameNewEntry.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection Collection = new AutoCompleteStringCollection( );
           
            string QueryFillType = "SELECT Name FROM textcodedb.checkerbodegeroaccounts";
            MySqlConnection con = DataBaseConnectionSourcePath.GetConnection( );
            MySqlCommand cmdFillProject = new MySqlCommand( QueryFillType, con );
            MySqlDataReader reader;


            reader = cmdFillProject.ExecuteReader( );

            while( reader.Read( ) )
            {
                string FillProject = reader.GetString( 0 );
                Collection.Add( FillProject );

            }
            txtNameNewEntry.AutoCompleteCustomSource = Collection;

            con.Close( );
        }
        public void ProjectNameAutoComple( TextBox txtProjectToFilter ) {
            txtProjectToFilter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtProjectToFilter.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection Collection = new AutoCompleteStringCollection( );

            string QueryFillType = "SELECT Project FROM textcodedb.calluppenalty";
            MySqlConnection con = DataBaseConnectionSourcePath.GetConnection( );
            MySqlCommand cmdFillProject = new MySqlCommand( QueryFillType, con );
            MySqlDataReader reader;


            reader = cmdFillProject.ExecuteReader( );

            while( reader.Read( ) )
            {
                string FillProject = reader.GetString( 0 );
                Collection.Add( FillProject );

            }
            txtProjectToFilter.AutoCompleteCustomSource = Collection;

            con.Close( );
        }
    }
}
