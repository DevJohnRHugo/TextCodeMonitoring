using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace TextCodeMonitoring.TextCodeMainFormClasses {
    class NewProjectOrWeeklyEntry {

        public void SaveNewEntryProject(TextBox txtProject, TextBox txtName ) {
            MySqlCommand cmd = new MySqlCommand( );
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection( );
            cmd.CommandText = "SELECT * FROM textcodedb.projects WHERE Project='"+txtProject.Text.Replace("'","''")+"'";
            MySqlDataReader reader = cmd.ExecuteReader( );
            int count = 0;
            while( reader.Read() )
            {
                count++;
            }
            if( count!=1 )
            {
                reader.Close( );
                cmd.CommandText = "INSERT INTO textcodedb.projects (Project,Name, ProjectStatus) values ('" + txtProject.Text.Replace( "'", "''" ) + "','" + txtName.Text.Replace( "'", "''" ) + "','On-going')";
                cmd.ExecuteNonQuery( );
                cmd.Connection.Close( );
            }
            else 
            {
                MessageBox.Show( "Duplicate entry of this Project : " + txtProject.Text.Replace( "'", "''" ).ToUpper() + " ", "DUPLICATE ENTRY", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation );
            }


        }
        public int GetPrimaryKeyHardCopy( TextBox txtProject ) {
            /*This is to Get the Max count of Primary Key in the database for placing of numbers*/
            MySqlCommand cmdGetTowCount = new MySqlCommand( );
            cmdGetTowCount.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection( );
            cmdGetTowCount.CommandText = "SELECT * FROM textcodedb.projects WHERE Project='" + txtProject.Text.Replace( "'", "''" ) + "' ";
            MySqlDataReader readerGetRowCount = cmdGetTowCount.ExecuteReader( );

            int getRowCount = 0;
            int GetPrimaryID = 0;
            while( readerGetRowCount.Read( ) )
            {
                getRowCount++;
            }
            if( getRowCount==1 )
            {
                getRowCount = Convert.ToInt32( readerGetRowCount.GetString( "PrimaryID" ) );
                
                GetPrimaryID = getRowCount;
            }
            
            return GetPrimaryID;
            /**/
        }

        public string GetImagePath( ) {
            string ImagePath = "";
            if( TextCodeMainFormClasses.SelectImage.ImagePath == null )
            {
                ImagePath = @"D:\My Files\My Programming\Programs Developed\Office\c# Projects\TextCodeMonitoring\TextCodeMonitoring\Resources\icon-person-64.png";
            }
            else
            {
                ImagePath = SelectImage.ImagePath;
            }
            return ImagePath;
        }
        public void SaveEntryTextCodeForExistingCheckerBodegero( TextBox txtProject, TextBox txtWeekNumber, MaskedTextBox dtpFrom, MaskedTextBox dtpTo, DateTimePicker dtpDateTexted,
            TextBox txtName, TextBox txtDesignation, TextBox txtRemarks, DataGridView dgvProjectOrName,
            RadioButton RbtnTextCode, RadioButton RbtnHardCopy, TextBox txtContactNumber, PictureBox pictureBoxCheckerBodegero ) {

            byte[ ] image=null;
            byte[ ] ImageDefault = null;//DEFAULT IMAGE
           

            FileStream filestream = new FileStream( GetImagePath( ), FileMode.Open, FileAccess.Read );
            BinaryReader binaryreader = new BinaryReader( filestream );
            ImageDefault = binaryreader.ReadBytes( ( int )filestream.Length );
            
            MySqlCommand cmd = new MySqlCommand( );
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection( );

            if (RbtnHardCopy.Checked == true)
            {
                MySqlCommand cmdChkBod = new MySqlCommand();
                cmdChkBod.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
                cmdChkBod.CommandText = "SELECT Picture FROM textcodedb.checkerbodegeroaccounts WHERE Name='" + txtName.Text.Replace("'", "''") + "'";
                MySqlDataReader readerForPictureBox;
                readerForPictureBox = cmdChkBod.ExecuteReader();
                int count = 0;

                while (readerForPictureBox.Read())
                {
                    image = (byte[])(readerForPictureBox["Picture"]);
                    MemoryStream MStream = new MemoryStream(image);
                    pictureBoxCheckerBodegero.Image = System.Drawing.Image.FromStream(MStream);

                }
                if (count == 1)
                {
                    if (readerForPictureBox["Picture"] != null)
                    {
                        cmd.CommandText = "INSERT INTO textcodedb.details (Project,WeekNumber,DateFrom,DateTo,DateTexted,Name,Designation,Remarks,Picture,TextCodeOrHardCopy,ForeignKey, ContactNumber) values ("
                               + " '" + txtProject.Text.Replace("'", "''") + "','" + txtWeekNumber.Text.Replace("'", "''") + "','" + dtpFrom.Text + "','" + dtpTo.Text + "','" + dtpDateTexted.Text + "', "
                               + " '" + txtName.Text.Replace("'", "''") + "','" + txtDesignation.Text.Replace("'", "''") + "', "
                               + " '" + txtRemarks.Text.Replace("'", "''") + "',@Image,'" + RbtnHardCopy.Text + "','" + GetPrimaryKeyHardCopy(txtProject) + "','" + txtContactNumber.Text.Replace("'", "''") + "' )";
                        cmd.Parameters.Add(new MySqlParameter("@Image", image));
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {

                        MemoryStream MStream = new MemoryStream(image);
                        pictureBoxCheckerBodegero.Image = System.Drawing.Image.FromStream(MStream);

                        cmd.CommandText = "INSERT INTO textcodedb.details (Project,WeekNumber,DateFrom,DateTo,DateTexted,Name,Designation,Remarks,Picture,TextCodeOrHardCopy,ForeignKey, ContactNumber) values ("
                              + " '" + txtProject.Text.Replace("'", "''") + "','" + txtWeekNumber.Text.Replace("'", "''") + "','" + dtpFrom.Text + "','" + dtpTo.Text + "','" + dtpDateTexted.Text + "', "
                              + " '" + txtName.Text.Replace("'", "''") + "','" + txtDesignation.Text.Replace("'", "''") + "', "
                              + " '" + txtRemarks.Text.Replace("'", "''") + "',@Image,'" + RbtnHardCopy.Text + "','" + GetPrimaryKeyHardCopy(txtProject) + "','" + txtContactNumber.Text.Replace("'", "''") + "' )";
                        cmd.Parameters.Add(new MySqlParameter("@Image", ImageDefault));
                        cmd.ExecuteNonQuery();

                    }
                }
                else
                {
                    byte[] ImageNoChecker = (byte[])(new ImageConverter()).ConvertTo(pictureBoxCheckerBodegero.Image, typeof(byte[]));

                    cmd.CommandText = "INSERT INTO textcodedb.details (Project,WeekNumber,DateFrom,DateTo,DateTexted,Name,Designation,Remarks,Picture,TextCodeOrHardCopy,ForeignKey, ContactNumber) values ("
                           + " '" + txtProject.Text.Replace("'", "''") + "','" + txtWeekNumber.Text.Replace("'", "''") + "','" + dtpFrom.Text + "','" + dtpTo.Text + "','" + dtpDateTexted.Text + "', "
                           + " '" + txtName.Text.Replace("'", "''") + "','" + txtDesignation.Text.Replace("'", "''") + "', "
                           + " '" + txtRemarks.Text.Replace("'", "''") + "',@Image,'" + RbtnHardCopy.Text + "','" + GetPrimaryKeyHardCopy(txtProject) + "','" + txtContactNumber.Text.Replace("'", "''") + "' )";
                    cmd.Parameters.Add(new MySqlParameter("@Image", ImageNoChecker));
                    cmd.ExecuteNonQuery();
                }

            }
            else
            {
                MySqlCommand cmdChkBod = new MySqlCommand();
                cmdChkBod.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
                cmdChkBod.CommandText = "SELECT Picture FROM textcodedb.checkerbodegeroaccounts WHERE Name='" + txtName.Text.Replace("'", "''") + "'";
                MySqlDataReader readerForPictureBox;
                readerForPictureBox = cmdChkBod.ExecuteReader();
                int count = 0;

                while (readerForPictureBox.Read())
                {
                    image = (byte[])(readerForPictureBox["Picture"]);
                    MemoryStream MStream = new MemoryStream(image);
                    pictureBoxCheckerBodegero.Image = System.Drawing.Image.FromStream(MStream);
                    count++;
                }

                if (count == 0)
                {
                    byte[] ImageNoChecker = (byte[])(new ImageConverter()).ConvertTo(pictureBoxCheckerBodegero.Image, typeof(byte[]));

                    cmd.CommandText = "INSERT INTO textcodedb.details (Project,WeekNumber,DateFrom,DateTo,DateTexted,Name,Designation,Remarks,Picture,TextCodeOrHardCopy,ForeignKey, ContactNumber) values ("
                                               + " '" + txtProject.Text.Replace("'", "''") + "','" + txtWeekNumber.Text.Replace("'", "''") + "','" + dtpFrom.Text + "','" + dtpTo.Text + "','" + dtpDateTexted.Text + "', "
                                               + " '" + txtName.Text.Replace("'", "''") + "','" + txtDesignation.Text.Replace("'", "''") + "', "
                                               + " '" + txtRemarks.Text.Replace("'", "''") + "',@Image,'" + RbtnTextCode.Text + "','" + GetPrimaryKeyHardCopy(txtProject) + "','" + txtContactNumber.Text.Replace("'", "''") + "' )";
                    cmd.Parameters.Add(new MySqlParameter("@Image", ImageNoChecker));
                    cmd.ExecuteNonQuery();
                  
                }
                else
                {
                    byte[] ImageNoChecker = (byte[])(new ImageConverter()).ConvertTo(pictureBoxCheckerBodegero.Image, typeof(byte[]));

                    cmd.CommandText = "INSERT INTO textcodedb.details (Project,WeekNumber,DateFrom,DateTo,DateTexted,Name,Designation,Remarks,Picture,TextCodeOrHardCopy,ForeignKey, ContactNumber) values ("
                                   + " '" + txtProject.Text.Replace("'", "''") + "','" + txtWeekNumber.Text.Replace("'", "''") + "','" + dtpFrom.Text + "','" + dtpTo.Text + "','" + dtpDateTexted.Text + "', "
                                   + " '" + txtName.Text.Replace("'", "''") + "','" + txtDesignation.Text.Replace("'", "''") + "', "
                                   + " '" + txtRemarks.Text.Replace("'", "''") + "',@Image,'" + RbtnTextCode.Text + "','" + GetMaxPrimaryKeyNumber() + "','" + txtContactNumber.Text.Replace("'", "''") + "' )";
                    cmd.Parameters.Add(new MySqlParameter("@Image", ImageNoChecker));
                    cmd.ExecuteNonQuery();
                   
                }
                        
            }                     
        }      

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
        public void SaveEntryTextCodeToWeeklyEntry( TextBox txtWeekNumber, MaskedTextBox dtpFrom, MaskedTextBox dtpTo, DateTimePicker dtpDateTexted, TextBox txtName ) {
            MySqlCommand cmd = new MySqlCommand( );
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection( );
           
            cmd.CommandText = "INSERT INTO textcodedb.textedtextcode (ForeignKey,WeekNumber,DateFrom,DateTo,DateTexted,Name) values ("
                + " '" + GetMaxPrimaryKeyNumber() + "','" + txtWeekNumber.Text.Replace( "'", "''" ) + "','" + dtpFrom.Text + "','" + dtpTo.Text + "','" + dtpDateTexted.Text + "', "
                + " '" + txtName.Text.Replace( "'", "''" ) + "')";
            cmd.ExecuteNonQuery( );
        }
        public void TxtCodeWeeklyEntry( TextBox txtWeekNumberWeekly, MaskedTextBox dtpFromWeekly, MaskedTextBox dtpToWeekly, DateTimePicker dtpDateTextedWeekly, TextBox txtRemarksWeekly, DataGridView dgvProjectOrName ) {
            MySqlCommand cmd = new MySqlCommand( );
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection( );

            cmd.CommandText = "INSERT INTO textcodedb.textedtextcode (ForeignKey,WeekNumber,DateFrom,DateTo,DateTexted,Name,Remarks) values ("
                + " '" + dgvProjectOrName.CurrentRow.Cells[ "PrimaryID" ].Value.ToString( ) + "','" + txtWeekNumberWeekly.Text.Replace( "'", "''" ) + "','" + dtpFromWeekly.Text + "','" + dtpToWeekly.Text + "','" + dtpDateTextedWeekly.Text + "', "
                + " '" + dgvProjectOrName.CurrentRow.Cells["Name"].Value.ToString().Replace("'","''") + "','" + txtRemarksWeekly.Text.Replace( "'", "''" ) + "')";
            cmd.ExecuteNonQuery( );
        }
      
    }
}
