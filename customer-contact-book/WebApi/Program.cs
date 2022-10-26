using System;
using System.IO;
using System.Reflection;
using Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ContactBookContext>();
builder.Services.AddScoped<ContactService>();
builder.Services.AddScoped<OrderService>();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(x =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    x.IncludeXmlComments(xmlPath);
});
builder.Services.AddDbContext<CustomerBookContext>(x => x.UserInMemoryDatabase("Customer Contant"));


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

var context = app.Services.GetRequiredService<ContactBookContext>();
context.Database.EnsureCreated();

app.Run();
