using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    class DataAddBooks
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G6B9LKR;Initial Catalog=library;Integrated Security=True;Connect Timeout=30");
        public int ID { set; get; }

        public string ISBN { get; set; }
        public int Copies { get; set; }

        public string BookTitle { set; get; }
        public string Author { set; get; }
        public string Published { set; get; }
        public string image { set; get; }
        public string Status { set; get; }

        public List<DataAddBooks> addBooksData()
        {
            List<DataAddBooks> listData = new List<DataAddBooks>();

            if (connect.State != ConnectionState.Open)
            {
                connect.Open();
            }

            try
            {
                string selectData = "SELECT id, book_title, author, published_date, image, status, copies, isbn FROM books WHERE date_delete IS NULL";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DataAddBooks data = new DataAddBooks();
                        data.ID = Convert.ToInt32(reader["id"]);
                        data.BookTitle = reader["book_title"].ToString();
                        data.Author = reader["author"].ToString();
                        data.Published = Convert.ToDateTime(reader["published_date"]).ToString("yyyy-MM-dd");
                        data.image = reader["image"].ToString();
                        data.Status = reader["status"].ToString();
                        data.Copies = Convert.ToInt32(reader["copies"]);
                        data.ISBN = reader["isbn"].ToString();


                        listData.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }

            return listData;
        }

    }
}
