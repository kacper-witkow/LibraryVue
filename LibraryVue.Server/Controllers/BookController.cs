using Bibliotekarz.Shared.Model;
using Library.Server.Services;
using LibraryVue.Server.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Collections.Generic;

namespace Library.Server.Controllers
{

    [ApiController]
    [Route("Api/[controller]")]
    public class BookController : Controller
    {

        private readonly ILogger<BookController> _logger;
        private readonly IBookDatabaseService _databaseService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public BookController(IBookDatabaseService databaseService, ILogger<BookController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _databaseService = databaseService;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpGet("[action]")]
        public string Test()
        {
            return "Dziala";
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {

            var result = await _databaseService.GetBooks();
            return Ok(result);
        }
        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> GetAllAuth()
        {
            _logger.LogInformation("Entering GetAllAuth method.");

            if (!User.IsInRole(UserRoles.User))
            {
                _logger.LogWarning("User is not in the required role.");
                return Unauthorized("User does not have the required role.");
            }
            IEnumerable<Book> books = await _databaseService.GetUserBooks(User.Identity.Name);
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
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest("Nie znaleziono książki");
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            await _databaseService.PostBook(book);
            return Created();
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _databaseService.DeleteBook(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Nie znaleziono książki");
            }
        }
    }
}
