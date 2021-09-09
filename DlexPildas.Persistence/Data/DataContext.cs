using DlexPildas.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DlexPildas.Persistence.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Article> Articles { get; set; }

    }
}