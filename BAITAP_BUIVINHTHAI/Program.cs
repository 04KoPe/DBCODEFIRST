using BAITAP_BUIVINHTHAI.data_access;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddMvc(option =>
{
    option.EnableEndpointRouting = false;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CompanyDbContext>(options => options.
UseSqlServer(builder.Configuration
.GetConnectionString("CompanyConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
app.UseMvcWithDefaultRoute();
app.MapControllers();
app.MapRazorPages();
app.Run();
