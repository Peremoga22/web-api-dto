using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.ModelsDto
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
    }
}
