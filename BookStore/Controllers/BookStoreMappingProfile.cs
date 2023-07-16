using AutoMapper;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class BookStoreMappingProfile : Profile
    {
        public BookStoreMappingProfile()
        {
            CreateMap<CreateBook, CreateBookDto>()
                //.ForMember(m => m.Id, c => c.MapFrom(s => s.Id))
                .ForMember(m => m.Title, c => c.MapFrom(s => s.Title))
                .ForMember(m => m.FirstNameOfAuthor, c => c.MapFrom(s => s.FirstNameOfAuthor))
                .ForMember(m => m.LastNameOfAuthor, c => c.MapFrom(s => s.LastNameOfAuthor))
                .ForMember(m => m.Species, c => c.MapFrom(s => s.Species))
                .ForMember(m => m.NumberOfPages, c => c.MapFrom(s => s.NumberOfPages))
                .ForMember(m => m.Rating, c => c.MapFrom(s => s.Rating))
                .ForMember(m => m.PublicationDate, c => c.MapFrom(s => s.PublicationDate));
            CreateMap<CreateBookDto, CreateBook>()
                .ForMember(m => m.Title, c => c.MapFrom(s => s.Title))
                .ForMember(m => m.FirstNameOfAuthor, c => c.MapFrom(s => s.FirstNameOfAuthor))
                .ForMember(m => m.LastNameOfAuthor, c => c.MapFrom(s => s.LastNameOfAuthor))
                .ForMember(m => m.Species, c => c.MapFrom(s => s.Species))
                .ForMember(m => m.NumberOfPages, c => c.MapFrom(s => s.NumberOfPages))
                 .ForMember(m => m.Rating, c => c.MapFrom(s => s.Rating))
                .ForMember(m => m.PublicationDate, c => c.MapFrom(s => s.PublicationDate));
            CreateMap<ReviewDto, Review>()
              .ForMember(m => m.Content, c => c.MapFrom(s => s.Content));
            CreateMap<Review, ReviewDto>()
          .ForMember(m => m.Content, c => c.MapFrom(s => s.Content));

            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();

            CreateMap<CreateBook, CreateBookDto>();
            CreateMap<CreateBookDto, CreateBook>();

        }
    }

}
