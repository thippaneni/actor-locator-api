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

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<GetAllLandmarksResponse>> GetAllRoutes()
        {
            var query = new GetAllRoutesQuery();
            var result = await _mediatr.Send(query);
            var response = new GetAllRoutesResponse();
            var routes = new List<RouteResponse>();
            if (result != null && result.Any())
            {
                result.ToList().ForEach(route => {
                    routes.Add(new RouteResponse()
                    {
                        StartLandmark = new LandmarkResponse()
                        {
                            Code = route.StartLandmark.Code,
                            Id = route.StartLandmark.Id,
                            Name = route.StartLandmark.Name
                        },
                        EndLandmark = new LandmarkResponse()
                        {
                            Code = route.EndLandmark.Code,
                            Id = route.EndLandmark.Id,
                            Name = route.EndLandmark.Name
                        },
                        Distance = route.Distance,
                        Id = route.Id,
                        RouteCode = route.RouteCode
                    });
                });
            }
            response.Data = routes;
            return Ok(response);
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

            var query = new GetNoOfRoutesBwLandmarksQuery(request);
            var result = await _mediatr.Send(query);

            var response = new GetNoOfRoutesBwLandmarksResponse() { NoOfRoutes = result.NoOfRoutes, Routes = result.Routes };
            return Ok(response);
        }
    }
}
