using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadioController : ControllerBase
    {
        private RadioSystem objRadio = new RadioSystem();
        // GET: api/Radio
        [HttpGet]
        public List<RadioSystem> GetAllRadioSystems()
        {
            return objRadio.GetAlRadioSystems();
        }

        // GET: api/Radio/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            var returnValue = string.Empty;
            objRadio.RadioSystems= objRadio.GetAlRadioSystems();
            var foundItem = objRadio.RadioSystems.Find(item => item.RadioId == id);
            if (foundItem != null)
            {
                returnValue = foundItem.AllowedLocations?[foundItem.AllowedLocations.Count - 1];
            }
            else
            {
                returnValue = "undefiner/unknown";
            }
            return returnValue;
        }

        [HttpPost]
        public List<RadioSystem> CreateRadioSystem([FromBody] RadioSystem radioSystem)
        {
            objRadio.AddRadioSystem(radioSystem);
            return objRadio.RadioSystems;
        }

        [HttpPut("{id}")]
        public List<RadioSystem> UpdateRadioSystem(int id, [FromBody] string location)
        {
            var itemsList = objRadio.RadioSystems;
            var foundItem = itemsList.Find(item => item.RadioId == id);
            if (foundItem != null)
            {
                if (foundItem.AllowedLocations.Contains(location))
                {
                    foundItem.AllowedLocations.Add(location);
                }
            }
            return objRadio.RadioSystems;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var foundItem = objRadio.RadioSystems.Find(item => item.RadioId == id);
            objRadio.RadioSystems.Remove(foundItem);
        }
    }
}
