using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace WebApplication1.Pages.Books
{
    public class IndexModel : PageModel
    {
        public List<Book> BooksList=new List<Book>();
        public static string str = "hello";

        public class Book {
            public string Code, Name, Author, Publication;
            public Book(string code,string name,string author,string publication) {

                this.Code = code;
                this.Name = name;
                this.Author = author;
                this.Publication = publication;

            }
        }
        public void OnGet()
        {
            SqlConnection connection = new SqlConnection("Data Source=5CG9410FHX;Initial Catalog=LMS_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            connection.Open();
            string query = "select book_code,book_title,author,publication from LMS_BOOK_DETAILS;";
            SqlCommand command=new SqlCommand(query, connection);
            using(SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    BooksList.Add(new Book((string)reader["book_code"], (string)reader["book_title"], (string)reader["author"], (string)reader["publication"]));
                }
            }
            connection.Close();
        }
    }
}
