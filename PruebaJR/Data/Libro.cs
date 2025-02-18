using System;
using System.Collections.Generic;

namespace PruebaJR.Data;

public partial class Libro
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public int AutorId { get; set; }

    public virtual Autor Autor { get; set; } = null!;
}
