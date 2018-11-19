using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ComicAPI.DAL.Repositories;
using ComicAPI.DAL.Utility;
using ComicAPI.Models;
using ComicAPI.Models.ComicVine;
using ComicAPI.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ComicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> GetAsync(int id)
        {
            // TODO: Test code for quickly verifying changes.


            UserRepository userRepository = new UserRepository();
            return userRepository.GetAll();

            /*
            ComicVineService comicVineService = new ComicVineService();
            //var testVolume = await comicVineService.GetVolume("4050-796");


            VolumeFilter filter = new VolumeFilter() { Name = "Teen Titans" };
            VolumeSort sort = new VolumeSort();

            ComicSearch comicSearch = new ComicSearch() { VolumeFilterCriteria = filter, VolumeSortCriteria = sort };




            var testVolumes = await comicVineService.SearchComics(comicSearch);

            return testVolumes.Results.ToString();
            */

            /*
            DALConfig config = new DALConfig();
            var collectionDb = config.GetMongoDatabase();
            collectionDb.DropCollection("User");

            UserRepository userRepository = new UserRepository();
            ComicCollectionRepository comicCollectionRepository = new ComicCollectionRepository();
            CollectedVolumeRepository collectedVolumeRepository = new CollectedVolumeRepository();

            userRepository.Save(new ComicAPI.Models.User() { Name = "Shannon" });
            userRepository.Save(new ComicAPI.Models.User() { Name = "Tony Stark" });

            var test = userRepository.GetAll();
            
            return "Testing!";
            */
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
