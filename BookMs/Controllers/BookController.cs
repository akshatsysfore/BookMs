using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace BookMs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IDatabasecs sp;
        public BookController()
        {
            sp = new database();
        }
        [HttpPost]
        [Route("AddBooks")]
        public ActionResult Addbooks([FromBody] BookToAuthor mapper)
        {

               sp.AddBook(mapper.Books,mapper.AuthorIds);
            

            return Ok();
        }

        [HttpGet]
        [Route("GetBooks")]
        public ActionResult GetBooks()
        {
            return Ok(sp.GetBooks());
        }
        [HttpGet]
        [Route("FetchAuthor")]
        public ActionResult FetchAuthor(Guid bookid)
        {
            return Ok(sp.Fetch(bookid));
        }


        [HttpPost]
        [Route("UpdateBooks")]
        public ActionResult UPDATEBooks([FromBody] BooksDto books, Guid bookid)
        {

            sp.UpdateBook(books,bookid);


            return Ok();
        }
        [HttpPost]
        [Route("ADDAUTHORS")]
        public ActionResult AddAuthors([FromBody] AuthorDto authors)
        {

            sp.AddAuthor(authors);


            return Ok();
        }
        [HttpGet]
        [Route("GetAuthor")]
        public ActionResult GetAuthor()
        {
            return Ok(sp.GetAuthor());
        }
        [HttpPost]
        [Route("UpdateAuthor")]
        public ActionResult UPDATEAuthor([FromBody] AuthorDto Auths, Guid authorid)
        {

            sp.UpdateAuthor(Auths, authorid);


            return Ok();
        }
        [HttpGet]
        [Route("Search")]
        public ActionResult Search(Guid bookid)
        {
            return Ok(sp.SearchById(bookid));
        }

        [HttpGet]
        [Route("SearchbyTitle")]
        public ActionResult Title(string Title)
        {
            return Ok(sp.SearchByTitle(Title));
        }

        [HttpGet]
        [Route("Authorscreation")]
        public ActionResult Authorcreation(string name)
        {
            return Ok(sp.AuthorsCreation(name));
        }
        [HttpPost]
        [Route("ADDGENRE")]
        public ActionResult Addgenre([FromBody] GenreDto genre)
        {

            sp.Addgenre(genre);


            return Ok();
        }
        [HttpPost]
        [Route("UpdateGenre")]
        public ActionResult UPDATEGenre(int id,string name)
        {

            sp.UpdateGenre(id,name);


            return Ok();
        }
        [HttpGet]
        [Route("GetGenre")]
        public ActionResult getgenre()
        {
            return Ok(sp.GetGenre());
        }

    }
}
