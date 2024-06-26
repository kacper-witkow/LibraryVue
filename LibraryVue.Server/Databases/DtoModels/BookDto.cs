﻿using LibraryVue.Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekarz.Shared.Model;

public class BookDto
{
    public int Id { get; set; }
    public string Author { get; set; }
    public string Title { get; set; }
    public int NumberOfPages { get; set; }
    public bool IsBorrowed { get; set; }
    public string? UserName { get; set; }
    public string? FileName { get; set; }

}
