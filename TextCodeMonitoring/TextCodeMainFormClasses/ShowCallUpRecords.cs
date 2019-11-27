using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using TextCodeMonitoring.DataBaseConnection;
using MySql.Data.MySqlClient;

namespace TextCodeMonitoring.TextCodeMainFormClasses {
    class ShowCallUpRecords {

        DataGridView dgvProjectOrName;
        DataGridView dgvHistoryPenaltyCallup;

        private DataGridView GetdgvProjectOrName {
            get; set;
        }

        private DataGridView GetdgvHistoryPenaltyCallup {
            get; set;
        }

        public ShowCallUpRecords( DataGridView _dgvProjectOrName, DataGridView _dgvHistoryPenaltyCallup ) {
            dgvProjectOrName = _dgvProjectOrName;
            dgvHistoryPenaltyCallup = _dgvHistoryPenaltyCallup;
        }
        public ShowCallUpRecords(DataGridView _dgvProjectOrName) {
            dgvProjectOrName = _dgvProjectOrName;
         
        }
        public ShowCallUpRecords() {
            
        }

        private string GetIndexOfProjectsUpperArrow() {
            int RowIndex = dgvProjectOrName.CurrentRow.Index +1; int ColumnIndex = dgvProjectOrName.CurrentCell.ColumnIndex;
            string GetPrevProjectName = dgvProjectOrName.Rows[RowIndex].Cells[ColumnIndex].Value.ToString().ToString();
            return GetPrevProjectName;
        }

        private string GetIndexOfProjectsLowerArrow() {
            int RowIndex = dgvProjectOrName.CurrentRow.Index + 1; int ColumnIndex = dgvProjectOrName.CurrentCell.ColumnIndex;
            string GetPrevProjectName = dgvProjectOrName.Rows[RowIndex].Cells[ColumnIndex].Value.ToString().ToString();
            return GetPrevProjectName;
        }

        public void ShowRecordsByProjectUpperArrow( ) {
            dgvHistoryPenaltyCallup.DataSource = null;
            dgvHistoryPenaltyCallup.Columns.Clear( );

           //MessageBox.Show(GetIndexOfProjectsUpperArrow().ToString());

            MySqlCommand cmd = new MySqlCommand( );
            cmd.Connection = DataBaseConnectionSourcePath.GetConnection( );
            cmd.CommandText = "SELECT PrimaryID, Name, Project, Weeknumber, WeekCount, Remarks, DateOfCallUp FROM textcodedb.calluppenalty WHERE Project='" + GetIndexOfProjectsUpperArrow().ToString() + "' ORDER BY PrimaryID DESC";            
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter( );
            dataAdapter.SelectCommand = cmd;
            DataTable dtable = new DataTable( );
            dataAdapter.Fill( dtable );

            dgvHistoryPenaltyCallup.DataSource = dtable;
            BindingSource bsource = new BindingSource( );
            bsource.DataSource = dtable;

            ColumnConfigurationClass config = new ColumnConfigurationClass( );
            config.PenaltyColumnSizes( dgvHistoryPenaltyCallup );
            dgvHistoryPenaltyCallup.Update( );

        }

        public void ShowRecordsByProjectLowerArrow() {
            dgvHistoryPenaltyCallup.DataSource = null;
            dgvHistoryPenaltyCallup.Columns.Clear();

            //MessageBox.Show(GetIndexOfProjectsUpperArrow().ToString());

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = DataBaseConnectionSourcePath.GetConnection();
            cmd.CommandText = "SELECT PrimaryID, Name, Project, Weeknumber, WeekCount, Remarks, DateOfCallUp FROM textcodedb.calluppenalty WHERE Project='" + GetIndexOfProjectsLowerArrow().ToString() + "' ORDER BY PrimaryID DESC";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DataTable dtable = new DataTable();
            dataAdapter.Fill(dtable);

            dgvHistoryPenaltyCallup.DataSource = dtable;
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dtable;

            ColumnConfigurationClass config = new ColumnConfigurationClass();
            config.PenaltyColumnSizes(dgvHistoryPenaltyCallup);
            dgvHistoryPenaltyCallup.Update();

        }

