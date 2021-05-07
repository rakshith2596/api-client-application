using Library.Helper.Stored_Procedures;
using Library.Models.BookModel;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services.BookService
{
    public class BookService : IBookService
    {
        String connectionString = @"data source=CSG-LPTP-62\MSSQLSERVER01;initial catalog = Library; user id = sa; password=Rakshith98;MultipleActiveResultSets=True";
        private readonly ILogger _logger;
        public BookService(ILogger<BookService> logger)
        {
            _logger = logger;
        }
        public bool AddBookData(BookModel book)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Constants.Book.SP.CreateBook, connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue(Constants.Book.DBColumns.BookId, book.BookID);
                    sqlCommand.Parameters.AddWithValue(Constants.Book.DBColumns.Title, book.Title);
                    sqlCommand.Parameters.AddWithValue(Constants.Book.DBColumns.Author, book.Author);
                    sqlCommand.Parameters.AddWithValue(Constants.Book.DBColumns.Price, book.Price);
                    sqlCommand.Parameters.AddWithValue(Constants.Book.DBColumns.Genre, book.Genre);
                    sqlCommand.ExecuteNonQuery();
                    _logger.LogInformation("Book Successfully added to Database");
                    return true;
                }
                catch
                {
                    _logger.LogError("Failed to add the book");
                    return false;
                }
                finally
                {
                    _logger.LogInformation("Connection Closed");
                    connection.Close();
                }
            }
        }

        public List<BookModel> GetAllBooks()
        {
            List<BookModel> bookList = new List<BookModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Constants.Book.SP.GetAllBooks, connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        BookModel book = new BookModel();
                        book.BookID = reader.GetInt32(0);
                        book.Title = reader.GetString(1);
                        book.Author = reader.GetString(2);
                        book.Price = reader.GetInt32(3);
                        book.Genre = reader.GetString(4);
                        bookList.Add(book);
                    }
                    _logger.LogInformation("Books retrieved successfully");
                    return bookList;
                }
                catch
                {
                    _logger.LogError("Failed to add the book");
                    return null;
                }
                finally
                {
                    _logger.LogInformation("Connection Closed");
                    connection.Close();
                }
            }
        }

        public BookModel GetBookDetailsByID(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Constants.Book.SP.GetBookById, connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("BookID", id);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    BookModel book = new BookModel();
                    while (reader.Read())
                    {
                        book.BookID = reader.GetInt32(0);
                        book.Title = reader.GetString(1);
                        book.Author = reader.GetString(2);
                        book.Price = reader.GetInt32(3);
                        book.Genre = reader.GetString(4);
                    }
                    _logger.LogInformation("Book for id " + id + "retrieved successfully");
                    return book;
                }
                catch
                {
                    _logger.LogError("Failed to add the book");
                    return null;
                }
                finally
                {
                    _logger.LogInformation("Connection Closed");
                    connection.Close();
                }
            }
        }
    }
}
