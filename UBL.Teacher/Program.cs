using Microsoft.EntityFrameworkCore;
using UBL.Teacher.Architecture.Application.Commands;
using UBL.Teacher.Architecture.Application.Commands.Implementations;
using UBL.Teacher.Architecture.Application.Dtos;
using UBL.Teacher.Architecture.Application.Queries;
using UBL.Teacher.Architecture.Application.Queries.Implementations;
using UBL.Teacher.Architecture.Application.Repositories;
using UBL.Teacher.Architecture.Domain.DomainServices;
using UBL.Teacher.Architecture.Domain.Models;
using UBL.Teacher.Architecture.Infrastructure.DomainServices.Implementations;
using UBL.Teacher.Architecture.Infrastructure.Repositories;
using UBL.Teacher.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Teacher
builder.Services.AddScoped<ICreateCommand<CreateRequestDtoTeacher>, CreateCommandTeacher>();
builder.Services.AddScoped<IDeleteCommand<TeacherEntity>, DeleteCommandTeacher>();
builder.Services.AddScoped<IGetQuery<QueryResultDtoTeacher>, GetQueryTeacher>();
builder.Services.AddScoped<IRepositoryTeacher, RepositoryTeacher>();
builder.Services.AddScoped<IDomainServiceTeacher, DomainServiceTeacher>();

// Database
builder.Services.AddDbContext<TeacherContext>();

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