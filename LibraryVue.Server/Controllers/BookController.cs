using Bibliotekarz.Shared.Model;
using Library.Server.Services;
using LibraryVue.Server.Models;
using LibraryVue.Server.Models.Auth;
using LibraryVue.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Net;

namespace Library.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Api/[controller]")]
    public class BookController : Controller
    {

        private readonly ILogger<BookController> _logger;
        private readonly IBookDatabaseService _databaseService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager; 
        private readonly IServerFileService _serverFileServicer;
        public BookController(IBookDatabaseService databaseService, ILogger<BookController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IServerFileService serverFileServicer)
        {
            _logger = logger;
            _databaseService = databaseService;
            _userManager = userManager;
            _signInManager = signInManager;
            _serverFileServicer = serverFileServicer;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAuth()
        {
            _logger.LogInformation("Entering GetAllAuth method.");
            IEnumerable<Book> books = new List<Book>();

            if (!User.IsInRole(UserRoles.User))
            {
                books = await _databaseService.GetBooks();
            }
            else
            {
                books = await _databaseService.GetUserBooks(User.Identity.Name);
            }
            return Ok(books);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAvailableBooks()
        {
            IEnumerable<Book> books = await _databaseService.GetAllAvailableBooks();
            return Ok(books);
        }

        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> borrowBook(int Id)
        {
            if (User.IsInRole(UserRoles.Admin))
            {
                return Unauthorized("Admin cannot borrow books");
            }
            
            _databaseService.UpdateBooksOwner(User.Identity.Name,Id);
            return Ok();
        }
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                Book book = await _databaseService.GetBook(Id);
                if (book.UserName == User.Identity.Name || User.IsInRole(UserRoles.Admin))
                        return Ok(book);

                return Unauthorized("This book doesn't belong to you!");
            }
            catch (Exception ex)
            {
                return BadRequest("Nie znaleziono książki");
            }
        }
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetFile(int Id)
        {
            try
            {
                Book book = await _databaseService.GetBook(Id);

                if (book.UserName == User.Identity.Name || User.IsInRole(UserRoles.Admin))
                {
                    string fileName = book.FileName;
                    MemoryStream responseStream = new MemoryStream();
                    responseStream = await _serverFileServicer.ReadFile(fileName);

                    return File(responseStream, "application/pdf", fileName);
                }
                else
                {

                    return Unauthorized();
                }

            }
            catch (Exception ex)
            {
                return BadRequest("Nie znaleziono książki");
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBook([FromForm] CreateBookRequest req)
        {
            if (req != null && User.IsInRole(UserRoles.Admin))
            {

                string fileName = await _serverFileServicer.SaveFile(req.file);
                
                if (fileName is not null)
                {
                    Book book = new Book(req.Author,req.Title,req.NumberOfPages);
                    await _databaseService.PostBook(book, fileName);
                    return Created();
                }
                
            }
            return BadRequest();
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                if (User.IsInRole(UserRoles.Admin))
                {
                    _databaseService.DeleteBook(id);
                    return Ok();
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Nie znaleziono książki");
            }
        }
    }
}
