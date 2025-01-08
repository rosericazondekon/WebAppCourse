using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MetadataViewer.Models;

namespace MetadataViewer.Controllers;

public class MetadataController : Controller
{
    public IActionResult Index()
    {
        var metadata = new Metadata
        {
            ApplicationName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
            ApplicationBasePath = AppContext.BaseDirectory,
            TargetFramework = GetTargetFramework(),
            Version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString()
        };
        return View(metadata);
    }

    private string GetTargetFramework()
    {
        var entryAssembly = System.Reflection.Assembly.GetEntryAssembly();
        var targetFramework = entryAssembly.GetCustomAttributes(typeof(System.Runtime.Versioning.TargetFrameworkAttribute), true)[0] as System.Runtime.Versioning.TargetFrameworkAttribute;
        return targetFramework.FrameworkName;
    }
}