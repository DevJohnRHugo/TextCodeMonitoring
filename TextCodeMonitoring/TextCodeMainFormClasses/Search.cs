using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace TextCodeMonitoring.TextCodeMainFormClasses {
    class Search {
        public void SearchProject(TextBox txtSearch, DataGridView dgvProjectOrName ) {
            MySqlCommand cmd = new MySqlCommand( );
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection( );
            cmd.CommandText = "SELECT * FROM textcodedb.projects ORDER BY PrimaryID DESC";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter( );
            dataAdapter.SelectCommand = cmd;
            DataTable dtable = new DataTable( );
            dataAdapter.Fill( dtable );

            dgvProjectOrName.DataSource = dtable;
            BindingSource bsource = new BindingSource( );
            bsource.DataSource = dtable;

            DataView view = new DataView( dtable );
            view.RowFilter = string.Format( "Name LIKE '%{0}%' OR Project LIKE '%{0}%'", txtSearch.Text.Replace( "'", "''" ) );
            dgvProjectOrName.DataSource = view;

            ColumnConfigurationClass configure = new ColumnConfigurationClass( );
            configure.ProjectCheckOrSetConfiguration( dgvProjectOrName );
            dgvProjectOrName.Update( );
        }
        public void SearchName( TextBox txtSearch, DataGridView dgvProjectOrName ) {
            MySqlCommand cmd = new MySqlCommand( );
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection( );
            cmd.CommandText = "SELECT * FROM textcodedb.projects ORDER BY PrimaryID DESC";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter( );
            dataAdapter.SelectCommand = cmd;
            DataTable dtable = new DataTable( );
            dataAdapter.Fill( dtable );

            dgvProjectOrName.DataSource = dtable;
            BindingSource bsource = new BindingSource( );
            bsource.DataSource = dtable;

            DataView view = new DataView( dtable );
            view.RowFilter = string.Format( "Name LIKE '%{0}%'", txtSearch.Text.Replace( "'", "''" ) );
            dgvProjectOrName.DataSource = view;

            ColumnConfigurationClass configure = new ColumnConfigurationClass( );
            configure.NameCheckedColumnConfiguration( dgvProjectOrName );
            dgvProjectOrName.Update( );
        }
    }
}
