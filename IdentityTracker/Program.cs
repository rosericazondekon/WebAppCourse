using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using ReturnTrue.AspNetCore.Identity.Anonymous;

var builder = WebApplication.CreateBuilder(args);

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

app.UseAnonymousId(new AnonymousIdCookieOptionsBuilder()
    .SetCustomCookieName("Anonymous_Cookie_Tracker")
    // .SetCustomCookieRequireSsl(true) // Uncomment in case of using SSL
    .SetCustomCookieTimeout(120)
);

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/id", async context =>
    {
        IAnonymousIdFeature feature = context.Features.Get<IAnonymousIdFeature>();
        string anonymousId = feature.AnonymousId;
        await context.Response.WriteAsync($"Hello User with anonymous id: {anonymousId}");
    });
});

app.UseAuthorization();

app.MapRazorPages();

// app.Run(async context =>
// {
//     IAnonymousIdFeature feature = context.Features.Get<IAnonymousIdFeature>();
//     string anonymousId = feature.AnonymousId;
//     await context.Response.WriteAsync($"Hello world with anonymous id {anonymousId}");
// });

app.Run();
