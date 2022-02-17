using GigsHub.Dtos;
using GigsHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigsHub.Controllers
{    

    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;
        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend([FromBody] AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();
            var exist = _context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId);
            if (exist) return BadRequest("Attendee is already exist");

            var attendance = new Attendance()
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
    
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }

    }
}
