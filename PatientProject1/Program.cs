using CoronaApp.Dal;
using CoronaApp.Middlewares;
using CoronaApp.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();

builder.Host.UseSerilog((hostContext, services, configuration) => {
    configuration.WriteTo.File("C:\\Users\\IMOE001\\source\\repos\\r.txt");
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();

}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.UseErrorMiddleware();
app.UseRouting();


app.MapControllers();

app.Run();
public partial class Program { }
