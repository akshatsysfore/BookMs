using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Model
{
    public class Author
    {
        public Author(AuthorDto auth)
        {
            this.FirstName = auth.FirstName;
            this.LastName = auth.LastName;
            this.Biography = auth.Biography;
            //this.Birthdate = auth.Birthdate;
            this.Country = auth.Country;
            this.CreatedDate = DateTime.Now;
            this.LastUpdated = DateTime.Now;
            AuthorId = Guid.NewGuid();
        }
        public Author()
        {
            AuthorId = Guid.NewGuid();

        }
        public Guid AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Biography { get; set; }
    //public DateOnly Birthdate { get; set; }
    public string Country { get; set; }
    public DateTime LastUpdated { get; set; }
    public DateTime CreatedDate { get; set; }
    }
}
