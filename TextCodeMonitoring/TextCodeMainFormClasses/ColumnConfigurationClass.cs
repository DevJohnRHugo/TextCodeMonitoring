using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace TextCodeMonitoring.TextCodeMainFormClasses {
    class ColumnConfigurationClass {
        public void ProjectCheckOrSetConfiguration( DataGridView dgvProjectName ) {
            dgvProjectName.Columns[ "PrimaryID" ].Visible = false;
            dgvProjectName.Columns[ "Project" ].Visible = true;
            //dgvProjectName.Columns[ "WeekNumber" ].Visible = false;
            //dgvProjectName.Columns[ "DateFrom" ].Visible = false;
            //dgvProjectName.Columns[ "DateTo" ].Visible = false;
            //dgvProjectName.Columns[ "DateTexted" ].Visible = false;
            dgvProjectName.Columns[ "Name" ].Visible = false;           
            dgvProjectName.Columns[ "ProjectStatus" ].Visible = false;
            //dgvProjectName.Columns[ "TypeOfReporting" ].Visible = false;
            //dgvProjectName.Columns[ "SignalStatus" ].Visible = false;
            //dgvProjectName.Columns[ "Remarks" ].Visible = false;
            //dgvProjectName.Columns[ "Picture" ].Visible = false;
            //dgvProjectName.Columns[ "TextCodeOrHardCopy" ].Visible = false;
        }
        public void NameCheckedColumnConfiguration( DataGridView dgvProjectName ) {
            dgvProjectName.Columns[ "PrimaryID" ].Visible = false;
            dgvProjectName.Columns[ "Project" ].Visible = false;
            //dgvProjectName.Columns[ "DateTexted" ].Visible = false;
            dgvProjectName.Columns[ "Name" ].Visible = true;
            dgvProjectName.Columns[ "ProjectStatus" ].Visible = false;
            //dgvProjectName.Columns[ "Designation" ].Visible = false;
            //dgvProjectName.Columns[ "TypeOfReporting" ].Visible = false;
            //dgvProjectName.Columns[ "SignalStatus" ].Visible = false;
            //dgvProjectName.Columns[ "Remarks" ].Visible = false;
            //dgvProjectName.Columns[ "Picture" ].Visible = false;
            //dgvProjectName.Columns[ "TextCodeOrHardCopy" ].Visible = false;
        }
        public void CheckerBodegeroAssigned( DataGridView dgvCheckerBodegeroAssigned ) {
            dgvCheckerBodegeroAssigned.Columns[ "PrimaryID" ].Visible = false;
            dgvCheckerBodegeroAssigned.Columns[ "ForeignKey" ].Visible = false;
            dgvCheckerBodegeroAssigned.Columns[ "Project" ].Visible = true;
            dgvCheckerBodegeroAssigned.Columns[ "Name" ].Visible = true;
            dgvCheckerBodegeroAssigned.Columns[ "WeekNumber" ].Visible = true;
            dgvCheckerBodegeroAssigned.Columns[ "DateFrom" ].Visible = true;
            dgvCheckerBodegeroAssigned.Columns[ "DateTo" ].Visible = true;
            dgvCheckerBodegeroAssigned.Columns[ "DateTexted" ].Visible = true;
           
            dgvCheckerBodegeroAssigned.Columns[ "Designation" ].Visible = true;
            dgvCheckerBodegeroAssigned.Columns[ "Remarks" ].Visible = true;         
            dgvCheckerBodegeroAssigned.Columns[ "TextCodeOrHardCopy" ].Visible = true;
            dgvCheckerBodegeroAssigned.Columns[ "Picture" ].Visible = false;
            dgvCheckerBodegeroAssigned.Columns[ "ContactNumber" ].Visible = true;
        }
        public void CheckerBodegeroAssignedColumnSizes( DataGridView dgvCheckerBodegeroAssigned ) {
            dgvCheckerBodegeroAssigned.Columns[ "Project" ].Width = 200;
            dgvCheckerBodegeroAssigned.Columns[ "Name" ].Width = 180;
            dgvCheckerBodegeroAssigned.Columns[ "WeekNumber" ].Width = 100;
            dgvCheckerBodegeroAssigned.Columns[ "DateFrom" ].Width = 100;
            dgvCheckerBodegeroAssigned.Columns[ "DateTo" ].Width = 100;
            dgvCheckerBodegeroAssigned.Columns[ "DateTexted" ].Width = 100;
            dgvCheckerBodegeroAssigned.Columns[ "Designation" ].Width = 150;
            dgvCheckerBodegeroAssigned.Columns[ "ContactNumber" ].Width = 150;
            dgvCheckerBodegeroAssigned.Columns[ "Remarks" ].Width = 180;
            dgvCheckerBodegeroAssigned.Columns[ "TextCodeOrHardCopy" ].Width = 100;

            dgvCheckerBodegeroAssigned.Columns[ "TextCodeOrHardCopy" ].HeaderText = "Type of report";
            dgvCheckerBodegeroAssigned.Columns[ "Project" ].HeaderText = "Project";
            dgvCheckerBodegeroAssigned.Columns[ "Name" ].HeaderText = "Name";
            dgvCheckerBodegeroAssigned.Columns[ "WeekNumber" ].HeaderText = "Week-#";
            dgvCheckerBodegeroAssigned.Columns[ "DateFrom" ].HeaderText = "Dcov. From";
            dgvCheckerBodegeroAssigned.Columns[ "DateTo" ].HeaderText = "Dcov. To";
            dgvCheckerBodegeroAssigned.Columns[ "DateTexted" ].HeaderText = "Date of report";
            dgvCheckerBodegeroAssigned.Columns[ "Designation" ].HeaderText = "Designation";
            dgvCheckerBodegeroAssigned.Columns[ "ContactNumber" ].HeaderText = "Contact-#";
            dgvCheckerBodegeroAssigned.Columns[ "Remarks" ].HeaderText = "Remarks";
        }
        public void PenaltyColumnSizes( DataGridView dgvHistoryPenaltyCallup ) {
            dgvHistoryPenaltyCallup.Columns[ "PrimaryID" ].Visible = false; 
            dgvHistoryPenaltyCallup.Columns[ "Name" ].Width = 200;
            dgvHistoryPenaltyCallup.Columns[ "Name" ].HeaderText = "Name";

            dgvHistoryPenaltyCallup.Columns[ "Project" ].Width = 350;
            dgvHistoryPenaltyCallup.Columns[ "Project" ].HeaderText = "Project";

            dgvHistoryPenaltyCallup.Columns[ "WeekNumber" ].Width = 130;
            dgvHistoryPenaltyCallup.Columns[ "WeekNumber" ].HeaderText = "Week-#";

            dgvHistoryPenaltyCallup.Columns[ "WeekCount" ].Width = 130;
            dgvHistoryPenaltyCallup.Columns[ "WeekCount" ].HeaderText = "Week Count";

            dgvHistoryPenaltyCallup.Columns[ "Remarks" ].Width = 150;
            dgvHistoryPenaltyCallup.Columns[ "Remarks" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvHistoryPenaltyCallup.Columns[ "DateOfCallup" ].Width = 180;
            dgvHistoryPenaltyCallup.Columns[ "DateOfCallUp" ].HeaderText = "Date of Call-up";
        }
        public void WeekNumber(DataGridView dgvWeekNumber ) {
            dgvWeekNumber.Columns[ "Name" ].Visible = false;
            dgvWeekNumber.Columns[ "PrimaryID" ].Visible = false;
            dgvWeekNumber.Columns[ "ForeignKey" ].Visible = false;
            dgvWeekNumber.Columns[ "DateFrom" ].Visible = false;
            dgvWeekNumber.Columns[ "DateTo" ].Visible = false;
            dgvWeekNumber.Columns[ "DateTexted" ].Visible = false;
            dgvWeekNumber.Columns[ "Remarks" ].Visible = false;
            dgvWeekNumber.Columns[ "WeekNumber" ].Visible = true;
            dgvWeekNumber.Columns[ "WeekNumber" ].HeaderText = "Week-#";
        }
        public void CheckerBodegeroAccounts( DataGridView dgvCheckerBodegeroAccounts ) {
            dgvCheckerBodegeroAccounts.Columns["PrimaryID"].Visible = false;
            dgvCheckerBodegeroAccounts.Columns[ "ForeignKey" ].Visible = false;
            dgvCheckerBodegeroAccounts.Columns["Picture"].Visible = false;
            dgvCheckerBodegeroAccounts.Columns["Name"].Visible = true;
            dgvCheckerBodegeroAccounts.Columns["Designation"].Visible = true;
            dgvCheckerBodegeroAccounts.Columns["ContactNumber"].Visible = true;
            dgvCheckerBodegeroAccounts.Columns["Remarks"].Visible = false;
            dgvCheckerBodegeroAccounts.Columns[ "ContactNumber" ].HeaderText = "Contact-#";
                    
        }
    }
}
