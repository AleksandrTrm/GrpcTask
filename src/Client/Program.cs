using Client.Requests;
using Client.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Map("/packets", async (PostPacketsRequest request, CancellationToken cancellationToken) => 
    await new ReadConfigurationEndpoint(app.Configuration).ReadConfigurationAsync(request, cancellationToken));

app.UseHttpsRedirection();

app.Run();