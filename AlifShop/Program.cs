using Infrastructure.Data;
using Infrastructure.IServices;
using Infrastructure.MapperProfiles;
using Infrastructure.SeedData;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AlifShopContext>(conf => conf.UseNpgsql(connection));
builder.Services.AddControllers();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<ICustomerService,CustomerService>();
builder.Services.AddScoped<IInstallmentServise,InstallmentServise>();

//configure automapper
builder.Services.AddAutoMapper(typeof(InfrastructureProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
try
{
    var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AlifShopContext>();
    context.Database.Migrate();
    SeedData.Seed(context);
}
catch (Exception ex)
{
    app.Logger.LogError(ex.Message);
}
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