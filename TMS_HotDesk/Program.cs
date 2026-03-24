using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Register connection strings from appsettings.json for Library.SQLServer and Library.Oracle.
// This bridges ASP.NET Core IConfiguration to the legacy ConfigurationManager-based libraries.
var config = app.Configuration;
Library.SQLServer.Connection.RegisterConnectionString("SQLCon", config.GetConnectionString("SQLCon"));
Library.Oraclecls.Connection.RegisterConnectionString("OraCon", config.GetConnectionString("OraCon"));
Library.Oraclecls.Connection.RegisterConnectionString("OraCon1", config.GetConnectionString("OraCon1"));
Library.Oraclecls.Connection.RegisterConnectionString("ORCL_ACL", config.GetConnectionString("ORCL_ACL"));
Library.Oraclecls.Connection.RegisterConnectionString("ORCL_IP", config.GetConnectionString("ORCL_IP"));

// Register app settings for BusinessLogicBase.
Library.Root.Other.BusinessLogicBase.RegisterMaxRowPerPage(config["AppSettings:MaxRowPerPage"]);

// Configure the HTTP request pipeline.
app.UseStaticFiles();

// Serve static files (css, js, images) from content root directories.
// These directories exist at project root level rather than in wwwroot/.
var contentRoot = builder.Environment.ContentRootPath;
string[] staticDirs = { "css", "css_new", "js", "jss", "image", "img", "icons", "resources", "Acc" };
foreach (var dir in staticDirs)
{
    var dirPath = Path.Combine(contentRoot, dir);
    if (Directory.Exists(dirPath))
    {
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(dirPath),
            RequestPath = "/" + dir
        });
    }
}

app.UseSession();
app.UseRouting();

app.MapRazorPages();

app.Run();
