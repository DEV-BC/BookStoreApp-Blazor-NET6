using AutoMapper;
using BookStoreApp.API.Data;
using BookStoreApp.API.DTOs.Author;
using BookStoreApp.API.DTOs.Book;
using BookStoreApp.API.DTOs.User;
using Microsoft.Build.Framework.Profiler;

namespace BookStoreApp.API.Configuration
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorCreateDto, Author>().ReverseMap();
            CreateMap<AuthorReadOnlyDto, Author>().ReverseMap();
            CreateMap<AuthorUpdateDto, Author>().ReverseMap();


            CreateMap<BookCreateDto, Book>().ReverseMap();
            CreateMap<BookUpdateDto, Book>().ReverseMap();
            CreateMap<Book, BookReadOnlyDto>()
                .ForMember(q => q.AuthorName, d => d.MapFrom(map => $"{map.Author.FirstName}{map.Author.LastName}"))
                .ReverseMap();

            CreateMap<Book, BookDetailsDto>()
                .ForMember(q => q.AuthorName, d => d.MapFrom(map => $"{map.Author.FirstName}{map.Author.LastName}"))
                .ReverseMap();


            CreateMap<ApiUser, UserDto>().ReverseMap();
        }
    }
}
