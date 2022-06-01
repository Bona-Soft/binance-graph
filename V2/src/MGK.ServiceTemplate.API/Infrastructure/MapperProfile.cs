// Copyright (c) BonaSoft, Inc. All rights reserved.

using AutoMapper;
using BSoft.BApp.Core.Automapper.Interfaces;
using BSoft.DemoApp.API.Application.Requests;
using BSoft.DemoApp.API.Models.ProofOfConcept;
using BSoft.DemoApp.Manager.Models.ProofOfConcept;

namespace BSoft.DemoApp.API.Infrastructure
{
    public class MapperProfile : Profile, IBaseMapperProfile
    {
        public MapperProfile()
        {

        }
    }
}
