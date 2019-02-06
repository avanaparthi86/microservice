using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;

namespace MicroApp.Models
{
    public class RadioSystem
    {
        public int RadioId { get; set; }
        public string RadioAlias { get; set; }
        public List<string> AllowedLocations { get; set; }

        public List<RadioSystem> RadioSystems { get; set; }

        public void AddRadioSystem(RadioSystem system)
        {           
            RadioSystems.Add(system);
        }

        public List<RadioSystem> GetAlRadioSystems()
        {
            //****************** Scenario 1
            #region
            var items = new List<RadioSystem>
            {
                new RadioSystem
                {
                    RadioId = 100,
                    RadioAlias = "Radio100",
                    AllowedLocations = new List<string> {"CPH-1", "CPH-2"}
                },
                new RadioSystem
                {
                    RadioId = 101,
                    RadioAlias = "Radio101",
                    AllowedLocations = new List<string> {"CPH-1", "CPH-2", "CPH-3" }
                }
            };
            #endregion
            //****************** Scenario 2
            #region
            //var items = new List<RadioSystem>
            //{
            //    new RadioSystem
            //    {
            //        RadioId = 102,
            //        RadioAlias = "Radio102",
            //        AllowedLocations = new List<string> {"CPH-1", "CPH-3"}
            //    }
            //};
            #endregion
            //******************Scenario 3
            #region
            //var items = new List<RadioSystem>
            //{
            //    new RadioSystem
            //    {
            //        RadioId = 101,
            //        RadioAlias = "Radio101",
            //        AllowedLocations = new List<string> {"CPH-1", "CPH-2", "CPH-3"}
            //    }
            //};
            #endregion
            if (RadioSystems != null) RadioSystems.AddRange(items);
            return items;
        }
    }


}
