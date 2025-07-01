using ZXing;
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

namespace LibraryManagementSystem
{
    public partial class ReturnBooks : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G6B9LKR;Initial Catalog=library;Integrated Security=True;Connect Timeout=30");

        public ReturnBooks()
        {
            InitializeComponent();

            // Set header background color to black and text color to white
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;

            displayIssuedBooksData();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }

            displayIssuedBooksData();
        }

        private void returnBooks_returnBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(returnBooks_name.Text)
                || string.IsNullOrWhiteSpace(returnBooks_rollno.Text)
                || string.IsNullOrWhiteSpace(returnBooks_email.Text)
                || string.IsNullOrWhiteSpace(returnBooks_bookTitle.Text)
                || string.IsNullOrWhiteSpace(returnBooks_author.Text))
            {
                MessageBox.Show("Please select item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (connect.State == ConnectionState.Closed)
            {
                DialogResult check = MessageBox.Show("Are you sure this book is returned already?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    try
                    {
                        connect.Open();
                        // 1. Use the issue date from the bookReturn_issueDate field
                        DateTime issueDate;
                        if (!DateTime.TryParse(bookReturn_issueDate.Text.Trim(), out issueDate))
                        {
                            MessageBox.Show("Invalid issue date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }


                        DateTime returnDate = DateTime.Today;
                        int fine = 0;
                        int gracePeriod = 7;

                        int totalDays = (returnDate - issueDate).Days;
                        int overdueDays = totalDays - gracePeriod;
                        if (overdueDays > 0)
                        {
                            fine = overdueDays * 100; // ₹100 fine per extra day
                        }

                        // 2. Update the issue record using ISBN
                        string updateData = "UPDATE issues SET status = @status, fine = @fine, return_date = @returnDate WHERE ISBN = @isbn AND status = 'Issued'";
                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@status", "Return");
                            cmd.Parameters.AddWithValue("@fine", fine);
                            cmd.Parameters.AddWithValue("@returnDate", returnDate);
                            cmd.Parameters.AddWithValue("@isbn", returnBooks_isbn.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Update book stock
                        string updateCopies = "UPDATE books SET copies = copies + 1 WHERE book_title = @bookTitle";
                        using (SqlCommand updateCmd = new SqlCommand(updateCopies, connect))
                        {
                            updateCmd.Parameters.AddWithValue("@bookTitle", returnBooks_bookTitle.Text.Trim());
                            updateCmd.ExecuteNonQuery();
                        }

                        if (fine > 0)
                        {
                            MessageBox.Show($"Book returned late. Fine: Rs.{fine}", "Fine Applied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        displayIssuedBooksData();
                        MessageBox.Show("Returned successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refreshData();
                        clearFields();
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
        }

        public void displayIssuedBooksData(string keyword = "")
        {
            DataIssueBooks dib = new DataIssueBooks();
            List<DataIssueBooks> listData = dib.ReturnIssueBooksData();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower();
                listData = listData.Where(item =>
                    item.ISBN.ToLower().Contains(keyword) ||
                    item.Name.ToLower().Contains(keyword) ||
                    item.Email.ToLower().Contains(keyword) ||
                    item.BookTitle.ToLower().Contains(keyword) ||
                    item.Author.ToLower().Contains(keyword)
                ).ToList();
            }

            dataGridView1.DataSource = listData;

            // Hide unwanted columns
            string[] columnsToHide = { "Contact", "ImagePath", "Fine" };
            foreach (string col in columnsToHide)
            {
                if (dataGridView1.Columns.Contains(col))
                {
                    dataGridView1.Columns[col].Visible = false;
                }
            }
        }
      
        
        private void returnBooksDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                returnBooks_name.Text = row.Cells["student_name"].Value.ToString();
                returnBooks_rollno.Text = row.Cells["roll_no"].Value.ToString();
                returnBooks_email.Text = row.Cells["email"].Value.ToString();
                returnBooks_bookTitle.Text = row.Cells["book_title"].Value.ToString();
                returnBooks_author.Text = row.Cells["author"].Value.ToString();
                returnBooks_isbn.Text = row.Cells["ISBN"].Value.ToString();

                // Set issue date field
                if (row.Cells["issue_date"].Value != null)
                {
                    DateTime issueDate;
                    if (DateTime.TryParse(row.Cells["issue_date"].Value.ToString(), out issueDate))
                    {
                        bookReturn_issueDate.Text = issueDate.ToString("yyyy-MM-dd");
                    }
                }
            }
        }

        public void clearFields()
        {
            returnBooks_isbn.Text = "";
            returnBooks_name.Text = "";
            returnBooks_rollno.Text = "";
            returnBooks_email.Text = "";
            returnBooks_bookTitle.Text = "";
            returnBooks_author.Text = "";
        }


        private void returnBooks_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            displayIssuedBooksData(searchTextBox.Text.Trim());
        }

        private void uploadQRButton_Click(object sender, EventArgs e)
     {
        try
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                // Read QR code using ZXing.Net
                var barcodeReader = new BarcodeReader();
                var bitmap = (Bitmap)Bitmap.FromFile(imagePath);
                var result = barcodeReader.Decode(bitmap);

                if (result != null)
                {
                    string qrText = result.Text;
                    var lines = qrText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var line in lines)
                    {
                        if (line.StartsWith("Book Title:"))
                            returnBooks_bookTitle.Text = line.Replace("Book Title:", "").Trim();

                        else if (line.StartsWith("Author:"))
                            returnBooks_author.Text = line.Replace("Author:", "").Trim();

                        else if (line.StartsWith("Issued To:"))
                        {
                            string issuedTo = line.Replace("Issued To:", "").Trim();
                            int parenStart = issuedTo.LastIndexOf('(');
                            int parenEnd = issuedTo.LastIndexOf(')');
                            if (parenStart > 0 && parenEnd > parenStart)
                            {
                                returnBooks_name.Text = issuedTo.Substring(0, parenStart).Trim();
                                returnBooks_rollno.Text = issuedTo.Substring(parenStart + 1, parenEnd - parenStart - 1).Trim();
                            }
                            else
                            {
                                returnBooks_name.Text = issuedTo;
                            }
                        }

                        else if (line.StartsWith("Email:"))
                            returnBooks_email.Text = line.Replace("Email:", "").Trim();

                        else if (line.StartsWith("ISBN:"))
                            returnBooks_isbn.Text = line.Replace("ISBN:", "").Trim();

                        else if (line.StartsWith("Issue Date:"))
                        {
                            string dateStr = line.Replace("Issue Date:", "").Trim();
                            if (DateTime.TryParse(dateStr, out DateTime issueDate))
                                bookReturn_issueDate.Value = issueDate;
                        }

                        //else if (line.StartsWith("Return Date:"))
                        //{
                        //    string dateStr = line.Replace("Return Date:", "").Trim();
                        //    if (DateTime.TryParse(dateStr, out DateTime returnDate))
                        //        //bookReturn_returnDate.Value = returnDate; // <-- fix for return date
                        //}
                    }
                }
                else
                {
                    MessageBox.Show("No QR Code detected in the image.", "No Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error reading QR Code: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }



    private void refreshBtn_Click(object sender, EventArgs e)
        {
            displayIssuedBooksData(); // Reload issued books without filtering
        }
    }
}
