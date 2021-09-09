using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DlexPildas.Api.Dtos.RemindersDtos;
using DlexPildas.Application.Services.ReminderAggregate;
using DlexPildas.Domain.Models;
using DlexPildas.Persistence.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DlexPildas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReminderController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IReminderService _reminderService;
        private readonly IMapper _mapper;

        public ReminderController(
            DataContext dataContext,
            IReminderService reminderService,
            IMapper mapper)
        {
            _reminderService = reminderService;
            _mapper = mapper;
            _dataContext = dataContext;
        }


        /// <summary>
        /// Method to create a new reminder
        /// </summary>
        /// <param name="reminder">Object that represent a reminder</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateReminder(ReminderCreateDto reminderDto)
        {
            try
            {
                var reminder = _mapper.Map<Reminder>(reminderDto);

                await _reminderService.AddReminder(reminder);

                return this.StatusCode(StatusCodes.Status201Created, "Reminder was created with success!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "There was an error to create a reminder :(");
            }
        }

        /// <summary>
        /// Method to return all reminders registereds
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllReminders()
        {
            try
            {
                var reminders = _dataContext.Reminders
                    .ToList();

                return Ok(reminders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Method to return a specific reminder by id
        /// </summary>
        /// <param name="id">Id of a reminder</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetReminderById(int id)
        {
            return Ok("");
        }

    }
}