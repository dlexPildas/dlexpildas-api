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
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> AddReminder(ReminderCreateDto reminderDto)
        {
            try
            {
                var reminder = _mapper.Map<Reminder>(reminderDto);

                await _reminderService.AddReminder(reminder);

                return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "There was an error to create a reminder :(");
            }
        }


        /// <summary>
        /// Method to update a reminder
        /// </summary>
        /// <param name="reminderUpdateDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateReminder(ReminderUpdateDto reminderUpdateDto)
        {
            try
            {
                var reminderExists = _dataContext.Reminders
                    .AsNoTracking()
                    .FirstOrDefault(x => x.Id == reminderUpdateDto.Id);

                if (reminderExists == null)
                    return NotFound("Reminder not found!");

                var reminder = _mapper.Map<Reminder>(reminderUpdateDto);

                await _reminderService.UpdateReminder(reminder);

                return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "There was an error to update a reminder :(");
            }
        }

        /// <summary>
        /// Method to delete a specific reminder by Id
        /// </summary>
        /// <param name="id">Reminder's Id that will be deleted</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReminder(int id)
        {
            try
            {
                var reminderExists = _dataContext.Reminders
                    .FirstOrDefault(x => x.Id == id);

                if (reminderExists == null)
                    return NotFound("Reminder not found!");

                await _reminderService.DeleteReminder(reminderExists);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
                    .OrderBy(x => x.ReminderDate)
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
            try
            {
                var reminder = _dataContext.Reminders
                .FirstOrDefault(x => x.Id == id);

                if (reminder == null)
                    return NotFound("Reminder not found!");

                return Ok(reminder);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "There was an error to update a reminder :(");
            }
        }

    }
}