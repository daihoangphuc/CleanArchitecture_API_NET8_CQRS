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
             .ForMember(dest => dest.BookTitle, opt => opt.Ignore())
             .ForMember(dest => dest.BookDescription, opt => opt.Ignore())
             .ForMember(dest => dest.BookAuthor, opt => opt.Ignore())
             .ReverseMap();

            CreateMap<CreateBookCommand, BookDTO>()
             .ForMember(dest => dest.BookTitle, opt => opt.Ignore())
             .ForMember(dest => dest.BookDescription, opt => opt.Ignore())
             .ForMember(dest => dest.BookAuthor, opt => opt.Ignore());


            CreateMap<UpdateBookCommand, Book>()
            .ForMember(dest => dest.BookTitle, opt => opt.Condition(src => src.BookTitle != null))
            .ForMember(dest => dest.BookDescription, opt => opt.Condition(src => src.BookDescription != null))
            .ForMember(dest => dest.BookAuthor, opt => opt.Condition(src => src.BookAuthor != null))
            .ConvertUsing(new NullValueIgnoringConverter<UpdateBookCommand, Book>());
        }
    }
}
