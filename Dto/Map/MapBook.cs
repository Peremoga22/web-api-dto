

using DataAccess.Models;

using Dto.ModelsDto;

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Dto.Map
{
    public static class MapBook
    {
        public static Book Map(this BookDto val)
        {
            var res = new Book();
            res.Id = val.Id;
            res.Name = val.Name;
            res.Author = val.Author;
            res.Image = val.Image;
            return res;
        }

        public static BookDto Map(this Book val)
        {
            var res = new BookDto();
            res.Id = val.Id;
            res.Name = val.Name;
            res.Author = val.Author;
            res.Image = val.Image;
            return res;
        }
    }
}
