using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class Teachers : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G6B9LKR;Initial Catalog=library;Integrated Security=True;Connect Timeout=30");

        public Teachers()
        {
            InitializeComponent();
            // Set header background color to black and text color to white
            addTeacher_gridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Black;
            addTeacher_gridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            addTeacher_gridView.EnableHeadersVisualStyles = false;

            addTeacher_gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            addTeacher_gridView.MultiSelect = false;

            DisplayTeacherData(); // Load on form start
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }

            DisplayTeacherData();
        }

        private void DisplayTeacherData(string keyword = "")
        {
            try
            {
                string query = "SELECT * FROM Teacher";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    keyword = keyword.ToLower();
                    var filteredRows = table.AsEnumerable().Where(row =>
                        row["CNIC"].ToString().ToLower().Contains(keyword) ||
                        row["FullName"].ToString().ToLower().Contains(keyword) ||
                        row["Gender"].ToString().ToLower().Contains(keyword) ||
                        row["Address"].ToString().ToLower().Contains(keyword) ||
                        row["DOB"].ToString().ToLower().Contains(keyword)
                    );

                    if (filteredRows.Any())
                        table = filteredRows.CopyToDataTable();
                    else
                        table.Rows.Clear(); // No matching results
                }

                addTeacher_gridView.DataSource = null;
                addTeacher_gridView.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading teacher data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addTeacher_addBtn_Click(object sender, EventArgs e)
        {
            if (addTeacher_cnic.Text == "" || addTeacher_name.Text == "" ||
                addTeacher_gender.Text == "" || addTeacher_address.Text == "")
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();

                    string insertQuery = "INSERT INTO Teacher (CNIC, FullName, DOB, Gender, Address, Image) " +
                                         "VALUES (@cnic, @name, @dob, @gender, @address, @image)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@cnic", addTeacher_cnic.Text.Trim());
                        cmd.Parameters.AddWithValue("@name", addTeacher_name.Text.Trim());
                        cmd.Parameters.AddWithValue("@dob", string.IsNullOrWhiteSpace(addTeacher_dob.Text)
                            ? DBNull.Value
                            : (object)DateTime.Parse(addTeacher_dob.Text));
                        cmd.Parameters.AddWithValue("@gender", addTeacher_gender.Text.Trim());
                        cmd.Parameters.AddWithValue("@address", addTeacher_address.Text.Trim());

                        // Check if an image has been selected
                        if (addTeacher_imagePicBox.Image != null)
                        {
                            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                            {
                                addTeacher_imagePicBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] imageBytes = ms.ToArray();
                                cmd.Parameters.Add("@image", SqlDbType.VarBinary).Value = imageBytes;
                            }
                        }
                        else
                        {
                            cmd.Parameters.Add("@image", SqlDbType.VarBinary).Value = DBNull.Value;
                        }


                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Teacher added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearFields();
                            refreshData(); // Reload the grid
                        }
                        else
                        {
                            MessageBox.Show("Failed to add teacher.", "Insert Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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

        public void clearFields()
        {
            addTeacher_cnic.Text = "";
            addTeacher_name.Text = "";
            addTeacher_dob.Text = "";
            addTeacher_gender.SelectedIndex = -1;
            addTeacher_address.Text = "";
            addTeacher_imagePicBox.Image = null; // Reset image
            addTeacher_cnic.Enabled = true;
        }

        private void addTeacher_deleteBtn_Click(object sender, EventArgs e)
        {
            if (addTeacher_gridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a teacher to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get selected row's CNIC
            string selectedCNIC = addTeacher_gridView.SelectedRows[0].Cells["CNIC"].Value.ToString();

            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete the teacher with CNIC: {selectedCNIC}?",
                                                   "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    connect.Open();
                    string deleteQuery = "DELETE FROM Teacher WHERE CNIC = @cnic";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@cnic", selectedCNIC);
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Teacher deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            refreshData();
                        }
                        else
                        {
                            MessageBox.Show("Deletion failed. Teacher not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void addTeacher_updateBtn_Click(object sender, EventArgs e)
        {
            if (addTeacher_gridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a teacher to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Basic validation
            if (addTeacher_cnic.Text == "" || addTeacher_name.Text == "" ||
                addTeacher_gender.Text == "" || addTeacher_address.Text == "")
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedCNIC = addTeacher_gridView.SelectedRows[0].Cells["CNIC"].Value.ToString();

            try
            {
                connect.Open();
                string updateQuery = "UPDATE Teacher SET FullName = @name, DOB = @dob, Gender = @gender, Address = @address, Image = @image WHERE CNIC = @cnic";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@cnic", selectedCNIC);
                    cmd.Parameters.AddWithValue("@name", addTeacher_name.Text.Trim());
                    cmd.Parameters.AddWithValue("@dob", string.IsNullOrWhiteSpace(addTeacher_dob.Text)
                        ? DBNull.Value
                        : (object)DateTime.Parse(addTeacher_dob.Text));
                    cmd.Parameters.AddWithValue("@gender", addTeacher_gender.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", addTeacher_address.Text.Trim());

                    // Check if an image has been selected
                    if (addTeacher_imagePicBox.Image != null)
                    {
                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                        {
                            addTeacher_imagePicBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            cmd.Parameters.AddWithValue("@image", ms.ToArray());
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@image", DBNull.Value);
                    }

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Teacher updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refreshData();
                        clearFields();
                    }
                    else
                    {
                        MessageBox.Show("Update failed. Teacher not found.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

  
        private void addTeacher_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void addTeacher_importBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Load the selected image into the PictureBox
                        addTeacher_imagePicBox.Image = new System.Drawing.Bitmap(openFileDialog.FileName);
                        addTeacher_imagePicBox.SizeMode = PictureBoxSizeMode.Zoom; // Optional: adjust image display
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message, "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void addTeacher_gridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = addTeacher_gridView.Rows[e.RowIndex];

                addTeacher_cnic.Text = row.Cells["CNIC"].Value.ToString(); // Primary key
                addTeacher_name.Text = row.Cells["FullName"].Value.ToString();
                addTeacher_dob.Text = row.Cells["DOB"].Value.ToString();
                addTeacher_gender.Text = row.Cells["Gender"].Value.ToString();
                addTeacher_address.Text = row.Cells["Address"].Value.ToString();

                // Image
                if (row.Cells["Image"].Value != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])row.Cells["Image"].Value;
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes))
                    {
                        addTeacher_imagePicBox.Image = System.Drawing.Image.FromStream(ms);
                    }
                }
                else
                {
                    addTeacher_imagePicBox.Image = null;
                }

                // Disable CNIC field to prevent editing (as it’s a primary key)
                addTeacher_cnic.Enabled = false;
            }
        }

        private void addTeacher_gridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = addTeacher_gridView.Rows[e.RowIndex];

                addTeacher_cnic.Text = row.Cells["CNIC"].Value.ToString(); // Primary key
                addTeacher_name.Text = row.Cells["FullName"].Value.ToString();
                addTeacher_dob.Text = row.Cells["DOB"].Value.ToString();
                addTeacher_gender.Text = row.Cells["Gender"].Value.ToString();
                addTeacher_address.Text = row.Cells["Address"].Value.ToString();

                // Image
                if (row.Cells["Image"].Value != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])row.Cells["Image"].Value;
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes))
                    {
                        addTeacher_imagePicBox.Image = System.Drawing.Image.FromStream(ms);
                    }
                }
                else
                {
                    addTeacher_imagePicBox.Image = null;
                }

                // Disable CNIC field to prevent editing (as it’s a primary key)
                addTeacher_cnic.Enabled = false;
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            DisplayTeacherData(searchTextBox.Text.Trim());
        }

    }
}
