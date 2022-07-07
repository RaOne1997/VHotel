using Microsoft.EntityFrameworkCore;
using staticclassmodel.DataAccess.Model.Master;
using VHotel;
using VHotel.DataAccess;
using VHotel.RepositoryPattern;
using VHotel.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

var connectionstring = builder.Configuration.GetConnectionString("VhotelSQL");
builder.Services.AddDbContext<VhotelsSQLContex>(options => options.UseSqlServer(connectionstring));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<IRoomServices, RoomServices>();
builder.Services.AddScoped<ICityServices, CityServices>();
builder.Services.AddScoped<IStateServices, StateServices>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

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
