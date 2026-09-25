
using Application.Behaviors;
using Application.Common;
using Application.Services;
using FluentValidation;
using Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PrivatSchoolsAPI.Infrastructure.Data;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer
(builder.Configuration.GetConnectionString("MyConnection")));

builder.Services.AddScoped<IAppDbContext>(provider =>
    provider.GetRequiredService<AppDbContext>());

//builder.Services.AddScoped(typeof(CQRS_LB.Repos.IRepo<>), typeof(CQRS_LB.Repos.MainRepo<>));
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Application.AssemblyMarker).Assembly));

builder.Services.AddValidatorsFromAssembly((typeof(Application.AssemblyMarker).Assembly));

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddControllersWithViews();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("RedisConStr");
    options.InstanceName = "Redis_";

});


builder.Services.AddScoped<IRedisCacheService, RedisCacheService>();

//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    c.IncludeXmlComments(xmlPath);
});


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
