using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseStaticFiles();
app.UseSession();

app.MapGet("/", () => "TMS HotDesk is running on .NET 8");

app.Run();
