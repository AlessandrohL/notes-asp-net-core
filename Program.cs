using Microsoft.EntityFrameworkCore;
using Todo_app.Data;
using Todo_app.Services.Contracts;
using Todo_app.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connection = builder.Configuration.GetConnectionString("DevConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connection);
});

builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IPriorityService, PriorityService>();
builder.Services.AddScoped<IStateService, StateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Note/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Note}/{action=Index}/{id?}");

app.Run();
