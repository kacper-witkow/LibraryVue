using AutoMapper;
using Bibliotekarz.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bibliotekarz.Server.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookDto, Book>();
            CreateMap<Book, BookDto>();
        }
    }
}
