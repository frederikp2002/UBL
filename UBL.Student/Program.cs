using Student.Architecture.Application.Commands;
using Student.Architecture.Application.Commands.Implementation;
using Student.Architecture.Application.DTOs;
using Student.Architecture.Application.Queries;
using Student.Architecture.Application.Queries.Implementations;
using Student.Architecture.Application.Repositories;
using Student.Architecture.Domain.Models;
using Student.Architecture.Infrastructure.Repositories;
using Student.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICreateCommandStudent<CreateRequestDtoStudent>, CreateCommandStudent>();
builder.Services.AddScoped<IDeleteCommandStudent<StudentEntity>, DeleteCommandStudent>();
builder.Services.AddScoped<IGetQueryStudent<QueryResultDtoStudent>, GetQueryStudent>();
builder.Services.AddScoped<IRepositoryStudent, RepositoryStudent>();

builder.Services.AddDbContext<StudentContext>();

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