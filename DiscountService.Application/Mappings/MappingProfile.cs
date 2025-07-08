using AutoMapper;
using DiscountService.Application.Commands.CreateDiscount;
using DiscountService.Application.Commands.UpdateDiscount;
using DiscountService.Application.DTOs;
using DiscountService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountService.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Discount, DiscountDto>().ReverseMap();
            CreateMap<CreateDiscountCommand, Discount>();
            CreateMap<UpdateDiscountCommand, Discount>();
        }
    }
}
