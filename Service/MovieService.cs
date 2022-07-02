using Domain.Entities;
using Infra.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace API.Service
{
    public class MovieService
    {
        private MovieApiClientFactory MovieApiClientFactory { get; }

        public MovieService(MovieApiClientFactory movieApiClientFactory)
        {
            MovieApiClientFactory = movieApiClientFactory;
        }


        internal async Task<Movie> GetFilmeById(string id)
        {
            var request = new RestRequest($"?apikey={MovieApiClientFactory.ApiKey}&i={id}")
            {
                Method = Method.Get
            };


            var response = await MovieApiClientFactory.RestClient.GetAsync(request);
            var result = JsonConvert.DeserializeObject<Movie>(response.Content);

            if (response.IsSuccessful)
            {
                return result;
            }

            return result;
        }

        internal async Task<List<Movie>> GetFilmeByTittle(string title)
        {
            var request = new RestRequest($"?apikey={MovieApiClientFactory.ApiKey}&t={title}")
            {
                Method = Method.Get
            };


            var response = await MovieApiClientFactory.RestClient.GetAsync(request);
            var result = JsonConvert.DeserializeObject<List<Movie>>(response.Content);

            if (response.IsSuccessful)
            {
                return result;
            }

            return result;
        }


    }
}
