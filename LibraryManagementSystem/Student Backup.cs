using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;

namespace LibraryManagementSystem
{
    public partial class Student_Backup : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G6B9LKR;Initial Catalog=library;Integrated Security=True;Connect Timeout=30");

        public Student_Backup()

        {

            InitializeComponent();
            addStudent_gridView.CellClick += new DataGridViewCellEventHandler(addStudent_gridView_CellClick);
            // Set header background color to black and text color to white
            addStudent_gridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Black;
            addStudent_gridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            addStudent_gridView.EnableHeadersVisualStyles = false;
            addStudent_gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            addStudent_gridView.MultiSelect = false;

            refreshData(); // Load data on form startup
        }

        private bool IsValidEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

    


        private void addStudent_addBtn_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(addStudent_rollNo.Text) ||
                string.IsNullOrWhiteSpace(addStudent_name.Text) ||
                string.IsNullOrWhiteSpace(addStudent_phoneNo.Text) ||
                string.IsNullOrWhiteSpace(addStudent_email.Text) ||
                string.IsNullOrWhiteSpace(addStudent_department.Text) ||
                string.IsNullOrWhiteSpace(addStudent_semester.Text) ||
                string.IsNullOrWhiteSpace(addStudent_gender.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if phone number is 11 digits
            if (!Regex.IsMatch(addStudent_phoneNo.Text.Trim(), @"^\d{11}$"))
            {
                MessageBox.Show("Phone number must be exactly 11 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (!IsValidEmail(addStudent_email.Text.Trim()))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                connect.Open();

                string insertQuery = "INSERT INTO Student (EnrollmentID, FullName, PhoneNo, Email, Department, Semester, Gender, Image) " +
                                     "VALUES (@enrollmentId, @fullName, @phoneNo, @email, @department, @semester, @gender, @image)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@enrollmentId", addStudent_rollNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@fullName", addStudent_name.Text.Trim());
                    cmd.Parameters.AddWithValue("@phoneNo", addStudent_phoneNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", addStudent_email.Text.Trim());
                    cmd.Parameters.AddWithValue("@department", addStudent_department.Text.Trim());
                    cmd.Parameters.AddWithValue("@semester", addStudent_semester.Text.Trim());
                    cmd.Parameters.AddWithValue("@gender", addStudent_gender.Text.Trim());

                    // Optional image
                    if (addStudent_pictureBox.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            addStudent_pictureBox.Image.Save(ms, ImageFormat.Png);
                            cmd.Parameters.Add("@image", SqlDbType.VarBinary).Value = ms.ToArray();
                        }
                    }
                    else
                    {
                        cmd.Parameters.Add("@image", SqlDbType.VarBinary).Value = DBNull.Value;
                    }

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        refreshData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add student.", "Insert Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 2627 || sqlEx.Number == 2601) // Duplicate key
                {
                    MessageBox.Show("A student with this Enrollment ID or Email already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Database error: " + sqlEx.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                connect.Close();
            }
        }

        private void addStudent_updateBtn_Click_1(object sender, EventArgs e)
        {
            if (addStudent_gridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(addStudent_rollNo.Text) ||
      string.IsNullOrWhiteSpace(addStudent_name.Text) ||
      string.IsNullOrWhiteSpace(addStudent_phoneNo.Text) ||
      string.IsNullOrWhiteSpace(addStudent_email.Text) ||
      string.IsNullOrWhiteSpace(addStudent_department.Text) ||
      string.IsNullOrWhiteSpace(addStudent_semester.Text) ||
      string.IsNullOrWhiteSpace(addStudent_gender.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if phone number is 11 digits
            if (!Regex.IsMatch(addStudent_phoneNo.Text.Trim(), @"^\d{11}$"))
            {
                MessageBox.Show("Phone number must be exactly 11 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (!IsValidEmail(addStudent_email.Text.Trim()))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string selectedRollNo = addStudent_gridView.SelectedRows[0].Cells["EnrollmentID"].Value.ToString();


            try
            {
                connect.Open();

                string updateQuery = "UPDATE Student SET FullName = @fullName, PhoneNo = @phoneNo, Email = @email, " +
                                     "Department = @department, Semester = @semester, Gender = @gender, Image = @image " +
                                     "WHERE EnrollmentID = @enrollmentId";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connect))

                {
                    cmd.Parameters.AddWithValue("@enrollmentId", selectedRollNo);
                    cmd.Parameters.AddWithValue("@fullName", addStudent_name.Text.Trim());
                    cmd.Parameters.AddWithValue("@phoneNo", addStudent_phoneNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", addStudent_email.Text.Trim());
                    cmd.Parameters.AddWithValue("@department", addStudent_department.Text.Trim());
                    cmd.Parameters.AddWithValue("@semester", addStudent_semester.Text.Trim());
                    cmd.Parameters.AddWithValue("@gender", addStudent_gender.Text.Trim());



                    if (addStudent_pictureBox.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            addStudent_pictureBox.Image.Save(ms, ImageFormat.Png);
                            cmd.Parameters.Add("@image", SqlDbType.VarBinary).Value = ms.ToArray();
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@image", DBNull.Value);
                    }

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refreshData();
                        ClearFields();
                        addStudent_rollNo.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Update failed. Student not found.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void addStudent_deleteBtn_Click_1(object sender, EventArgs e)
        {
            if (addStudent_gridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedRollNo = addStudent_gridView.SelectedRows[0].Cells["EnrollmentID"].Value.ToString();

            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete the student with Roll No: {selectedRollNo}?",
                                                   "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    connect.Open();
                    string deleteQuery = "DELETE FROM Student WHERE EnrollmentID = @enrollmentId";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@enrollmentId", selectedRollNo);
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Student deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            refreshData();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Deletion failed. Student not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void addStudent_clearBtn_Click_1(object sender, EventArgs e)
        {
            ClearFields();
            addStudent_rollNo.Enabled = true;
        }

   
        private void addStudent_importBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select Student Image",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                try
                {
                    addStudent_pictureBox.Image = new Bitmap(imagePath);
                    addStudent_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    MessageBox.Show("Image imported successfully. Now click 'Add' to save the student.",
                                    "Image Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearFields()
        {
            addStudent_rollNo.Text = "";
            addStudent_name.Text = "";
            addStudent_phoneNo.Text = "";
            addStudent_email.Text = "";
            addStudent_department.Text = "";
            addStudent_semester.Text = "";
            addStudent_gender.SelectedIndex = -1;
            addStudent_pictureBox.Image = null;
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }

            DisplayStudentData();
            addStudent_rollNo.Enabled = true;
        }
  private void DisplayStudentData(string keyword = "")
        {
            try
            {
                string query = "SELECT * FROM Student";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    keyword = keyword.ToLower();
                    var filteredRows = table.AsEnumerable().Where(row =>
                        row["EnrollmentID"].ToString().ToLower().Contains(keyword) ||
                        row["FullName"].ToString().ToLower().Contains(keyword) ||
                        row["PhoneNo"].ToString().ToLower().Contains(keyword) ||
                        row["Email"].ToString().ToLower().Contains(keyword) ||
                        row["Department"].ToString().ToLower().Contains(keyword) ||
                        row["Semester"].ToString().ToLower().Contains(keyword) ||
                        row["Gender"].ToString().ToLower().Contains(keyword)
                    );

                    if (filteredRows.Any())
                        table = filteredRows.CopyToDataTable();
                    else
                        table.Rows.Clear(); // Show no rows if nothing matches
                }

                addStudent_gridView.DataSource = null;
                addStudent_gridView.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading student data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void addStudent_gridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = addStudent_gridView.Rows[e.RowIndex];

                addStudent_rollNo.Text = row.Cells["EnrollmentID"].Value.ToString();
                addStudent_name.Text = row.Cells["FullName"].Value.ToString();
                addStudent_phoneNo.Text = row.Cells["PhoneNo"].Value.ToString();
                addStudent_email.Text = row.Cells["Email"].Value.ToString();
                addStudent_department.Text = row.Cells["Department"].Value.ToString();
                addStudent_semester.Text = row.Cells["Semester"].Value.ToString();
                addStudent_gender.Text = row.Cells["Gender"].Value.ToString();

                // Load image from byte array
                if (row.Cells["Image"].Value != DBNull.Value)
                {
                    byte[] imageData = (byte[])row.Cells["Image"].Value;

                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        addStudent_pictureBox.Image = Image.FromStream(ms);
                        addStudent_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    addStudent_pictureBox.Image = null;
                }

                // Disable editing roll number during update
                addStudent_rollNo.Enabled = false;
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            DisplayStudentData(searchTextBox.Text.Trim());
        }

    }
}
