using AutoMapper;
using ReservationService.Application.Commands.CreateReservation;
using ReservationService.Application.DTOs;
using ReservationService.Domain.Entities;

namespace ReservationService.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Reservation, ReservationDto>();
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<CreateReservationCommand, Reservation>();
        }
    }
}
