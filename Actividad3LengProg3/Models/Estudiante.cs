using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models;

public partial class Estudiante
{
    public int IdEstudiante { get; set; }
    [Required (ErrorMessage = "Nombre es obligatorio")]
    [StringLength(100)]
    [Display (Name ="Nombre completo")]

    public string NombreCompleto { get; set; } = null!;

    [Required(ErrorMessage = "Matrícula es obligatoria")]
    [StringLength(15, MinimumLength =6)]
    public string Matricula { get; set; } = null!;

    [Required(ErrorMessage = "Seleccione una carrera")]
    public string Carrera { get; set; } = null!;

    [Required(ErrorMessage = "Correo es obligatorio")]
    [EmailAddress(ErrorMessage = "Correo inválido")]
    [Display(Name = "Correo Institucional")]
    public string CorreoInstitucional { get; set; } = null!;


    [Phone]
    [MinLength(10)]
    public long Telefono { get; set; }

    [Required(ErrorMessage = "Indique su fecha de nacimiento")]
    [DataType(DataType.Date)]
    public DateOnly FechaNac { get; set; }

    [Required]
    public string Genero { get; set; } = null!;
    
    
    [Required]
    public string Turno { get; set; } = null!;

    [Required (ErrorMessage ="Elige tipo de ingreso")]
    [Display (Name = "Tipo de ingreso")]
    public string TipoIngreso { get; set; } = null!;

    [Required]
    public bool EstaBecado { get; set; }
    [Range (0,100)]
    public int? PorcentajeBeca { get; set; }

    [Required]  
    [Range (typeof(bool), "true", "true", ErrorMessage ="Acepte términos y condiciones")]
    public bool TerminosCondiciones { get; set; }

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();
}
