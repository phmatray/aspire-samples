using System.IO.Compression;
using System.Reflection;

namespace AspireAppWithMicroFrontends.Web.Extensions;

public static class WebModuleLoaderExtensions
{
    public static RazorComponentsEndpointConventionBuilder AddModulesFromAssemblies(
        this RazorComponentsEndpointConventionBuilder builder,
        IWebHostEnvironment environment)
    {
        var assemblyPath = Path.Combine(environment.WebRootPath, "assemblies");
        var modulesPath = Path.Combine(environment.WebRootPath, "assemblies", "modules");
    
        // read *.nupkg files from the assemblies folder
        var nupkgFiles = Directory.GetFiles(modulesPath, "*.nupkg");
    
        // extract the assemblies from the nupkg files
        foreach (var nupkgFile in nupkgFiles)
        {
            using ZipArchive archive = ZipFile.OpenRead(nupkgFile);
        
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                if (!entry.FullName.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
                    continue;
                
                var fileName = Path.GetFileName(entry.FullName);
                var destinationPath = Path.Combine(assemblyPath, fileName);
                entry.ExtractToFile(destinationPath, overwrite: true);
            }
        }

        Assembly[] assemblies = [
            Assembly.LoadFrom(Path.Combine(assemblyPath, "BlueModule.Web.dll")),
            Assembly.LoadFrom(Path.Combine(assemblyPath, "RedModule.Web.dll")),
            Assembly.LoadFrom(Path.Combine(assemblyPath, "GreenModule.Web.dll")),
            Assembly.LoadFrom(Path.Combine(assemblyPath, "YellowModule.Web.dll"))
        ];
        
        builder.AddAdditionalAssemblies(assemblies);
        
        return builder;
    }
}