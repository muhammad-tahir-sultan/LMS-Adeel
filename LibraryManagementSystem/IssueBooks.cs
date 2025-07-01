using QRCoder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;  
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace LibraryManagementSystem
{
    public partial class IssueBooks : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G6B9LKR;Initial Catalog=library;Integrated Security=True;Connect Timeout=30");
        private string imagePath;
        public IssueBooks()
        {
            InitializeComponent();

            // Style and data
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            displayBookIssueData();
            DataBookTitle();

            // Event binding
            dataGridView1.CellClick += dataGridView1_CellClick;
        }


        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }

            displayBookIssueData();
            DataBookTitle();
        }
        public void displayBookIssueData(string keyword = "")
            {
                try
                {
                DataIssueBooks dib = new DataIssueBooks();
                List<DataIssueBooks> listData = dib.IssueBooksData()
                                   .Where(d => d.Status == "Issued")
                                   .ToList();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    keyword = keyword.ToLower();

                    listData = listData.Where(d =>
                        d.ISBN.ToLower().Contains(keyword) ||
                        d.Name.ToLower().Contains(keyword) ||
                        d.Email.ToLower().Contains(keyword) ||
                        d.BookTitle.ToLower().Contains(keyword) ||
                        d.Author.ToLower().Contains(keyword) ||
                        d.Status.ToLower().Contains(keyword)
                    ).ToList();
                }

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ISBN", DataPropertyName = "ISBN", Name = "ISBN" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Name", DataPropertyName = "Name", Name = "Name" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "RollNo", DataPropertyName = "RollNo", Name = "RollNo" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Email", DataPropertyName = "Email", Name = "Email" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Book Title", DataPropertyName = "BookTitle", Name = "BookTitle" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Author", DataPropertyName = "Author", Name = "Author" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Issue Date", DataPropertyName = "DateIssue", Name = "DateIssue" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Return Date", DataPropertyName = "DateReturn", Name = "DateReturn" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Status", DataPropertyName = "Status", Name = "Status" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fine", DataPropertyName = "Fine", Name = "Fine" });

                dataGridView1.DataSource = listData;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

     
        private void bookIssue_addBtn_Click(object sender, EventArgs e)
        {
            if (bookIssue_name.Text == "" || bookIssue_rollNo.Text == "" ||
                bookIssue_email.Text == "" || bookIssue_bookTitle.Text == "" || bookIssue_author.Text == "" ||
                bookIssue_isbn.Text == "" ||
                bookIssue_issueDate.Value == null || bookIssue_returnDate.Value == null)
            {
                MessageBox.Show("Please fill all required fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                    DateTime today = DateTime.Today;
                   
                 
             

                    // Check for available copies
                    string checkCopies = "SELECT copies FROM books WHERE book_title = @bookTitle";
                    using (SqlCommand checkCmd = new SqlCommand(checkCopies, connect))
                    {
                        checkCmd.Parameters.AddWithValue("@bookTitle", bookIssue_bookTitle.Text.Trim());
                        int availableCopies = (int)checkCmd.ExecuteScalar();

                        if (availableCopies <= 0)
                        {
                            MessageBox.Show("No copies available for this book.", "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string insertData = "INSERT INTO issues " +
                        "(full_name, rollno, email, book_title, author, isbn, status, issue_date, return_date,  date_insert, fine) " +
                        "VALUES(@fullname, @rollno, @email, @bookTitle, @author, @isbn, @status, @issueDate, @returnDate, @dateInsert, @fine)";

                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        cmd.Parameters.AddWithValue("@fullname", bookIssue_name.Text.Trim());
                        cmd.Parameters.AddWithValue("@rollno", bookIssue_rollNo.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", bookIssue_email.Text.Trim());
                        cmd.Parameters.AddWithValue("@bookTitle", bookIssue_bookTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@author", bookIssue_author.Text.Trim());
                        cmd.Parameters.AddWithValue("@isbn", bookIssue_isbn.Text.Trim());
                        cmd.Parameters.AddWithValue("@status", "Issued");
                        cmd.Parameters.AddWithValue("@issueDate", bookIssue_issueDate.Value);
                        cmd.Parameters.AddWithValue("@returnDate", bookIssue_returnDate.Value);
                        cmd.Parameters.AddWithValue("@dateInsert", today);
                        cmd.Parameters.AddWithValue("@fine", 0);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            string updateCopies = "UPDATE books SET copies = copies - 1 WHERE book_title = @bookTitle AND copies > 0";
                            using (SqlCommand updateCmd = new SqlCommand(updateCopies, connect))
                            {
                                updateCmd.Parameters.AddWithValue("@bookTitle", bookIssue_bookTitle.Text.Trim());
                                updateCmd.ExecuteNonQuery();
                            }

                            // Send email
                            try
                            {
                                MailMessage mail = new MailMessage();
                                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                                mail.From = new MailAddress("tahirsultanofficial@gmail.com", "Library Admin");
                                mail.To.Add(bookIssue_email.Text.Trim());
                                mail.Subject = "Book Issued - Library Notification";

                                string body = $"Dear {bookIssue_name.Text.Trim()},\n\n" +
                                              $"The following book has been issued to you:\n\n" +
                                              $"Book Title: {bookIssue_bookTitle.Text.Trim()}\n" +
                                              $"ISBN: {bookIssue_isbn.Text.Trim()}\n" +
                                              $"Author: {bookIssue_author.Text.Trim()}\n" +
                                              $"Issue Date: {bookIssue_issueDate.Value.ToShortDateString()}\n" +
                                              $"Return Date: {bookIssue_returnDate.Value.ToShortDateString()}\n\n" +
                                              $"Please make sure to return the book on or before the due date.\n\n" +
                                              $"Regards,\nLibrary Management System";

                                mail.Body = body;
                                smtpServer.Port = 587;
                                smtpServer.Credentials = new NetworkCredential("tahirsultanofficial@gmail.com", "zwnajhzdgfcrfdct");
                                smtpServer.EnableSsl = true;
                                smtpServer.Send(mail);

                                // QR Code
                                string qrContent = $"Book Title: {bookIssue_bookTitle.Text.Trim()}\n" +
                                                   $"Author: {bookIssue_author.Text.Trim()}\n" +
                                                   $"ISBN: {bookIssue_isbn.Text.Trim()}\n" +
                                                   $"Issued To: {bookIssue_name.Text.Trim()} ({bookIssue_rollNo.Text.Trim()})\n" +
                                                   $"Email: {bookIssue_email.Text.Trim()}\n" +
                                                   $"Issue Date: {bookIssue_issueDate.Value.ToShortDateString()}\n" +
                                                   $"Return Date: {bookIssue_returnDate.Value.ToShortDateString()}";

                                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                                {
                                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrContent, QRCodeGenerator.ECCLevel.Q);
                                    using (QRCode qrCode = new QRCode(qrCodeData))
                                    {
                                        using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
                                        {
                                            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                                            {
                                                saveFileDialog.Filter = "PNG Image|*.png";
                                                saveFileDialog.Title = "Save QR Code";
                                                saveFileDialog.FileName = $"QR_{bookIssue_name.Text.Trim()}_{bookIssue_rollNo.Text.Trim()}_{bookIssue_bookTitle.Text.Trim()}.png";

                                                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                                                {
                                                    qrCodeImage.Save(saveFileDialog.FileName, ImageFormat.Png);
                                                    MessageBox.Show("QR Code saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                            }
                                        }
                                    }
                                }

                                MessageBox.Show("Issued successfully and email sent!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception emailEx)
                            {
                                MessageBox.Show("Book issued but failed to send email:\n" + emailEx.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            displayBookIssueData();
                            clearFields();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        MessageBox.Show("This ISBN already exists. Please use a different one.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        public void clearFields()
        {
            bookIssue_isbn.Text = "";
            bookIssue_name.Text = "";
            bookIssue_rollNo.Text = "";
            bookIssue_email.Text = "";
            bookIssue_bookTitle.SelectedIndex = -1;
            bookIssue_author.Text = "";
        }

        public void DataBookTitle()
        {
            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT id, book_title FROM books WHERE status = 'Available' AND date_delete IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        bookIssue_bookTitle.DataSource = table;
                        bookIssue_bookTitle.DisplayMember = "book_title";
                        bookIssue_bookTitle.ValueMember = "id"; // ✅ this must match your SQL SELECT
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

        private void bookIssue_bookTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Closed && bookIssue_bookTitle.SelectedValue != null)
            {
                try
                {
                    connect.Open();
                    int selectedID = Convert.ToInt32(bookIssue_bookTitle.SelectedValue);
                    string selectData = "SELECT * FROM books WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedID);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            bookIssue_author.Text = table.Rows[0]["author"].ToString();
                            bookIssue_isbn.Text = table.Rows[0]["isbn"].ToString();
                   
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Populate fields with row data
                bookIssue_isbn.Text = row.Cells["ISBN"].Value?.ToString();
                bookIssue_name.Text = row.Cells["Name"].Value?.ToString();
                bookIssue_rollNo.Text = row.Cells["RollNo"].Value?.ToString();
                bookIssue_email.Text = row.Cells["Email"].Value?.ToString();
                bookIssue_bookTitle.Text = row.Cells["BookTitle"].Value?.ToString();
                bookIssue_author.Text = row.Cells["Author"].Value?.ToString();
                bookIssue_issueDate.Value = Convert.ToDateTime(row.Cells["DateIssue"].Value);
                bookIssue_returnDate.Value = Convert.ToDateTime(row.Cells["DateReturn"].Value);

                // Optional: Load image if you have image path in data
                // bookIssue_picture.Image = Image.FromFile(row.Cells["Image"].Value?.ToString());
            }
        }

        private void bookIssue_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }


        private void addBooks_importBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName; // Store the path to save later
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    
        private void bookIssue_deleteBtn_Click(object sender, EventArgs e)
        {
            // Confirm if the user really wants to delete the record
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?",
                                                  "Confirm Deletion",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string issueID = bookIssue_isbn.Text.Trim();

                if (!string.IsNullOrEmpty(issueID))
                {
                    DeleteIssue(issueID);
                }
                else
                {
                    MessageBox.Show("Please select a record to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DeleteIssue(string issueID)
        {
            try
            {
                if (connect.State != ConnectionState.Open)
                    connect.Open();

                string deleteQuery = "DELETE FROM issues WHERE isbn = @ISBN";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@ISBN", issueID);
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        displayBookIssueData();
                        clearFields();
                    }
                    else
                    {
                        MessageBox.Show("No record found to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting issue: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        private void bookIssue_updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State != ConnectionState.Open)
                    connect.Open();

                string updateQuery = "UPDATE issues SET full_name=@fullname, rollno=@rollno, email=@email, " +
                                     "book_title=@bookTitle, author=@author, status=@status, " +
                                     "issue_date=@issueDate, return_date=@returnDate";

         

                updateQuery += " WHERE ISBN=@isbn";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@isbn", bookIssue_isbn.Text.Trim());
                    cmd.Parameters.AddWithValue("@fullname", bookIssue_name.Text.Trim());
                    cmd.Parameters.AddWithValue("@rollno", bookIssue_rollNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", bookIssue_email.Text.Trim());
                    cmd.Parameters.AddWithValue("@bookTitle", bookIssue_bookTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@author", bookIssue_author.Text.Trim());
                    cmd.Parameters.AddWithValue("@status", "Issued");
                    cmd.Parameters.AddWithValue("@issueDate", bookIssue_issueDate.Value);
                    cmd.Parameters.AddWithValue("@returnDate", bookIssue_returnDate.Value);

                

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        displayBookIssueData();
                        clearFields();
                    }
                    else
                    {
                        MessageBox.Show("Update failed. Record may not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating issue: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

  

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            displayBookIssueData(searchTextBox.Text.Trim());
        }

        private void searchStudent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(bookIssue_rollNo.Text))
            {
                MessageBox.Show("Please enter a roll number to search.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }

                string query = "SELECT FullName, Email FROM Student WHERE EnrollmentID = @rollNo";
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@rollNo", bookIssue_rollNo.Text.Trim());

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bookIssue_name.Text = reader["FullName"].ToString();
                            bookIssue_email.Text = reader["Email"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Student not found with the given roll number.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bookIssue_name.Clear();
                            bookIssue_email.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching for the student:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            displayBookIssueData();
        }
    }
}
