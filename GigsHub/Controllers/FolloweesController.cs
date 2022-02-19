using GigsHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GigsHub.Controllers
{
    public class FolloweesController : Controller
    {
        private ApplicationDbContext _context;
        public FolloweesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Followees
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var myFollowees = _context.Followings.Where(f => f.FollowerId == userId)
                    .Select(f => f.Followee).ToList();

            return View(myFollowees);
        }
    }
}