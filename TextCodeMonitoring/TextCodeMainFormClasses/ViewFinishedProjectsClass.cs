using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace TextCodeMonitoring.TextCodeMainFormClasses {
    class ViewFinishedProjectsClass {
        public void ViewFinishedProjects( DataGridView dgvProjectName ) {
            MySqlCommand cmd = new MySqlCommand( );
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection( );
            cmd.CommandText = "SELECT * FROM textcodedb.projects WHERE ProjectStatus='Finished' ORDER BY PrimaryID DESC";
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
    }
}
