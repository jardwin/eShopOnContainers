namespace Identity.API.Factories
{
    public class PersistedGrantDbContextFactory : IDesignTimeDbContextFactory<PersistedGrantDbContext>
    {
        public PersistedGrantDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables()
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PersistedGrantDbContext>();
            var operationOptions = new OperationalStoreOptions();

            optionsBuilder.UseMySql(config["ConnectionString"], ServerVersion.AutoDetect(config["ConnectionString"]), mySqlOptionsAction: o => o.MigrationsAssembly("Identity.API"));

            return new PersistedGrantDbContext(optionsBuilder.Options, operationOptions);
        }
    }
}