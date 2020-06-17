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

            CreateMap<Room, RoomDTO>();
            CreateMap<RoomDTO, Room>();

            CreateMap<Hotel, HotelDTO>();
            CreateMap<HotelDTO, Hotel>();
        }
    }
}