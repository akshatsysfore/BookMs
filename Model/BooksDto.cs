using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BooksDto
    {
        public string Title { get; set; }

        public int GenreId { get; set; }

        public string Description { get; set; }

        public string ISBN { get; set; }

       // public DateOnly PublicationDate { set; get; }
        public int Price { get; set; }

        public string Language { get; set; }

        public string Publisher { get; set; }

        public float AvgRating { get; set; }

        public int PageCount { get; set; }

    }
}
