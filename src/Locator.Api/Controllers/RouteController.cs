using Locator.Api.Contracts.Requests;
using Locator.Api.Contracts.Responses;
using Locator.Api.Core.Locator.Queries;
using Locator.Api.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locator.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouteController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly ILogger<RouteController> _logger;
        public RouteController(IMediator mediatr, ILogger<RouteController> logger)
        {
            _mediatr = mediatr;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<GetAllLandmarksResponse>> GetAllRoutes()
        {
            _logger.LogInformation($"GetAllRoutes invoked at {DateTime.Now}");
            var query = new GetAllRoutesQuery();
            var result = await _mediatr.Send(query);
            
            var routes = new List<RouteResponse>();
            result.ToList().ForEach(route => {
                var routeResponse = new RouteResponse()
                {
                    StartLandmark = new LandmarkResponse()
                    {
                        Code = route.StartLandmark.Code,
                        Id = route.StartLandmark.LandmarkId,
                        Name = route.StartLandmark.Name
                    },
                    EndLandmark = new LandmarkResponse()
                    {
                        Code = route.EndLandmark.Code,
                        Id = route.EndLandmark.LandmarkId,
                        Name = route.EndLandmark.Name
                    },
                    Distance = route.Distance,
                    Id = route.RouteId,
                    RouteCode = route.RouteCode
                };
                routes.Add(routeResponse);
            });
            
            var response = new GetAllRoutesResponse() { Data = routes};
            return Ok(response);
        }

        [HttpPost]
        [Route("GetNoOfRoutesBwLandmarks")]
        public async Task<ActionResult<GetNoOfRoutesBwLandmarksResponse>> GetNoOfRoutesBwLandmarks([FromBody] GetNoOfRoutesBwLandmarksRequest request)
        {
            _logger.LogInformation($"GetNoOfRoutesBwLandmarks invoked at {DateTime.Now}");
            //validate request
            var validationMessage = ValidateRequest(request);
            if (!string.IsNullOrEmpty(validationMessage))
            {
                _logger.LogWarning(validationMessage);
                return BadRequest(validationMessage);
            }

            //send query
            var query = new GetNoOfRoutesBwLandmarksQuery(request);
            var result = await _mediatr.Send(query);

            //map response
            var response = new GetNoOfRoutesBwLandmarksResponse() { NoOfRoutes = result.NoOfRoutes, Routes = result.Routes };
            return Ok(response);
        }

        private string ValidateRequest(GetNoOfRoutesBwLandmarksRequest request)
        {
            string validationMessage = string.Empty;
            if (request == null || string.IsNullOrEmpty(request.EndingLanmarkCode) || string.IsNullOrEmpty(request.EndingLanmarkCode))
            {
                validationMessage = "input values should not be empty or null";
            }

            if (request.StatingLanmarkCode.Equals(request.EndingLanmarkCode))
            {
                validationMessage = "Starting and Ending landmarks should be different";
            }
            return validationMessage;
        }
    }
}
