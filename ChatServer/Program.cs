global using System;
using CharServer.Hubs;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

#region Services

builder.Services.AddCors();
builder.Services.AddSignalR();

#endregion



WebApplication app = builder.Build();

#region Middlewares

app.UseCors(options=>
{
    options.WithOrigins("http://127.0.0.1:5500/")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((x) => true)
        .AllowCredentials();
});

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/chat");
});

#endregion

app.Run();

