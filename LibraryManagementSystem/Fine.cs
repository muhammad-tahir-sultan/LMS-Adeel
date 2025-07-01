using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;


namespace LibraryManagementSystem
{
    public partial class Fine : UserControl
    {
        public Fine()
        {
        
            InitializeComponent();
            LoadStudentsWithFines();
            dataGridViewFines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewFines.MultiSelect = false; // optional, to allow only one row at a time

            // Set header background color to black and text color to white
            dataGridViewFines.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Black;
            dataGridViewFines.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridViewFines.EnableHeadersVisualStyles = false;
        }

        private void LoadStudentsWithFines(string keyword = "")
        {
            string connectionString = @"Data Source=DESKTOP-G6B9LKR;Initial Catalog=library;Integrated Security=True;Connect Timeout=30";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT ISBN, full_name, contact, email, book_title, author, issue_date, return_date, fine FROM issues WHERE fine > 0";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        keyword = keyword.ToLower();

                        var filtered = table.AsEnumerable().Where(row =>
                        row["ISBN"].ToString().ToLower().Contains(keyword) ||
                        row["full_name"].ToString().ToLower().Contains(keyword) ||
                        row["contact"].ToString().ToLower().Contains(keyword) ||
                        row["email"].ToString().ToLower().Contains(keyword) ||
                        row["book_title"].ToString().ToLower().Contains(keyword) ||
                        row["author"].ToString().ToLower().Contains(keyword)
      );

                        if (filtered.Any())
                            table = filtered.CopyToDataTable();
                        else
                            table.Rows.Clear();
                    }

                    dataGridViewFines.DataSource = table;

                    dataGridViewFines.Columns["ISBN"].HeaderText = "ISBN";
                    dataGridViewFines.Columns["full_name"].HeaderText = "Name";
                    dataGridViewFines.Columns["contact"].HeaderText = "Contact";
                    dataGridViewFines.Columns["email"].HeaderText = "Email";
                    dataGridViewFines.Columns["book_title"].HeaderText = "Book Title";
                    dataGridViewFines.Columns["author"].HeaderText = "Author";
                    dataGridViewFines.Columns["issue_date"].HeaderText = "Issue Date";
                    dataGridViewFines.Columns["return_date"].HeaderText = "Return Date";
                    dataGridViewFines.Columns["fine"].HeaderText = "Fine";

                    dataGridViewFines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading fines: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sendEmailBtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewFines.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to send an email.");
                return;
            }

            // Get selected row
            DataGridViewRow row = dataGridViewFines.SelectedRows[0];

            string toAddress = row.Cells["email"].Value.ToString();
            string studentName = row.Cells["full_name"].Value.ToString();
            string bookTitle = row.Cells["book_title"].Value.ToString();
            string fineAmount = row.Cells["fine"].Value.ToString();

            // Configure your sender email credentials
            string fromAddress = "tahirsultanofficial@gmail.com"; 
            string fromPassword = "zwnajhzdgfcrfdct";         

            string subject = "Library Fine Notification";
            string body = $"Dear {studentName},\n\n" +
                          $"You have an outstanding fine for the book \"{bookTitle}\". " +
                          $"Your current fine is: Rs. {fineAmount}.\n\n" +
                          $"Please return the book and pay the fine as soon as possible.\n\n" +
                          $"Regards,\nLibrary Management";

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromAddress);
                mail.To.Add(toAddress);
                mail.Subject = subject;
                mail.Body = body;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587); // e.g., smtp.gmail.com
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.EnableSsl = true;

                smtp.Send(mail);
                MessageBox.Show("Email sent successfully to " + studentName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email. Error: " + ex.Message);
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadStudentsWithFines(searchTextBox.Text.Trim());
        }

        private void clearFineBtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewFines.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to clear the fine.");
                return;
            }

            DataGridViewRow selectedRow = dataGridViewFines.SelectedRows[0];
            string isbn = selectedRow.Cells["ISBN"].Value.ToString();

            string connectionString = @"Data Source=DESKTOP-G6B9LKR;Initial Catalog=library;Integrated Security=True;Connect Timeout=30";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE issues SET fine = 0 WHERE ISBN = @isbn";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@isbn", isbn);


                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Fine cleared successfully.");
                        LoadStudentsWithFines(); // Refresh the grid
                    }
                    else
                    {
                        MessageBox.Show("Failed to clear the fine.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error clearing fine: " + ex.Message);
                }
            }
        }

 

        private void refreshBtn_Click_1(object sender, EventArgs e)
        {
            LoadStudentsWithFines();

        }
    }
}
