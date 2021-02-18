﻿using Application.DTO;
using AutoMapper;
using Data;

namespace Application.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(b => b.BookToTagsDTO, opt => opt.MapFrom(src => src.BookToTags))
                .ReverseMap();
        }
    }
}
