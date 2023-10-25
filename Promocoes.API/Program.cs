using System.Reflection;
using Microsoft.VisualBasic;
using Promocoes.Application.Input.Commands.BusinessContext;
using Promocoes.Application.Input.Commands.ProductContext;
using Promocoes.Application.Input.Commands.PromotionsContext;
using Promocoes.Application.Input.Receivers.BusinessReceiver;
using Promocoes.Application.Input.Repositories.Interfaces;
using Promocoes.Application.Output.DTOs;
using Promocoes.Application.Output.Interfaces;
using Promocoes.Infrastructure.Input.Repositories;
using Promocoes.Infrastructure.Output.Repositories;
using Promocoes.Infrastructure.Shared.Factory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<SqlFactory>();
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssemblies(typeof(BusinessCommand).Assembly);
    cfg.RegisterServicesFromAssemblies(typeof(ProductCommand).Assembly);
    cfg.RegisterServicesFromAssemblies(typeof(PromotionsCommand).Assembly);
    cfg.RegisterServicesFromAssemblies(typeof(AuthenticationCommand).Assembly);
    cfg.RegisterServicesFromAssemblies(typeof(AllBusinessDTO).Assembly);
    cfg.RegisterServicesFromAssemblies(typeof(ByIdBusinessDTO).Assembly);
    cfg.RegisterServicesFromAssemblies(typeof(ByIdProductDTO).Assembly);
    
});
builder.Services.AddScoped<IReadPromotionRepository, ReadPromotionRepository>();
builder.Services.AddScoped<IWritePromotionsRepository, WritePromotionRepository>();
builder.Services.AddScoped<IWriteProductRepository, WriteProductRepository>();
builder.Services.AddScoped<IReadProductRepository, ReadProductRepository>();
builder.Services.AddScoped<IReadBusinessRepository, ReadBusinessRepository>();
builder.Services.AddScoped<IWriteBusinessRepository, WriteBusinessRepository>();
builder.Services.AddScoped<IAuthenticationBusinessRepository, AuthenticationBusinessRepository>();

builder.Services.AddOutputCache(options =>
    {
        options.AddPolicy("ProductsRefresh",builder => builder.Tag("products"));
        options.AddPolicy("BusinessRefresh",builder => builder.Tag("Business"));
        options.AddPolicy("PromotionRefresh",builder => builder.Tag("Promotion"));
        
    }
    );

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
        policy =>
        {
            policy.WithOrigins("*").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("MyPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseOutputCache();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();