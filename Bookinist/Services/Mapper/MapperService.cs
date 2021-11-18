using Bookinist.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookinist.Services.Mapper
{
    public class MapperService:AutoMapper.Profile
    {
        public MapperService()
        {
            this.CreateMap<Bookinist.Models.Entity.Book, BookDTO>()
                .ForMember(m => m.Categories, option => option.Ignore())
                .ForMember(m => m.CategoryId, option => option.MapFrom(m => m.CategoryId))
                .ForMember(m => m.CategoryName, option => option.MapFrom(m => m.Category.Name))
                .ForMember(m => m.Name, option => option.MapFrom(m => m.Name))
                .ForMember(m => m.ShortDesc, option => option.MapFrom(m => m.ShortDesc))
                .ForMember(m => m.LongDesc, option => option.MapFrom(m => m.LongDesc))
                .ForMember(m => m.Price, option => option.MapFrom(m => m.Price))
                .ForMember(m => m.Author, option => option.MapFrom(m => m.Author))
                .ForMember(m => m.Id, option => option.MapFrom(m => m.Id))
                .ForMember(m => m.ImageFile, option => option.Ignore())
                .ForMember(m => m.ImageName, option => option.MapFrom(m => m.Image))
                .ForMember(m => m.CreatedAt, option => option.MapFrom(m => m.CreatedAt))
                .ForMember(m => m.UpdatedAt, option => option.MapFrom(m => m.UpdatedAt))
                .ForMember(m => m.UserId, option => option.MapFrom(m => m.UserId))
                .ForMember(m => m.UserName, option => option.MapFrom(m => m.User.UserName))
                .ReverseMap()
                .ForMember(m => m.CategoryId, option => option.MapFrom(m => m.CategoryId))
                .ForMember(m => m.ShortDesc, option => option.MapFrom(m => m.ShortDesc))
                .ForMember(m => m.LongDesc, option => option.MapFrom(m => m.LongDesc))
                .ForMember(m => m.Author, option => option.MapFrom(m => m.Author))
                .ForMember(m => m.Price, option => option.MapFrom(m => m.Price))
                .ForMember(m => m.Name, option => option.MapFrom(m => m.Name))
                .ForMember(m => m.Id, option => option.MapFrom(m => m.Id))
                .ForMember(m => m.Image, option => option.MapFrom(m => m.ImageName))
                .ForMember(m => m.CreatedAt, option => option.MapFrom(m => m.CreatedAt))
                .ForMember(m => m.UserId, option => option.MapFrom(m => m.UserId))
                .ForMember(m => m.UpdatedAt, option => option.MapFrom(m => m.UpdatedAt))
                .ForMember(m => m.User, option => option.Ignore());
        }
    }
}
