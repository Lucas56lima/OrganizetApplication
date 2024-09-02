
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
var conectionDefault = builder.Configuration.GetConnectionString("ConectionDefault");
builder.Services.AddDbContext<OrganizetContextDb> (options =>
    options.UseSqlite(conectionDefault));
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITaskForUserRepository, TaskForUserRepository>();
builder.Services.AddScoped<ITaskForUserService, TaskForUserService>();
builder.Services.AddScoped<ITaskForManyRepository, TaskForManyRepository>();
builder.Services.AddScoped<ITaskForManyService, TaskForManyService>();

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

app.Run();
