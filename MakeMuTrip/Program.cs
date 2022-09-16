using Microsoft.EntityFrameworkCore;
using staticclassmodel.Models;
using MakeMuTrip;
using MakeMuTrip.DataAccess;
using MakeMuTrip.DataAccess.DTo;
using MakeMuTrip.RepositoryPattern;
using MakeMuTrip.RepositoryPattern.Interface;
using MakeMuTrip.Services;
using MakeMuTrip.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
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
builder.Services.AddScoped<ICustomers<CustomersDTO>, CustomersServices>();
builder.Services.AddScoped<IFilightShedulServices, FlightScheduleServices>();
builder.Services.AddScoped<IFlightBookingServices, FlightBookingServices>();
builder.Services.AddScoped<IAccountService, AccountService>();
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
builder.Services.AddScoped<IAccountRepositery, AccountRepositery>();
builder.Services.AddScoped<IHotelAmenitiesLinkRepository, HotelAmenitiesLinkRepository>();
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
builder.Services.AddScoped<IFlightScheduleRepository, FlightScheduleRepository>();
builder.Services.AddScoped<IFlightBookingReoposttory, FlightBookingReoposttory>();
builder.Services.AddScoped<IHotelBookingRepository, HotelBookingRepository>();
builder.Services.AddScoped<IHotelCustomerDetailRepository, HotelCustomerDetailRepository>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
