using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class Dashboard : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G6B9LKR;Initial Catalog=library;Integrated Security=True;Connect Timeout=30");

        public Dashboard()
        {
            InitializeComponent();

            displayAB();
            displayIB();
            displayRB();
            displayStudents();     
            displayTeachers();     
            displayTotalCopies();  
            displayTotalFine();  
        }

        public void displayTotalFine()
        {
            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT SUM(fine) FROM issues WHERE date_delete IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        decimal totalFine = 0;

                        if (reader.Read() && reader[0] != DBNull.Value)
                        {
                            totalFine = Convert.ToDecimal(reader[0]);
                            totalFineText.Text = totalFine.ToString("F2"); // Formats to 2 decimal places
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        public void displayStudents()
        {
            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT COUNT(EnrollmentID) FROM Student";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        int studentCount = 0;

                        if (reader.Read())
                        {
                            studentCount = Convert.ToInt32(reader[0]);
                            dashboard_Students.Text = studentCount.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        public void displayTeachers()
        {
            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT COUNT(CNIC) FROM Teacher";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        int teacherCount = 0;

                        if (reader.Read())
                        {
                            teacherCount = Convert.ToInt32(reader[0]);
                            dashboard_Teachers.Text = teacherCount.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }

            displayAB();
            displayIB();
            displayRB();
            displayStudents();     
            displayTeachers();     
            displayTotalCopies();  
            displayTotalFine();

        }

        public void displayTotalCopies()
        {
            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT SUM(copies) FROM books WHERE date_delete IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        int totalCopies = 0;

                        if (reader.Read() && reader[0] != DBNull.Value)
                        {
                            totalCopies = Convert.ToInt32(reader[0]);
                            allCopiesLabel.Text = totalCopies.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        // Display available books count (titles with at least one available copy)
        public void displayAB()
        {
            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    string selectData = @"
                SELECT COUNT(*) AS AvailableBooks
                FROM books b
                WHERE b.date_delete IS NULL
                AND (
                    b.copies > (
                        SELECT COUNT(*) 
                        FROM issues i 
                        WHERE i.isbn = b.isbn 
                        AND i.date_delete IS NULL 
                        AND i.status != 'Return'
                    )
                )
            ";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int availableBooks = Convert.ToInt32(reader["AvailableBooks"]);
                            dashboard_AB.Text = $"{availableBooks}";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        // Display total number of issued books
        public void displayIB()
        {
            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    // Count only books with status 'Issued' and not deleted
                    string selectData = "SELECT COUNT(isbn) FROM issues WHERE status = 'Issued' AND date_delete IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        int tempIB = 0;

                        if (reader.Read())
                        {
                            tempIB = Convert.ToInt32(reader[0]);
                            dashboard_IB.Text = tempIB.ToString(); // Make sure dashboard_IB exists
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        // Display number of returned books
        public void displayRB()
        {
            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT COUNT(isbn) FROM issues WHERE status = 'Return' AND date_delete IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        int tempRB = 0;

                        if (reader.Read())
                        {
                            tempRB = Convert.ToInt32(reader[0]);
                            dashboard_RB.Text = tempRB.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // You can handle custom painting here if needed
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void totalFineText_Click(object sender, EventArgs e)
        {

        }
    }
}
