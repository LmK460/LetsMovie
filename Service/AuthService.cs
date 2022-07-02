using API.Dto;
using API.Models;
using Infra.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Service
{
    public class AuthService
    {
        private ApiClientFactory AuthApiClientFactory { get; }

        public AuthService(ApiClientFactory authApiClientFactory)
        {
            AuthApiClientFactory = authApiClientFactory;
        }

        internal async Task<LoginResultDTO> Login(UserLoginDTO userLoginDTO)
        {
            string bodyData = JsonConvert.SerializeObject(userLoginDTO);
            var request = new RestRequest("auth");
            request.Method = Method.Post;
            request.AddJsonBody(bodyData);



            var response = await AuthApiClientFactory.RestClient.PostAsync(request);
            var result = JsonConvert.DeserializeObject<LoginResultDTO>(response.Content);

            if (response.IsSuccessful)
            {
                return result;
            }

            return new LoginResultDTO { Autenticated = result.Autenticated, Message = result.Message };
        }

        //ficou pendente implementar a validação
        internal Claim ValidateToken(string token)
        {
            try
            {
                var aux = new JwtSecurityToken(token).Claims;
                return (Claim)aux;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
