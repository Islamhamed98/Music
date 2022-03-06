using AutoMapper;
using GigsHub.Dtos;
using GigsHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigsHub.App_Start
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {

            Mapper.CreateMap<Gig, GigDto>();
            Mapper.CreateMap<Notification, NotificationDto>();
            Mapper.CreateMap<ApplicationUser, UserDto>();

        }
    }
}