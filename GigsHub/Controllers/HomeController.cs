using GigsHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using GigsHub.ViewModels;

namespace GigsHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcomingGigs = _context.Gigs
                .Include(g => g.Artist)
                .Include(g=>g.Genre)
                .Where(g=>g.DateTime > DateTime.Now);

            var viewModel = new HomeViewModel
            {
                UpcomingGigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated
                
            };

            return View("Gig",viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Changes"; 
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page."; 
            return View();
        }
    }
}