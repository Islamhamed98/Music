using GigsHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigsHub.ViewModels
{
    public class GigFormViewModel
    {
        [Required]
        public string Venue { get; set; }
        [Required]
        [FutureDate]
        public string Date { get; set; }
        [Required]
        [ValidTime]
        public string Time { get; set; }
        [Required]
        public int Genre { get; set; }  
        public IEnumerable<Genre> Genres { get; set; }
        public DateTime GetDateTime () { 
             return DateTime.Parse(string.Format("{0},{1}", Date, Time)); 
        }
    }
}