using AutoMapper;
using Bibliotekarz.Server.Data.Context;
using Bibliotekarz.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Library.Server.Services
{
    public class BookDatabaseService : IBookDatabaseService
    {
        private readonly BooksDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<IBookDatabaseService> _logger;
        public BookDatabaseService(BooksDbContext dbContext, IMapper mapper, ILogger<IBookDatabaseService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public async void DeleteBook(int id)
        {
            _dbContext.Books.Remove(_dbContext.Books.First(b => b.Id == id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Book> GetBook(int id)
        {
            BookDto book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);

            Book result = _mapper.Map<Book>(
                book);
            return result;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            IEnumerable<BookDto> books = await _dbContext.Books.ToListAsync();

            // Fetching related data for borrowed books using explicit loading

            var borrowedBooks = books.Where(b => b.IsBorrowed).ToList();
            IEnumerable<Book> result = _mapper.Map<IEnumerable<Book>>(
                books);
            return result;
        }
        public async Task<IEnumerable<Book>> GetUserBooks(string userName)
        {
            IEnumerable<BookDto> books = await _dbContext.Books.Where(b=>b.IsBorrowed && b.UserName==userName).ToListAsync();

            // Fetching related data for borrowed books using explicit loading

            IEnumerable<Book> result = _mapper.Map<IEnumerable<Book>>(
                books);
            return result;
        }
        public async Task<IEnumerable<Book>> GetAllAvailableBooks()
        {
            IEnumerable<BookDto> books = await _dbContext.Books.Where(b => !b.IsBorrowed).ToListAsync();

            // Fetching related data for borrowed books using explicit loading

            IEnumerable<Book> result = _mapper.Map<IEnumerable<Book>>(
                books);
            return result;
        }

        public async Task<int> PostBook(Book book)
        {
            await _dbContext.Books.AddAsync(_mapper.Map<BookDto>(book));
            return await _dbContext.SaveChangesAsync();
        }

        public async void UpdateBooksOwner(string userName,int bookId)
        {
            BookDto book = _dbContext.Books.FirstOrDefault(b=>b.Id==bookId);
            book.UserName = userName;
            book.IsBorrowed = true;
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
        }
    }

    public interface IBookDatabaseService
    {
        public Task<Book> GetBook(int id);
        public Task<IEnumerable<Book>> GetBooks();
        public Task<IEnumerable<Book>> GetAllAvailableBooks();
        public Task<IEnumerable<Book>> GetUserBooks(string userName); 
        public void UpdateBooksOwner(string userName, int bookId);
        public void DeleteBook(int id);
        public Task<int> PostBook(Book book);


    }
}
