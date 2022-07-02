using API.Dto.Comment;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Configuration;
using Newtonsoft.Json;
using Npgsql;
using RestSharp;
using System.Data;

namespace API.Service
{
    public class RattingService
    {
        public IDatabaseConnectionFactory DatabaseConnectionFactory { get; }


        public RattingService(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            DatabaseConnectionFactory = databaseConnectionFactory;
        }

        internal async Task<bool> InsertRatting(RattingDTO ratting)
        {
            using (var conn = await DatabaseConnectionFactory.GetConnectionFactoryAsync())
            {
                using (var cmd = new NpgsqlCommand("INSERT_RATTING", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IMDB_ID", ratting.ImdbId);
                    cmd.Parameters.AddWithValue("RATING", ratting.rating);
                    cmd.Parameters.AddWithValue("USERNAME", ratting.UserName);
                    cmd.Prepare();
                    var reader = cmd.ExecuteScalarAsync();
                    Console.WriteLine(reader);
                    var result = Convert.ToBoolean(reader.Result);

                    if (result == true)
                    {
                        return true;
                    }
                    else
                        return false;
                }

            }
        }


    }
}
