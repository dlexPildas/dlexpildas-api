using AutoMapper;
using DlexPildas.Api.Dtos.RemindersDtos;
using DlexPildas.Domain.Models;

namespace DlexPildas.Api.Profiles
{
    public class ReminderProfile : Profile
    {
        public ReminderProfile()
        {
            CreateMap<Reminder, ReminderCreateDto>().ReverseMap();
        }

    }
}