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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            {
                if (!optionsBuilder.IsConfigured)
                {
                    string connectionString = string.Empty;
                    try
                    {
                        // Create an instance of StreamReader to read from a file.
                        // The using statement also closes the StreamReader.
                        
                        using (StreamReader sr = new StreamReader("StringConnection.txt"))
                        {
                            
                            // Read and display lines from the file until the end of
                            // the file is reached.
                            connectionString = sr.ReadToEnd();
                        }
                    }
                    catch (Exception e)
                    {
                        // Let the user know what went wrong.
                        Console.WriteLine("The file could not be read:");
                        Console.WriteLine(e.Message);
                    }

                    optionsBuilder.UseSqlServer(connectionString)
                    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
                    .EnableSensitiveDataLogging();
                }
            }
        }
    }
}
