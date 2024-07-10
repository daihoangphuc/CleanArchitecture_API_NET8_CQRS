using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTOs
{
    public class BookDTO
   {
        public int BookId { get; set; }
        public string? BookTitle { get; set; }
        public string? BookDescription { get; set; }
        public string? BookAuthor { get; set; }
    }
}