        public void ShowRecordsByProject() {
            dgvHistoryPenaltyCallup.DataSource = null;
            dgvHistoryPenaltyCallup.Columns.Clear();

            //MessageBox.Show(GetIndexOfProjectsUpperArrow().ToString());

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = DataBaseConnectionSourcePath.GetConnection();
            cmd.CommandText = "SELECT PrimaryID, Name, Project, Weeknumber, WeekCount, Remarks, DateOfCallUp FROM textcodedb.calluppenalty WHERE Project='" + dgvProjectOrName.CurrentRow.Cells["Project"].Value.ToString() + "' ORDER BY PrimaryID DESC";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DataTable dtable = new DataTable();
            dataAdapter.Fill(dtable);

            dgvHistoryPenaltyCallup.DataSource = dtable;
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dtable;

            ColumnConfigurationClass config = new ColumnConfigurationClass();
            config.PenaltyColumnSizes(dgvHistoryPenaltyCallup);
            dgvHistoryPenaltyCallup.Update();

        }

        public void ShowRecordsByChecker( ) {
            dgvHistoryPenaltyCallup.DataSource = null;
            dgvHistoryPenaltyCallup.Columns.Clear( );
            MySqlCommand cmd = new MySqlCommand( );
            cmd.Connection = DataBaseConnectionSourcePath.GetConnection( );
            cmd.CommandText = "SELECT PrimaryID,Name, Project, Weeknumber, WeekCount, Remarks, DateOfCallUp FROM textcodedb.calluppenalty WHERE Name='" + dgvProjectOrName.CurrentRow.Cells[ "Name" ].Value.ToString( ) + "' ";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter( );
            dataAdapter.SelectCommand = cmd;
            DataTable dtable = new DataTable( );
            dataAdapter.Fill( dtable );

            dgvHistoryPenaltyCallup.DataSource = dtable;
            BindingSource bsource = new BindingSource( );
            bsource.DataSource = dtable;

            ColumnConfigurationClass config = new ColumnConfigurationClass( );
            config.PenaltyColumnSizes( dgvHistoryPenaltyCallup );
            dgvHistoryPenaltyCallup.Update( );

        }
        private string GetCallupRecordsProjectChecker( ) {
            string Name = "";
            string Project = "";
            string Weeknumber = "";
            string WeekCount = "";
           // string Remarks = "";
            string DateOfCallUp = "";
            string MsgBox = "";

            MySqlCommand cmd = new MySqlCommand( );
            cmd.Connection = DataBaseConnectionSourcePath.GetConnection( );
            cmd.CommandText = "SELECT Name, Project, Weeknumber, WeekCount, DateOfCallUp FROM textcodedb.calluppenalty WHERE Project='" + dgvProjectOrName.CurrentRow.Cells[ "Project" ].Value.ToString( ) + "' AND Name='"+ dgvProjectOrName.CurrentRow.Cells[ "Name" ].Value.ToString( ) + "' ";
            MySqlDataReader reader = cmd.ExecuteReader( );
        //    int count = 0;
            reader.Read( );
            //while( reader.Read( ) )
            //{
            //    count++;
            //}
            //if( count==1 )
            //{
            
              Name = reader.GetString( "Name" );
           Project = reader.GetString( "Project" ); Weeknumber = reader.GetString( "WeekCount" );
                                                     //  Remarks = reader.GetString( "Remarks" );
            DateOfCallUp = reader.GetString( "DateOfCallUp" );
            MsgBox = "Project : " + Project + " , Name : " + Name + " , Week-# : " + Weeknumber + " , Week Count : " + WeekCount + " , Date of Call-up : " + DateOfCallUp;
            //} 

            return MsgBox;
            // return MessageBox = "Project : " + Project + " , Name : " + Name + " , Week-# : " + Weeknumber + " , Week Count : " + WeekCount + " , Remarks : " + Remarks + " , Date of Call-up : " + DateOfCallUp; 
        }
        public void ShowRecordsByProjectAndChecker( ) {
            MessageBox.Show( GetCallupRecordsProjectChecker() );
        }
        public void FilterCallUpRecords(NumericUpDown NumericUpDown, DataGridView _dgvHistoryPenaltyCallup,CheckBox checkFilterSpecProject, TextBox txtProjectToFilter ) {
            DataTable dtablDgv = new DataTable( );
            
            _dgvHistoryPenaltyCallup.DataSource = null;
            _dgvHistoryPenaltyCallup.Columns.Clear( );

            dtablDgv.Columns.Add( "PrimaryID" );
            dtablDgv.Columns.Add( "Name" );
            dtablDgv.Columns.Add( "Project" );
            dtablDgv.Columns.Add( "WeekNumber" );
            dtablDgv.Columns.Add( "WeekCount" );
            dtablDgv.Columns.Add( "Remarks" );
            dtablDgv.Columns.Add( "DateOfCallup" );

            MySqlCommand cmd = new MySqlCommand();
            MySqlCommand cmd2 = new MySqlCommand();
            try
            {
                
                cmd.Connection = DataBaseConnectionSourcePath.GetConnection();
                cmd.CommandText = "SELECT PrimaryID, Name, Project, Weeknumber, WeekCount, Remarks, DateOfCallUp FROM textcodedb.calluppenalty GROUP BY Project ORDER BY PrimaryID DESC";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                DataTable dtable = new DataTable();
                dataAdapter.Fill(dtable);

                foreach (DataRow GetProjects in dtable.Rows)
                {
                    if (checkFilterSpecProject.Checked)
                    {
                       
                        cmd2.Connection = DataBaseConnectionSourcePath.GetConnection();
                        cmd2.CommandText = "SELECT PrimaryID, Name, Project, Weeknumber, WeekCount, Remarks, DateOfCallUp FROM textcodedb.calluppenalty  WHERE Project LIKE '" + GetProjects["Project"] + "'  ORDER BY  PrimaryID ASC";
                        MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter();
                        dataAdapter2.SelectCommand = cmd2;
                        DataTable dtable2 = new DataTable();
                        dataAdapter2.Fill(dtable2);
                        if (dtable2.Rows.Count == NumericUpDown.Value)
                        {
                            foreach (DataRow item in dtable2.Rows)
                            {
                                if (item["Project"].ToString() == txtProjectToFilter.Text)
                                {
                                    dtablDgv.Rows.Add(item["PrimaryID"], item["Name"], item["Project"], item["WeekNumber"], item["WeekCount"], item["Remarks"], item["DateOfCallup"]);
                                }
                            }

                            _dgvHistoryPenaltyCallup.DataSource = dtablDgv;
                            BindingSource source = new BindingSource();
                            source.DataSource = dtablDgv;

                            ColumnConfigurationClass config = new ColumnConfigurationClass();
                            config.PenaltyColumnSizes(_dgvHistoryPenaltyCallup);
                        }

                    }
                    else
                    {
                        //MySqlCommand cmd2 = new MySqlCommand();
                        cmd2.Connection = DataBaseConnectionSourcePath.GetConnection();
                        cmd2.CommandText = "SELECT PrimaryID, Name, Project, Weeknumber, WeekCount, Remarks, DateOfCallUp FROM textcodedb.calluppenalty  WHERE Project='" + GetProjects["Project"] + "'  ORDER BY  PrimaryID ASC";
                        MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter();
                        dataAdapter2.SelectCommand = cmd2;
                        DataTable dtable2 = new DataTable();
                        dataAdapter2.Fill(dtable2);
                        if (dtable2.Rows.Count == NumericUpDown.Value)
                        {
                            foreach (DataRow item in dtable2.Rows)
                            {
                                dtablDgv.Rows.Add(item["PrimaryID"], item["Name"], item["Project"], item["WeekNumber"], item["WeekCount"], item["Remarks"], item["DateOfCallup"]);
                            }

                            _dgvHistoryPenaltyCallup.DataSource = dtablDgv;
                            BindingSource source = new BindingSource();
                            source.DataSource = dtablDgv;

                            ColumnConfigurationClass config = new ColumnConfigurationClass();
                            config.PenaltyColumnSizes(_dgvHistoryPenaltyCallup);
                        }
                    }
                }
            }
            finally
            {
                cmd.Connection.Close();
                cmd2.Connection.Close();
            }

            
        }
        //public void CustomDateRangeFilter(TextBox _txtProjectFlter,DataGridView _dgvHistoryPenaltyCallup, DateTimePicker _dtpDateRangeFrom, DateTimePicker _dtpDateRangeTo) {
            //DataTable dtablDgv = new DataTable();
            //string strDateFrom = _dtpDateRangeFrom.Text;
            //strDateFrom = _dtpDateRangeFrom.Value.ToString(" MMMM   d, yyyy ");
                        
