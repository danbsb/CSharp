using Blog.models;
using Blog.repositories;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data.SqlClient;
using System.Runtime.ConstrainedExecution;

namespace Blog
{
    class Program
    {
        //string de conexão com os parâmetros do banco de dados
        private const string connectionString = "Server = localhost, 1401; Database = Blog; User ID = sa; Password = devD@niel123; TrustServerCertificate=True";

        static void Main(string[] args)
        {
            //cria  conexão
            var mainConnection = new SqlConnection(connectionString);
            //abre a conexão e depois do uso, garante que a conexão seja fechada
            //não precisa usar o mainConnection.Open() nem o Close();
            using (mainConnection)
            {
                ReadUsersWithRoles(mainConnection);
                //ReadRoles(mainConnection);
                //ReadTags(mainConnection);
                //DeleteUser(mainConnection);
                //ReadUser(mainConnection, 1);
                //CreateUser(mainConnection);
                //UpdateUser(mainConnection);
            }
        }

        //lê todos
        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var users = repository.GetAll();

            foreach ( var user in users )
                Console.WriteLine(user.Name);
        }

        //leitura 1 pra muitos
        //repositório espeficico
        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepOtM_MtO_MtM(connection);
            var users = repository.ReadWithRole();

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
                foreach (var role in user.Roles)
                {
                    Console.WriteLine($"- {role.Name}");
                }
            }
        }

        public static void ReadUser(SqlConnection connection, int Id)
        {

            var repository = new Repository<User>(connection);
            var users = repository.Get(Id);

            Console.WriteLine(users.Name);
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var roles = repository.GetAll();

            foreach (var role in roles)
            {
                Console.WriteLine(role.Name);
            }
        }

        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var tags = repository.GetAll();

            foreach (var tag in tags)
            {
                Console.WriteLine(tag.Name);
            }
        }

        public static void DeleteUser<T>(SqlConnection connection)
        {
            var userId = 1;
            var repository = new Repository<User>(connection);
            var user = repository.Get(userId);
            Console.WriteLine(user.Name);

            if (user != null)
            {
                repository.Delete(user);
                Console.WriteLine("Usuário excluído com sucesso.");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }

        public static void CreateUser(SqlConnection connection)
        {
            //define a classe que será criada no repositório genérico
            var repository = new Repository<User>(connection);

            //cria o usuário
            var user = new User()
            {
                Bio = "Equipa Balta.io",
                Email = "williamjohnson@example.com",
                Name = "William Johnson",
                Image = "https://",
                PasswordHash = "password987",
                Slug = "william - johnson"
            };

            //pega o usuário na variável e passa para o banco
            repository.Create(user);
        }

        public static void UpdateUser(SqlConnection connection)
        {
            var userId = 1;
            var repository = new Repository<User>(connection);
            var user = repository.Get(userId);
            user.Name = "Daniel Fontinele";
            user.Email = "daniel@gmail.com";

            //comando de atualização
            repository.Update(user);

            Console.WriteLine("Atualização Realizada");
        }
    }
}