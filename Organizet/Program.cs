
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var conectionDefault = builder.Configuration.GetConnectionString("ConnectionDefault");
builder.Services.AddDbContext<OrganizetContextDbLocal> (options =>
    options.UseSqlite(conectionDefault));

var conectionSecond = builder.Configuration.GetConnectionString("ConnectionSecond");
builder.Services.AddDbContext<OrganizetContextDbServer>(options =>
    options.UseNpgsql(conectionSecond));

builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("https://localhost:7130") // URL do seu frontend
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
builder.Services.AddScoped<ITaskForUserRepository, TaskForUserRepository>();
builder.Services.AddScoped<ITaskForUserService, TaskForUserService>();
builder.Services.AddScoped<ITaskForManyRepository, TaskForManyRepository>();
builder.Services.AddScoped<ITaskForManyService, TaskForManyService>();
builder.Services.AddScoped<ITaskForManySectorRepository, TaskForManySectorRepository>();
builder.Services.AddScoped<ITaskForManySectorService, TaskForManySectorService>();
builder.Services.AddScoped<IStickNoteTaskRepository, StickNoteTaskRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IStickNoteTaskService, StickNoteTaskService>();
builder.Services.AddScoped<ISectorService, SectorService>();
builder.Services.AddScoped<ISectorRepository, SectorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
