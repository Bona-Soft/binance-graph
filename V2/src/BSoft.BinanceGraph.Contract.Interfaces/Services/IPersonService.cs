// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BSoft.BApp.Services;
using BSoft.DemoApp.Manager.Models.ProofOfConcept;

namespace BSoft.DemoApp.Services.Interfaces
{
    public interface IPersonService : IBaseService
    {
        Task<PersonDto> AddPersonAsync(AddPersonDto personDto);

        Task<IEnumerable<PersonDto>> GetAllPersonsAsync();

        Task<PersonDto> GetPersonAsync(Guid personId);

        Task<PersonDto> RemovePersonAsync(Guid personId);

        Task<PersonDto> UpdatePersonAsync(PersonDto personDto);
    }
}
