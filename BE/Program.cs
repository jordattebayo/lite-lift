using BE.DataAccess;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

// Removing allow CORS for prod
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "*",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddControllers();

builder.Services.AddDbContext<LiteliftdevContext>(options => options.UseNpgsql("Host=localhost;Username=jordan;Password=elephant1;Database=liteliftdev"));
builder.Services.AddScoped<IDataAccessProvider, DataAccessProvider>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("*");
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
