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
            objRadio.RadioSystems = objRadio.GetAlRadioSystems();
            var foundItem = objRadio.RadioSystems.Find(item => item.RadioId == id);
            if (foundItem != null)
            {
                if (id == 100)
                    returnValue = foundItem.AllowedLocations?[0];
                else
                    returnValue = foundItem.AllowedLocations ? [foundItem.AllowedLocations.Count - 1];
                //for (int i = 0; i < foundItem.AllowedLocations.Count; i++)
                //{
                //    if (!string.IsNullOrEmpty(returnValue))
                //        returnValue += ",";
                //    returnValue += foundItem.AllowedLocations[i];
                //}
            }
            else
            {
                returnValue = "undefiner/unknown";
            }
            return returnValue;
        }

        [HttpPost]
        public List<RadioSystem> CreateRadioSystem([FromBody]RadioSystem[] radioSystem)
        {
            objRadio.RadioSystems = new List<RadioSystem>(radioSystem.Length);
            for (int i = 0; i < radioSystem.Length; i++)
                objRadio.AddRadioSystem(radioSystem[i]);
            return objRadio.RadioSystems;
        }

        [HttpPut("{id}")]
        public string UpdateRadioSystem(int id, [FromBody] string location)
        {
            string response = string.Empty;
            var itemsList = objRadio.GetAlRadioSystems();
            objRadio.RadioSystems = itemsList;
            var foundItem = itemsList.Find(item => item.RadioId == id);
            if (foundItem != null)
            {                
                if (foundItem.AllowedLocations.Contains(location))
                {
                    response = "Accepted";
                    foundItem.AllowedLocations.Add(location);
                }
                else
                    response = "Denied";
            }
            return response;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<RadioSystem> Delete(int id)
        {
            var itemsList = objRadio.GetAlRadioSystems();
            objRadio.RadioSystems = itemsList;
            var foundItem = objRadio.RadioSystems.Find(item => item.RadioId == id);
            objRadio.RadioSystems.Remove(foundItem);
            return objRadio.RadioSystems;
        }
    }


}
