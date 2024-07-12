using AutoMapper;
using CleanArchitecture.Application.Books.Commands.CreateBook;
using CleanArchitecture.Application.Books.Commands.UpdateBook;
using CleanArchitecture.Application.Books.Queries.GetAllBook;
using CleanArchitecture.Application.Books.Queries.GetBookById;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;


namespace CleanArchitecture.Application.Common.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookDTO, Book>()
             .ForMember(dest => dest.BookId, opt => opt.Ignore())
             .ForMember(dest => dest.BookTitle, opt => opt.Ignore())
             .ForMember(dest => dest.BookDescription, opt => opt.Ignore())
             .ForMember(dest => dest.BookAuthor, opt => opt.Ignore())
             .ForMember(dest => dest.BookPrice, opt => opt.Ignore())
             .ReverseMap();

            CreateMap<CreateBookCommand, BookDTO>()
             .ForMember(dest => dest.BookId, opt => opt.Ignore())
             .ForMember(dest => dest.BookTitle, opt => opt.Ignore())
             .ForMember(dest => dest.BookDescription, opt => opt.Ignore())
             .ForMember(dest => dest.BookAuthor, opt => opt.Ignore())
             .ForMember(dest => dest.BookPrice, opt => opt.Ignore());


            CreateMap<UpdateBookCommand, Book>()
             .ForMember(dest => dest.BookId, opt => opt.Ignore())
            .ForMember(dest => dest.BookTitle, opt => opt.Ignore())
            .ForMember(dest => dest.BookDescription, opt => opt.Ignore())
            .ForMember(dest => dest.BookAuthor, opt => opt.Ignore())
            .ForMember(dest => dest.BookPrice, opt => opt.Ignore())
            .ConvertUsing(new NullValueIgnoringConverter<UpdateBookCommand, Book>());
        }
    }
}
