using System.Collections.Generic;
using AutoMapper;
using IdentityAPI.DTOs;
using IdentityAPI.Models;

namespace IdentityAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDTO>();
            CreateMap<ApplicationUserDTO, ApplicationUser>();
        }
    }
}