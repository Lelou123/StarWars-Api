using RestSharp;
using StarWarsApiCSharp;

using System.Threading.Tasks;

namespace StarwarsAPI.Models.Services
{
    public class GetCharactersService
    {
        public int PeopCount { get; set; }
        public async Task<RestResponse> Execute()
        {
            IRepository<Person> peopleRepo = new Repository<Person>();
            
            var p = peopleRepo.GetEntities(size: int.MaxValue);
            PeopCount = p.Count;

            return new RestResponse();
        }
    }
}
