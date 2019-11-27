using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using TextCodeMonitoring.TextCodeMainFormClasses;

namespace TextCodeMonitoring
{
    public partial class TextCodeMonitoringForm : Form {
        public static string GetPicPath;

        public TextCodeMonitoringForm() {
            InitializeComponent();            
          FindMissingWeeks();
            LoadMethod( );
            //   backgroundWorker1.RunWorkerAsync( );

        }
        FormSearchLoading frm2 = new FormSearchLoading();
        private void CallForm2Loading() {
            Application.Run(frm2);
        }

        #region My Methods

        private void GetImageAccounts() {
            var image_value = dgvCheckerBodegeroAccounts.CurrentRow.Cells[ "Picture" ].Value;
            byte[ ] image = ( byte[ ] ) ( image_value );
            MemoryStream MStream = new MemoryStream( image );
            pictureBoxCheckerBodegero.Image = Image.FromStream( MStream );
        }
        private void GetImageAssigned() {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
            cmd.CommandText = "SELECT Picture FROM textcodedb.details WHERE PrimaryID='" + dgvCheckerBodegeroAssigned.CurrentRow.Cells["PrimaryID"].Value.ToString() + "'";
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                byte[] image = (byte[])(reader["Picture"]);
                MemoryStream MStream = new MemoryStream(image);
                pictureBoxCheckerBodegero.Image = System.Drawing.Image.FromStream(MStream);
            }
            cmd.Connection.Close();
        }

