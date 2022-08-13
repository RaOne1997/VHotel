using Microsoft.EntityFrameworkCore;
using staticclassmodel.DataAccess.Model.Master;
using staticclassmodel.Models;
using VHotel;
using VHotel.DataAccess;
using VHotel.DataAccess.DTo;
using VHotel.RepositoryPattern;
using VHotel.RepositoryPattern.Interface;
using VHotel.Services;
using VHotel.Services.Interface;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

var connectionstring = builder.Configuration.GetConnectionString("VhotelSQL");
builder.Services.AddDbContext<VhotelsSQLContex>(options => options.UseSqlServer(connectionstring));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<IRoomServices, RoomServices>();
builder.Services.AddScoped<IStateServices, StateServices>();
builder.Services.AddScoped<IHotelServices, HotelServices>();
builder.Services.AddScoped<IStaticInsert, StaticInsert>();




builder.Services.AddScoped<ICityServices, CityServices>();
builder.Services.AddScoped<ICrudeServices<CountryDTO>, CountryServices>();
builder.Services.AddScoped<ICrudeServices<AmenuitiesDTO>, AmenuitiesServices>();
builder.Services.AddScoped<ICrudeServices<AirportDTO>, AirportServices>();
builder.Services.AddScoped<ICrudeServices<HotelAmenitiesLinkDTO>, HotelAmenitiesLinkservices>();
builder.Services.AddScoped<ICrudeServices<AirlineDetailsDTO>, AirlineServices>();
builder.Services.AddScoped<ICrudeServices<FlightDTO>, FlightServices>();
builder.Services.AddScoped<ICrudeServices<CustomersDTO>, CustomersServices>();
builder.Services.AddScoped<IFilightShedulServices, FlightScheduleServices>();
builder.Services.AddScoped<IFlightBookingServices, FlightBookingServices>();
builder.Services.AddScoped<ICrudeServices<HotelBookingDTO>, HotelBookingsServices>();
builder.Services.AddScoped<ICrudeServices<HotelCustomerDetailDTO>, HotelCustomerDetailServices>();



builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IAmenuitiesRepository, AmenuitiesRepository>();
builder.Services.AddScoped<IAirportRepository, AirportRepository>();
builder.Services.AddScoped<IAirlineRepository, AirlineRepository>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IHotelAmenitiesLinkRepository, HotelAmenitiesLinkRepository>();
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
builder.Services.AddScoped<IFlightScheduleRepository, FlightScheduleRepository>();
builder.Services.AddScoped<IFlightBookingReoposttory, FlightBookingReoposttory>();
builder.Services.AddScoped<IHotelBookingRepository, HotelBookingRepository>();
builder.Services.AddScoped<IHotelCustomerDetailRepository, HotelCustomerDetailRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
SeedDatabase();
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

void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IStaticInsert>();
        dbInitializer.start();
    }
}
