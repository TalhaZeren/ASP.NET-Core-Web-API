using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using Repositories.EFCore;
using Services.Contracts;
using WebAPI.Extensions;


var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));


// Add services to the container.
builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true; // Provides to return different format like jsýn,xml etc.
});

builder.Services.AddControllers()
    .AddCustomCsvFormatter()
    .AddXmlDataContractSerializerFormatters()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly)
    .AddNewtonsoftJson();

builder.Services.Configure<ApiBehaviorOptions>(options=>{
    options.SuppressModelStateInvalidFilter = true; // Exception Configuration for Creating.
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();


var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);  

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction()) 
{ 
    app.UseHsts();   // Https'e doðrudan baðlanma zorunluluðu.
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
