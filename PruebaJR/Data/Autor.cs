using System;
using System.Collections.Generic;

namespace PruebaJR.Data;

public partial class Autor
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
