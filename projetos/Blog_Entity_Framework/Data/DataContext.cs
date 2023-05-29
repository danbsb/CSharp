using Blog_Entity_Framework.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Entity_Framework.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        //public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }

        //conexão com o Banco de Dados
        private const string connectionString = "Server = localhost, 1401; Database = Blog; User ID = sa; Password = devD@niel123; TrustServerCertificate=True";
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(connectionString);
    }
}
