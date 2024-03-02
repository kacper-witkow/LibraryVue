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
    public string Autor { get; set; }
    public string Title { get; set; }
    public int NumerOfPages { get; set; }
    public bool IsBorrowed { get; set; }

}
