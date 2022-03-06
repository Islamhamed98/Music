using GigsHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigsHub.Dtos
{
    public class NotificationDto
    {
        public DateTime DateTime { get; private set; }
        public NotificationType NotificationType { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        public GigDto Gig { get; private set; }
    } 

}