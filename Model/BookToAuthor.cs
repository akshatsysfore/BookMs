using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BookToAuthor
    {
        public BooksDto Books { get; set; }
        public List<Guid> AuthorIds { get; set; }
    }
}
