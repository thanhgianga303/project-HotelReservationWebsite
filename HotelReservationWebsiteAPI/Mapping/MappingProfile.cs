using System.Collections.Generic;
using AutoMapper;
using HotelReservationWebsiteAPI.DTOs;
using HotelReservationWebsiteAPI.Models;

namespace HotelReservationWebsiteAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityDTO>();
            CreateMap<CityDTO, City>();

            CreateMap<RoomCategoryDTO, RoomCategory>();
            CreateMap<RoomCategory, RoomCategoryDTO>();

            CreateMap<Room, RoomDTO>();
            CreateMap<RoomDTO, Room>();

            CreateMap<Hotel, HotelDTO>();
            CreateMap<HotelDTO, Hotel>();

            // CreateMap<ApplicationUser, ApplicationUserDTO>();
            // CreateMap<ApplicationUserDTO, ApplicationUser>();
        }
    }
}