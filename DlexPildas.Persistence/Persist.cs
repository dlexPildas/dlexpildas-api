using System.Threading.Tasks;
using DlexPildas.Persistence.Contracts;

namespace DlexPildas.Persistence.Data
{
    public class Persist : IPersist
    {
        private readonly DataContext _dataContext;

        public Persist(DataContext dataContext)
        {
            _dataContext = dataContext;

        }

        public void Add<T>(T entity) where T : class
        {
            _dataContext.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _dataContext.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _dataContext.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            _dataContext.RemoveRange(entity);
        }
        

        public async Task<bool> SaveChangesAsync()
        {
            return (await _dataContext.SaveChangesAsync()) > 0;
        }

       
    }
}