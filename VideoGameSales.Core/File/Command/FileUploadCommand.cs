using System;
using Microsoft.AspNetCore.Http;

namespace VideoGameSales.Core.File.Command
{
    public class FileUploadCommand
    {
        public IFormFile file { get; set; }
    }
}
