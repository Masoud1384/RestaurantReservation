﻿using BusinessLogicLayer.Commands.Reservation;
using BusinessLogicLayer.IServices;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _reservationService.GetReservations();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _reservationService.GetReservation(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateReservationCommand reservationCommand)
        {
            int id = 0;
            var result = _reservationService.CreateReservation(reservationCommand,out id);
            if (result&&id>0)
            {
                string url = Url.Action(nameof(Get),"Reservation",new {Id = id },Request.Scheme);
                return Ok(url);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] UpdateReservationCommand reservationCommand)
        {
            int id = 0;
            if (!_reservationService.ReservationExists(r=>r.Id==reservationCommand.Id))
            {
                var create = new CreateReservationCommand(reservationCommand.NumberOfGuests, reservationCommand.ReservationTime, reservationCommand.SpecialRequests, reservationCommand.reservationStatus);
                var result = _reservationService.CreateReservation(create,out id);
            }
            else
            {
                var result = _reservationService.UpdateReservation(reservationCommand);
            }
            string url = Url.Action(nameof(Get), "Reservation", new { Id = id }, Request.Scheme);
            return Ok(url);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_reservationService.ReservationExists(r=>r.Id==id))
            {
                _reservationService.DeleteReservation(id);
                return Ok();
            }
            return BadRequest();
        }
    }
}
