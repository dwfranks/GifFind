using AutoMapper;
using GifFind.API.Models;
using GifFind.API.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GifFind.API.Controllers
{
    [Authorize]
    [ApiVersionNeutral]
    [Route("api/[controller]")]
    [ApiController]
    public class GifsController : ControllerBase
    {
        private readonly IAppClient _appClient;
        private readonly IMapper _mapper;

        public GifsController(IAppClient appClient, IMapper mapper)
        {
            this._appClient = appClient;
            this._mapper = mapper;
        }

        [HttpGet("search", Name="Search Gifs")]
        public async Task<ActionResult<IEnumerable<GifPackage>>> Search([FromQuery] string queryTopic)
        {

            var results = await _appClient.SearchAsync(queryTopic);

            var mappedResults = _mapper.Map<GifPackage>(results);

            return Ok(mappedResults);
        }
    }
}