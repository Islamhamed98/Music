using GigsHub.Models;
using GigsHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GigsHub.Controllers
{
    public class GigsController : Controller
    {
        private ApplicationDbContext _context;
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Gigs
        [Authorize]
        public ActionResult Create()
        {
            var GigViewModel = new GigFormViewModel()
            {
               Genres = _context.Genres.ToList() 
            };           
            return View(GigViewModel);
        } 

        // POST: Gig
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel GigViewModel)
        {
            if (!ModelState.IsValid)
            {
                GigViewModel.Genres = _context.Genres.ToList(); 
                return View("Create", GigViewModel);
            }

            var gig = new Gig()
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = GigViewModel.GetDateTime(),
                GenreId = GigViewModel.Genre,
                Venue = GigViewModel.Venue
            }; 
            
            _context.Gigs.Add(gig);
            _context.SaveChanges();  
            
            return RedirectToAction("Index", "Home");
        }


    }
}