using Locator.Api.Contracts.Requests;
using Locator.Api.Contracts.Responses;
using Locator.Api.Core.Locator.Queries;
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
    public class LandmarkController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly ILogger<LandmarkController> _logger;
        public LandmarkController(IMediator mediatr, ILogger<LandmarkController> logger)
        {
            _mediatr = mediatr;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<GetAllLandmarksResponse>> GetAllLandmarks()
        {
            _logger.LogInformation($"GetAllLandmarks invoked at {DateTime.Now}");
            var query = new GetAllLandMarksQuery();
            var result = await _mediatr.Send(query);
            
            var landmarks = new List<LandmarkResponse>();
            result.ToList().ForEach(lm => {
                landmarks.Add(new LandmarkResponse() { Code = lm.Code, Id = lm.Id, Name = lm.Name });
            });

            var response = new GetAllLandmarksResponse() { Data = landmarks };
            return Ok(response);
        }

        [HttpPost]
        [Route("GetDistanceBwLandmarks")]
        public async Task<ActionResult<GetDistanceBwLandmarksResponse>> GetDistanceBwLandmarks([FromBody] GetDistanceBwLandmarksRequest request)
        {
            _logger.LogInformation($"GetDistanceBwLandmarks invoked at {DateTime.Now}");
            //validate request
            var validationMessage = ValidateRequest(request);
            if (!string.IsNullOrEmpty(validationMessage))
            {
                _logger.LogError(validationMessage);
                return BadRequest(validationMessage);
            }

            //send query
            var query = new GetDistanceBwLandmarksQuery(request);
            var result = await _mediatr.Send(query);

            //map response
            var disatnce = "Path not Found";
            if (result.HasValue)
                disatnce = result.Value.ToString();
            var response = new GetDistanceBwLandmarksResponse() { Disatnce = disatnce };
            return Ok(response);
        }
        private string ValidateRequest(GetDistanceBwLandmarksRequest request)
        {
            string validationMessage = string.Empty;
            if (request == null || string.IsNullOrEmpty(request.EndingLanmarkCode) || string.IsNullOrEmpty(request.EndingLanmarkCode)
                || request.ViaLandmarkCodes == null || !request.ViaLandmarkCodes.Any())
            {
                validationMessage = "input values should not be empty or null";
            }

            if (request.StatingLanmarkCode.Equals(request.EndingLanmarkCode))
            {
                validationMessage = "Starting and Ending landmarks should be different";
            }

            if (request.ViaLandmarkCodes.Count() != request.ViaLandmarkCodes.Distinct().Count())
            {
                validationMessage = "A given via Landmark Codes should not appear more than once";
            }
            return validationMessage;
        }
    }
}

