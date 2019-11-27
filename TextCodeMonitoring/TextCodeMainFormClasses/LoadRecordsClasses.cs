using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using TextCodeMonitoring.TextCodeMainFormClasses;

namespace TextCodeMonitoring.TextCodeMainFormClasses {
    class LoadRecordsClasses {

        public void Project(DataGridView dgvProjectName ) {
            MySqlCommand cmd = new MySqlCommand( );
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection( );
            cmd.CommandText = "SELECT * FROM textcodedb.projects WHERE ProjectStatus='On-going' ORDER BY PrimaryID DESC";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter( );
            dataAdapter.SelectCommand = cmd;
            DataTable dtable = new DataTable( );
            dataAdapter.Fill( dtable );

            dgvProjectName.DataSource = dtable;
            BindingSource bsource = new BindingSource( );
            bsource.DataSource = dtable;

            ColumnConfigurationClass column = new ColumnConfigurationClass( );
            column.ProjectCheckOrSetConfiguration( dgvProjectName );
            dgvProjectName.Update( );
        }
        public void Name( DataGridView dgvProjectName ) {
            MySqlCommand cmd = new MySqlCommand( );
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection( );
            cmd.CommandText = "SELECT * FROM textcodedb.projects ORDER BY PrimaryID DESC ";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter( );
            dataAdapter.SelectCommand = cmd;
            DataTable dtable = new DataTable( );
            dataAdapter.Fill( dtable );

            dgvProjectName.DataSource = dtable;
            BindingSource bsource = new BindingSource( );
            bsource.DataSource = dtable;
            ColumnConfigurationClass column = new ColumnConfigurationClass( );
            column.NameCheckedColumnConfiguration( dgvProjectName );
            dgvProjectName.Update( );
        }
        public void CheckerBodegeroAssigned( DataGridView dgvCheckerBodegeroAssigned ) {
            MySqlCommand cmd = new MySqlCommand( );
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection( );
            cmd.CommandText = "SELECT PrimaryID,ForeignKey,Project,Name,Designation,ContactNumber,WeekNumber,DateTexted,DateFrom,DateTo,TypeOfReporting,TextCodeOrHardCopy,SignalStatus,Remarks FROM textcodedb.details";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter( );
            dataAdapter.SelectCommand = cmd;
            DataTable dtable = new DataTable( );
            dataAdapter.Fill( dtable );

            dgvCheckerBodegeroAssigned.DataSource = dtable;
            BindingSource bsource = new BindingSource( );
            bsource.DataSource = dtable;
            ColumnConfigurationClass column = new ColumnConfigurationClass( );
            column.CheckerBodegeroAssigned( dgvCheckerBodegeroAssigned );
            column.CheckerBodegeroAssignedColumnSizes( dgvCheckerBodegeroAssigned );
            dgvCheckerBodegeroAssigned.Update( );
        }
        public void CheckerBodegeroAccounts(DataGridView dgvCheckerBodegeroAccounts ) {
            MySqlCommand cmd = new MySqlCommand( );
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection( );
            cmd.CommandText = "SELECT * FROM textcodedb.checkerbodegeroaccounts";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter( );
            dataAdapter.SelectCommand = cmd;
            DataTable dtable = new DataTable( );
            dataAdapter.Fill( dtable );

            dgvCheckerBodegeroAccounts.DataSource = dtable;
            BindingSource bsource = new BindingSource( );
            bsource.DataSource = dtable;

            ColumnConfigurationClass config = new ColumnConfigurationClass( );
            config.CheckerBodegeroAccounts( dgvCheckerBodegeroAccounts );
            dgvCheckerBodegeroAccounts.Update( );
        }
       
    }
}
