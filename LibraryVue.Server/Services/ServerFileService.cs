
using AutoMapper;
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

        public void ReadFile(string name)
        {
            throw new NotImplementedException();
        }

        async public Task<string> SaveFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", file.FileName);

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
        void ReadFile(string name);

    }
}
