using Data.ImportExportService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile(File.Exists("appsettings.Development.json") ? "appsettings.Development.json" : "appsettings.json")
            .Build();

        services
        .AddOptions<TaskSettings>().Bind(config.GetSection(TaskSettings.Settings));
        
        services
        .AddHostedService<Worker>();

    })
    .UseWindowsService(options => {
        options.ServiceName = "Export/Import service";
    })
    .Build();

await host.RunAsync();
