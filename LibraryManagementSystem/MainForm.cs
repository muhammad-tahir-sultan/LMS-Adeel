using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronBarCode;

namespace LibraryManagementSystem
{

    public partial class MainForm : Form
    {
        private Fine fineForm;
        private Student_Backup Student_Backup;
        private Teachers teachers;
        public MainForm()
        {
            InitializeComponent();

            // Initialize all forms with DockStyle.Fill
            this.addTeacher1 = new LibraryManagementSystem.AddTeacher();
            //this.addTeacher1.Dock = DockStyle.Fill;
            this.addTeacher1.Visible = false;
            //this.WindowState = FormWindowState.Maximized;
            this.panel3.Controls.Add(this.addTeacher1);

       

            // Make sure all other forms are also set to DockStyle.Fill
            this.dashboard1.Dock = DockStyle.Fill;
            this.addBooks1.Dock = DockStyle.Fill;
            this.issueBooks1.Dock = DockStyle.Fill;
            this.returnBooks1.Dock = DockStyle.Fill;

            this.addTeacher1 = new LibraryManagementSystem.AddTeacher();
            this.addTeacher1.Dock = DockStyle.Fill;
            this.addTeacher1.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            this.panel3.Controls.Add(this.addTeacher1);  // ✅ FIXED: Add to panel3



            this.fineForm = new Fine();
            this.fineForm.Dock = DockStyle.Fill;
            this.fineForm.Visible = false;
            this.panel3.Controls.Add(this.fineForm);

            this.teachers = new Teachers();
            this.teachers.Dock = DockStyle.Fill;
            this.teachers.Visible = false;
            this.panel3.Controls.Add(this.teachers);

            IronBarCode.License.LicenseKey = "IRONSUITE.TAHIRSULTANOFFICIAL.GMAIL.COM.1519-E06496E87F-BFH47OMZCDQ6CF-2NTR7LCD2KOJ-EHZXIJVOKEQK-QVH37VUPAU3W-6PTJBC4RRTZY-FQAP6QUUGXOG-RS3RUJ-TSAH2XZLIBOPUA-DEPLOYMENT.TRIAL-TRXOAE.TRIAL.EXPIRES.09.JUN.2025";



        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(check == DialogResult.Yes)
            {
                LoginForm lForm = new LoginForm();
                lForm.Show();
                this.Hide();
            }

        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = true;
            addBooks1.Visible = false;
            returnBooks1.Visible = false;
            issueBooks1.Visible = false;
            addTeacher1.Visible = false;
            fineForm.Visible = false;
            Student_Backup.Visible = false;

            Dashboard dForm = dashboard1 as Dashboard;
            if (dForm != null)
            {
                dForm.refreshData();
            }
        }

        private void addBooks_btn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            returnBooks1.Visible = false;
            addTeacher1.Visible = false;
            fineForm.Visible = false;
            Student_Backup.Visible = false;

            addBooks1.Visible = true;

            AddBooks aForm = addBooks1 as AddBooks;
            if(aForm != null)
            {
                aForm.refreshData();
            }
        }

        private void issueBooks_btn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            addBooks1.Visible = false;
            returnBooks1.Visible = false;
            addTeacher1.Visible=false;
            fineForm.Visible=false;
            Student_Backup.Visible = false;
            issueBooks1.Visible = true;

            ReturnBooks rForm = returnBooks1 as ReturnBooks;
            if (rForm != null)
            {
                rForm.refreshData();
            }
        }

        private void returnBooks_btn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            addBooks1.Visible = false;
            issueBooks1.Visible = false;
            Student_Backup.Visible = false;
            addTeacher1.Visible = false;
            returnBooks1.Visible = true;


            IssueBooks iForm = issueBooks1 as IssueBooks;
            if (iForm != null)
            {
                iForm.refreshData();
            }
        }


        private void addTeacher_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            addBooks1.Visible = false;
            returnBooks1.Visible = false;
            issueBooks1.Visible = false;
            fineForm.Visible = false;

            teachers.Visible = true;
            Student_Backup.Visible = false;


            if (teachers is Teachers aForm)
            {
                aForm.refreshData();
            }
        }

        private void addStudent_button_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            addBooks1.Visible = false;
            returnBooks1.Visible = false;
            issueBooks1.Visible = false;
            addTeacher1.Visible = false;

            //addStudentForm.Visible = true;
            Student_Backup.Visible = true;


            Student_Backup.refreshData();
        }

        private void Fine_Click(object sender, EventArgs e)
        {
            // Hide all other forms
            dashboard1.Visible = false;
            addBooks1.Visible = false;
            returnBooks1.Visible = false;
            issueBooks1.Visible = false;
            addTeacher1.Visible = false;
            fineForm.Visible = false;
            Student_Backup.Visible = false;


            // Show Fine form
            fineForm.Visible = true;
        }

    }
}

