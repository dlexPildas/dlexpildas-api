using System;

namespace DlexPildas.Domain.Models
{
    public class Reminder
    {
        public int Id { get; private set; }
        public DateTime ReminderDate { get; private set; }
        public string Description { get; private set; }
        public string Icon { get; private set; }

        public void Update(DateTime reminderDate, string description, string icon)
        {
            ReminderDate = reminderDate;
            Description = description;
            Icon = icon;
        }
    }
}