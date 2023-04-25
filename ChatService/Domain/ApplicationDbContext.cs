using ChatService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatService.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MessageEntity> Message { get; set; }
        public DbSet<UserLastSeenEntity> UserLastSeen { get; set; }


        // конфигурация контекста
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}