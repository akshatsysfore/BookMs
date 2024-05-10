using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Genre
    {
        public Genre(GenreDto genre)
        {
            this.GenreName = genre.GenreName;
            this.CreatedDate = DateTime.Now;
            this.LastUpdated = DateTime.Now;
        }
        public Genre() { }

        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
