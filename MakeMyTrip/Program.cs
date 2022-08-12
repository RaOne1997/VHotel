using MakeMyTrip.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MakeMyTrip.Data;
using MakeMyTrip;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IRoomServices, RoomServices>();
builder.Services.AddHttpClient<IBooksServices, BooksServices>();
builder.Services.AddHttpClient<IFlightScheduleServices, FlightScheduleServices>();
builder.Services.AddHttpClient<ITextSercides, TextSercides>();

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
    pattern: "{controller=Books}/{action=Index}/{id?}");

app.Run();
