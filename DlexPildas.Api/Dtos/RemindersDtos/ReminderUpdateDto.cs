using System;

namespace DlexPildas.Api.Dtos.RemindersDtos
{
    public class ReminderUpdateDto
    {
        public int Id { get; set; }
        public DateTime ReminderDate { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}