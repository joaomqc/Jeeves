namespace Jeeves.Infrastructure
{
    using Entities;
    using Microsoft.Data.Sqlite;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseContext : DbContext
    {
        static DatabaseContext()
        {
            using var client = new DatabaseContext();
            client.Database.Migrate();
        }

        public DbSet<MediaResource> MediaResources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder
            {
                DataSource = "Jeeves.db"
            };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }
    }
}
