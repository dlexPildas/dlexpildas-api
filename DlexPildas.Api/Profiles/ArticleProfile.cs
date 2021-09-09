using AutoMapper;
using DlexPildas.Api.Dtos.ArticlesDtos;
using DlexPildas.Domain.Models;

namespace DlexPildas.Api.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleCreateDto>().ReverseMap();
            CreateMap<Article, ArticleUpdateDto>().ReverseMap();
        }
    }
}