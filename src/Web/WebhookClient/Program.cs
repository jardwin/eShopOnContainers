using System.IO;

CreateWebHostBuilder(args).Build().Run();


IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
    .UseConfiguration(GetConfiguration())
        .UseStartup<Startup>();

IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddSystemsManager("/webhookclient")
        .AddEnvironmentVariables();

    return builder.Build();
}
