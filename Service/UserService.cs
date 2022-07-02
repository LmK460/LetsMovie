using API.Dto;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Configuration;
using Npgsql;
using System.Data;

namespace API.Service
{
    public class UserService
    {

        public IDatabaseConnectionFactory DatabaseConnectionFactory { get; }


        public UserService(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            DatabaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<Boolean> InsertUser(UserInsertDTO userDto)
        {
            using (var conn = await DatabaseConnectionFactory.GetConnectionFactoryAsync())
            {
                using (var cmd = new NpgsqlCommand("INSERT_PEOPLE", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("iMDB_ID", userDto.Name);
                    cmd.Parameters.AddWithValue("DS_COMMENT", userDto.Email);
                    cmd.Parameters.AddWithValue("USERNAME", userDto.Dt_nascimento);
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