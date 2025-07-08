using AutoMapper;
using ReservationService.Application.Commands.CreateReservation;
using ReservationService.Application.DTOs;
using ReservationService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Reservation, ReservationDto>();
            CreateMap<CreateReservationCommand, Reservation>();
        }
    }
}
