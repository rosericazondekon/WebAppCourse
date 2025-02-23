using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Runtime.InteropServices;
using System.Reflection;

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

app.UseAuthorization();

app.MapRazorPages();

app.Run(async context => {
    context.Response.Headers["Content-Type"] = "text/html";
    await context.Response.WriteAsync("<html><body>");
    await context.Response.WriteAsync("<h1>.NET Core Info</h1>");
    await context.Response.WriteAsync($"Environment.Version: {Environment.Version}");
    await context.Response.WriteAsync("<br/>");
    await context.Response.WriteAsync($"RuntimeInformation.FrameworkDescription: {RuntimeInformation.FrameworkDescription}");
    await context.Response.WriteAsync("<br/>");

    var coreCLR = ((AssemblyInformationalVersionAttribute[])typeof(object).Assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false))[0].InformationalVersion;
    await context.Response.WriteAsync($"CoreCLR Build: {coreCLR.Split('+')[0]}");
    await context.Response.WriteAsync("<br/>");
    await context.Response.WriteAsync($"CoreCLR Hash: {coreCLR.Split('+')[1]}");
    await context.Response.WriteAsync("<br/>");

    var coreFX = ((AssemblyInformationalVersionAttribute[])typeof(Uri).Assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false))[0].InformationalVersion;
    await context.Response.WriteAsync($"CoreFX Build: {coreFX.Split('+')[0]}");
    await context.Response.WriteAsync("<br/>");
    await context.Response.WriteAsync($"CoreFX Hash: {coreFX.Split('+')[1]}");
    await context.Response.WriteAsync("<br/>");
    await context.Response.WriteAsync("<h2>Environment info</h2>");
    await context.Response.WriteAsync($"Environment.OSVersion: {Environment.OSVersion}");
    await context.Response.WriteAsync("<br/>");
    await context.Response.WriteAsync($"RuntimeInformation.OSDescription: {RuntimeInformation.OSDescription}");
    await context.Response.WriteAsync("<br/>");
    await context.Response.WriteAsync($"RuntimeInformation.OSArchitecture: {RuntimeInformation.OSArchitecture}");
    await context.Response.WriteAsync("<br/>");
    await context.Response.WriteAsync($"Environment.ProcessorCount: {Environment.ProcessorCount}");
    await context.Response.WriteAsync("</body></html>");
});

app.Run();
