using System.Collections.Generic;
using AutoMapper;
using RoomCategoryAPI.DTOs;
using RoomCategoryAPI.Models;

namespace RoomCategoryAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RoomCategoryDTO, RoomCategory>();
            CreateMap<RoomCategory, RoomCategoryDTO>();
        }
    }
}