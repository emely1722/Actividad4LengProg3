using System;
using System.Collections.Generic;

namespace Actividad4LengProg3.Models;

public partial class Materia
{
    public string CodigoMateria { get; set; } = null!;

    public string NombreMateria { get; set; } = null!;

    public int Creditos { get; set; }

    public string Carrera { get; set; } = null!;

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();
}
