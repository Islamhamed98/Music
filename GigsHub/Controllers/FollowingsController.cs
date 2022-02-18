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
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;
        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow([FromBody] FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();
            var exist = _context.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == dto.followeeId);

            if(exist) return BadRequest("Something Failed"); 

            var follow = new Following()
            {
                FollowerId = userId,
                FolloweeId = dto.followeeId
            };

            _context.Followings.Add(follow);
            _context.SaveChanges(); 

            return Ok();
        }

    }
}
