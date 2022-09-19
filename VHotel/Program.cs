using Microsoft.EntityFrameworkCore;
using staticclassmodel.Models;
using MakeMuTrip;
using MakeMuTrip.DataAccess;
using MakeMuTrip.DataAccess.DTo;
using MakeMuTrip.RepositoryPattern;
using MakeMuTrip.RepositoryPattern.Interface;
using MakeMuTrip.Services;
using MakeMuTrip.Services.Interface;
using Microsoft.AspNetCore.Identity;
using VHotel.DataAccess.Model.Master;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VHotel.Services;
using VHotel.DataAccess.Model.security;
using staticclassmodel.Modelss;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var connectionstring = builder.Configuration.GetConnectionString("VhotelSQL");
builder.Services.AddDbContext<VhotelsSQLContex>(options => options.UseSqlServer(connectionstring));
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<VhotelsSQLContex>();
var securitySetting = builder.Configuration.GetSection(nameof(JwtSecuritySettings));
builder.Services.Configure<JwtSecuritySettings>(securitySetting);

var securityKey = builder.Configuration.GetValue<string>("JwtSecuritySettings:SecurityKey");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey =
new SymmetricSecurityKey(Encoding.ASCII.GetBytes(@"54d6504255f2effe17f74a8b8170e7a8ece0fc79"))
    };
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<IRoomServices, RoomServices>();
builder.Services.AddScoped<IStateServices, StateServices>();
builder.Services.AddScoped<IHotelServices, HotelServices>();
builder.Services.AddScoped<IStaticInsert, StaticInsert>();




builder.Services.AddScoped<ICityServices, CityServices>();
builder.Services.AddScoped<IAuthTokenService, AuthTokenService>();
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


app.UseAuthentication();
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



