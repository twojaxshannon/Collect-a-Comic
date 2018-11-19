using ComicAPI.Models.ComicVine;
using ComicAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicVineController : ControllerBase
    {
        ComicVineService _comicVineService = new ComicVineService();

        [HttpGet("{comicSearch}")]
        public async Task<ActionResult<IssuesResponse>> GetAsync(string comicSearch)
        {
            var comicSearchDeserialized = JsonConvert.DeserializeObject<ComicSearch>(comicSearch);

            return await _comicVineService.SearchComics(comicSearchDeserialized);
        }
    }
}
