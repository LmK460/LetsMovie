using Domain.Entities;
using Domain.Interfaces;
using Infra.Configuration;
using Newtonsoft.Json;
using Npgsql;
using RestSharp;
using System.Data;

namespace API.Service
{
    public class CommentService
    {
        public IDatabaseConnectionFactory DatabaseConnectionFactory { get; }


        public CommentService(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            DatabaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<Comment> InsertComment(Comment comment)
        {
            using (var conn = await DatabaseConnectionFactory.GetConnectionFactoryAsync())
            {
                using (var cmd = new NpgsqlCommand("INSERT_COMMENT", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("iMDB_ID", comment.ImdbId.ToString());
                    cmd.Parameters.AddWithValue("DS_COMMENT", comment.Commentary.ToString());
                    cmd.Parameters.AddWithValue("USERNAME", comment.UserName).ToString() ;
                    cmd.Prepare();
                    var reader = cmd.ExecuteScalarAsync();
                    Console.WriteLine(reader);
                    var result = Convert.ToBoolean(reader.Result);

                    if (result == true)
                    {
                        return new Comment { Commentary = comment.Commentary, ImdbId = comment.ImdbId, UserName = comment.UserName };
                    }
                    else
                        return null;
                }

            }
        }

    


    }
}
