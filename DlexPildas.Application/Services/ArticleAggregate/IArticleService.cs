using System.Threading.Tasks;
using DlexPildas.Domain.Models;

namespace DlexPildas.Application.Services.ArticleAggregate
{
    public interface IArticleService
    {
        Task<bool> AddArticle(Article article);
        Task<bool> UpdateArticle(Article article);
        Task<bool> DeleteArticle(Article article);
    }
}