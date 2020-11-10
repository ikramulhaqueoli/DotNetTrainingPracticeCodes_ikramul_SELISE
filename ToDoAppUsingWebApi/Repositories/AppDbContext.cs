using Microsoft.EntityFrameworkCore;
using System.Configuration;
using ToDoAppUsingWebApi.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ToDoAppUsingWebApi.Repositories
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TodoTask> TodoTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
        private string ConnectionString
        {
            get
            {
                var configuation = GetConfiguration();
                return configuation.GetSection("ConnectionStrings").GetSection("TodoAppDb").Value;
            }
        }

        private IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}
