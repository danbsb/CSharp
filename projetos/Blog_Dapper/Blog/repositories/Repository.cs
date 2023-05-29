using Blog.models;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace Blog.repositories
{
    //só permite criação se for uma classe (where class)
    //neste generico
    public class Repository<T> where T : class
    {
        //construtor
        public Repository(SqlConnection connection)
            => _connection = connection;

        //variável que recebe a conexão do construtor e
        //somente de leitura(readonly), não pode ser modificada
        private readonly SqlConnection _connection;

        public IEnumerable<T> GetAll()
            => _connection.GetAll<T>();

        //os métodos de cima => fazem a mesma coisa deste abaixo:
        //os de cima chama expression body
        //pode procurar uma ID de int ou string
        public T Get(int id = 0, string stId = "")
        {
            if (id == 0 && !string.IsNullOrEmpty(stId))
            {
                return _connection.Get<T>(stId);
            }

            return _connection.Get<T>(id);
        }

        public void Create(T Model)
        {
            _connection.Insert<T>(Model);
        }
        public void Update(T Model)
        {
            _connection.Update<T>(Model);
        }
        public void Delete(T Model)
        {
            _connection.Delete<T>(Model);
        }
    }
}

