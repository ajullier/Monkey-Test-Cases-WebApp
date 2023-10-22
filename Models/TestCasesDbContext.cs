using Microsoft.EntityFrameworkCore;

namespace TestCases.Models
{
    public class TestCasesDbContext : DbContext
    {
        public TestCasesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BusinessUnit>? BusinessUnits { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<State>? States { get; set; }
        public DbSet<TestCase>? TestCases { get; set; }
        public DbSet<TestCase_BusinessUnit>? TestCases_BusinessUnits { get; set; }
        public DbSet<TestCase_Role>? TestCases_Roles { get; set; }
        public DbSet<View>? Views { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
        {
                if (!optionsBuilder.IsConfigured)
                {
                    //string conection = "Data Source=monkeytestcases-server.database.windows.net,1433;Initial Catalog=monkeytestcases-database;User ID=monkeytestcases-server-admin;Password=643POH5GZ67D8UO1%";
                    string conection = "Server=DESKTOP-LOTSMGA\\SQLEXPRESS;Database=TestCasesDb;User Id=MONO;Password=MONO;Encrypt=False;";
                    optionsBuilder.UseSqlServer(conection)
                    .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name}, Microsoft.Extensions.Logging.LogLevel.Information)
                    .EnableSensitiveDataLogging();
                }
            }
        }
    }
}
