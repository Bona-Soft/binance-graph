// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BSoft.BApp.Services;
using BSoft.DemoApp.Contract.Errors;
using BSoft.DemoApp.Entities;
using BSoft.DemoApp.Services.Interfaces;
using BSoft.DemoApp.DataAccess.Infrastructure.Queries.ProofOfConcept;
using BSoft.DemoApp.DataAccess.Infrastructure.UnitOfWork;
using BSoft.DemoApp.Manager.Infrastructure.ServiceProviders;
using BSoft.DemoApp.Manager.Models.ProofOfConcept;
using BSoft.DemoApp.Manager.Services.Base;
using MGK.Acceptance;

namespace BSoft.DemoApp.Manager.Services.ProofOfConcept
{
    public class PersonService : BaseService<PersonService>, IPersonService
    {
        private readonly IDataAccessServiceProvider _dataAccessServiceProvider;

        public PersonService(
            IDataAccessServiceProvider dataAccessServiceProvider,
            IBaseInternalServices<PersonService> internalServices)
            : base(internalServices)
        {
            Ensure.Parameter.IsNotNull(dataAccessServiceProvider, nameof(dataAccessServiceProvider));

            _dataAccessServiceProvider = dataAccessServiceProvider;
        }

        private IPersonQueryConstructor PersonQueryConstructor
            => _dataAccessServiceProvider.Get<IPersonQueryConstructor>();

        private IProofOfConceptUoW ProofOfConceptUoW
            => _dataAccessServiceProvider.Get<IProofOfConceptUoW>();

        public async Task<PersonDto> AddPersonAsync(AddPersonDto addPersonDto)
        {
            Ensure.Parameter.IsNotNull(addPersonDto, nameof(addPersonDto));

            var person = await PersonQueryConstructor
                .Start()
                .FilterByDocumentNumber(addPersonDto.DocumentNumber)
                .GetRecordAsync();

            if (person != null)
            {
                throw Errors.PersonAlreadyExists.Error.Default(addPersonDto.DocumentNumber);
            }

            person = ProofOfConceptUoW.Add(Mapper.Map<Person>(addPersonDto));
            await ProofOfConceptUoW.CommitChangesAsync();

            return Mapper.Map<PersonDto>(person);
        }

        public async Task<IEnumerable<PersonDto>> GetAllPersonsAsync()
        {
            return await PersonQueryConstructor
                .Start()
                .OrderByFullName()
                .QueryAsArrayAsync<PersonDto>();
        }

        public async Task<PersonDto> GetPersonAsync(Guid personId)
        {
            return await PersonQueryConstructor
                .Start()
                .FilterById(personId)
                .GetRecordAsync<PersonDto>();
        }

        public async Task<PersonDto> RemovePersonAsync(Guid personId)
        {
            var personDto = await GetPersonAsync(personId);

            if (personDto == null)
            {
                throw Errors.PersonNotFound.Error.Default(personId);
            }

            ProofOfConceptUoW.RemoveByIds<Person>(personId);
            await ProofOfConceptUoW.CommitChangesAsync();

            return personDto;
        }

        public async Task<PersonDto> UpdatePersonAsync(PersonDto personDto)
        {
            Ensure.Parameter.IsNotNull(personDto, nameof(personDto));

            var person = await PersonQueryConstructor
                .Start()
                .FilterById(personDto.PersonId)
                .GetRecordAsync(true);

            if (person == null)
            {
                throw Errors.PersonAlreadyExists.Error.Default(personDto.PersonId);
            }

            person.Name = personDto.Name;
            person.Surname = personDto.Surname;
            person.LastUpdateDate = DateTime.UtcNow;

            await ProofOfConceptUoW.CommitChangesAsync();

            return Mapper.Map(person, personDto);
        }
    }
}
