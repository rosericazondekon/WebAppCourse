using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetadataViewer.Models;
public class Metadata
{
    public string ApplicationName { get; set; }
    public string ApplicationBasePath { get; set; }
    public string TargetFramework { get; set; }
    public string Version { get; set; }
}