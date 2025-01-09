global using Microsoft.AspNetCore.Components.Forms;
global using Microsoft.EntityFrameworkCore;
global using UDI_kodetest_revised.Components;
global using UDI_kodetest_revised.Data;
global using UDI_kodetest_revised.Models;
global using UDI_kodetest_revised.Services.FileService;
global using UDI_kodetest_revised.Services.DataInsightService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services
    .AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IDataInsightService, DataInsightService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
