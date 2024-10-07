using System.Net;
using Serilog;
using Serilog.Events;
using Server.Database;
using Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddScoped<ApplicationDbContext>()
    .AddGrpc();

builder.Services.AddSerilog();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Seq(
        builder.Configuration.GetConnectionString("Seq") ??
        throw new ArgumentNullException("Argument was null")
    )
    .WriteTo.Console()
    .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
    .CreateLogger();

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(new IPAddress([127, 0, 0, 1]), builder.Configuration.GetValue<int>("Port"));
});

var app = builder.Build();

app.UseRouting();

app.MapGrpcService<ReaderConfigurationService>();

app.Run();