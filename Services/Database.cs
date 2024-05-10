using Microsoft.Data.SqlClient;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Services
{
    public class database:IDatabasecs
    {
        private readonly string _databaseName = @"Data Source=192.168.10.28\SQLEX2017;Initial Catalog=Akshat;User Id=sysfore.ea;Password=Sys@2024#;Encrypt=false";
        public void AddBook(BooksDto Books, List<Guid> authorId)
        {
            using SqlConnection conn = new SqlConnection(_databaseName);
            conn.Open();
            var authorIdTable = new DataTable();
            authorIdTable.Columns.Add("AuthorID", typeof(Guid));
            foreach (var id in authorId)
            {
                authorIdTable.Rows.Add(id);
            }
            var storedproc = "addbookwithauthors";
            Books book = new Books(Books);
            //SqlCommand command = new SqlCommand(storedproc, conn);
            //command.CommandType = CommandType.StoredProcedure;
            DynamicParameters Parameters = new DynamicParameters();
            Parameters.Add("@BookId", book.BookId);
            Parameters.Add("@GenreId", book.GenreId);
            Parameters.Add("@Title", book.Title);
            Parameters.Add("@Description", book.Description);
            Parameters.Add("@ISBN", book.ISBN);
            //command.Parameters.Add("@PUBLICATIONDATE", SqlDbType.Date).Value = (book.PublicationDate);
            Parameters.Add("@Price", book.Price);
            Parameters.Add("@Language", book.Language);
            //Parameters.Add("@CREATEddate", book.CreatedDate);
            //Parameters.Add("@LastUpdated", book.LastUpdated);
            Parameters.Add("@Publisher", book.Publisher);
            Parameters.Add("@PageCount", book.PageCount);
            Parameters.Add("@AvgRating", book.AvgRating);
            Parameters.Add("@AuthorIds", authorIdTable.AsTableValuedParameter("AuthorIdListType"));
            var authors = conn.Query<Author>(storedproc, Parameters,commandType: CommandType.StoredProcedure).ToList();
            

            //int rowsAffected = command.ExecuteNonQuery();
            conn.Close();


        }
        public List<Books> GetBooks()
        {
            var storedproc = "GetAllBooks";
            using SqlConnection sqlConnection = new SqlConnection(_databaseName);
            using SqlCommand command = new SqlCommand(storedproc, sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();
            var BookVar = new List<Books>();
            while (reader.Read())
            {
                var eachbook = MapReaderToBook(reader);
                BookVar.Add(eachbook);
            }
            return BookVar;
        }
        private Books MapReaderToBook(SqlDataReader reader)
        {
            var book = new Books();
            book.BookId = reader.GetGuid(0);
            book.GenreId=reader.GetInt32(1);
            book.Title = reader.GetString(2);
            book.Description = reader.GetString(3);
            book.ISBN = reader.GetString(4);
            book.Price = reader.GetInt32(5);
            book.Language = reader.GetString(6);
            book.Publisher = reader.GetString(7);
            book.AvgRating = reader.GetFloat(8);
            book.PageCount = reader.GetInt32(9);
            book.LastUpdated = reader.GetDateTime(10);
            book.CreatedDate = reader.GetDateTime(11);

            return book;

        }
        public void UpdateBook(BooksDto book, Guid bookid)
        {
            using SqlConnection conn = new SqlConnection(_databaseName);
            conn.Open();
            var storedproc = "UPDATEBOOK";
            SqlCommand command = new SqlCommand(storedproc, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@BookID", SqlDbType.UniqueIdentifier).Value = (bookid);
            command.Parameters.Add("@GENREID", SqlDbType.Int).Value = (book.GenreId);
            command.Parameters.Add("@TITLE", SqlDbType.VarChar).Value = (book.Title);
            command.Parameters.Add("@DESCRIPTION", SqlDbType.Text).Value = (book.Description);
            command.Parameters.Add("@ISBN", SqlDbType.VarChar).Value = (book.ISBN);
            //command.Parameters.Add("@PUBLICATIONDATE", SqlDbType.Date).Value = (book.PublicationDate);
            command.Parameters.Add("@PRICE", SqlDbType.Int).Value = (book.Price);
            command.Parameters.Add("@LANGUAGE", SqlDbType.VarChar).Value = (book.Language);
            command.Parameters.Add("@PUBLISHER", SqlDbType.VarChar).Value = (book.Publisher);
            command.Parameters.Add("@PAGECOUNT", SqlDbType.Int).Value = (book.PageCount);
            command.Parameters.Add("@AVGRATING", SqlDbType.Float).Value = (book.AvgRating);
            command.Parameters.Add("@UPDATED_AT", SqlDbType.DateTime).Value = (DateTime.Now);

            int rowsAffected = command.ExecuteNonQuery();
        }
        public void AddAuthor(AuthorDto Authors)
        {
            using SqlConnection conn = new SqlConnection(_databaseName);
            conn.Open();
            var storedproc = "INSERTAUTHOR";
            Author Auth = new Author(Authors);
            SqlCommand command = new SqlCommand(storedproc, conn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@AuthorID", SqlDbType.UniqueIdentifier).Value = (Auth.AuthorId);
            command.Parameters.Add("@FIRSTNAME", SqlDbType.VarChar).Value = (Auth.FirstName);
            command.Parameters.Add("@LASTNAME", SqlDbType.VarChar).Value = (Auth.LastName);
            command.Parameters.Add("@BIOGRAPHY", SqlDbType.VarChar).Value = (Auth.Biography);
            command.Parameters.Add("@COUNTRY", SqlDbType.VarChar).Value = (Auth.Country);
            command.Parameters.Add("@CREATEddate", SqlDbType.DateTime).Value = (Auth.CreatedDate);
            command.Parameters.Add("@LastUpdated", SqlDbType.DateTime).Value = (Auth.LastUpdated);

            int rowsAffected = command.ExecuteNonQuery();
            conn.Close();


        }
        public List<Author> GetAuthor()
        {
            var storedproc = "GETALLAUTHOR";
            using SqlConnection sqlConnection = new SqlConnection(_databaseName);
             var authors = sqlConnection.Query<Author>(storedproc, commandType: CommandType.StoredProcedure).ToList();
            sqlConnection.Open();
            return authors;
        }
        public List<Genre> GetGenre()
        {
            var storedproc = "GETALLGenre";
            using SqlConnection sqlConnection = new SqlConnection(_databaseName);
            var genres = sqlConnection.Query<Genre>(storedproc, commandType: CommandType.StoredProcedure).ToList();
            sqlConnection.Open();
            return genres;
        }

        public void UpdateAuthor(AuthorDto Auth, Guid authorid)
        {
            using SqlConnection conn = new SqlConnection(_databaseName);
            conn.Open();
            var storedproc = "UPDATEAUTHOR";
            SqlCommand command = new SqlCommand(storedproc, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AUTHORID", SqlDbType.UniqueIdentifier).Value = (authorid);
            command.Parameters.Add("@FIRSTNAME", SqlDbType.VarChar).Value = (Auth.FirstName);
            command.Parameters.Add("@LASTNAME", SqlDbType.VarChar).Value = (Auth.LastName);
            command.Parameters.Add("@COUNTRY", SqlDbType.VarChar).Value = (Auth.Country);
            command.Parameters.Add("@BIOGRAPHY", SqlDbType.VarChar).Value = (Auth.Biography);
            command.Parameters.Add("@UPDATED_AT", SqlDbType.DateTime).Value = (DateTime.Now);
            int rowsAffected = command.ExecuteNonQuery();
        }

        public List<dynamic> Fetch(Guid BookId)
        {
            var storedproc = "FetchMappingValues";
            using SqlConnection sqlConnection = new SqlConnection(_databaseName);
            DynamicParameters Parameters = new DynamicParameters();
            Parameters.Add("@book_Id", BookId);
            var authors = sqlConnection.Query<dynamic>(storedproc,Parameters ,commandType: CommandType.StoredProcedure).ToList();
            sqlConnection.Open();
            return authors;
        }

        public void Addgenre(GenreDto genre)
        {
            using SqlConnection conn = new SqlConnection(_databaseName);
            conn.Open();
            var storedproc = "ADDGENRE";
            Genre genreobj = new Genre(genre);
            SqlCommand command = new SqlCommand(storedproc, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@GENRE", SqlDbType.VarChar).Value = (genreobj.GenreName);
            command.Parameters.Add("@CREATEddate", SqlDbType.DateTime).Value = (genreobj.CreatedDate);
            command.Parameters.Add("@LastUpdated", SqlDbType.DateTime).Value = (genreobj.LastUpdated);

            int rowsAffected = command.ExecuteNonQuery();
            conn.Close();


        }
        public void UpdateGenre(int id, string name)
        {
            var storedproc = "UPDATEGENRE";
            using SqlConnection sqlConnection = new SqlConnection(_databaseName);
            DynamicParameters Parameters = new DynamicParameters();
            Parameters.Add("@GenreId",id);
            Parameters.Add("@genre", name);
            var authors = sqlConnection.Query<dynamic>(storedproc, Parameters, commandType: CommandType.StoredProcedure).ToList();
            sqlConnection.Open();

        }
        public List<dynamic> SearchById(Guid BookId)
        {
            var storedproc = "SearchBookDetails";
            using SqlConnection sqlConnection = new SqlConnection(_databaseName);
            DynamicParameters Parameters = new DynamicParameters();
            Parameters.Add("@Bookid", BookId);
            var authors = sqlConnection.Query<dynamic>(storedproc, Parameters, commandType: CommandType.StoredProcedure).ToList();
            sqlConnection.Open();
            return authors;
        }
        public List<dynamic> SearchByTitle(String Title)
        {
            var storedproc = "SearchBookDetailsByTitle";
            using SqlConnection sqlConnection = new SqlConnection(_databaseName);
            DynamicParameters Parameters = new DynamicParameters();
            Parameters.Add("@search_keyword", Title);
            var authors = sqlConnection.Query<dynamic>(storedproc, Parameters, commandType: CommandType.StoredProcedure).ToList();
            sqlConnection.Open();
            return authors;
        }
        public List<dynamic> AuthorsCreation (String name)
        {
            var storedproc = "AuthorBook";
            using SqlConnection sqlConnection = new SqlConnection(_databaseName);
            DynamicParameters Parameters = new DynamicParameters();
            Parameters.Add("@search_keyword", name);
            var authors = sqlConnection.Query<dynamic>(storedproc, Parameters, commandType: CommandType.StoredProcedure).ToList();
            sqlConnection.Open();
            return authors;
        }
    }
}
