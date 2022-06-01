// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using BSoft.BApp.Core.Automapper.Infrastructure;
using BSoft.BApp.Core.Automapper.Interfaces;
using BSoft.DemoApp.Entities;
using BSoft.DemoApp.Manager.Models.ProofOfConcept;

namespace BSoft.DemoApp.Manager.Infrastructure
{
    public class MapperProfile : BaseMapperProfile, IBaseMapperProfile
    {
        public MapperProfile()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.PersonId, mo => mo.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<AddPersonDto, Person>()
                .ForMember(dest => dest.Id, mo => mo.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.CreationDate, mo => mo.MapFrom(_ => DateTime.UtcNow));
        }
    }
}
