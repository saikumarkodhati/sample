using System;
using System.Collections.Generic;

#nullable disable

namespace DigitalBook.Models
{
    public partial class SearchBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string ReleasedDate { get; set; }
    }
}
