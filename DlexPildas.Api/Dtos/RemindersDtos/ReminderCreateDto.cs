using System;

namespace DlexPildas.Api.Dtos.RemindersDtos
{
    public class ReminderCreateDto
    {
        public DateTime ReminderDate { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}