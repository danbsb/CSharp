using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.models
{
    [Table("[User]")]
    public class User
    {
        //construtor
        public User()
        {
            Roles = new List<Role>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        //considerando que Roles é uma propriedade apenas pra leitura
        //de um pra muitos, é necessario colocar o [Write(false)]
        //para que na inclusão CREATEUSER ele desconsidere a lista abaixo de ROles
        [Write(false)]
        public List<Role> Roles { get; set; }
    }
}
