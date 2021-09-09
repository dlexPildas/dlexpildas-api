using System.Threading.Tasks;
using DlexPildas.Domain.Models;

namespace DlexPildas.Application.Services.ReminderAggregate
{
    public interface IReminderService
    {
        Task<bool> AddReminder(Reminder reminder);
        Task<bool> UpdateReminder(Reminder reminder);
        Task<bool> DeleteReminder(Reminder reminder);
    }
}