﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekarz.Shared.Model;

public class Book
{
    public int Id { get; set; }
    public string Autor { get; set; }
    public string Title { get; set; }
    public int NumerOfPages { get; set; }
    public bool IsBorrowed { get; set; }

}
