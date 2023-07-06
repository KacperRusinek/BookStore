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
                .ForMember(m => m.Id, c => c.MapFrom(s => s.Id))
                .ForMember(m => m.Title, c => c.MapFrom(s => s.Title))
                .ForMember(m => m.FirstNameOfAuthor, c => c.MapFrom(s => s.FirstNameOfAuthor))
                .ForMember(m => m.LastNameOfAuthor, c => c.MapFrom(s => s.LastNameOfAuthor))
                .ForMember(m => m.Species, c => c.MapFrom(s => s.Species))
                .ForMember(m => m.NumberOfPages, c => c.MapFrom(s => s.NumberOfPages))
                .ForMember(m => m.PublicationDate, c => c.MapFrom(s => s.PublicationDate));
            CreateMap<CreateBookDto, CreateBook>()
                .ForMember(m => m.Title, c => c.MapFrom(s => s.Title))
                .ForMember(m => m.FirstNameOfAuthor, c => c.MapFrom(s => s.FirstNameOfAuthor))
                .ForMember(m => m.LastNameOfAuthor, c => c.MapFrom(s => s.LastNameOfAuthor))
                .ForMember(m => m.Species, c => c.MapFrom(s => s.Species))
                .ForMember(m => m.NumberOfPages, c => c.MapFrom(s => s.NumberOfPages))
                .ForMember(m => m.PublicationDate, c => c.MapFrom(s => s.PublicationDate));

            //       CreateMap<UpdateBook, UpdateBookDto>()
            //.ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            //.ForMember(dest => dest.FirstNameOfAuthor, opt => opt.MapFrom(src => src.FirstNameOfAuthor))
            //.ForMember(dest => dest.LastNameOfAuthor, opt => opt.MapFrom(src => src.LastNameOfAuthor))
            //.ForMember(dest => dest.Species, opt => opt.MapFrom(src => src.Species))
            //.ForMember(dest => dest.NumberOfPages, opt => opt.MapFrom(src => src.NumberOfPages))
            //.ForMember(dest => dest.PublicationDate, opt => opt.MapFrom(src => src.PublicationDate));


            //CreateMap<RegisterUserDto, User>()
            //              .ForMember(m => m.Email, c => c.MapFrom(s => s.Email))
            //              .ForMember(m => m.DateOfBirth, c => c.MapFrom(s => s.DateOfBirth))
            //              .ForMember(m => m.Nationality, c => c.MapFrom(s => s.Nationality))
            //              .ForMember(m => m.RoleId, c => c.MapFrom(s => s.RoleId));

            CreateMap<UserDto, User>();

            CreateMap<CreateBook, CreateBookDto>();
            CreateMap<CreateBookDto, CreateBook>();

            CreateMap<Review, ReviewDto>()
              .ForMember(m => m.Content, c => c.MapFrom(s => s.Content))
              .ForMember(m => m.rating, c => c.MapFrom(s => s.rating))
              .ForMember(m => m.TitleOfBook, c => c.MapFrom(s => s.TitleOfBook));

            CreateMap<ReviewDto, Review>()
                .ForMember(m => m.Content, c => c.MapFrom(s => s.Content))
                .ForMember(m => m.rating, c => c.MapFrom(s => s.rating))
                .ForMember(m => m.TitleOfBook, c => c.MapFrom(s => s.TitleOfBook));








        }




    }
    
}
