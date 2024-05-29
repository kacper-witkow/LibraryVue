using LibraryVue.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekarz.Shared.Model;

public class Book
{
    public int? Id { get; set; }
    public string Author { get; set; }
    public string Title { get; set; }
    public int NumberOfPages { get; set; }
    public bool IsBorrowed { get; set; }
    public string? UserName { get; set; }
    public string? FileName { get; set; }

    public Book(string _Author, string _Title,int _NumberOfPages)
    {
        this.Author = _Author;
        this.Title = _Title;
        this.NumberOfPages = _NumberOfPages;
        this.IsBorrowed = false;
    }
    public Book()
    {

    }
}
