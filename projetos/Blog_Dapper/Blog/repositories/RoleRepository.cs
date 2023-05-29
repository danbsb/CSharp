using Blog.models;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.repositories
{
    public class RoleRepository
    {
        //construtor
        public RoleRepository(SqlConnection connection)
            => _connection = connection;

        //variável que recebe a conexão do construtor e
        //somente de leitura(readonly), não pode ser modificada
        private readonly SqlConnection _connection;

        public IEnumerable<Role> GetAll()
            => _connection.GetAll<Role>();

        //os métodos de cima => fazem a mesma coisa deste abaixo:
        //os de cima chama expression body
        public Role Get(int id)
        {
            return _connection.Get<Role>(id);
        }

        public void Create(Role role)
            => _connection.Insert<Role>(role);

        public void Update(Role role)
        {
            if (role.Id != 0)
                _connection.Update<Role>(role);
        }
        public void Delete(Role role)
        {
            if (role.Id != 0)
                _connection.Delete<Role>(role);
        }
        public void Delete(int Id)
        {
            if (Id != 0)
                return;
            var role = _connection.Get<Role>(Id);
            _connection.Delete<Role>(role);
        }
    }
}
