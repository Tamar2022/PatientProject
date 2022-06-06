


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface ILocationService
    {
        Task<List<Location>> GetAsync(int patientId);
        Task<List<Location>> GetAllAsync();
        Task<List<Location>> GetAllByCityAsync(string city);
        Task PostAsync(Location location);
    }
    public interface ILocationRepository
    {
        Task<List<Location>> GetAsync(int patientId);
        Task<List<Location>> GetAllAsync();
        Task PostAsync(Location location);
    }
    public class LocationService : ILocationService
    {
        ILocationRepository _locationRepository;
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<List<Location>> GetAsync(int patientId)
        {
            return await _locationRepository.GetAsync(patientId);
        }
        public async Task<List<Location>> GetAllAsync()
        {
            

            return await _locationRepository.GetAllAsync();


        }
        public async Task<List<Location>> GetAllByCityAsync(string city)
        {
            var location = await _locationRepository.GetAllAsync();

            return location.FindAll(l=>l.City==city);


        }
        public async Task PostAsync(Location location)
        {
            await _locationRepository.PostAsync(location);
        }
    }
}
