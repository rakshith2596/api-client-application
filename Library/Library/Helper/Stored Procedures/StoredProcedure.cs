using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Helper.Stored_Procedures
{
    public static class Constants
    {

        public static class Book
        {
            public static class DBColumns
            {
                public const string BookId = "BookID";
                public const string Title = "Title";
                public const string Author = "Author";
                public const string Price = "Price";
                public const string Genre = "Genre";

            }
            public static class SP
            {
                public const string CreateBook = "BookCreate_pr";
                public const string GetAllBooks = "GetAllBooks_pr";
                public const string GetBookById = "GetBookByID_pr";
            }
        }
    }
}
