using Blog.models;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.repositories
{
    public class UserRepository
    {
        //construtor
        public UserRepository(SqlConnection connection)
            => _connection = connection;

        //variável que recebe a conexão do construtor e
        //somente de leitura(readonly), não pode ser modificada
        private readonly SqlConnection _connection;

        public IEnumerable<User> GetAll()
            => _connection.GetAll<User>();

        //os métodos de cima => fazem a mesma coisa deste abaixo:
        //os de cima chama expression body
        public User Get(int id)
        {
            return _connection.Get<User>(id);
        }
        public void Create(User user)
        {
            user.Id = 0;
            _connection.Insert<User>(user);
        }
        public void Update(User user)
        {
            if (user.Id != 0)
                _connection.Update<User>(user);
        }
        public void Delete(User user)
        {
            if (user.Id != 0)
                _connection.Delete<User>(user);
        }
    }
}