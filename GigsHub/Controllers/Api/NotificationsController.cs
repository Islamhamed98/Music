using GigsHub.Models;
using GigsHub.Dtos;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AutoMapper;

namespace GigsHub.Controllers.Api
{    
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;
         public NotificationsController()
        {
            _context = new ApplicationDbContext();
 
        }
        public IEnumerable<NotificationDto> GetNewNotification()
        { 
           string userId = User.Identity.GetUserId(); 

           var notifications = _context.UserNotifications.Where(u => u.UserId == userId && !u.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();

            return notifications.Select(Mapper.Map<Notification,NotificationDto>);
        }
     

    }
}
