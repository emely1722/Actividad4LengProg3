using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Actividad4LengProg3.Models;

public class BdActividad4Context : DbContext
{
    public BdActividad4Context(DbContextOptions options) : base(options)
    {
    }



    public DbSet<EstudianteViewModel> Estudiantes { get; set; }
    public DbSet<MateriaViewModel> Materias { get; set; }

    public DbSet<CalificacionViewModel> Calificaciones { get; set; }

}

