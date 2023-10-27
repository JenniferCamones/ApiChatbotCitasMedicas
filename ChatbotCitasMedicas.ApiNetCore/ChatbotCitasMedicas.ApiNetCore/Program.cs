using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ChatbotCitasMedicas.ApiNetCore.Servicios;
using ChatbotCitasMedicas.ApiNetCore.DataModel;
using ChatbotCitasMedicas.ApiNetCore.Util;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var services = builder.Services;
// Add services to the container.

builder.Services.AddControllers();

services.AddScoped<IDapper, Dapperr>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyHeader();
                          builder.AllowAnyMethod();
                          builder.AllowAnyOrigin();
                          builder.WithMethods("GET", "PUT", "POST", "DELETE", "OPTIONS");
                      });
});
services.AddDbContext<CitasMedicasDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Connection")));
services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
services.AddTransient<IMailService, MailService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
