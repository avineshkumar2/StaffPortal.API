using Microsoft.EntityFrameworkCore;
using StaffPortal.API.Data;
using StaffPortal.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddHttpClient();

builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddScoped<IQualificationService, QualificationService>();

builder.Services.AddControllers();
builder.Services.AddRazorPages(); // Add Razor Pages services

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapRazorPages(); // Map Razor Pages

app.Run();
