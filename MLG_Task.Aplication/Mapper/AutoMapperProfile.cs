using AutoMapper;
using MLG_Task.Dtos.Book;
using MLG_Task.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MLG_Task.Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<AddOrUpdateBookDto, Book>().ReverseMap();
            CreateMap<AddOrUpdateBookDto, BookDto>().ReverseMap();
            CreateMap<BookDto, Book>().ReverseMap();
        }
    }
}
