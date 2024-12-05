using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyShoppingEntity;
using MyShoppingRepository.Data;
using MyShoppingRepository.Repositories;
using MyShoppingService.Services;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Configure NLog
builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.SetMinimumLevel(LogLevel.Trace);
});

// Add NLog as the logger provider
builder.Services.AddSingleton<ILoggerProvider, NLogLoggerProvider>();

// Add services to the container.
//Configuration - appsetting.json
var sqlconnectionstring = builder.Configuration.GetConnectionString("sqlcon");
//MyShoppingDbContext obj=new MyShoppingDbContext();
builder.Services.AddDbContext<MyShoppingDbContext>
    (abc => abc.UseSqlServer(sqlconnectionstring));

//IProductRepository obj=new ProductRepository
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddControllers();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
