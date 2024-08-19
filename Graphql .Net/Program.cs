using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Graphql_.Net.GraphQL;
using Graphql_.Net.Data;
using Microsoft.EntityFrameworkCore;
using Graphql_.Net.Services;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<Query>();
builder.Services.AddScoped<Mutation>();
builder.Services.AddScoped<AppDbContext>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddAuthorization()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();


app.MapGraphQL();

if (app.Environment.IsDevelopment())
{
    app.UsePlayground(new PlaygroundOptions
    {
        Path = "/playground",
        QueryPath = "/graphql"
    });
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();