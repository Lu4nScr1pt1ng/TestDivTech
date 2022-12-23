using Microsoft.EntityFrameworkCore;
using TestDivTech.Data;

var builder = WebApplication.CreateBuilder(args);

// CREATE DATABASE [FORNECEDORDB]
// GO

//USE [FORNECEDORDB]
//GO

//CREATE TABLE [dbo].[FORNECEDOR] (
//    [Id]          INT            IDENTITY (1, 1) NOT NULL,
//    [nome]        NVARCHAR (250) NULL,
//    [cnpj]        NVARCHAR (50)       NULL,
//    [especialidade]   NVARCHAR (30)       NULL,
//);




builder.Services.AddControllers();

string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FORNECEDORDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(connectionString));

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

app.Run();
