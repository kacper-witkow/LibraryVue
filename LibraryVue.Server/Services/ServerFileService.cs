
using AutoMapper;
using Azure.Core;
using Bibliotekarz.Server.Data.Context;
using Library.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryVue.Server.Services
{
    public class ServerFileService : IServerFileService
    {

        private readonly IMapper _mapper;
        private readonly ILogger<IBookDatabaseService> _logger;
        public ServerFileService (IMapper mapper, ILogger<IBookDatabaseService> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MemoryStream> ReadFile(string name)
        {
            if (name == null || name.Length == 0)
                return null;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");

            path = Path.Combine(path, name);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return memory;

        }

        async public Task<string> SaveFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");

            if(!Directory.Exists(path))
                Directory.CreateDirectory(path);

            path = Path.Combine(path,file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return file.FileName;
        }
    }

    public interface IServerFileService
    {
        Task<string> SaveFile(IFormFile  file);
        Task<MemoryStream> ReadFile(string name);

    }
}
