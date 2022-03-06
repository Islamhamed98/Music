using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigsHub.Models
{
    public class Notification
    {
         
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType NotificationType { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        [Required]
        public Gig Gig { get; private set; }

        protected Notification() { }
        private Notification(Gig gig,NotificationType notificationType)
        {
            if (gig == null)
                throw new ArgumentNullException("gig");

            Gig = gig;
            DateTime = DateTime.Now;
            NotificationType = notificationType;
        }

        public static Notification GigCreated(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCreated);
        }
        public static Notification GigCanceled(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCancled);
        }
        public static Notification GigUpdated(Gig newGig,DateTime dateTime,string venue)
        {
            var notification = new Notification(newGig, NotificationType.GigUpdated);
            notification.DateTime = dateTime;
            notification.OriginalVenue = venue;

            return notification;
        }

    }
}