using CohesionApp.Domain.Dtos;
using CohesionApp.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CohesionApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService; 

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateRequest(CreateRequestDto requestDto)
        {
            await _requestService.CreateRequest(requestDto);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRequest(UpdateRequestDto requestDto)
        {
            await _requestService.UpdateRequest(requestDto);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRequestById(Guid id)
        {
            var result = await _requestService.GetRequestById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRequests()
        {
            var result = await _requestService.GetAllRequests();
            return Ok(result);
        }
    }
}
