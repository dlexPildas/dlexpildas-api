using System.Threading.Tasks;
using DlexPildas.Persistence.Data;

namespace DlexPildas.Persistence.Contracts
{
    public interface IPersist
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;

        Task<bool> SaveChangesAsync();
    }
}