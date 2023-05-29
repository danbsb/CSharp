using Blog.models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.repositories 
{
    //repositório um pra muitos, muitos pra muitos e muitos pra um
    //repositório espeficico
    public class UserRepOtM_MtO_MtM : Repository<User>
    {
        //construtor
        public UserRepOtM_MtO_MtM(SqlConnection connection)
            //quando herdar classe com construtor, tem que herdar o construtor também
            : base(connection)
            => _connection = connection;

        //variável que recebe a conexão do construtor e
        //somente de leitura(readonly), não pode ser modificada
        private readonly SqlConnection _connection;

        public List<User> ReadWithRole()
        {
            var query = @"
                SELECT
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";
            //se usar o left join e os ROLES vierem vazios ele vai apresentar erro
            //dai é necessario colocar um IF dentro do usr para filtrar

            var users = new List<User>();
            var items = _connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        //if (role != null){
                        //usr.Roles.Add(role);
                        //}
                        usr.Roles.Add(role);
                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);

                    return user;
                }, splitOn: "Id");
            return users;
        }
    }
}
