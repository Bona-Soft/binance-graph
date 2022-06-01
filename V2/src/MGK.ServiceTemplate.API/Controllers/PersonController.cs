// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BSoft.BApp.Core.Controller;
using BSoft.BApp.Core.Controller.Attribute;
using BSoft.BApp.Core.Controller.Interfaces;
using BSoft.BApp.Core.Infraestructure;
using BSoft.DemoApp.Contract.Errors;
using BSoft.DemoApp.Services.Interfaces;
using BSoft.DemoApp.API.Application.Requests;
using BSoft.DemoApp.API.Constants;
using BSoft.DemoApp.API.Models;
using BSoft.DemoApp.API.Models.ProofOfConcept;
using BSoft.DemoApp.Manager.Models.ProofOfConcept;
using Microsoft.AspNetCore.Mvc;

namespace BSoft.DemoApp.API.Controllers
{
    [Route(CoreConstants.ContextPath + "[controller]")]
    [ApiController]
    public class PersonController : BaseController<PersonController, IPersonService>
    {
        public PersonController(
            IBaseCommonControllerServices<PersonController> common)
            : base(common)
        {
        }

        /// <summary>
        /// Adds a person.
        /// </summary>
        /// <param name="request">Request with the person's information.</param>
        /// <returns>The person information.</returns>
        /// <response code="400">Invalid parameters provided.</response>
        /// <response code="409">Person already exists.</response>
        [HttpPost]
        [Route("add")]
        [ProducesResponseOk(typeof(PersonViewModel))]
        [ProducesResponseBaseError(Errors.PersonAlreadyExists.StatusCode)]
        [ProducesResponseBaseError(StatusCodes.Status400_BadRequest)]
        public async Task<IActionResult> AddPersonAsync([FromBody] AddPersonRequest request)
        {
            var dto = Map<AddPersonDto>(request);

            var result = await Service.AddPersonAsync(dto);

            return Ok(Map<PersonViewModel>(result));
        }

        /// <summary>
        /// Get all persons.
        /// </summary>
        /// <returns>The information of all persons.</returns>
        [HttpGet]
        [Route("all")]
        [ProducesResponseOk(typeof(IEnumerable<PersonViewModel>))]
        public async Task<IActionResult> GetAllPersonsAsync()
        {
            var personList = await Service.GetAllPersonsAsync();

            return Ok(Map<IEnumerable<PersonViewModel>>(personList));
        }

        /// <summary>
        /// Gets the information of one person.
        /// </summary>
        /// <param name="personId">The identification of the person.</param>
        /// <returns>The person information.</returns>
        [HttpGet]
        [Route("{personId}")]
        [ProducesResponseOk(typeof(PersonViewModel))]
        [ProducesResponseOk()]
        public async Task<IActionResult> GetPersonAsync(Guid personId)
        {
            var result = await Service.GetPersonAsync(personId);

            return Ok(result);
        }

        /// <summary>
        /// Removes the information of a person.
        /// </summary>
        /// <param name="personId">The identification of the person.</param>
        /// <returns>Information of the person removed.</returns>
        [HttpDelete]
        [Route("{personId}")]
        [ProducesResponseOk(typeof(ResponseViewModel))]
        [ProducesResponseBaseError(Errors.PersonNotFound.StatusCode)]
        public async Task<IActionResult> RemovePersonAsync(Guid personId)
        {
            var result = await Service.RemovePersonAsync(personId);

            return Ok(result);
        }

        /// <summary>
        /// Updates the person's information.
        /// </summary>
        /// <param name="personId">The identification of the person.</param>
        /// <param name="request">The requested data to update.</param>
        /// <returns>The updated information of the person.</returns>
        [HttpPut]
        [Route("{personId}")]
        [ProducesResponseOk(typeof(PersonViewModel))]
        [ProducesResponseBaseError(Errors.PersonNotFound.StatusCode)]
        public async Task<IActionResult> UpdatePersonAsync(Guid personId, [FromBody] UpdatePersonRequest request)
        {
            var dto = Map<PersonDto>(request);
            dto.PersonId = personId;

            var result = await Service.UpdatePersonAsync(dto);

            var response = Map<PersonViewModel>(result);

            return Ok(response);
        }
    }
}
