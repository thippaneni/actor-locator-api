using Locator.Api.Contracts.Requests;
using Locator.Api.Contracts.Responses;
using Locator.Api.Core.Locator.Queries;
using Locator.Api.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public RouteController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        [Route("GetNoOfRoutesBwLandmarks")]
        public async Task<ActionResult<GetNoOfRoutesBwLandmarksResponse>> GetNoOfRoutesBwLandmarks([FromBody] GetNoOfRoutesBwLandmarksRequest request)
        {
            //validate request
            if (request == null || string.IsNullOrEmpty(request.EndingLanmarkCode) || string.IsNullOrEmpty(request.EndingLanmarkCode))
            {
                return BadRequest("input values should not be empty or null");
            }

            if (request.StatingLanmarkCode.Equals(request.EndingLanmarkCode))
            {
                return BadRequest("Starting and Ending landmarks should be different");
            }

            var startingLandMarkdto = new Landmark() { Code = request.StatingLanmarkCode, Name = request.StatingLanmarkCode };
            var endingLandMarkdto = new Landmark() { Code = request.EndingLanmarkCode, Name = request.EndingLanmarkCode };

            var query = new GetNoOfRoutesBwLandmarksQuery(startingLandMarkdto, endingLandMarkdto, request.MaxStops);
            var result = await _mediatr.Send(query);

            var response = new GetNoOfRoutesBwLandmarksResponse() { NoOfRoutes = result.NoOfRoutes, Routes = result.Routes };
            return Ok(response);
        }
    }
}
