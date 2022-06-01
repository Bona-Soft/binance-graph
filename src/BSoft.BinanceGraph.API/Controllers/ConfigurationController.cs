using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BSoft.BinanceGraph.API.Constants;
using BSoft.BinanceGraph.API.Infrastructure;
using BSoft.BinanceGraph.Contract.Dto;
using BSoft.BinanceGraph.Contract.Interfaces.Manager;
using BSoft.BinanceGraph.Contract.ParamsDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BSoft.BinanceGraph.API.Controllers
{
    [Route(CoreConstants.ContextPath + "[controller]")]
    [ApiController]
    public class ConfigurationController : BaseController<ConfigurationController>
    {
        private readonly IApiConfigurationService _apiConfigService;

        public static class Routes
        {
            internal const string Get_AllApiConfiguration = "ApiConfigurations";
            internal const string Get_ApiConfiguration = "ApiConfiguration/{id}";
            internal const string Post_ApiConfiguration = "ApiConfiguration";
            internal const string Put_ApiConfiguration = "UpdateConfiguration";
            internal const string Delete_ApiConfiguration = "ApiConfiguration/{id}";
        }

        public ConfigurationController(
            ICommonControllerServices<ConfigurationController> commonControllerServices,
            IApiConfigurationService apiConfigService)
            : base(commonControllerServices)
        {
            _apiConfigService = apiConfigService;
        }

        /// <summary>
        /// Get all Api configured.
        /// </summary>
        /// <returns>All the apis in the sistem. This method should be and admin right only method.</returns>
        [HttpGet]
        [Route(Routes.Get_AllApiConfiguration)]
        [ProducesResponseType(typeof(IEnumerable<ApiConfigurationDto>), (int)HttpStatusCode.OK)]
        [SurroundException]
        public async Task<IActionResult> GetAllApiConfiguration()
        {
            var results = await _apiConfigService.GetAllConfigurations();
            return Ok(results);
        }

        /// <summary>
        /// Get an specific ApiConfiguration
        /// </summary>
        /// <returns>The api configuration requested.</returns>
        [HttpGet]
        [Route(Routes.Get_ApiConfiguration)]
        [ProducesResponseType(typeof(ApiConfigurationDto), (int)HttpStatusCode.OK)]
        [SurroundException]
        public async Task<IActionResult> GetApiConfigurationById([FromRoute] Guid id)
        {
            var results = await _apiConfigService.GetApiConfigurationById(id);
            return Ok(results);
        }

        /// <summary>
        /// Create a new Api Configuration
        /// </summary>
        /// <returns>The api configuration requested.</returns>
        [HttpPost]
        [Route(Routes.Post_ApiConfiguration)]
        [ProducesResponseType(typeof(ApiConfigurationDto), (int)HttpStatusCode.OK)]
        [SurroundException]
        public async Task<IActionResult> GetApiConfigurationById([FromBody] BinanceApiDto request)
        {
            var results = await _apiConfigService.AddBinanceApi(request);
            return Ok(results);
        }

        /// <summary>
        /// Create a new Api Configuration
        /// </summary>
        /// <returns>The api configuration requested.</returns>
        [HttpPut]
        [Route(Routes.Put_ApiConfiguration)]
        [ProducesResponseType(typeof(ApiConfigurationDto), (int)HttpStatusCode.OK)]
        [SurroundException]
        public async Task<IActionResult> UpdateConfigurationById([FromBody] BinanceApiDto request)
        {
            var results = await _apiConfigService.UpdateApiConfiguration(request);
            return Ok(results);
        }

        /// <summary>
        /// Create a new Api Configuration
        /// </summary>
        /// <returns>The api configuration requested.</returns>
        [HttpDelete]
        [Route(Routes.Delete_ApiConfiguration)]
        [ProducesResponseType(typeof(ApiConfigurationDto), (int)HttpStatusCode.OK)]
        [SurroundException]
        public async Task<IActionResult> RemoveApiConfiguration([FromRoute] Guid id)
        {
            var results = await _apiConfigService.RemoveApiConfiguration(id);
            return Ok(results);
        }
    }

    public class SurroundException : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            try
            {
                base.OnActionExecuted(context);
            }
            catch (Exception ex)
            {
                ConfigurationControllerExceptions.ManageException(ex);
            }
            
        }
    }

    public static class ConfigurationControllerExceptions
    {
        public static void ManageException(Exception ex)
        {
            throw ex;
        }
    }
}
