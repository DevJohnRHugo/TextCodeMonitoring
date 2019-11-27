using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace TextCodeMonitoring.DataBaseConnection {
    class DataBaseConnectionSourcePath {
        
        public static MySqlConnection GetConnection( ) {
            MySqlConnection con = new MySqlConnection( "datasource=localhost;port=3306;user=root;password=engineering1105;pooling=false;" );
            try
            {
                
                con.Open( );
                
            }
            catch ( Exception ex )
            {

                MessageBox.Show( "Error! : " + ex.Message, "ERROR!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error );
            }
            return con;
        }
    }
}
