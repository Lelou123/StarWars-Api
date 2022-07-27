using RestSharp;
using StarWarsApiCSharp;

using System.Threading.Tasks;

namespace StarwarsAPI.Models.Services
{
    public class GetVehiclesService
    {
        public int PlanetCount { get; set; }
        public async Task<RestResponse> Execute()
        {
            IRepository<Vehicle> planetRepo = new Repository<Vehicle>();

            var p = planetRepo.GetEntities(size: int.MaxValue);
            PlanetCount = p.Count;

            return new RestResponse();
        }
    }
}
