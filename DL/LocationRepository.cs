using CoronaApp.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CoronaApp.Services;

 
namespace CoronaApp.Dal
{
    

    public class LocationRepository : ILocationRepository
    {
        const string no_data= "";
        string data = System.IO.File.ReadAllText(@"Locations.json");

       
        public LocationRepository()
        {

        }
        public async Task<List<Location>> GetAsync(int  patientId)
        {
            var locations = JsonConvert.DeserializeObject<List<Location>>(data);

            var location = locations.FindAll(l =>l.PatientId== patientId).ToList(); 
            return location;
            

        }

        public async Task<List<Location>> GetAllAsync()
        {
            var locations = JsonConvert.DeserializeObject<List<Location>>(data);

            return locations;
        }
        public async Task PostAsync(Location locationToAdd)
        {
            try
            {
                if (data == no_data)
                {
                    List<Location> locationsList = new List<Location>();
                    locationsList.Add(locationToAdd);
                    string locationsListJson = System.Text.Json.JsonSerializer.Serialize(locationsList);
                    File.AppendAllText(@"Locations.json", locationsListJson);

                }
                else
                {
                    var locationsList = JsonConvert.DeserializeObject<List<Location>>(data);
                    locationsList.Add(locationToAdd);
                    string locationsListJson = System.Text.Json.JsonSerializer.Serialize(locationsList);
                    File.WriteAllText(@"Locations.json", locationsListJson);

                }
            }catch(Exception ex)
            {
                throw new Exception("failed to write file!");
            }

            
        }






       

    }

}
