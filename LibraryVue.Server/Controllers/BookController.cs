using Bibliotekarz.Shared.Model;
using Library.Server.Services;
using LibraryVue.Server.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace Library.Server.Controllers
{

    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class BookController : Controller
    {

        private readonly ILogger<BookController> _logger;
        private readonly IBookDatabaseService _databaseService;
        public BookController(IBookDatabaseService databaseService, ILogger<BookController> logger)
        {
            _logger = logger;
            _databaseService = databaseService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {

            var result = await _databaseService.GetBooks();
            return Ok(result);
        }
        [HttpGet("[action]")]
        [Authorize(Roles =UserRoles.User)]
        public async Task<IActionResult> GetAllAuth()
        {
            var result = await _databaseService.GetBooks();
            return Ok(result);
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