            //string strDateTo = _dtpDateRangeTo.Text;
            //strDateTo = _dtpDateRangeTo.Value.ToString(" MMMM   d, yyyy ");

            //_dgvHistoryPenaltyCallup.DataSource = null;
            //_dgvHistoryPenaltyCallup.Columns.Clear();

            //dtablDgv.Columns.Add("PrimaryID");
            //dtablDgv.Columns.Add("Name");
            //dtablDgv.Columns.Add("Project");
            //dtablDgv.Columns.Add("WeekNumber");
            //dtablDgv.Columns.Add("WeekCount");
            //dtablDgv.Columns.Add("Remarks");
            //dtablDgv.Columns.Add("DateOfCallup");

            //MySqlCommand cmd = new MySqlCommand();
            //cmd.Connection = DataBaseConnectionSourcePath.GetConnection();
            //cmd.CommandText = "SELECT PrimaryID, Name, Project, Weeknumber, WeekCount, Remarks, DateOfCallUp FROM textcodedb.calluppenalty GROUP BY Project ORDER BY DateOfCallUp ASC";
            //MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            //dataAdapter.SelectCommand = cmd;
            //DataTable dtable = new DataTable();
            //dataAdapter.Fill(dtable);

            //foreach (DataRow GetProjects in dtable.Rows)
            //{
                //MySqlCommand cmdDateRange = new MySqlCommand();
                //cmdDateRange.Connection = DataBaseConnectionSourcePath.GetConnection();
                //cmdDateRange.CommandText = "SELECT PrimaryID, Name, Project, Weeknumber, WeekCount, Remarks, DateOfCallUp FROM textcodedb.calluppenalty  WHERE Project='" + "Caguisanan, Iloilo South" + "'AND DateOfCallUp BETWEEN '" + strDateFrom + "' AND '" + strDateTo + "' ORDER BY DateOfCallUp,Project ASC";
                //MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter();
                //dataAdapter2.SelectCommand = cmdDateRange;
                //DataTable dtable2 = new DataTable();
                //dataAdapter2.Fill(dtable2);

                //foreach (DataRow item in dtable2.Rows)
                //{
                //    dtablDgv.Rows.Add(item["PrimaryID"], item["Name"], item["Project"], item["WeekNumber"], item["WeekCount"], item["Remarks"], item["DateOfCallup"]);

                //}

                //_dgvHistoryPenaltyCallup.DataSource = dtablDgv;
                //BindingSource source = new BindingSource();
                //source.DataSource = dtablDgv;

                //ColumnConfigurationClass config = new ColumnConfigurationClass();
                //config.PenaltyColumnSizes(_dgvHistoryPenaltyCallup);

            //}
        //}  
    }
}
