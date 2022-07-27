using RestSharp;
using StarWarsApiCSharp;

using System.Threading.Tasks;

namespace StarwarsAPI.Models.Services
{
    public class GetStarshipsService
    {
        public int StarshipsCount { get; set; }
        public async Task<RestResponse> Execute()
        {
            IRepository<Starship> starshipsRepo = new Repository<Starship>();

            var p = starshipsRepo.GetEntities(size: int.MaxValue);
            StarshipsCount = p.Count;
            return new RestResponse();
        }
    }
}
