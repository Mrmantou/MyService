using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileBrowser
{
    public static class Extensions
    {
        public static void UseStaticFilesAndDirectoryBrowser(this IApplicationBuilder app)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files");
            var fileProvider = new PhysicalFileProvider(path);

            // add file extention mapping
            var contenTypeProvider = new FileExtensionContentTypeProvider();
            contenTypeProvider.Mappings.Add(".7z", "application/x-7z-compressed");

            var fileOptions = new StaticFileOptions
            {
                ContentTypeProvider = contenTypeProvider,
                FileProvider = fileProvider,
                RequestPath = "/files"
            };

            var directoryOptions = new DirectoryBrowserOptions
            {
                FileProvider = fileProvider,
                RequestPath = "/files"
            };

            app.UseStaticFiles(fileOptions)
                .UseDirectoryBrowser(directoryOptions);
        }
    }
}
