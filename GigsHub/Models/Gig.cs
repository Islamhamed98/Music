using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GigsHub.Models
{
    public class Gig
    {
        public int Id { get; set; }
        public bool IsCanceled { get; private set; }
        public ApplicationUser Artist { get; set; }
        [Required]
        public string ArtistId { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        [StringLength(255)]
        public string Venue { get; set; }
        public Genre Genre { get; set; }
        [Required]
        public int GenreId { get; set; }

        public ICollection<Attendance> Attendances { get;set;}
        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }

        public void Cancel()
        {
            
            this.IsCanceled = true;
            
            var notification = Notification.GigCanceled(this);

            foreach (var attendee in  Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

             

        public void Modify(string venue, DateTime dateTime, int genre)
        {
            var notification = Notification.GigUpdated(this, this.DateTime, this.Venue);
             
            this.DateTime = dateTime;
            this.Venue = venue;
            GenreId = genre;

            foreach(var attendee in Attendances.Select(a=>a.Attendee))
            {
                attendee.Notify(notification);
            }

        }
    } 
        
}