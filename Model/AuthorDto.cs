using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AuthorDto
    {
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use Letters Only Please")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use Letters Only Please")]
        public string LastName { get; set; }
        public string Biography { get; set; }
       // public DateOnly Birthdate { get; set; }
        public string Country { get; set; }
      }
}
