using System.Threading.Tasks;
using DlexPildas.Domain.Models;
using DlexPildas.Persistence.Contracts;

namespace DlexPildas.Application.Services.ReminderAggregate
{
    public class ReminderService : IReminderService
    {
        private readonly IPersist _persist;
        
        public ReminderService(IPersist persist)
        {
            _persist = persist;
        }

        public async Task<bool> AddReminder(Reminder reminder)
        {
            _persist.Add<Reminder>(reminder);

            return await _persist.SaveChangesAsync();
        }

        public async Task<bool> DeleteReminder(Reminder reminder)
        {
            _persist.Delete<Reminder>(reminder);

            return await _persist.SaveChangesAsync();
        }

        public async Task<bool> UpdateReminder(Reminder reminder)
        {
            _persist.Update<Reminder>(reminder);

            return await _persist.SaveChangesAsync();
        }
    }
}