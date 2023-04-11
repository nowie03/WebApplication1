using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;

namespace WebApplication1.Pages.Books
{
    public class CreateBookModel : PageModel
    {
        public string ResultMessage="";
        public void OnGet()
        {
        }

        public async  void OnPost() {
            
                SqlConnection connection = new SqlConnection("Data Source=5CG9410FHX;Initial Catalog=LMS_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
                connection.Open();
                string bookCode = Request.Form["book-code"];
                string bookTitle = Request.Form["book-title"];
                string category = Request.Form["category"];
                string author = Request.Form["author"];
                string publication = Request.Form["publication"];
                string publishedDate = Request.Form["published-date"];
                string bookEdition = Request.Form["book-edition"];
                string price = Request.Form["price"];

                string rackNum = "a1";
                SqlDateTime dateArrival = new SqlDateTime(DateTime.Now);
                string supplierId = "s01";
                string query = $"insert into LMS_BOOK_DETAILS values('{bookCode}','{bookTitle}','{category}','{author}','{publication}','{publishedDate}','{bookEdition}',{price},'{rackNum}','{dateArrival}','{supplierId}');";

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    ResultMessage = ex.Message;
                }
                ResultMessage = "data inserted sucessfully";
                connection.Close();
            
            
        }
    }
}
