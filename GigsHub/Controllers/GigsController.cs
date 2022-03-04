using GigsHub.Models;
using GigsHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                Genres = _context.Genres.ToList(),
                Heading = "Add a Gig"
            };           
            return View("GigForm", GigViewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _context.Gigs.Single(g => g.Id == id && g.ArtistId == userId);

            var GigViewModel = new GigFormViewModel()
            {   
                Heading = "Edit a Gig", 
                Genres = _context.Genres.ToList(),
                Date = gig.DateTime.ToString("d MMM yyyy"),
                Id=gig.Id,
                Time = gig.DateTime.ToString("HH:MM"),
                Genre = gig.GenreId,
                Venue = gig.Venue
            };
            return View("GigForm", GigViewModel);
        }
          
        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _context.Gigs
                            .Where(g => g.ArtistId == userId && g.DateTime > DateTime.Now && !g.IsCanceled)
                            .Include(g => g.Genre)
                            .ToList(); 
            return View(gigs);
        }
         
        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _context.Attendances.Where(a => a.AttendeeId == userId)
                .Select(a => a.gig)
                .Include(a => a.Artist)
                .Include(a => a.Genre).ToList();

            var viewModel = new HomeViewModel()
            {
                UpcomingGigs = gigs,
                ShowActions = User.Identity.IsAuthenticated
            }; 
            return View("Gig" , viewModel);
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
            
            return RedirectToAction("Mine", "Gigs");
        }
         
        // POST: Gig
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GigFormViewModel GigViewModel)
        {
            if (!ModelState.IsValid)
            {
                GigViewModel.Genres = _context.Genres.ToList();
                return View("GigForm", GigViewModel);   
            } 
            var userId = User.Identity.GetUserId();
            var gig = _context.Gigs.Single(g => g.Id == GigViewModel.Id && g.ArtistId == userId);
            gig.Venue = GigViewModel.Venue;
            gig.DateTime = GigViewModel.GetDateTime();
            gig.GenreId = GigViewModel.Genre;
             
            _context.SaveChanges();

            return RedirectToAction("Mine", "Gigs");
        }
         
    }
}