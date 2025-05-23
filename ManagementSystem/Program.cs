using Csla.Configuration;
using ManagementSystem.DataAccessLayer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddCsla();
builder.Services.AddScoped<ICourseDAL,CourseDAL>();
builder.Services.AddScoped<IFacilitatorDAL,FacilitatorDAL>();
builder.Services.AddScoped<IClassDAL, ClassDAL>();
builder.Services.AddScoped<ILookupDAL, LookupDAL>();
builder.Services.AddScoped<IStudentDAL, StudentDAL>();
builder.Services.AddDbContext<WebApiDbContext>();
builder.Services.AddMudServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
