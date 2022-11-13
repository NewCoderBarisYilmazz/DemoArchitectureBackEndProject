using Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concrete.EntityFreamwork.Context
{
    public class SimpleContextDb:DbContext
    {

      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-UUKUT9CD\\SQLEXPRESS;Initial Catalog=DemoDb;Integrated Security=True");
        }



        public DbSet<User>? Users { get; set; }

        public DbSet<OperationClaim> ?OperationClaims { get; set; }

        public DbSet<UserOperationClaim>? UserOperationClaims { get; set; }
    }
}