        private void GetImageAssignedAutoCompleteName() {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
            cmd.CommandText = "SELECT Name,Picture FROM textcodedb.checkerbodegeroaccounts WHERE Name='" + txtNameNewEntry.Text + "'";
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                byte[] image = (byte[])(reader["Picture"]);
                MemoryStream MStream = new MemoryStream(image);
                pictureBoxCheckerBodegero.Image = System.Drawing.Image.FromStream(MStream);
                // reader.Close( );
            }

        }


        private void ShowWeekNumberEntries() {
            ShowWeekNumbers show = new ShowWeekNumbers();
            show.ShowWeekNumberEntries(dgvWeekNumber, dgvProjectOrName);
        }
        private void ShowAssignedCheckerBodegero() {
            ShowCheckerBodegeroAssigned show = new ShowCheckerBodegeroAssigned();
            show.ShowAssignedCheckerBodegero(dgvCheckerBodegeroAssigned, dgvProjectOrName);
        }
        private void RefreshClear() {
            FileInfo file = new FileInfo("icon-person-64.png");
            txtProject.Clear(); txtWeekNumber.Clear(); MtxtDateFrom.ResetText(); MtxtDateTo.ResetText();
            dtpDateTexted.Value = DateTime.Now;
            txtRemarks.Clear(); txtNameNewEntry.Clear(); txtDesignationNewEntry.Clear(); txtSearchAccounts.Clear();
            txtWeekNumberWeekly.Clear(); dtpDateTextdWeekly.Value = DateTime.Now; MtxtDateFromWeekly.ResetText(); MtxtDateToWeekly.ResetText();
            txtRemarksWeekly.Clear(); txtContactNmber.Clear(); pictureBoxCheckerBodegero.Image = Image.FromFile(file.DirectoryName + @"\icon-person-64.png");

            dgvWeekNumber.DataSource = null; dgvWeekNumber.Columns.Clear();
            dgvHistoryPenaltyCallup.DataSource = null; dgvHistoryPenaltyCallup.Columns.Clear();
            dgvCheckerBodegeroAssigned.DataSource = null; dgvCheckerBodegeroAssigned.Columns.Clear();
            //dgvCheckerBodegeroAccounts.DataSource = null; dgvCheckerBodegeroAccounts.Columns.Clear( );
            LoadMethod();
        }
        private void DateFromToDateTo(MaskedTextBox MtxtDateFrom, MaskedTextBox MtxtDateTo) {
            if (MtxtDateFrom.Text == "    /  /")
            {
                MessageBox.Show("No Date input, must have Date-Covered!", "Date Covered", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);

            }
            else
            {
                string DateTo = Convert.ToDateTime(MtxtDateFrom.Text).AddDays(Convert.ToDouble(6)).ToString("yyyy/MM/dd");
                MtxtDateTo.Text = DateTo;
            }
        }

        private void FindMissingWeeks() {
            FindMissingWeekNumbers( );
            //GettingTheTextedTextcodeMonitoringRecords( );
        }
        private void LoadMethod() {

            LoadRecordsClasses load = new LoadRecordsClasses();
            load.Project(dgvProjectOrName);
            load.CheckerBodegeroAccounts(dgvCheckerBodegeroAccounts);

            EmptyRows EmptyRows = new EmptyRows();
            EmptyRows.WeekNumber(dgvWeekNumber);
            EmptyRows.HistoryPenaltyCallup(dgvHistoryPenaltyCallup);
            EmptyRows.CheckerBodegeroAssigned(dgvCheckerBodegeroAssigned);

            txtSearch.Select();
            dgvCheckerBodegeroAssigned.CellClick -= dgvCheckerBodegeroAssigned_CellClick;
            dgvCheckerBodegeroAssigned.CellMouseDown -= dgvCheckerBodegeroAssigned_CellMouseDown;
            dgvCheckerBodegeroAssigned.CellEndEdit -= dgvCheckerBodegeroAssigned_CellEndEdit;

            AutoCompleteClass AutoComplete = new AutoCompleteClass();
            AutoComplete.CheckerNameComplete(txtNameNewEntry);
            AutoComplete.ProjectNameAutoComple(txtProjectToFilter);
            
        }
        private void SaveNewEntry() {
            NewProjectOrWeeklyEntry save = new TextCodeMainFormClasses.NewProjectOrWeeklyEntry(); //Instantiating Class NewProjectOrWeeklyEntry
                                                                                                                                                     //save.SaveNewEntryProject( txtProject, txtNameNewEntry );/* Saving the new Project to table projects */
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
            cmd.CommandText = "SELECT * FROM textcodedb.projects WHERE Project='" + txtProject.Text.Replace("'", "''") + "'";
            MySqlDataReader reader = cmd.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count++;
            }
            if (count != 1)
            {
                reader.Close();
                cmd.CommandText = "INSERT INTO textcodedb.projects (Project,Name, ProjectStatus) values ('" + txtProject.Text.Replace("'", "''") + "','" + txtNameNewEntry.Text.Replace("'", "''") + "','On-going')";
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
              
                save.SaveEntryTextCodeForExistingCheckerBodegero(txtProject, txtWeekNumber, MtxtDateFrom, MtxtDateTo, dtpDateTexted,
                txtNameNewEntry, txtDesignationNewEntry, txtRemarks,
                dgvProjectOrName, RbtnTextCode, RbtnHardCopy, txtContactNmber, pictureBoxCheckerBodegero); /* Saving the new Project to table details */

                NewCheckerBodegero NewAcc = new NewCheckerBodegero();
                NewAcc.SaveNewCheckerBodegero(txtNameNewEntry, txtDesignationNewEntry, txtContactNmber, txtRemarks, pictureBoxCheckerBodegero);

                /* This is to Save an entry to weekly textcode if radio button textcode is selected */
                if (RbtnTextCode.Checked == true)
                {
                    save.SaveEntryTextCodeToWeeklyEntry(txtWeekNumber, MtxtDateFrom, MtxtDateTo, dtpDateTexted, txtNameNewEntry);
                }
                /*Till here*/
            }
            else
            {
                MessageBox.Show("Duplicate entry of this Project : " + txtProject.Text.Replace("'", "''").ToUpper() + " ", "DUPLICATE ENTRY", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
            }
        }
        #endregion
        private void txtSearch_TextChanged(object sender, EventArgs e) {
            try
            {
                Search search = new Search();
                if (RBtnName.Checked == true)
                {
                    search.SearchName(txtSearch, dgvProjectOrName);
                }
                else
                {
                    search.SearchProject(txtSearch, dgvProjectOrName);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void txtSearch_Enter(object sender, EventArgs e) {
            txtSearch.Clear();
        }

        private void txtSearch_Leave(object sender, EventArgs e) {

        }

        private void btnSelectImage_Click(object sender, EventArgs e) {
            try
            {
                GetPicPath = SelectImage.ImagePath;
                SelectImage select = new SelectImage( );
                select.SelectAnImage(pictureBoxCheckerBodegero, GetPicPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSaveEntry_Click(object sender, EventArgs e) {
            //try
            //{
                string EmptyTextBoxes;//Make it much more reachable by declaring this variable above the codes
                /* Checking the textboxes if null/empty then prompt user if condition is true */
                List<string> TxtBoxes = new List<string> { txtProject.Text, txtWeekNumber.Text, txtNameNewEntry.Text, txtDesignationNewEntry.Text };//Creating list placing the corresponding textboxes

                List<string> DefaultTextBoxValues = new List<string>(); /*Creating a list that will be the default values to match the "TxtBoxes"-List created above. 
                                                                          Matching of value of TxtBoxes and DefaultTextBoxValues List: Project= txtProject, Week-#= txtWeekNumber,
                                                                          Name= txtNameNewEntry and Designation= txtDesignationNewEntry*/
                DefaultTextBoxValues.Add("Project");
                DefaultTextBoxValues.Add("Week-#");
                DefaultTextBoxValues.Add("Name");
                DefaultTextBoxValues.Add("Designation");

                List<string> FillTextBoxnames = new List<string>();//After matching the values to get the right string value or name of txtboxes, create this list box that will hold all the matching values

                /* Ends here */

                /* Now matching the values and getting the textboxes with empty values */
                for (int indexNumber = 0; indexNumber < TxtBoxes.Count; indexNumber++)//Making a for loop initialize to 0, condition less than the item count of TxtBoxes List
                {
                    if (TxtBoxes[indexNumber] == "")//Now checking the textbox items of list TxtBoxes for empty values
                    {
                        FillTextBoxnames.Add(DefaultTextBoxValues[indexNumber]);/*Then Adding it as another values for FillTextBoxnames list, which the string item name comes from FillTextboxnames and its index number matches
                                                                              the index number of TxtBoxes list the return true/Empty from the if statement above*/
                    }
                }
                EmptyTextBoxes = string.Join(", ", FillTextBoxnames).Trim();/*using string.Join the declared string EmtyTextBoxes shall hold all the values added to List FillTextBoxnames
                                                                                and Joining them all together with string.Join, with separator character of ", '*/
                if (string.IsNullOrWhiteSpace(EmptyTextBoxes) == false && MtxtDateFrom.MaskFull == true)
                {
                    MessageBox.Show("Fill-up the Ff. records :" + Environment.NewLine + EmptyTextBoxes.ToUpper(), "MISSING RECORDS", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
                else if (MtxtDateFrom.MaskFull == false && string.IsNullOrWhiteSpace(EmptyTextBoxes) == true)
                {
                    MessageBox.Show("Fill-up the Ff. records :" + Environment.NewLine + "DATE-COVERED", "MISSING RECORDS", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrWhiteSpace(EmptyTextBoxes) == false && MtxtDateFrom.MaskFull == false)
                {
                    MessageBox.Show("Fill-up the Ff. records :" + Environment.NewLine + EmptyTextBoxes.ToUpper() + " AND DATE-COVERED", "MISSING RECORDS", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
                else
                {

                    if (RbtnTextCode.Checked == false && RbtnHardCopy.Checked == false)
                    {
                        MessageBox.Show("Please select [Type of report]!", "Select Type of reporting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SaveNewEntry();
                        RefreshClear();

                    }
                }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("ERROR! " + ex.Message, "ERROR!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            //}
        }

        private void TextCodeMonitoringForm_Load(object sender, EventArgs e) {
            this.Location = new Point(0);
            
            dgvWeeklyTextMonitoring.Columns[ "Name" ].Width = 170;
            dgvWeeklyTextMonitoring.Columns[ "Name" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvWeeklyTextMonitoring.Columns[ "Designation" ].Width = 150;
            dgvWeeklyTextMonitoring.Columns[ "Designation" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvWeeklyTextMonitoring.Columns[ "PrevDcov" ].HeaderText = "Pev. - Dcov";
            dgvWeeklyTextMonitoring.Columns[ "PrevDcov" ].Width = 200;
            dgvWeeklyTextMonitoring.Columns[ "PrevDcov" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvWeeklyTextMonitoring.Columns[ "LastWeekTexted" ].HeaderText = "Last week texted";
            dgvWeeklyTextMonitoring.Columns[ "LastWeekTexted" ].Width = 150;
            dgvWeeklyTextMonitoring.Columns[ "LastWeekTexted" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvWeeklyTextMonitoring.Columns[ "NumWeeks" ].HeaderText = "Num. of weeks";
            dgvWeeklyTextMonitoring.Columns[ "NumWeeks" ].Width = 100;
            dgvWeeklyTextMonitoring.Columns[ "NumWeeks" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvWeeklyTextMonitoring.Columns[ "DateLastTxt" ].HeaderText = "Date last text";
            dgvWeeklyTextMonitoring.Columns[ "DateLastTxt" ].Width = 150;
            dgvWeeklyTextMonitoring.Columns[ "DateLastTxt" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            // dgvWeeklyTextMonitoring.Columns[ "ContactNumber" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvWeeklyTextMonitoring.Columns[ "ContactNumber" ].Width = 200;
        }

        private void dgvProjectOrName_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void RBtnName_Click(object sender, EventArgs e) {
            try
            {
                if (RBtnName.Checked == true)
                {
                    LoadRecordsClasses name = new LoadRecordsClasses();
                    name.Name(dgvProjectOrName);
                }
                else
                {
                    Search search = new Search();
                    search.SearchName(txtSearch, dgvProjectOrName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void RBtnProject_Click(object sender, EventArgs e) {
            try
            {
                if (RBtnProject.Checked == true)
                {
                    LoadRecordsClasses Project = new LoadRecordsClasses();
                    Project.Project(dgvProjectOrName);
                }
                else
                {
                    Search search = new Search();
                    search.SearchProject(txtSearch, dgvProjectOrName);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void MtxtDateFrom_Leave(object sender, EventArgs e) {
            try
            {
                if (MtxtDateFrom.MaskCompleted == true)
                {
                    DateFromToDateTo(MtxtDateFrom, MtxtDateTo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void MtxtDateFromWeekly_Leave(object sender, EventArgs e) {
            try
            {
                DateFromToDateTo(MtxtDateFromWeekly, MtxtDateToWeekly);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAddWeek_Click(object sender, EventArgs e) {
            try
            {
                NewProjectOrWeeklyEntry New = new NewProjectOrWeeklyEntry();
                New.TxtCodeWeeklyEntry(txtWeekNumberWeekly, MtxtDateFromWeekly, MtxtDateToWeekly, dtpDateTextdWeekly, txtRemarksWeekly, dgvProjectOrName);
                RefreshClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void MtxtDateFrom_TextChanged(object sender, EventArgs e) {
            try
            {
                if (MtxtDateFrom.MaskCompleted == true)
                {
                    MtxtDateTo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void dgvProjectOrName_CellClick(object sender, DataGridViewCellEventArgs e) {
            try
            {
                if (RBtnName.Checked == true)
                {
                    ShowWeekNumberEntries();
                    ShowAssignedCheckerBodegero();

                    dgvCheckerBodegeroAssigned.CellClick += dgvCheckerBodegeroAssigned_CellClick;
                    dgvCheckerBodegeroAssigned.CellEndEdit += dgvCheckerBodegeroAssigned_CellEndEdit;
                    dgvCheckerBodegeroAssigned.CellMouseDown += dgvCheckerBodegeroAssigned_CellMouseDown;
                }
                else
                {
                    ShowWeekNumberEntries();
                    ShowAssignedCheckerBodegero();

                    dgvCheckerBodegeroAssigned.CellClick += dgvCheckerBodegeroAssigned_CellClick;
                    dgvCheckerBodegeroAssigned.CellEndEdit += dgvCheckerBodegeroAssigned_CellEndEdit;
                    dgvCheckerBodegeroAssigned.CellMouseDown += dgvCheckerBodegeroAssigned_CellMouseDown;
                }

                ShowCallUpRecords callUp = new ShowCallUpRecords(dgvProjectOrName, dgvHistoryPenaltyCallup);
                callUp.ShowRecordsByProject();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MtxtDateFromWeekly_TextChanged(object sender, EventArgs e) {
            if (MtxtDateFromWeekly.MaskCompleted == true)
            {
                MtxtDateToWeekly.Focus();
            }
        }

        private void dgvHistoryPenaltyCallup_CellClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void dgvCheckerBodegeroAssigned_CellClick(object sender, DataGridViewCellEventArgs e) {
            txtProject.Text = dgvCheckerBodegeroAssigned.CurrentRow.Cells["Project"].Value.ToString();
            dtpDateTexted.Text = dgvCheckerBodegeroAssigned.CurrentRow.Cells["DateTexted"].Value.ToString();
            txtNameNewEntry.Text = dgvCheckerBodegeroAssigned.CurrentRow.Cells["Name"].Value.ToString();
            txtDesignationNewEntry.Text = dgvCheckerBodegeroAssigned.CurrentRow.Cells["Designation"].Value.ToString();
            txtRemarks.Text = dgvCheckerBodegeroAssigned.CurrentRow.Cells["Remarks"].Value.ToString();
            GetImageAssigned();
            txtWeekNumber.Text = dgvCheckerBodegeroAssigned.CurrentRow.Cells["WeekNumber"].Value.ToString();
            MtxtDateFrom.Text = dgvCheckerBodegeroAssigned.CurrentRow.Cells["DateFrom"].Value.ToString();
            MtxtDateTo.Text = dgvCheckerBodegeroAssigned.CurrentRow.Cells["DateTo"].Value.ToString();
            txtContactNmber.Text = dgvCheckerBodegeroAssigned.CurrentRow.Cells["ContactNumber"].Value.ToString();
            if (dgvCheckerBodegeroAssigned.CurrentRow.Cells["TextCodeOrHardCopy"].Value.ToString() == "Hard Copy")
            {
                RbtnHardCopy.Checked = true;
            }
            else
            {
                RbtnTextCode.Checked = true;
            }
        }


        private void dgvWeekNumber_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void dgvWeekNumber_CellClick(object sender, DataGridViewCellEventArgs e) {
            dtpDateTextdWeekly.Text = dgvWeekNumber.CurrentRow.Cells["DateTexted"].Value.ToString();
            txtRemarksWeekly.Text = dgvWeekNumber.CurrentRow.Cells["Remarks"].Value.ToString();
            txtWeekNumberWeekly.Text = dgvWeekNumber.CurrentRow.Cells["WeekNumber"].Value.ToString();
            MtxtDateFromWeekly.Text = dgvWeekNumber.CurrentRow.Cells["DateFrom"].Value.ToString();
            MtxtDateToWeekly.Text = dgvWeekNumber.CurrentRow.Cells["DateTo"].Value.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            try
            {
                dgvWeeklyTextMonitoring.DataSource = null; dgvWeeklyTextMonitoring.Columns.Clear(); 
                FindMissingWeekNumbers();
                RefreshClear();

                dgvWeeklyTextMonitoring.Columns[ "Name" ].Width = 170;
                dgvWeeklyTextMonitoring.Columns[ "Name" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                dgvWeeklyTextMonitoring.Columns[ "Designation" ].Width = 150;
                dgvWeeklyTextMonitoring.Columns[ "Designation" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                dgvWeeklyTextMonitoring.Columns[ "PrevDcov" ].HeaderText = "Pev. - Dcov";
                dgvWeeklyTextMonitoring.Columns[ "PrevDcov" ].Width = 200;
                dgvWeeklyTextMonitoring.Columns[ "PrevDcov" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                dgvWeeklyTextMonitoring.Columns[ "LastWeekTexted" ].HeaderText = "Last week texted";
                dgvWeeklyTextMonitoring.Columns[ "LastWeekTexted" ].Width = 150;
                dgvWeeklyTextMonitoring.Columns[ "LastWeekTexted" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                dgvWeeklyTextMonitoring.Columns[ "NumWeeks" ].HeaderText = "Num. of weeks";
                dgvWeeklyTextMonitoring.Columns[ "NumWeeks" ].Width = 100;
                dgvWeeklyTextMonitoring.Columns[ "NumWeeks" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                dgvWeeklyTextMonitoring.Columns[ "DateLastTxt" ].HeaderText = "Date last text";
                dgvWeeklyTextMonitoring.Columns[ "DateLastTxt" ].Width = 150;
                dgvWeeklyTextMonitoring.Columns[ "DateLastTxt" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                // dgvWeeklyTextMonitoring.Columns[ "ContactNumber" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvWeeklyTextMonitoring.Columns[ "ContactNumber" ].Width = 200;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void dgvCheckerBodegeroAssigned_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void dgvCheckerBodegeroAccounts_CellClick(object sender, DataGridViewCellEventArgs e) {
            try
            {
                txtNameNewEntry.Text = dgvCheckerBodegeroAccounts.CurrentRow.Cells[ "Name" ].Value.ToString( );
                txtDesignationNewEntry.Text = dgvCheckerBodegeroAccounts.CurrentRow.Cells[ "Designation" ].Value.ToString( );
                txtContactNmber.Text = dgvCheckerBodegeroAccounts.CurrentRow.Cells[ "ContactNumber" ].Value.ToString( );
                // GetImageAccounts();
                var image_value = dgvCheckerBodegeroAccounts.CurrentRow.Cells[ "Picture" ].Value;
                byte[ ] image = ( byte[ ] ) ( image_value );
                MemoryStream MStream = new MemoryStream( image );
                pictureBoxCheckerBodegero.Image = Image.FromStream( MStream );

                ShowCallUpRecords call = new ShowCallUpRecords( dgvCheckerBodegeroAccounts , dgvHistoryPenaltyCallup );
                call.ShowRecordsByChecker( );

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void txtSearchAccounts_TextChanged(object sender, EventArgs e) {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
                cmd.CommandText = "SELECT * FROM textcodedb.checkerbodegeroaccounts ";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                DataTable dtable = new DataTable();
                dataAdapter.Fill(dtable);

                dgvCheckerBodegeroAccounts.DataSource = dtable;
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dtable;

                DataView view = new DataView(dtable);
                view.RowFilter = string.Format("Name LIKE '%{0}%'", txtSearchAccounts.Text.Replace("'", "''"));
                dgvCheckerBodegeroAccounts.DataSource = view;

                ColumnConfigurationClass config = new ColumnConfigurationClass();
                config.CheckerBodegeroAccounts(dgvCheckerBodegeroAccounts);
                dgvCheckerBodegeroAccounts.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e) {

        }
        private void CheckWeeklyTextRecords() {

        }
        private void FindMissingWeekNumbers() {
            //try
            //{
          //  List<string> table;
          
         //   string[ ][] arr = new string[8][];
         
                 double dateCount = 0;
                string match = "";
                double CountDate = 0;
                string ContactNumber = "";
                string Week = "";
                string Designation = "";
            // string Name2 = "";

            //This is to Check Weekly Text Entries
            dT.Columns.Add( "Name"  );
            dT.Columns.Add( "Project" );
            dT.Columns.Add( "Designation"  );
            dT.Columns.Add( "PrevDcov"  );
            dT.Columns.Add( "LastWeekTexted" );
            dT.Columns.Add( "NumWeeks"  );
            dT.Columns.Add( "DateLastTxt"  );
            dT.Columns.Add( "ContactNumber"  );

            /* Get the projects */
            MySqlCommand cmdProject2 = new MySqlCommand();
                cmdProject2.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
                cmdProject2.CommandText = "SELECT * FROM textcodedb.projects WHERE ProjectStatus='" + "On-going" +"' ORDER BY PrimaryID ASC";
                MySqlDataAdapter dataAdapterProject2 = new MySqlDataAdapter();
                dataAdapterProject2.SelectCommand = cmdProject2;
                DataTable dtableProject2 = new DataTable();
                dataAdapterProject2.Fill(dtableProject2);

                string MatchID = "";
                /* Iterate each Projects*/
                foreach (DataRow itemProject2 in dtableProject2.Rows)
                {
                    /* Getting the latest Checker assigned */
                    MatchID = itemProject2["PrimaryID"].ToString();

                    MySqlCommand cmdGetLatestChecker = new MySqlCommand();
                    cmdGetLatestChecker.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
                    cmdGetLatestChecker.CommandText = "SELECT * FROM (SELECT * FROM textcodedb.textedtextcode  GROUP BY PrimaryID ORDER BY DateTo DESC) AS X WHERE ForeignKey='" + itemProject2["PrimaryID"].ToString() + "' GROUP BY ForeignKey ORDER BY DateTo DESC";
                    MySqlDataAdapter dataAdapterGetLatestChecker = new MySqlDataAdapter();
                    dataAdapterGetLatestChecker.SelectCommand = cmdGetLatestChecker;
                    DataTable dtableGetLatestChecker = new DataTable();
                    dataAdapterGetLatestChecker.Fill(dtableGetLatestChecker);


                    foreach (DataRow itemGetLatestChecker in dtableGetLatestChecker.Rows)
                    {

                        Week = itemGetLatestChecker["WeekNumber"].ToString();
                        DateTime dt = Convert.ToDateTime(itemGetLatestChecker["DateTo"].ToString());

                        /* Getting the Contact Number,and Designation of the latest Checker Assigned */
                        MySqlCommand cmdGetLatestChecker2 = new MySqlCommand();
                        cmdGetLatestChecker2.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
                        cmdGetLatestChecker2.CommandText = "SELECT * FROM (SELECT * FROM textcodedb.details  GROUP BY PrimaryID ORDER BY DateTo DESC) AS X WHERE Name='" + itemProject2["Name"].ToString() + "' GROUP BY ForeignKey ORDER BY DateTo DESC";
                        MySqlDataAdapter dataAdapterGetLatestChecker2 = new MySqlDataAdapter();
                        dataAdapterGetLatestChecker2.SelectCommand = cmdGetLatestChecker2;
                        DataTable dtableGetLatestChecker2 = new DataTable();
                        dataAdapterGetLatestChecker2.Fill(dtableGetLatestChecker2);

                        foreach (DataRow itemGetLatestChecker2 in dtableGetLatestChecker2.Rows)
                        {
                            /* Assigning the Contact Number and Designation of the Latest Checker Assigned */
                            ContactNumber = itemGetLatestChecker2["ContactNumber"].ToString();
                            Designation = itemGetLatestChecker2["Designation"].ToString();

                        }

                        dateCount = Convert.ToDouble(DateTime.Now.Date.Subtract(dt).TotalDays / 7);
                    
                    /* Condition checking if days since last text DateTo is 7 or Greater and if Designation is Checker  & ProjectStatus is "On-going" */
                    if (dateCount >= 1 /*&&  Designation.ToString().Remove(8) != "Bodegero"*/)// && itemProject2["ProjectStatus"].ToString() == "On-going"
                    {

                        //for ( int col = 0 ; col < arr.Length ; col++ )
                        //{
                        //    string[] row_arr = arr[ col ];
                        //    for ( int row = 0 ; row < row_arr.Length ; row++ )
                        //    {
                        //        arr[ col ][ row ] = itemGetLatestChecker[ "Name" ] + "," + itemProject2[ "Project" ] + "," + Designation + "," + itemGetLatestChecker[ "DateFrom" ] + " - " + itemGetLatestChecker[ "DateTo" ] + "," + itemGetLatestChecker[ "WeekNumber" ]
                        //      + "," + dateCount.ToString( "#.0" ).Remove( 1 ) + "," + itemGetLatestChecker[ "DateTexted" ] + "," + ContactNumber;
                        //    }
                        //}
                        /* Concatenating and Placing the records to datagridview */

                        dT.Rows.Add( itemGetLatestChecker[ "Name" ] , itemProject2[ "Project" ] , Designation , itemGetLatestChecker[ "DateFrom" ] + " - " + itemGetLatestChecker[ "DateTo" ] , itemGetLatestChecker[ "WeekNumber" ]
                            , dateCount.ToString( "#.0" ).Remove( 1 ) , itemGetLatestChecker[ "DateTexted" ] , ContactNumber );
                        // DataTable dtable = new DataTable();
                    }
                    //   row++;
                    cmdGetLatestChecker2.Connection.Close();

                        match = itemGetLatestChecker["ForeignKey"].ToString();
                        CountDate = dateCount;

                    }
                    cmdGetLatestChecker.Connection.Close();
                    /*Checking the WeekNumbers*/
                    MySqlCommand cmdGetMatch = new MySqlCommand();
                    cmdGetMatch.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
                    cmdGetMatch.CommandText = "SELECT * FROM textcodedb.textedtextcode WHERE ForeignKey='" + itemProject2["PrimaryID"].ToString() + "' GROUP BY ForeignKey ORDER BY DateTo DESC";
                    MySqlDataReader reader = cmdGetMatch.ExecuteReader();

                    int count = 0;
                    while (reader.Read())
                    {
                        count++;
                    }
                    if (count == 0)
                    {

                        /* Condition to check if the latest Checkers Foreignkey doesnt match any Project and the Designation is Checker */
                        /* Placing the records of Hard copy only, not yet texted any text code week */
                        if (itemProject2["PrimaryID"].ToString() != match /*&& Designation.ToString().Remove(8) != "Bodegero"*/)// && itemProject2["ProjectStatus"].ToString() == "On-going"
                        {

                            MySqlCommand cmdGetDetails = new MySqlCommand();
                            cmdGetDetails.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
                            cmdGetDetails.CommandText = "SELECT * FROM(SELECT * FROM textcodedb.details GROUP BY PrimaryID ORDER BY DateTo ASC) AS X WHERE ForeignKey='" + itemProject2["PrimaryID"].ToString() + "' GROUP BY ForeignKey ORDER BY DateTo DESC";
                            MySqlDataAdapter dataAdapterGetDetails = new MySqlDataAdapter();
                            dataAdapterGetDetails.SelectCommand = cmdGetDetails;
                            DataTable dtableGetDetails = new DataTable();
                            dataAdapterGetDetails.Fill(dtableGetDetails);
                            foreach (DataRow item in dtableGetDetails.Rows)
                            {

                                DateTime dt = Convert.ToDateTime(item["DateFrom"].ToString());
                                double dateCountdetails = Convert.ToDouble(DateTime.Now.Date.Subtract(dt).TotalDays / 7);
                                if (dateCountdetails.ToString("#.0").Remove(1) != "." /*&& item["Designation"].ToString().Remove(8) != "Bodegero"*/)
                                {
                                    double CountWeeks = 0;
                                    int IndexOfDotCharacter = 0;

                                    if (dateCountdetails.ToString("#.0").Contains("."))
                                    {
                                        IndexOfDotCharacter = Convert.ToInt32(dateCountdetails.ToString("#.0").IndexOf('.').ToString());
                                        CountWeeks = Convert.ToDouble(dateCountdetails.ToString("#.0").Remove((IndexOfDotCharacter)));
                                    }
                                    else
                                    {
                                        CountWeeks = Convert.ToDouble(dateCountdetails.ToString("#.0"));
                                    }
                                /*concatenating the values and placing it in datagridview*/

                                dT.Rows.Add( item[ "Name" ] , item[ "Project" ] , item[ "Designation" ] , item[ "DateFrom" ] + " - " + item[ "DateTo" ] , item[ "WeekNumber" ] + " - Hard Copy" , CountWeeks , item[ "DateTexted" ] , item[ "ContactNumber" ] );
                            }

                            }
                            cmdGetDetails.Connection.Close();
                        }
                    }
                    cmdGetMatch.Connection.Close();
                }
                cmdProject2.Connection.Close();

            dgvWeeklyTextMonitoring.DataSource = dT;
       
            dgvWeeklyTextMonitoring.Update( );
          
            /*
            //This is to Find Missng Week Numbers
            //Creating Columns of dataGridView11
            dgvMissingWeekNumbers.Columns.Add("Name", "Name");
            dgvMissingWeekNumbers.Columns.Add("Project", "Project");
            dgvMissingWeekNumbers.Columns.Add("Designation", "Designation");
            dgvMissingWeekNumbers.Columns.Add("Weeknumbers", "Week-#/'s");
            dgvMissingWeekNumbers.Columns.Add("LastWeekTexted", "Prev. Week-#");
            dgvMissingWeekNumbers.Columns.Add("DateLastTexted", "Prev. Date Texted");
            dgvMissingWeekNumbers.Columns.Add("ContactNumber", "Contact-#/'s");

            dgvMissingWeekNumbers.Columns["Designation"].Width = 140;
            dgvMissingWeekNumbers.Columns["Designation"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            ////  dgvMissingWeekNumbers.Columns[ "Weeknumbers" ].Width = 100;
            // dgvMissingWeekNumbers.Columns[ "Weeknumbers" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvMissingWeekNumbers.Columns["ContactNumber"].Width = 200;
            dgvMissingWeekNumbers.Columns["ContactNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvMissingWeekNumbers.Columns["LastWeekTexted"].Width = 100;
            dgvMissingWeekNumbers.Columns["LastWeekTexted"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvMissingWeekNumbers.Columns["DateLastTexted"].Width = 110;
            dgvMissingWeekNumbers.Columns["DateLastTexted"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvMissingWeekNumbers.Columns["Name"].Width = 170;
            dgvMissingWeekNumbers.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            //Getting the PrimaryID of All Projects
            MySqlCommand cmdProject = new MySqlCommand();
            cmdProject.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
            cmdProject.CommandText = "SELECT * FROM  textcodedb.projects  ORDER BY PrimaryID ASC";

            MySqlDataAdapter dataAdapterProject = new MySqlDataAdapter();
            dataAdapterProject.SelectCommand = cmdProject;
            DataTable dtableProject = new DataTable();
            dataAdapterProject.Fill(dtableProject);

            //Iterating each projects and getting their texted Week Number reports
            foreach (DataRow itemWeeks in dtableProject.Rows)
            {
                //Getting the Weeks and GROUP BY their ForeignKey of each Projects
                MySqlCommand cmdGetWeeks = new MySqlCommand();
                cmdGetWeeks.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
                cmdGetWeeks.CommandText = "SELECT * FROM  textcodedb.textedtextcode WHERE ForeignKey='" + itemWeeks["PrimaryID"].ToString() + "' GROUP BY ForeignKey";
                MySqlDataAdapter dataAdapterGetWeeks = new MySqlDataAdapter();
                dataAdapterGetWeeks.SelectCommand = cmdGetWeeks;
                DataTable dtableGetWeeks = new DataTable();
                dataAdapterGetWeeks.Fill(dtableGetWeeks);
                cmdGetWeeks.Connection.Close();

                //This is to Get all the weeks of each projects
                MySqlCommand cmdGetAllWeeks = new MySqlCommand();
                cmdGetAllWeeks.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
                cmdGetAllWeeks.CommandText = "SELECT * FROM  textcodedb.textedtextcode WHERE ForeignKey='" + itemWeeks["PrimaryID"].ToString() + "' ";
                MySqlDataAdapter dataAdapterGetAllWeeks = new MySqlDataAdapter();
                dataAdapterGetAllWeeks.SelectCommand = cmdGetAllWeeks;
                DataTable dtableGetAllWeeks = new DataTable();
                dataAdapterGetAllWeeks.Fill(dtableGetAllWeeks);


                //This is to get the latest week number of each projects Text code
                MySqlCommand cmdGetLatestWeekNumber = new MySqlCommand();
                cmdGetLatestWeekNumber.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
                cmdGetLatestWeekNumber.CommandText = "SELECT * FROM (SELECT * FROM textcodedb.textedtextcode GROUP BY PrimaryID ORDER BY DateTo DESC) AS X WHERE ForeignKey='" + itemWeeks["PrimaryID"].ToString() + "' GROUP BY ForeignKey ORDER BY WeekNumber DESC";
                MySqlDataAdapter dataAdapterGetLatestWeekNumber = new MySqlDataAdapter();
                dataAdapterGetLatestWeekNumber.SelectCommand = cmdGetLatestWeekNumber;
                DataTable dtableGetLatestWeekNumber = new DataTable();
                dataAdapterGetLatestWeekNumber.Fill(dtableGetLatestWeekNumber);
                cmdGetLatestWeekNumber.Connection.Close();

                MySqlCommand cmdGetLatestChecker = new MySqlCommand();
                cmdGetLatestChecker.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
                cmdGetLatestChecker.CommandText = "SELECT * FROM (SELECT * FROM textcodedb.details GROUP BY PrimaryID ORDER BY DateTo DESC) AS X WHERE ForeignKey='" + itemWeeks["PrimaryID"].ToString() + "' GROUP BY ForeignKey ORDER BY PrimaryID DESC";
                MySqlDataAdapter dataAdapterGetLatestChecker = new MySqlDataAdapter();
                dataAdapterGetLatestChecker.SelectCommand = cmdGetLatestChecker;
                DataTable dtableGetLatestChecker = new DataTable();
                dataAdapterGetLatestChecker.Fill(dtableGetLatestChecker);

                List<int> FillWeeks = new List<int>(); //Fill list of the Weeks of each projects
                int GetLatestWeekInt = 0;
                string ContactNumber2 = "";
                string Designation2 = "";
                string Project = "";
                string Name = "";
                string DateLastText = "";

                //Looping and getting the weeks of each projects then fill the 'FillWeeks' List
                foreach (DataRow item in dtableGetAllWeeks.Rows)
                {
                    foreach (DataRow GetLatestWeek in dtableGetLatestWeekNumber.Rows)
                    {
                        GetLatestWeekInt = Convert.ToInt32(GetLatestWeek["WeekNumber"]);
                        DateLastText = item["DateTexted"].ToString();
                    }

                    foreach (DataRow GetLatestChecker in dtableGetLatestChecker.Rows)
                    {
                        ContactNumber2 = GetLatestChecker["ContactNumber"].ToString();
                        Designation2 = GetLatestChecker["Designation"].ToString();
                        Project = GetLatestChecker["Project"].ToString();
                        Name = GetLatestChecker["Name"].ToString();
                    }


                    if (string.IsNullOrWhiteSpace(item["WeekNumber"].ToString()) == false)
                    {
                        FillWeeks.Add(Convert.ToInt32(item["WeekNumber"]));
                    }


                }
                cmdGetAllWeeks.Connection.Close();

                //After filling the List 'FillWeeks' to this

                var result = Enumerable.Range(1, GetLatestWeekInt).Except(FillWeeks); //Setting the Range(Start of count, Comparison number).Except(Compare with 'FillWeeks' values)
                var WeekNumberMissing = string.Join(",", result); //using string.join(","-is the separator, the result or difference in the number sequence)

                if (Designation.ToString().Remove(8) != "Bodegero" && itemWeeks["ProjectStatus"].ToString() == "On-going")
                {

                    dgvMissingWeekNumbers.Rows.Add(Name, Project, Designation2, WeekNumberMissing.ToString(), GetLatestWeekInt, DateLastText, ContactNumber2); //Adding each records to the rows of DataGridView
                    if (Name == string.Empty || WeekNumberMissing == string.Empty)
                    {
                        dgvMissingWeekNumbers.Rows.RemoveAt(dgvMissingWeekNumbers.Rows.Count - 1);

                    }

                }


                //  check.Show( );

            }
            cmdProject.Connection.Close();*/
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void button2_Click(object sender, EventArgs e) {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
            {
                //DataView view = new DataView( );
                //view.RowFilter = string.Format( "Project LIKE '%{0}%'", txtSearch.Text );
                //dgvProjectOrName.DataSource = view;
                dgvProjectOrName.Focus();
                dgvProjectOrName.Rows[0].Selected = true;
                //MessageBox.Show(dgvProjectOrName.CurrentCell.OwningColumn.ToString());

                dgvWeekNumber.DataSource = null;
                dgvWeekNumber.Columns.Clear();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
                cmd.CommandText = "SELECT * FROM textcodedb.textedtextcode WHERE ForeignKey='" + dgvProjectOrName.Rows[0].Cells["PrimaryID"].Value.ToString() + "' ORDER BY DateTo DESC";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                DataTable dtable = new DataTable();
                dataAdapter.Fill(dtable);

                dgvWeekNumber.DataSource = dtable;
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dtable;
                ColumnConfigurationClass config = new ColumnConfigurationClass();
                config.WeekNumber(dgvWeekNumber);
                dgvWeekNumber.Update();

                ShowCallUpRecords callUp = new ShowCallUpRecords(dgvProjectOrName, dgvHistoryPenaltyCallup);
                callUp.ShowRecordsByProject();
            }
        }

        private void dgvProjectOrName_CellValueChanged(object sender, DataGridViewCellEventArgs e) {

        }
       
        private void dgvProjectOrName_KeyDown(object sender, KeyEventArgs e) {
            int index = dgvProjectOrName.CurrentRow.Cells["Project"].RowIndex;
            if (e.KeyCode == Keys.Up)
            {
             
                if (index < 0)
                {

                }
                else
                {
                    dgvWeekNumber.DataSource = null;
                    dgvWeekNumber.Columns.Clear();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
                    cmd.CommandText = "SELECT * FROM textcodedb.textedtextcode WHERE ForeignKey='" + dgvProjectOrName.Rows[index-1].Cells["PrimaryID"].Value.ToString() + "' ORDER BY DateTo DESC";
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                    dataAdapter.SelectCommand = cmd;
                    DataTable dtable = new DataTable();
                    dataAdapter.Fill(dtable);

                    dgvWeekNumber.DataSource = dtable;
                    BindingSource bsource = new BindingSource();
                    bsource.DataSource = dtable;
                    ColumnConfigurationClass config = new ColumnConfigurationClass();
                    config.WeekNumber(dgvWeekNumber);
                    dgvWeekNumber.Update();

                    ShowCallUpRecords callUp = new ShowCallUpRecords(dgvProjectOrName, dgvHistoryPenaltyCallup);
                    callUp.ShowRecordsByProjectUpperArrow();

                  //  ShowAssignedCheckerBodegeroUpArrow();
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                int index2 = dgvProjectOrName.CurrentCell.RowIndex + 1;
              
                if (index2 == dgvProjectOrName.Rows.Count)
                {

                }
                else
                {
                    dgvWeekNumber.DataSource = null;
                    dgvWeekNumber.Columns.Clear();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
                    cmd.CommandText = "SELECT * FROM textcodedb.textedtextcode WHERE ForeignKey='" + dgvProjectOrName.Rows[index2].Cells["PrimaryID"].Value.ToString() + "' ORDER BY DateTo DESC";
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                    dataAdapter.SelectCommand = cmd;
                    DataTable dtable = new DataTable();
                    dataAdapter.Fill(dtable);

                    dgvWeekNumber.DataSource = dtable;
                    BindingSource bsource = new BindingSource();
                    bsource.DataSource = dtable;
                    ColumnConfigurationClass config = new ColumnConfigurationClass();
                    config.WeekNumber(dgvWeekNumber);
                    dgvWeekNumber.Update();

                    ShowCallUpRecords callUp = new ShowCallUpRecords(dgvProjectOrName, dgvHistoryPenaltyCallup);
                    callUp.ShowRecordsByProjectLowerArrow();

                 //   ShowAssignedCheckerBodegeroDownArrow();
                }

            }
            if (e.KeyCode == Keys.Right)
            {
                ShowWeekNumbers show = new ShowWeekNumbers();
                show.ShowWeekNumberEntries(dgvWeekNumber, dgvProjectOrName);
              
                dgvWeekNumber.Focus();
               
            }
        }
        
        private void ShowAssignedCheckerBodegeroDownArrow (){
            dgvCheckerBodegeroAssigned.DataSource = null;
            dgvCheckerBodegeroAssigned.Columns.Clear( );

           int index = Convert.ToInt32(dgvProjectOrName.CurrentRow.Cells["PrimaryID"].Value.ToString())-1;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection( );
            cmd.CommandText = "SELECT PrimaryID,ForeignKey,Project,Name,Designation,ContactNumber,WeekNumber,DateTexted,DateFrom,DateTo,TextCodeOrHardCopy,Remarks,Picture FROM textcodedb.details WHERE ForeignKey='"+ index + " ' ORDER BY DateTo DESC";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DataTable dtable = new DataTable();
            dataAdapter.Fill( dtable );

            dgvCheckerBodegeroAssigned.DataSource = dtable;
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dtable;
            ColumnConfigurationClass config = new ColumnConfigurationClass();
            config.CheckerBodegeroAssigned( dgvCheckerBodegeroAssigned );
            config.CheckerBodegeroAssignedColumnSizes( dgvCheckerBodegeroAssigned );
            dgvCheckerBodegeroAssigned.Update( );
        }

        private void ShowAssignedCheckerBodegeroUpArrow() {
            dgvCheckerBodegeroAssigned.DataSource = null;
            dgvCheckerBodegeroAssigned.Columns.Clear();

            int index = Convert.ToInt32(dgvProjectOrName.CurrentRow.Cells["PrimaryID"].Value.ToString()) - 1;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
            cmd.CommandText = "SELECT PrimaryID,ForeignKey,Project,Name,Designation,ContactNumber,WeekNumber,DateTexted,DateFrom,DateTo,TextCodeOrHardCopy,Remarks,Picture FROM textcodedb.details WHERE ForeignKey='" + index + " ' ORDER BY DateTo DESC";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DataTable dtable = new DataTable();
            dataAdapter.Fill(dtable);

            dgvCheckerBodegeroAssigned.DataSource = dtable;
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dtable;
            ColumnConfigurationClass config = new ColumnConfigurationClass();
            config.CheckerBodegeroAssigned(dgvCheckerBodegeroAssigned);
            config.CheckerBodegeroAssignedColumnSizes(dgvCheckerBodegeroAssigned);
            dgvCheckerBodegeroAssigned.Update();
        }

        private void dgvCheckerBodegeroAssigned_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            //   dgvCheckerBodegeroAssigned.Focus( );

        }

        private void dgvCheckerBodegeroAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            
        }

        private void dgvCheckerBodegeroAccounts_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            EditUpdateClass edit = new EditUpdateClass();
            edit.EditCheckerBodegeroAccounts(dgvCheckerBodegeroAccounts);

            dgvCheckerBodegeroAccounts.ReadOnly = true;
        }

        private void dgvCheckerBodegeroAssigned_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            EditUpdateClass edit = new EditUpdateClass();
            edit.EditCheckerBodegeroAssigned(dgvCheckerBodegeroAssigned);
            dgvCheckerBodegeroAssigned.ReadOnly = true;
        }

        private void dgvProjectOrName_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            EditUpdateClass edit = new EditUpdateClass();
            edit.EditProjectOrName(dgvProjectOrName);

            dgvProjectOrName.ReadOnly = true;
        }

        private void editPictureToolStripMenuItem_Click(object sender, EventArgs e) {
            TextCodeMainFormClasses.SelectImage select = new TextCodeMainFormClasses.SelectImage();
            select.SelectAnImage(pictureBoxCheckerBodegero, GetPicPath);

            EditUpdateClass edit = new EditUpdateClass();
            edit.ChangePicure(dgvCheckerBodegeroAccounts);
        }

        private void btnEditWeek_Click(object sender, EventArgs e) {
            EditUpdateClass edit = new EditUpdateClass();
            edit.EditWeekEntry(txtWeekNumberWeekly, dtpDateTextdWeekly, MtxtDateFromWeekly, MtxtDateToWeekly, txtRemarksWeekly, dgvWeekNumber);
        }

        private void onGoingToolStripMenuItem_Click(object sender, EventArgs e) {
            EditUpdateClass edit = new EditUpdateClass();
            edit.EditProjectStatusOngoing(onGoingToolStripMenuItem, dgvProjectOrName);

            ViewFinishedProjectsClass view = new ViewFinishedProjectsClass();
            view.ViewFinishedProjects(dgvProjectOrName);
            ContextMenuStripOnGoingFinished.Close();
        }

        private void finishedToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void vIEWToolStripMenuItem_Click(object sender, EventArgs e) {
            ViewFinishedProjectsClass view = new ViewFinishedProjectsClass();
            view.ViewFinishedProjects(dgvProjectOrName);
        }

        private void vIEWToolStripMenuItem1_Click(object sender, EventArgs e) {
            LoadRecordsClasses load = new LoadRecordsClasses();
            load.Project(dgvProjectOrName);
        }

        private void dgvProjectOrName_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {

        }

        private void dgvProjectOrName_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button == MouseButtons.Right)
            {
                dgvProjectOrName.CurrentCell = dgvProjectOrName.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvProjectOrName.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvCheckerBodegeroAccounts_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button == MouseButtons.Right)
            {
                dgvCheckerBodegeroAccounts.CurrentCell = dgvCheckerBodegeroAccounts.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvCheckerBodegeroAccounts.Rows[e.RowIndex].Selected = true;

                txtNameNewEntry.Text = dgvCheckerBodegeroAccounts.CurrentRow.Cells["Name"].Value.ToString();
                txtDesignationNewEntry.Text = dgvCheckerBodegeroAccounts.CurrentRow.Cells["Designation"].Value.ToString();
                txtContactNmber.Text = dgvCheckerBodegeroAccounts.CurrentRow.Cells["ContactNumber"].Value.ToString();
                GetImageAccounts();
            }
        }

        private void statusToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show(dgvProjectOrName.CurrentRow.Cells["Project"].Value.ToString() + " - " + dgvProjectOrName.CurrentRow.Cells["ProjectStatus"].Value.ToString());
        }

        private void dgvCheckerBodegeroAssigned_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button == MouseButtons.Right)
            {
                dgvCheckerBodegeroAssigned.CurrentCell = dgvCheckerBodegeroAssigned.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvCheckerBodegeroAssigned.Rows[e.RowIndex].Selected = true;

                txtProject.Text = dgvCheckerBodegeroAssigned.CurrentRow.Cells["Project"].Value.ToString();
                dtpDateTexted.Text = dgvCheckerBodegeroAssigned.CurrentRow.Cells["DateTexted"].Value.ToString();
                txtNameNewEntry.Text = dgvCheckerBodegeroAssigned.CurrentRow.Cells["Name"].Value.ToString();
                txtDesignationNewEntry.Text = dgvCheckerBodegeroAssigned.CurrentRow.Cells["Designation"].Value.ToString();
                txtRemarks.Text = dgvCheckerBodegeroAssigned.CurrentRow.Cells["Remarks"].Value.ToString();
                GetImageAssigned();
                txtWeekNumber.Text = dgvCheckerBodegeroAssigned.CurrentRow.Cells["WeekNumber"].Value.ToString();
                MtxtDateFrom.Text = dgvCheckerBodegeroAssigned.CurrentRow.Cells["DateFrom"].Value.ToString();
                MtxtDateTo.Text = dgvCheckerBodegeroAssigned.CurrentRow.Cells["DateTo"].Value.ToString();
                txtContactNmber.Text = dgvCheckerBodegeroAssigned.CurrentRow.Cells["ContactNumber"].Value.ToString();
            }
        }

        private void editPictureToolStripMenuItem2_Click(object sender, EventArgs e) {
            TextCodeMainFormClasses.SelectImage select = new TextCodeMainFormClasses.SelectImage();
            select.SelectAnImage(pictureBoxCheckerBodegero, GetPicPath);

            EditUpdateClass edit = new EditUpdateClass();
            edit.ChangePicure2(dgvCheckerBodegeroAssigned);
        }

        private void finishedToolStripMenuItem_DoubleClick(object sender, EventArgs e) {

        }

        private void finishedToolStripMenuItem_Click_1(object sender, EventArgs e) {
            EditUpdateClass edit = new EditUpdateClass();
            edit.EditProjectStatusFinished(finishedToolStripMenuItem, dgvProjectOrName);

            LoadRecordsClasses load = new LoadRecordsClasses();
            load.Project(dgvProjectOrName);
            ContextMenuStripOnGoingFinished.Close();
        }

        private void dgvCheckerBodegeroAccounts_AllowUserToDeleteRowsChanged(object sender, EventArgs e) {
            DeleteClass Delete = new DeleteClass(dgvCheckerBodegeroAccounts);
            Delete.DeleteCheckerBodegeroAccount();
        }

        private void txtNameNewEntry_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
                cmd.CommandText = "SELECT Name,Designation,ContactNumber,Picture FROM textcodedb.checkerbodegeroaccounts WHERE Name='" + txtNameNewEntry.Text + "'";
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();

                int count = 0;
                while (reader.Read())
                {
                    count++;
                }
                if (count == 1)
                {
                    txtDesignationNewEntry.Text = reader.GetString("Designation");
                    txtContactNmber.Text = reader.GetString("ContactNumber");
                    GetImageAssignedAutoCompleteName();
                }
                cmd.Connection.Close();
            }

        }

        private void dgvHistoryPenaltyCallup_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void txtNameNewEntry_TextChanged(object sender, EventArgs e) {

        }

        private void txtNameNewEntry_Validated(object sender, EventArgs e) {

        }

        private void button2_MouseHover(object sender, EventArgs e) {

        }

        private void dgvProjectOrName_MouseHover(object sender, EventArgs e) {

        }

        private void dgvHistoryPenaltyCallup_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            EditUpdateClass edit = new EditUpdateClass();
            edit.CallUpRecordsEdit(dgvHistoryPenaltyCallup);
        }

        private void printDocumentWeeklyTextMonitoring_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
            //Margins margin = new Margins( 100, 100, 100, 100 );
            //printDocumentWeeklyTextMonitoring.DefaultPageSettings.Margins = margin;
            e.Graphics.DrawString("ENGINEERING  &  CONSTRUCTION DEPARTMENT", new Font("Cambria", 14), new SolidBrush(Color.Black), new RectangleF(200, 50, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height));
            e.Graphics.DrawString("OPERATION SECTION", new Font("Cambria", 12), new SolidBrush(Color.Black), new RectangleF(320, 85, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height));
            e.Graphics.DrawString("TEXT CODE CALL-UP", new Font("Cambria", 12, FontStyle.Bold), new SolidBrush(Color.Black), new RectangleF(320, 120, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height));
            e.Graphics.DrawString("TO :   " + dgvWeeklyTextMonitoring.CurrentRow.Cells["Name"].Value.ToString(), new Font("Cambria", 11), new SolidBrush(Color.Black), new RectangleF(105, 180, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height));
            e.Graphics.DrawString("DATE :     " + DateTime.Now.ToString(" MMMM  d, yyyy "), new Font("Cambria", 11), new SolidBrush(Color.Black), new RectangleF(550, 180, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height));
            e.Graphics.DrawString("PROJECT :  " + dgvWeeklyTextMonitoring.CurrentRow.Cells["Project"].Value.ToString(), new Font("Cambria", 11), new SolidBrush(Color.Black), new RectangleF(65, 200, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height));
            e.Graphics.DrawString("Tinatawagan ka ng pansin sa hindi mo pagtugon sa                      Text Code.", new Font("Cambria", 11), new SolidBrush(Color.Black), new RectangleF(65, 260, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height));
            e.Graphics.DrawString( "WEEKLY" , new Font( "Cambria" , 11,FontStyle.Bold ) , new SolidBrush( Color.Black ) , new RectangleF( 405 , 260 , printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width , printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height ) );

            int WeekFrom = 0;
            int WeekTo = 0;

            if (dgvWeeklyTextMonitoring.CurrentRow.Cells["LastWeekTexted"].Value.ToString().Contains("Hard Copy"))
            {
                WeekFrom = Convert.ToInt32(dgvWeeklyTextMonitoring.CurrentRow.Cells["LastWeekTexted"].Value.ToString().Remove(1));
                WeekTo = Convert.ToInt32(dgvWeeklyTextMonitoring.CurrentRow.Cells["NumWeeks"].Value.ToString());
            }
            else
            {
                WeekFrom = Convert.ToInt32(dgvWeeklyTextMonitoring.CurrentRow.Cells["LastWeekTexted"].Value.ToString()) + 1;
                WeekTo = Convert.ToInt32(dgvWeeklyTextMonitoring.CurrentRow.Cells["NumWeeks"].Value.ToString()) + Convert.ToInt32(dgvWeeklyTextMonitoring.CurrentRow.Cells["LastWeekTexted"].Value.ToString());
            }

            int WeekCount = Convert.ToInt32(dgvWeeklyTextMonitoring.CurrentRow.Cells["NumWeeks"].Value.ToString());
            if (WeekCount == 1)
            {
                e.Graphics.DrawString("WEEKS :  " + WeekTo + "  " + "(" + dgvWeeklyTextMonitoring.CurrentRow.Cells["NumWeeks"].Value.ToString() + " week" + ")", new Font("Cambria", 11, FontStyle.Bold), new SolidBrush(Color.Black), new RectangleF(65, 280, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height));
            }
            else
            {
                e.Graphics.DrawString("WEEKS :  " + WeekFrom + "-" + WeekTo + "  " + "(" + dgvWeeklyTextMonitoring.CurrentRow.Cells["NumWeeks"].Value.ToString() + " weeks" + ")", new Font("Cambria", 11, FontStyle.Bold), new SolidBrush(Color.Black), new RectangleF(65, 280, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height));
            }

            e.Graphics.DrawString("Nota :  ", new Font("Cambria", 11, FontStyle.Bold), new SolidBrush(Color.Black), new RectangleF(65, 325, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height));
            e.Graphics.DrawString("I-text kaagad ang Text Code, kung walang signal sa Project ay sa pagluwas sa Distrito o Lokal magtext.", new Font("Cambria", 11), new SolidBrush(Color.Black), new RectangleF(110, 325, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height));
            e.Graphics.DrawString("TEXT CODE  # :  09179814621", new Font("Cambria", 11, FontStyle.Bold), new SolidBrush(Color.Black), new RectangleF(65, 345, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height));

            e.Graphics.DrawString("Prepared by  : PETER JOHN R. HUGO", new Font("Cambria", 11), new SolidBrush(Color.Black), new RectangleF(65, 420, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height));
            e.Graphics.DrawString("Noted by  : JESSIE T. SAGUIGUIT", new Font("Cambria", 11), new SolidBrush(Color.Black), new RectangleF(430, 420, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Width, printDocumentWeeklyTextMonitoring.DefaultPageSettings.PrintableArea.Height));

        }

        private void printPreviewDialogWeeklyTextcodeMonitoring_Load(object sender, EventArgs e) {

        }

        private void previewToolStripMenuItem_Click(object sender, EventArgs e) {
            printPreviewDialogWeeklyTextcodeMonitoring.Document = printDocumentWeeklyTextMonitoring;
            string PrintName = "Text Code Call-up";
            printDocumentWeeklyTextMonitoring.DocumentName = PrintName;
            ToolStripButton b = new ToolStripButton();
            b.Image = Properties.Resources.emblem_print_png128;
            b.DisplayStyle = ToolStripItemDisplayStyle.Image;
            b.Click += B_Click;
            ((ToolStrip)(printPreviewDialogWeeklyTextcodeMonitoring.Controls[1])).Items.RemoveAt(0);
            ((ToolStrip)(printPreviewDialogWeeklyTextcodeMonitoring.Controls[1])).Items.Insert(0, b);
            b.ToolTipText = "Print Call-up";
            printPreviewDialogWeeklyTextcodeMonitoring.ShowDialog();


        }

        private void B_Click(object sender, EventArgs e) {
            string PrintName = "Text Code Call-up";
            printDocumentWeeklyTextMonitoring.DocumentName = PrintName;
            printDocumentWeeklyTextMonitoring.Print();
            printDocumentWeeklyTextMonitoring.EndPrint += PrintDocumentWeeklyTextMonitoring_EndPrint1;
        }

        private void PrintDocumentWeeklyTextMonitoring_EndPrint1(object sender, System.Drawing.Printing.PrintEventArgs e) {
            GenerateCallUp callup = new GenerateCallUp();
            callup.InsertPenaltyRecord(dgvWeeklyTextMonitoring);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e) {
            PrintDialog Dialog = new PrintDialog();
            Dialog.Document = printDocumentWeeklyTextMonitoring;
            Dialog.UseEXDialog = true;

            //if( DialogResult.OK == Dialog.ShowDialog( ) )
            //{
            string PrintName = "Text Code Call-up";
            printDocumentWeeklyTextMonitoring.DocumentName = PrintName;
            printDocumentWeeklyTextMonitoring.Print();

            /* Insert call-up to penalty record */
            GenerateCallUp callup = new GenerateCallUp();
            callup.InsertPenaltyRecord(dgvWeeklyTextMonitoring);
            //}
        }

        private void printPreviewDialogWeeklyTextcodeMonitoring_Click(object sender, EventArgs e) {

        }

        private void dgvWeeklyTextMonitoring_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button == MouseButtons.Right)
            {
                dgvWeeklyTextMonitoring.CurrentCell = dgvWeeklyTextMonitoring.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvWeeklyTextMonitoring.Rows[e.RowIndex].Selected = true;
            }
        }

        private void viewCallupRecordToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowCallUpRecords show = new ShowCallUpRecords(dgvWeeklyTextMonitoring);
            show.ShowRecordsByProjectAndChecker();
        }

        private void previewToolStripMenuItem_Click_1(object sender, EventArgs e) {
            printPreviewDialogWeeklyTextcodeMonitoring.Document = printDocumentWeeklyTextMonitoring;
            string PrintName = "Text Code Call-up";
            printDocumentWeeklyTextMonitoring.DocumentName = PrintName;
            ToolStripButton b = new ToolStripButton();
            b.Image = Properties.Resources.emblem_print_png128;
            b.DisplayStyle = ToolStripItemDisplayStyle.Image;
            b.Click += B_Click;
            ((ToolStrip)(printPreviewDialogWeeklyTextcodeMonitoring.Controls[1])).Items.RemoveAt(0);
            ((ToolStrip)(printPreviewDialogWeeklyTextcodeMonitoring.Controls[1])).Items.Insert(0, b);
            b.ToolTipText = "Print Call-up";
            printPreviewDialogWeeklyTextcodeMonitoring.ShowDialog();

            //printPreviewDialogCallUpCoverLetter.Document = printDocumentCallUpCoverLetter;
            //printPreviewDialogCallUpCoverLetter.ShowDialog();
        }


        private void printToolStripMenuItem_Click_1(object sender, EventArgs e) {
            try
            {
                /* Prints the call-up */
                PrintDialog Dialog = new PrintDialog();
                Dialog.Document = printDocumentWeeklyTextMonitoring;
                Dialog.UseEXDialog = true;

                string PrintName = "Text Code Call-up";
                printDocumentWeeklyTextMonitoring.DocumentName = PrintName;
                printDocumentWeeklyTextMonitoring.Print();
                /* Ends here 

                /* Insert call-up to penalty record in database
                     Nothing to do with the print report design*/
                GenerateCallUp callup = new GenerateCallUp();
                callup.InsertPenaltyRecord(dgvWeeklyTextMonitoring);
                /*Ends here

                /* Print the cover letter */
                PrintDialog DialogCoverLetter = new PrintDialog();
                DialogCoverLetter.Document = printDocumentCallUpCoverLetter;
                DialogCoverLetter.UseEXDialog = true;

                string PrintCoverLetterName = "Call-up Cover letter";
                printDocumentCallUpCoverLetter.DocumentName = PrintCoverLetterName;
                printDocumentCallUpCoverLetter.Print();
                /* End here */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgvWeeklyTextMonitoring_CellClick(object sender, DataGridViewCellEventArgs e) {
            ShowCallUpRecords callUp = new ShowCallUpRecords(dgvWeeklyTextMonitoring, dgvHistoryPenaltyCallup);
            callUp.ShowRecordsByProject();
        }

        private void dgvWeeklyTextMonitoring_CellMouseDown_1(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button == MouseButtons.Right)
            {
                dgvWeeklyTextMonitoring.CurrentCell = dgvWeeklyTextMonitoring.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvWeeklyTextMonitoring.Rows[e.RowIndex].Selected = true;
            }
        }
        public int GetMaxPrimaryKeyNumber() {
            /*This is to Get the Max count of Primary Key in the database for placing of numbers*/
            MySqlCommand cmdGetTowCount = new MySqlCommand();
            cmdGetTowCount.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
            cmdGetTowCount.CommandText = "SELECT MAX(PrimaryID) FROM textcodedb.projects";
            MySqlDataReader readerGetRowCount = cmdGetTowCount.ExecuteReader();

            int getRowCount = 0;
            while (readerGetRowCount.Read())
            {

            }
            getRowCount = Convert.ToInt32(readerGetRowCount.GetString(0));
            int GetPrimaryID = 0;
            GetPrimaryID = getRowCount;
            return GetPrimaryID;
            /**/
        }

        private void button1_Click_1(object sender, EventArgs e) {
            dgvWeeklyTextMonitoring.Columns.Clear();
            dT.Clear();
            GettingTheTextedTextcodeMonitoringRecords();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
            try
            {
                DialogResult YesNo = MessageBox.Show("Are you sure you want to delete Project : " + dgvProjectOrName.CurrentRow.Cells["Project"].Value.ToString().ToUpper() + "? All instances of records will also be deleted.", "Delete Project?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (YesNo == DialogResult.Yes)
                {

                    cmd.CommandText = "DELETE FROM textcodedb.details WHERE ForeignKey ='" + dgvProjectOrName.CurrentRow.Cells["PrimaryID"].Value.ToString() + "'";//Delete Detailed entry of project/Checker/Bodegero Assigned
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "DELETE FROM textcodedb.textedtextcode WHERE ForeignKey ='" + dgvProjectOrName.CurrentRow.Cells["PrimaryID"].Value.ToString() + "'";//Delete textcode entries
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "DELETE FROM textcodedb.calluppenalty WHERE Project ='" + dgvProjectOrName.CurrentRow.Cells["Project"].Value.ToString() + "'";//Delete Penalties/Call-ups
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "DELETE FROM textcodedb.projects WHERE PrimaryID ='" + dgvProjectOrName.CurrentRow.Cells["PrimaryID"].Value.ToString() + "'";//Delete Project
                    cmd.ExecuteNonQuery();

                    RefreshClear();//Reload records on datagridviews and clear/reset values of input records
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        DataTable dT = new DataTable();
        DataTable dTMissingWeeks = new DataTable();
        public delegate void TxtTesting(string text);
        public delegate void ProgressBarSearch(int intProgress);
        public delegate void txtSearchPercentageLoad(string text);

        private void GettingTheTextedTextcodeMonitoringRecords() {
            double dateCount = 0;
            string match = "";
            double CountDate = 0;
            string ContactNumber = "";
            string Week = "";
            string Designation = "";
            int countLoop = 0;
            string MatchID = "";

          //  this.Invoke(new TxtTesting(TxtSearch), new object[] { txtSearchWeeklyMonitoring.Text });

            if (dT.Columns.Count != 8)//This is to check if the count of columns are not equal zero, if true add the columns below to datatable dT
            {
                dT.Columns.Add("Name");
                dT.Columns.Add("Project");
                dT.Columns.Add("Designation");
                dT.Columns.Add("PrevDcov");
                dT.Columns.Add("LastWeekTexted");
                dT.Columns.Add("NumWeeks");
                dT.Columns.Add("DateLastTxt");
                dT.Columns.Add("ContactNumber");
            }

            /* Get the projects */
            MySqlCommand cmdProject2 = new MySqlCommand();
            cmdProject2.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
            cmdProject2.CommandText = "SELECT * FROM textcodedb.projects ORDER BY PrimaryID ASC";
            MySqlDataAdapter dataAdapterProject2 = new MySqlDataAdapter();
            dataAdapterProject2.SelectCommand = cmdProject2;
            DataTable dtableProject2 = new DataTable();
            dataAdapterProject2.Fill(dtableProject2);

            /* Iterate each Projects*/
            foreach (DataRow itemProject2 in dtableProject2.Rows)
            {
                /* Getting the latest Checker assigned */
                MatchID = itemProject2["PrimaryID"].ToString();

                MySqlCommand cmdGetLatestChecker = new MySqlCommand();
                cmdGetLatestChecker.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
                cmdGetLatestChecker.CommandText = "SELECT * FROM (SELECT * FROM textcodedb.textedtextcode  GROUP BY PrimaryID ORDER BY DateTo DESC) AS X WHERE ForeignKey='" + itemProject2["PrimaryID"].ToString() + "' GROUP BY ForeignKey ORDER BY DateTo DESC";
                MySqlDataAdapter dataAdapterGetLatestChecker = new MySqlDataAdapter();
                dataAdapterGetLatestChecker.SelectCommand = cmdGetLatestChecker;
                DataTable dtableGetLatestChecker = new DataTable();
                dataAdapterGetLatestChecker.Fill(dtableGetLatestChecker);


                foreach (DataRow itemGetLatestChecker in dtableGetLatestChecker.Rows)
                {

                    Week = itemGetLatestChecker["WeekNumber"].ToString();
                    DateTime dt = Convert.ToDateTime(itemGetLatestChecker["DateTo"].ToString());

                    /* Getting the Contact Number,and Designation of the latest Checker Assigned */
                    MySqlCommand cmdGetLatestChecker2 = new MySqlCommand();
                    cmdGetLatestChecker2.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
                    cmdGetLatestChecker2.CommandText = "SELECT * FROM (SELECT * FROM textcodedb.details GROUP BY PrimaryID ORDER BY DateTo DESC) AS X WHERE Name='" + itemProject2["Name"].ToString() + "' GROUP BY ForeignKey ORDER BY DateTo DESC";
                    MySqlDataAdapter dataAdapterGetLatestChecker2 = new MySqlDataAdapter();
                    dataAdapterGetLatestChecker2.SelectCommand = cmdGetLatestChecker2;
                    DataTable dtableGetLatestChecker2 = new DataTable();
                    dataAdapterGetLatestChecker2.Fill(dtableGetLatestChecker2);

                    foreach (DataRow itemGetLatestChecker2 in dtableGetLatestChecker2.Rows)
                    {
                        /* Assigning the Contact Number and Designation of the Latest Checker Assigned */
                        ContactNumber = itemGetLatestChecker2["ContactNumber"].ToString();
                        Designation = itemGetLatestChecker2["Designation"].ToString();

                    }

                    dateCount = Convert.ToDouble(DateTime.Now.Date.Subtract(dt).TotalDays / 7);

                    /* Condition checking if days since last text DateTo is 7 or Greater and if Designation is Checker */
                    if (dateCount >= 1 /*&& Designation.ToString().Remove(8) != "Bodegero"*/ && itemProject2["ProjectStatus"].ToString() == "On-going")
                    {
                        /* Concatenating and Placing the records to datagridview */
                        DataRow row = dT.NewRow();
                        row["Name"] = itemGetLatestChecker["Name"];
                        row["Project"] = itemProject2["Project"];
                        row["Designation"] = Designation;
                        row["PrevDcov"] = itemGetLatestChecker["DateFrom"] + " - " + itemGetLatestChecker["DateTo"];
                        row["LastWeekTexted"] = itemGetLatestChecker["WeekNumber"];
                        row["NumWeeks"] = dateCount.ToString("#.0").Remove(1);
                        row["DateLastTxt"] = itemGetLatestChecker["DateTexted"];
                        row["ContactNumber"] = ContactNumber;
                        dT.Rows.Add(row);

                        DataTable dtable = new DataTable();

                    }

                    cmdGetLatestChecker2.Connection.Close();

                    match = itemGetLatestChecker["ForeignKey"].ToString();
                    CountDate = dateCount;

                }
                cmdGetLatestChecker.Connection.Close();
                /*Checking the WeekNumbers*/
                MySqlCommand cmdGetMatch = new MySqlCommand();
                cmdGetMatch.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
                cmdGetMatch.CommandText = "SELECT * FROM textcodedb.textedtextcode WHERE ForeignKey='" + itemProject2["PrimaryID"].ToString() + "' GROUP BY ForeignKey ORDER BY DateTo DESC";
                MySqlDataReader reader = cmdGetMatch.ExecuteReader();

                int count = 0;
                while (reader.Read())
                {
                    count++;
                }
                if (count == 0)
                {

                    /* Condition to check if the latest Checkers Foreignkey doesnt match any Project and the Designation is Checker */
                    /* Placing the records of Hard copy only, not yet texted any text code week */
                    if (itemProject2["PrimaryID"].ToString() != match /*&& Designation.ToString().Remove(8) != "Bodegero"*/)
                    {

                        MySqlCommand cmdGetDetails = new MySqlCommand();
                        cmdGetDetails.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
                        cmdGetDetails.CommandText = "SELECT * FROM(SELECT * FROM textcodedb.details GROUP BY PrimaryID ORDER BY DateTo ASC) AS X WHERE ForeignKey='" + itemProject2["PrimaryID"].ToString() + "' GROUP BY ForeignKey ORDER BY DateTo DESC";
                        MySqlDataAdapter dataAdapterGetDetails = new MySqlDataAdapter();
                        dataAdapterGetDetails.SelectCommand = cmdGetDetails;
                        DataTable dtableGetDetails = new DataTable();
                        dataAdapterGetDetails.Fill(dtableGetDetails);
                        foreach (DataRow item in dtableGetDetails.Rows)
                        {

                            DateTime dt = Convert.ToDateTime(item["DateFrom"].ToString());
                            double dateCountdetails = Convert.ToDouble(DateTime.Now.Date.Subtract(dt).TotalDays / 7);
                            if (dateCountdetails.ToString("#.0").Remove(1) != "." /*&& item["Designation"].ToString().Remove(8) != "Bodegero"*/)
                            {
                                double CountWeeks = 0;
                                int IndexOfDotCharacter = 0;

                                if (dateCountdetails.ToString("#.0").Contains("."))
                                {
                                    IndexOfDotCharacter = Convert.ToInt32(dateCountdetails.ToString("#.0").IndexOf('.').ToString());
                                    CountWeeks = Convert.ToDouble(dateCountdetails.ToString("#.0").Remove((IndexOfDotCharacter)));
                                }
                                else
                                {
                                    CountWeeks = Convert.ToDouble(dateCountdetails.ToString("#.0"));
                                }
                                /*concatenating the values and placing it in datagridview*/

                                //DataRow row2 = dT.NewRow( );
                                //row2[ "Name" ] = item[ "Name" ];
                                //row2[ "Project" ] = item[ "Project" ];
                                //row2[ "Designation" ] = item[ "Designation" ];
                                //row2[ "PrevDcov" ] = item[ "DateFrom" ] + " - " + item[ "DateTo" ];
                                //row2[ "LastWeekTexted" ] = item[ "WeekNumber" ] + " - Hard Copy";
                                //row2[ "NumWeeks" ] = CountWeeks;
                                //row2[ "DateLastTxt" ] = item[ "DateTexted" ];
                                //row2[ "ContactNumber" ] = item[ "ContactNumber" ];
                                //dT.Rows.Add( row2 );
                                dT.Rows.Add(item["Name"], item["Project"], item["Designation"], item["DateFrom"] + " - " + item["DateTo"], item["WeekNumber"] + " - Hard Copy", CountWeeks, item["DateTexted"], item["ContactNumber"]);

                            }

                        }
                        cmdGetDetails.Connection.Close();
                    }
                }
                cmdGetMatch.Connection.Close();
                countLoop++;
            }
            cmdProject2.Connection.Close();

            //-----------------------------------------------       
            //This is to Find Missng Week Numbers
            //Creating Columns of dataGridView11
          //  int countLoopMissingWeeks = 0;

            //if (dTMissingWeeks.Columns.Count != 7)//This is to check if the count of columns are not equal zero, if true add the columns below to datatable dT
            //{
            //    dTMissingWeeks.Columns.Add("Name");
            //    dTMissingWeeks.Columns.Add("Project");
            //    dTMissingWeeks.Columns.Add("Designation");
            //    dTMissingWeeks.Columns.Add("Weeknumbers");
            //    dTMissingWeeks.Columns.Add("LastWeekTexted");
            //    dTMissingWeeks.Columns.Add("DateLastTexted");
            //    dTMissingWeeks.Columns.Add("ContactNumber");
            //}


            ////Getting the PrimaryID of All Projects
            //MySqlCommand cmdProject = new MySqlCommand();
            //cmdProject.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
            //cmdProject.CommandText = "SELECT * FROM  textcodedb.projects  ORDER BY PrimaryID ASC";

            //MySqlDataAdapter dataAdapterProject = new MySqlDataAdapter();
            //dataAdapterProject.SelectCommand = cmdProject;
            //DataTable dtableProject = new DataTable();
            //dataAdapterProject.Fill(dtableProject);

            ////Iterating each projects and getting their texted Week Number reports
            //foreach (DataRow itemWeeks in dtableProject.Rows)
            //{
            //    //Getting the Weeks and GROUP BY their ForeignKey of each Projects
            //    MySqlCommand cmdGetWeeks = new MySqlCommand();
            //    cmdGetWeeks.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
            //    cmdGetWeeks.CommandText = "SELECT * FROM  textcodedb.textedtextcode WHERE ForeignKey='" + itemWeeks["PrimaryID"].ToString() + "' GROUP BY ForeignKey";
            //    MySqlDataAdapter dataAdapterGetWeeks = new MySqlDataAdapter();
            //    dataAdapterGetWeeks.SelectCommand = cmdGetWeeks;
            //    DataTable dtableGetWeeks = new DataTable();
            //    dataAdapterGetWeeks.Fill(dtableGetWeeks);
            //    cmdGetWeeks.Connection.Close();

            //    //This is to Get all the weeks of each projects
            //    MySqlCommand cmdGetAllWeeks = new MySqlCommand();
            //    cmdGetAllWeeks.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
            //    cmdGetAllWeeks.CommandText = "SELECT * FROM  textcodedb.textedtextcode WHERE ForeignKey='" + itemWeeks["PrimaryID"].ToString() + "' ";
            //    MySqlDataAdapter dataAdapterGetAllWeeks = new MySqlDataAdapter();
            //    dataAdapterGetAllWeeks.SelectCommand = cmdGetAllWeeks;
            //    DataTable dtableGetAllWeeks = new DataTable();
            //    dataAdapterGetAllWeeks.Fill(dtableGetAllWeeks);


            //    //This is to get the latest week number of each projects Text code
            //    MySqlCommand cmdGetLatestWeekNumber = new MySqlCommand();
            //    cmdGetLatestWeekNumber.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
            //    cmdGetLatestWeekNumber.CommandText = "SELECT * FROM (SELECT * FROM textcodedb.textedtextcode GROUP BY PrimaryID ORDER BY DateTo DESC) AS X WHERE ForeignKey='" + itemWeeks["PrimaryID"].ToString() + "' GROUP BY ForeignKey ORDER BY WeekNumber DESC";
            //    MySqlDataAdapter dataAdapterGetLatestWeekNumber = new MySqlDataAdapter();
            //    dataAdapterGetLatestWeekNumber.SelectCommand = cmdGetLatestWeekNumber;
            //    DataTable dtableGetLatestWeekNumber = new DataTable();
            //    dataAdapterGetLatestWeekNumber.Fill(dtableGetLatestWeekNumber);
            //    cmdGetLatestWeekNumber.Connection.Close();

            //    MySqlCommand cmdGetLatestChecker = new MySqlCommand();
            //    cmdGetLatestChecker.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
            //    cmdGetLatestChecker.CommandText = "SELECT * FROM (SELECT * FROM textcodedb.details GROUP BY PrimaryID ORDER BY DateTo DESC) AS X WHERE ForeignKey='" + itemWeeks["PrimaryID"].ToString() + "' GROUP BY ForeignKey ORDER BY PrimaryID DESC";
            //    MySqlDataAdapter dataAdapterGetLatestChecker = new MySqlDataAdapter();
            //    dataAdapterGetLatestChecker.SelectCommand = cmdGetLatestChecker;
            //    DataTable dtableGetLatestChecker = new DataTable();
            //    dataAdapterGetLatestChecker.Fill(dtableGetLatestChecker);

            //    List<int> FillWeeks = new List<int>(); //Fill list of the Weeks of each projects
            //    int GetLatestWeekInt = 0;
            //    string ContactNumber2 = "";
            //    string Designation2 = "";
            //    string Project = "";
            //    string Name = "";
            //    string DateLastText = "";

            //    //Looping and getting the weeks of each projects then fill the 'FillWeeks' List
            //    foreach (DataRow item in dtableGetAllWeeks.Rows)
            //    {
            //        foreach (DataRow GetLatestWeek in dtableGetLatestWeekNumber.Rows)
            //        {
            //            GetLatestWeekInt = Convert.ToInt32(GetLatestWeek["WeekNumber"]);
            //            DateLastText = item["DateTexted"].ToString();
            //        }

            //        foreach (DataRow GetLatestChecker in dtableGetLatestChecker.Rows)
            //        {
            //            ContactNumber2 = GetLatestChecker["ContactNumber"].ToString();
            //            Designation2 = GetLatestChecker["Designation"].ToString();
            //            Project = GetLatestChecker["Project"].ToString();
            //            Name = GetLatestChecker["Name"].ToString();
            //        }


            //        if (string.IsNullOrWhiteSpace(item["WeekNumber"].ToString()) == false)
            //        {
            //            FillWeeks.Add(Convert.ToInt32(item["WeekNumber"]));
            //        }


            //    }
            //    cmdGetAllWeeks.Connection.Close();

            //    //After filling the List 'FillWeeks' to this

            //    var result = Enumerable.Range(1, GetLatestWeekInt).Except(FillWeeks); //Setting the Range(Start of count, Comparison number).Except(Compare with 'FillWeeks' values)
            //    var WeekNumberMissing = string.Join(",", result); //using string.join(","-is the separator, the result or difference in the number sequence)

            //    if (Designation.ToString().Remove(8) != "Bodegero" && itemWeeks["ProjectStatus"].ToString() == "On-going")
            //    {
            //        //Adding each records to the rows of datatable
            //        //DataRow row2 = dTMissingWeeks.NewRow( );
            //        //row2[ "Name" ] = Name;
            //        //row2[ "Project" ] = Project;
            //        //row2[ "Designation" ] = Designation2;
            //        //row2[ "Weeknumbers" ] = WeekNumberMissing.ToString( );
            //        //row2[ "LastWeekTexted" ] = GetLatestWeekInt;
            //        //row2[ "DateLastTexted" ] = DateLastText;
            //        //row2[ "ContactNumber" ] = ContactNumber2;
            //        //dTMissingWeeks.Rows.Add( row2 );
            //        backgroundWorker1.ReportProgress(dTMissingWeeks.Rows.Count);
            //        dTMissingWeeks.Rows.Add(Name, Project, Designation2, WeekNumberMissing, GetLatestWeekInt, DateLastText, ContactNumber2);

            //        //dgvMissingWeekNumbers.DataSource = dTMissingWeeks;
            //        //BindingSource sourceMissingWeeks = new BindingSource( );
            //        //sourceMissingWeeks.DataSource = dTMissingWeeks;

            //        if (Name == string.Empty || WeekNumberMissing == string.Empty)
            //        {
            //            dTMissingWeeks.Rows.RemoveAt(dTMissingWeeks.Rows.Count - 1);
            //        }
            //    }

            //}          

            //cmdProject.Connection.Close();
        }

        private void dgvWeeklyTextMonitoring_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {

        }

        private void button4_Click(object sender, EventArgs e) {

        }
        private void timer1_Tick(object sender, EventArgs e) {
            if (TimerToSearchMonitoringText.Interval == 2000)
            {
                frm2.Show();
                frm2.lblSearchLoading.Text = "Please wait while searching records...";
                frm2.TopMost = true;
                frm2.lblSearchLoading.Location = new Point(90, 46);
                frm2.Location = new Point(550, 800);
                dT.Clear();
                dTMissingWeeks.Clear();
                backgroundWorker1.RunWorkerAsync();
                TimerToSearchMonitoringText.Stop();
            }
        }
        private void txtSearchWeeklyMonitoring_TextChanged(object sender, EventArgs e) {
            //TimerToSearchMonitoringText.Stop();//Each type in textbox stop the timer count
            //TimerToSearchMonitoringText.Start();//this is to start the timer count after input of characters in textbox  
            DataView view = new DataView( dT );
            view.RowFilter = string.Format( "Project LIKE '%{0}%' or Name LIKE '%{0}%' " , txtSearchWeeklyMonitoring.Text.Replace( "'" , "''" ) );
            dgvWeeklyTextMonitoring.DataSource = view;
        }

        private void txtWeekMissing_TextChanged(object sender, EventArgs e) {

        }

        private void timerMissingWeeks_Tick(object sender, EventArgs e) {

        }

        private void RBtnName_CheckedChanged(object sender, EventArgs e) {

        }

        private void timer1_Tick_1(object sender, EventArgs e) {

        }

        private void button1_Click_2(object sender, EventArgs e) {

        }
        string Str;
        private void TxtSearch(string txt) {
            Str = txtSearchWeeklyMonitoring.Text;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
              GettingTheTextedTextcodeMonitoringRecords( );
           //  FindMissingWeeks( );        
           
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            frm2.progressBarSearchLoading.Increment( e.ProgressPercentage );
            frm2.lblSearchLoading.Location = new Point( 187 , 46 );
            frm2.lblSearchLoading.Text = frm2.progressBarSearchLoading.Value.ToString( ) + "%";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            /* Clearing the columns of datagridviews */
            dgvWeeklyTextMonitoring.Columns.Clear( );
            dgvWeeklyTextMonitoring.Update( );
            /* Ends here */

            /* Binding dgvWeeklyTextMonitoring datasource to datatable dT */
            dgvWeeklyTextMonitoring.DataSource = dT;
            BindingSource source = new BindingSource( );
            source.DataSource = dT;
            /* Ends here */

            /* This is to filter the datagridview */
            DataView view = new DataView( dT );
            view.RowFilter = string.Format( "Project LIKE '%{0}%'" , txtSearchWeeklyMonitoring.Text.Replace( "'" , "''" ) );
            dgvWeeklyTextMonitoring.DataSource = view;
            /* Ends here */

            dgvWeeklyTextMonitoring.Columns[ "Name" ].Width = 170;
            dgvWeeklyTextMonitoring.Columns[ "Name" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvWeeklyTextMonitoring.Columns[ "Designation" ].Width = 150;
            dgvWeeklyTextMonitoring.Columns[ "Designation" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvWeeklyTextMonitoring.Columns[ "PrevDcov" ].Width = 200;
            dgvWeeklyTextMonitoring.Columns[ "PrevDcov" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvWeeklyTextMonitoring.Columns[ "PrevDcov" ].HeaderText = "Prev. Dcov";

            dgvWeeklyTextMonitoring.Columns[ "LastWeekTexted" ].Width = 150;
            dgvWeeklyTextMonitoring.Columns[ "LastWeekTexted" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvWeeklyTextMonitoring.Columns[ "LastWeekTexted" ].HeaderText = "Prev. Report Week -#";

            dgvWeeklyTextMonitoring.Columns[ "NumWeeks" ].Width = 100;
            dgvWeeklyTextMonitoring.Columns[ "NumWeeks" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvWeeklyTextMonitoring.Columns[ "NumWeeks" ].HeaderText = "Num. of Weeks";

            dgvWeeklyTextMonitoring.Columns[ "DateLastTxt" ].Width = 150;
            dgvWeeklyTextMonitoring.Columns[ "DateLastTxt" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvWeeklyTextMonitoring.Columns[ "DateLastTxt" ].HeaderText = "Prev. Date Texted";

            // dgvWeeklyTextMonitoring.Columns[ "ContactNumber" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvWeeklyTextMonitoring.Columns[ "ContactNumber" ].Width = 200;
            dgvWeeklyTextMonitoring.Columns[ "ContactNumber" ].HeaderText = "Contact-#/'s";

            //---------------------/

            BindingSource sourceMissingWeeks = new BindingSource( );
            sourceMissingWeeks.DataSource = dTMissingWeeks;

            DataView view2 = new DataView( dTMissingWeeks );
            view2.RowFilter = string.Format( "Project LIKE '%{0}%'" , txtSearchWeeklyMonitoring.Text.Replace( "'" , "''" ) );

            //if( frm2.progressBarSearchLoading.Value==100 )// ProgressBar reach 100% or datagridview loadded records done
            //{
            // frm2.progressBarSearchLoading.Value = 0;//set progress bar value to zero
            frm2.Hide( );// hide form loading                
                         // frm2.lblSearchLoading.Text = "";//empty the label of percentage
                         // }
        }

        private void BtnFilterCallUprecords_Click(object sender, EventArgs e) {
            try
            {
                ShowCallUpRecords show = new ShowCallUpRecords(dgvProjectOrName, dgvHistoryPenaltyCallup);
                show.FilterCallUpRecords(NumericUpDown, dgvHistoryPenaltyCallup, checkFilterSpecProject, txtProjectToFilter);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnResetDgvCallUp_Click(object sender, EventArgs e) {
            try
            {
                dgvHistoryPenaltyCallup.DataSource = null; dgvHistoryPenaltyCallup.Columns.Clear();//Clear the datasource of datagridview and columns

                EmptyRows EmptyRows = new EmptyRows();//instatiate class EmptyRows
                EmptyRows.HistoryPenaltyCallup(dgvHistoryPenaltyCallup);//Call method that fills empty rows

                NumericUpDown.Value = 0;//set value of numeric up down to zero
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void checkFilterSpecProject_CheckStateChanged(object sender, EventArgs e) {
            try
            {
                if (checkFilterSpecProject.Checked == true)
                {
                    txtProjectToFilter.Enabled = true;
                }
                else
                {
                    txtProjectToFilter.Clear();
                    txtProjectToFilter.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgvProjectOrName_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            dgvProjectOrName.ReadOnly = false;
        }

        private void dgvWeekNumber_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
            {
                txtWeekNumberWeekly.Text = dgvWeekNumber.CurrentRow.Cells["WeekNumber"].Value.ToString();
                dtpDateTextdWeekly.Text = dgvWeekNumber.CurrentRow.Cells["DateTexted"].Value.ToString();
                MtxtDateFromWeekly.Text = dgvWeekNumber.CurrentRow.Cells["DateFrom"].Value.ToString();
                MtxtDateToWeekly.Text = dgvWeekNumber.CurrentRow.Cells["DateTo"].Value.ToString();
                txtRemarksWeekly.Text = dgvWeekNumber.CurrentRow.Cells["Remarks"].Value.ToString();
                txtWeekNumberWeekly.Select();
            }
        }

        private void dgvCheckerBodegeroAccounts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) {
            dgvCheckerBodegeroAccounts.ReadOnly = false;
        }

        private void dgvCheckerBodegeroAccounts_MouseHover(object sender, EventArgs e) {

        }

        private void txtContactNmber_KeyDown(object sender, KeyEventArgs e) {

        }

        private void dgvCheckerBodegeroAssigned_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void dgvCheckerBodegeroAssigned_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            dgvCheckerBodegeroAssigned.ReadOnly = false;
            //dgvCheckerBodegeroAccounts.Rows[0].Cells[1].DataGridView.DefaultCellStyle.BackColor = Color.Red;
        }

        private void printDocumentCallUpCoverLetter_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
            e.Graphics.DrawString("Engineering & Construction Department", new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Black), new RectangleF(25, 30, printDocumentCallUpCoverLetter.DefaultPageSettings.PrintableArea.Width, printDocumentCallUpCoverLetter.DefaultPageSettings.PrintableArea.Height));

            e.Graphics.DrawString("INC Central Office No. 1 Central Ave., New Era Q.C. 1107 Tel (02) 981-43-11 Fax (02) 981-11-15 Loc. 3516", new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Black), new RectangleF(25, 52, printDocumentCallUpCoverLetter.DefaultPageSettings.PrintableArea.Width, printDocumentCallUpCoverLetter.DefaultPageSettings.PrintableArea.Height));

            e.Graphics.DrawString(dgvWeeklyTextMonitoring.CurrentRow.Cells["Name"].Value.ToString(), new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), new RectangleF(320, 120, printDocumentCallUpCoverLetter.DefaultPageSettings.PrintableArea.Width, printDocumentCallUpCoverLetter.DefaultPageSettings.PrintableArea.Height));

            e.Graphics.DrawString("INC Construction", new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Black), new RectangleF(340, 140, printDocumentCallUpCoverLetter.DefaultPageSettings.PrintableArea.Width, printDocumentCallUpCoverLetter.DefaultPageSettings.PrintableArea.Height));

            e.Graphics.DrawString(dgvWeeklyTextMonitoring.CurrentRow.Cells["Project"].Value.ToString(), new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), new RectangleF(320, 160, printDocumentCallUpCoverLetter.DefaultPageSettings.PrintableArea.Width, printDocumentCallUpCoverLetter.DefaultPageSettings.PrintableArea.Height));
            Color LightBlack = ControlPaint.Light(Color.Black);
            e.Graphics.DrawString("Text Code", new Font("Tahoma", 9, FontStyle.Bold), new SolidBrush(LightBlack), new RectangleF(560, 200, printDocumentCallUpCoverLetter.DefaultPageSettings.PrintableArea.Width, printDocumentCallUpCoverLetter.DefaultPageSettings.PrintableArea.Height));

            Pen BlackPen = new Pen(Color.Black, 1);//to create a line, color black with thickness of 1
            Point point1 = new Point(22, 50);//22 is starting point of line, 50 is the starting point in height of the 1st endpoint of the line(left side)
            Point point2 = new Point(825, 50);//825 is width or how long the line is, 50 is the point in height of the 2st endpoint of the line(right side)
            e.Graphics.DrawLine(BlackPen, point1, point2);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e) {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
            try
            {
                DialogResult YesNo = MessageBox.Show("Are you sure you want to delete this record?", "Delete record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (YesNo == DialogResult.Yes)
                {

                    cmd.CommandText = "DELETE FROM textcodedb.calluppenalty WHERE PrimaryID ='" + dgvHistoryPenaltyCallup.CurrentRow.Cells["PrimaryID"].Value.ToString() + "'";
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception)
            {

            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        private void dgvHistoryPenaltyCallup_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button == MouseButtons.Right)
            {
                dgvHistoryPenaltyCallup.CurrentCell = dgvHistoryPenaltyCallup.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvHistoryPenaltyCallup.Rows[e.RowIndex].Selected = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e) {
            MessageBox.Show(dgvProjectOrName.CurrentRow.Cells["Project"].Value.ToString() + " - " + dgvProjectOrName.CurrentRow.Index);

        }

        private void button1_Click_3(object sender, EventArgs e) {
            int rowIndex = dgvProjectOrName.CurrentRow.Cells["Project"].RowIndex; MessageBox.Show(rowIndex.ToString());
            dgvProjectOrName.CurrentCell = dgvProjectOrName.Rows[rowIndex - 1].Cells["Project"];
        }

        private void dgvProjectOrName_RowLeave(object sender, DataGridViewCellEventArgs e) {

        }

        private void toolStripButton2_Click(object sender, EventArgs e) {
            CustomeDateRangeCallUpForm CustomDate = new CustomeDateRangeCallUpForm();
            CustomDate.Show();
        }

        private void button1_Click_4(object sender, EventArgs e) {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = DataBaseConnection.DataBaseConnectionSourcePath.GetConnection();
            try
            {
                DialogResult YesNo = MessageBox.Show("Are you sure you want to delete this record?", "Delete record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (YesNo == DialogResult.Yes)
                {
              
                    cmd.CommandText = "DELETE FROM textcodedb.textedtextcode WHERE PrimaryID ='" + dgvWeekNumber.CurrentRow.Cells["PrimaryID"].Value.ToString() + "'";
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        private void printPreviewDialogCallUpCoverLetter_Load(object sender, EventArgs e) {

        }

        private void dgvCheckerBodegeroAccounts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
           
        }

        private void lblTitle_Click( object sender , EventArgs e ) {
          
        }

        private void txtWeekNumber_TextChanged( object sender , EventArgs e ) {
         
        }

        private void label6_Click( object sender , EventArgs e ) {
            //foreach( DataGridViewColumn item in dgvWeeklyTextMonitoring.Columns )
            //{
            //    MessageBox.Show( item.Name );
            //}         
        }

        private void label12_Click( object sender , EventArgs e ) {

        }
    }
}
