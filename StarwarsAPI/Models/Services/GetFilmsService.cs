using RestSharp;
using StarWarsApiCSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarwarsAPI.Models.Services
{
    public class GetFilmsService
    {
        public int FilmCount { get; set; }

        public List<Film> Films { get; set; }
        public List<Film> Characters { get; set; }

        public async Task<RestResponse> Execute()
        {
            IRepository<Film> filmsRepo = new Repository<Film>();
            var films = filmsRepo.GetEntities(size: int.MaxValue);
            
            if (films == null)
            {
                //Console.WriteLine("No films!");
               
            }
            FilmCount = films.Count;
            Films = (List<Film>)films;

            return new RestResponse();

        }
    }
}
