using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextCodeMonitoring.TextCodeMainFormClasses;


namespace TextCodeMonitoring {
    public partial class CustomeDateRangeCallUpForm : Form {
        public static string passValueDgvCallUp;
        public CustomeDateRangeCallUpForm() {
            InitializeComponent();
        }
       
        private void btnFilter_Click(object sender, EventArgs e) {
            TextCodeMonitoringForm txtCodeform = new TextCodeMonitoringForm();
            DataGridView dgvHistoryPenaltyCallup = txtCodeform.dgvHistoryPenaltyCallup;

            //ShowCallUpRecords show = new ShowCallUpRecords();
            //show.CustomDateRangeFilter(dgvHistoryPenaltyCallup, dtpDateRangeFrom, dtpDateRangeTo);
            
        }
    }
}
