using LinkShortener.Data;
using LinkShortener.Helpers.Links;
using LinkShortener.Services.Links.Commands.CreateLink;
using LinkShortener.Services.Links.Commands.SetShortenedLink;
using LinkShortener.Services.Links.Queries.GetByShortLink;
using LinkShortener.Services.Links.Queries.GetLinkById;
using LinkShortener.Services.Links.Queries.GetLinks;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseInMemoryDatabase("ShortenedUrls"));

builder.Services.AddScoped<ILinkHelper, LinkHelper>();

builder.Services.AddMediatR(typeof(CreateLinkCommand));
builder.Services.AddMediatR(typeof(SetShortenedLinkCommand));
builder.Services.AddMediatR(typeof(GetLinksQuery));
builder.Services.AddMediatR(typeof(GetLinkByIdQuery));
builder.Services.AddMediatR(typeof(GetByShortLinkQuery));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
