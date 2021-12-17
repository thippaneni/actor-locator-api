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
    public class LandmarkController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public LandmarkController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        [Route("GetDistanceBwLandmarks")]
        public async Task<ActionResult<GetDistanceBwLandmarksResponse>> GetDistanceBwLandmarks([FromBody] GetDistanceBwLandmarksRequest request)
        {
            //validate request
            if (request == null || string.IsNullOrEmpty(request.EndingLanmarkCode) || string.IsNullOrEmpty(request.EndingLanmarkCode)
                || request.ViaLandmarkCodes == null || !request.ViaLandmarkCodes.Any())
            {
                return BadRequest("input values should not be empty or null");
            }

            if (request.StatingLanmarkCode.Equals(request.EndingLanmarkCode))
            {
                return BadRequest("Starting and Ending landmarks should be different");
            }

            if (request.ViaLandmarkCodes.Count() != request.ViaLandmarkCodes.Distinct().Count())
            {
                return BadRequest("A given via Landmark Codes should not appear more than once");
            }


            // Automapper
            var startingLandMarkdto = new Landmark() { Code = request.StatingLanmarkCode, Name = request.StatingLanmarkCode }; 
            var endingLandMarkdto = new Landmark() { Code = request.EndingLanmarkCode, Name = request.EndingLanmarkCode };
            var viaLandMarksdto = new List<Landmark>();
            if (request.ViaLandmarkCodes !=null && request.ViaLandmarkCodes.Any())
            {
                request.ViaLandmarkCodes.ToList().ForEach(lm=> {
                    viaLandMarksdto.Add(new Landmark() {Code = lm, Name = lm });
                });
            }
            

            var query = new GetDistanceBwLandmarksQuery(startingLandMarkdto, endingLandMarkdto, viaLandMarksdto);
            var result = await _mediatr.Send(query);

            var disatnce = "Path not Found";
            if (result.HasValue)
                disatnce = result.Value.ToString();
            var response = new GetDistanceBwLandmarksResponse() { Disatnce = disatnce };
            return Ok(response);
        }
    }
}
