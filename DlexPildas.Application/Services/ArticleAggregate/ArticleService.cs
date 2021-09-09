using System.Threading.Tasks;
using DlexPildas.Domain.Models;
using DlexPildas.Persistence.Contracts;
using DlexPildas.Persistence.Data;

namespace DlexPildas.Application.Services.ArticleAggregate
{
    public class ArticleService : IArticleService
    {
        private readonly IPersist _persist;

        public ArticleService(IPersist persist)
        {
            _persist = persist;
        }

        public async Task<bool> AddArticle(Article article)
        {
            _persist.Add<Article>(article);

            return await _persist.SaveChangesAsync();
        }

        public async Task<bool> DeleteArticle(Article article)
        {
            _persist.Delete<Article>(article);

            return await _persist.SaveChangesAsync();
        }

        public async Task<bool> UpdateArticle(Article article)
        {
            _persist.Update<Article>(article);

            return await _persist.SaveChangesAsync();
        }
    }
}