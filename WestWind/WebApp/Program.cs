#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using WestWindSystem;
#endregion

var builder = WebApplication.CreateBuilder(args);

//retreive the connection string from the appsetting.json file
//The connection string will be passed to the class library extension method
//  for use in registering the access to the required database
var connectionString = builder.Configuration.GetConnectionString("WWDB");

//setup the registration of services to be available for use by this web app project
//the technique used in this example has the registration of service encapsulated within
//  the class library
//Technically you could do all coding within this class (Program.cs)
builder.Services.WWExtensions(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddRazorPages();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
