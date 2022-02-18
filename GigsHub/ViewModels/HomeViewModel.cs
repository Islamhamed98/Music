using GigsHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigsHub.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public bool ShowActions { get; set;}
    }
}