namespace LibraryVue.Server.Models
{
    public class CreateBookRequest
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int NumberOfPages { get; set; }

        public IFormFile file { get; set; }
    }
}
