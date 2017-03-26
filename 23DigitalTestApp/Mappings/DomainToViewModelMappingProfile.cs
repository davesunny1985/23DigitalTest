﻿using AutoMapper;
using DigitalTestApp.Core.Entities;
using DigitalTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalTestApp.Mappings
{
    public class DomainToViewModelMappingProfile:Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Product, ProductViewModel>();
        }
    }
}
