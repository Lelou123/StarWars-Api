using RestSharp;
using StarWarsApiCSharp;

using System.Threading.Tasks;

namespace StarwarsAPI.Models.Services
{
    public class GetPlanetService
    {
        public int PlanetCount { get; set; }
        public async Task<RestResponse> Execute()
        {
            IRepository<Planet> planetRepo = new Repository<Planet>();

            var p = planetRepo.GetEntities(size: int.MaxValue);
            PlanetCount = p.Count;

            return new RestResponse();
        }
    }
}
