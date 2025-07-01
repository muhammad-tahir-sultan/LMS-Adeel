using IronBarCode;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;


namespace LibraryManagementSystem
{
    public partial class AddBooks : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G6B9LKR;Initial Catalog=library;Integrated Security=True;Connect Timeout=30");


        public AddBooks()
        {
            InitializeComponent();
            displayBooks();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayBooks();
        }

        private string imagePath;

        private void addBooks_importBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    addBooks_picture.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addBooks_addBtn_Click(object sender, EventArgs e)
        {
            if (addBooks_bookTitle.Text == "" ||
                addBooks_author.Text == "" ||
                addBooks_status.Text == "" ||
                txtCopies.Text == "" ||
                addBook_ISBN.Text == "" 
                )
            {
                MessageBox.Show("Please fill all required fields (Title, Author, Status)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    DateTime today = DateTime.Today;
                    connect.Open();

                    string insertData = "INSERT INTO books (book_title, author, published_date, status, image, date_insert, copies, isbn) " +
     "VALUES(@bookTitle, @Author, @PublishedDate, @Status, @Image, @DateInsert, @Copies, @ISBN)";


                    string imageSavePath = null;

                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        string baseDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "LibraryImages");
                        string fileName = addBooks_bookTitle.Text.Trim() + "_" + addBooks_author.Text.Trim() + ".jpg";
                        imageSavePath = Path.Combine(baseDirectory, fileName);

                        Directory.CreateDirectory(baseDirectory);
                        File.Copy(imagePath, imageSavePath, true);
                    }

                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        cmd.Parameters.AddWithValue("@bookTitle", addBooks_bookTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@Author", addBooks_author.Text.Trim());
                        cmd.Parameters.AddWithValue("@PublishedDate", addBooks_published.Value);
                        cmd.Parameters.AddWithValue("@Status", addBooks_status.Text.Trim());
                        cmd.Parameters.AddWithValue("@ISBN", addBook_ISBN.Text.Trim());


                        int copies;
                        if (!int.TryParse(txtCopies.Text.Trim(), out copies) || copies <= 0)
                        {
                            MessageBox.Show("Please enter a valid number of copies.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        cmd.Parameters.AddWithValue("@Copies", int.Parse(txtCopies.Text.Trim()));


                        if (imageSavePath != null)
                            cmd.Parameters.AddWithValue("@Image", imageSavePath);
                        else
                            cmd.Parameters.AddWithValue("@Image", DBNull.Value);

                        cmd.Parameters.AddWithValue("@DateInsert", today);

                        cmd.ExecuteNonQuery();
                    }

                    displayBooks();
                    MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        public void clearFields()
        {
            addBooks_bookTitle.Text = "";
            addBooks_author.Text = "";
            addBooks_picture.Image = null;
            addBooks_status.SelectedIndex = -1;
            txtCopies.Text = "";
            addBook_ISBN.Text = "";
            imagePath = null;
        }


        public void displayBooks(string keyword = "")
        {
            DataAddBooks dab = new DataAddBooks();
            List<DataAddBooks> listData = dab.addBooksData();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower();
                listData = listData.Where(b =>
                    b.BookTitle.ToLower().Contains(keyword) ||
                    b.Author.ToLower().Contains(keyword) ||
                    b.Status.ToLower().Contains(keyword) ||
                    b.ISBN.ToLower().Contains(keyword)  // <-- Added ISBN search
                ).ToList();
            }

            dataGridView1.DataSource = listData;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        private int bookID = 0;
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns[1].DefaultCellStyle.BackColor = Color.LightYellow; // example
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                bookID = Convert.ToInt32(row.Cells["ID"].Value);

                addBooks_bookTitle.Text = row.Cells["BookTitle"].Value?.ToString();
                addBooks_author.Text = row.Cells["Author"].Value?.ToString();
                addBook_ISBN.Text = row.Cells["ISBN"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["Published"].Value?.ToString(), out DateTime publishedDate))
                {
                    addBooks_published.Value = publishedDate;
                }
                else
                {
                    addBooks_published.Value = DateTime.Today;
                }

                string imgPath = row.Cells["image"].Value?.ToString();
                if (!string.IsNullOrEmpty(imgPath) && File.Exists(imgPath))
                {
                    addBooks_picture.Image = Image.FromFile(imgPath);
                    imagePath = imgPath;
                }
                else
                {
                    addBooks_picture.Image = null;
                    imagePath = null;
                }

                addBooks_status.Text = row.Cells["Status"].Value?.ToString();

                if (int.TryParse(row.Cells["Copies"].Value?.ToString(), out int copies))
                {
                    txtCopies.Text = copies.ToString();
                }
                else
                {
                    txtCopies.Text = string.Empty;
                }
            }
        }

        private void addBooks_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void addBooks_updateBtn_Click(object sender, EventArgs e)
        {
            if (addBooks_bookTitle.Text == "" || addBooks_author.Text == "" || addBooks_status.Text == "")
            {
                MessageBox.Show("Please fill all required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (connect.State != ConnectionState.Open)
            {
                DialogResult check = MessageBox.Show("Update Book ID: " + bookID + "?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        connect.Open();
                        DateTime today = DateTime.Today;

                        string updateQuery = "UPDATE books SET book_title = @Title, author = @Author, published_date = @PublishedDate, status = @Status, isbn = @ISBN, date_update = @DateUpdate WHERE id = @ID";

                        using (SqlCommand cmd = new SqlCommand(updateQuery, connect))
                        {
                            cmd.Parameters.AddWithValue("@Title", addBooks_bookTitle.Text.Trim());
                            cmd.Parameters.AddWithValue("@Author", addBooks_author.Text.Trim());
                            cmd.Parameters.AddWithValue("@PublishedDate", addBooks_published.Value);
                            cmd.Parameters.AddWithValue("@Status", addBooks_status.Text.Trim());
                            cmd.Parameters.AddWithValue("@DateUpdate", today);
                            cmd.Parameters.AddWithValue("@ID", bookID);
                            cmd.Parameters.AddWithValue("@ISBN", addBook_ISBN.Text.Trim());


                            cmd.ExecuteNonQuery();
                        }

                        displayBooks();
                        MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void addBooks_deleteBtn_Click(object sender, EventArgs e)
        {
            if (bookID == 0)
            {
                MessageBox.Show("Please select a book to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult check = MessageBox.Show("Delete Book ID: " + bookID + "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (check == DialogResult.Yes)
            {
                try
                {
                    connect.Open();
                    DateTime today = DateTime.Today;

                    string deleteQuery = "UPDATE books SET date_delete = @DateDelete WHERE id = @ID";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@DateDelete", today);
                        cmd.Parameters.AddWithValue("@ID", bookID);

                        cmd.ExecuteNonQuery();
                    }

                    displayBooks();
                    MessageBox.Show("Book deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

   
 

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            displayBooks(searchTextBox.Text.Trim());
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            displayBooks(); // Reload all books without any filter
        }

    }
}
