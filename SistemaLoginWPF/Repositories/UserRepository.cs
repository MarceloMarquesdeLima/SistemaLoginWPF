using SistemaLoginWPF.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;

namespace SistemaLoginWPF.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            throw new System.NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var commad = new SqlCommand())
            {
                connection.Open();
                commad.Connection = connection;
                commad.CommandText = "SELECT * FROM [User] WHERE username=@username and [Password]=@password";
                commad.Parameters.Add("@username", System.Data.SqlDbType.NVarChar).Value=credential.UserName;
                commad.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = credential.Password;
                validUser = commad.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }

        public void Edit(UserModel userModel)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new System.NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var commad = new SqlCommand())
            {
                connection.Open();
                commad.Connection = connection;
                commad.CommandText = "SELECT * FROM [User] WHERE username=@username";
                commad.Parameters.Add("@username", System.Data.SqlDbType.NVarChar).Value = username;
                using (var reader = commad.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            Username = reader[1].ToString(),
                            Password = string.Empty,
                            Name = reader[3].ToString(),
                            LastName = reader[4].ToString(),
                            Email = reader[5].ToString(),
                        };
                    }
                }
            }
            return user;
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
