using Microsoft.Data.SqlClient;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IDatabasecs
    {
        public void AddBook(BooksDto Books, List<Guid> authorId);
        public List<Books> GetBooks();

        public void UpdateBook(BooksDto Books, Guid bookid);

        public void AddAuthor(AuthorDto Authors);

        public List<Author> GetAuthor();

        public void UpdateAuthor(AuthorDto Auth, Guid authorid);

        public List<dynamic> Fetch(Guid BookId);
        public List<dynamic> SearchById(Guid BookId);
        public List<dynamic> SearchByTitle(String Title);

        public List<dynamic> AuthorsCreation(String name);

        public List<Genre> GetGenre();

        public void Addgenre(GenreDto genre);

        public void UpdateGenre(int id, string name);
    }
}