using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    class DataIssueBooks
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G6B9LKR;Initial Catalog=library;Integrated Security=True;Connect Timeout=30");



            public string RollNo { get; set; }
            public string ISBN { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string BookTitle { get; set; }
            public string Author { get; set; }
            public DateTime DateIssue { get; set; }
            public DateTime DateReturn { get; set; }
            public string Status { get; set; }
            public string ImagePath { get; set; }
            public decimal Fine { get; set; } // <== make sure this is here


        public List<DataIssueBooks> IssueBooksData()
        {
            List<DataIssueBooks> listData = new List<DataIssueBooks>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    // Filter only issued books
                    string selectData = "SELECT * FROM issues WHERE status = 'Issued' AND date_delete IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            try
                            {
                                DataIssueBooks data = new DataIssueBooks();

                                data.ISBN = reader["ISBN"].ToString();
                                data.Name = reader["full_name"].ToString();
                                data.RollNo = reader["rollno"].ToString();
                                data.Email = reader["email"].ToString();
                                data.BookTitle = reader["book_title"].ToString();
                                data.Author = reader["author"].ToString();
                                data.DateIssue = Convert.ToDateTime(reader["issue_date"]);
                                data.DateReturn = Convert.ToDateTime(reader["return_date"]);
                                data.Status = reader["status"].ToString();
                                data.ImagePath = reader["image"].ToString();
                                data.Fine = reader["fine"] != DBNull.Value ? Convert.ToDecimal(reader["fine"]) : 0;

                                listData.Add(data);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("DATA FETCH ERROR (Row Read): " + ex.Message);
                            }
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DATA FETCH ERROR (Connection or Query): " + ex.Message);
                }
                finally
                {
                    connect.Close();
                }
            }

            return listData;
        }

        internal List<DataIssueBooks> ReturnIssueBooksData()
        {
            List<DataIssueBooks> listData = new List<DataIssueBooks>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    // Updated query for returned books
                    string selectData = "SELECT * FROM issues WHERE status = 'Return' AND date_delete IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            try
                            {
                                DataIssueBooks dib = new DataIssueBooks();

                                // Now using ISBN instead of issue_id
                                dib.ISBN = reader["ISBN"].ToString();
                                dib.Name = reader["full_name"].ToString();
                                dib.RollNo = reader["rollno"].ToString();
                                dib.Email = reader["email"].ToString();
                                dib.BookTitle = reader["book_title"].ToString();
                                dib.Author = reader["author"].ToString();
                                dib.Fine = reader["fine"] != DBNull.Value ? Convert.ToInt32(reader["fine"]) : 0;
                                dib.DateIssue = reader["issue_date"] != DBNull.Value ? Convert.ToDateTime(reader["issue_date"]) : DateTime.MinValue;
                                dib.DateReturn = reader["return_date"] != DBNull.Value ? Convert.ToDateTime(reader["return_date"]) : DateTime.MinValue;

                                dib.Status = reader["status"].ToString();

                                listData.Add(dib);
                            }
                            catch (Exception ex)
                            {
                                // Catch field-level errors
                                MessageBox.Show("DATA FETCH ERROR (Row Read): " + ex.Message);
                            }
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    // Catch connection or query issues
                    MessageBox.Show("DATA FETCH ERROR (Connection or Query): " + ex.Message);
                }
                finally
                {
                    connect.Close();
                }
            }

            return listData;
        }


    }
}
