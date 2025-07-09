using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Actividad4LengProg3.Models
{
    public class EstudianteViewModel
    {
        [Required(ErrorMessage = "Ingrese nombre completo")]
        [StringLength(100, ErrorMessage = "Nombre Obligatorio")]
        [Column("nombre_estudiante")]
        public string nombre_estudiante { get; set; }

        [Key]
        [Required(ErrorMessage = "Matricula es obligatoria")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "La matrícula debe tener entre 6 y 15 caracteres.")]
        [Column("matricula_estudiante")]
        public string matricula_estudiante { get; set; }

        [Required(ErrorMessage = "Eliga una carrera")]
        [Column("carrera_estudiante")]
        public string carrera_estudiante { get; set; }

        [Required(ErrorMessage = "Correo obligatorio")]
        [EmailAddress(ErrorMessage = "Correo no válido")]
        [Column("correo_estudiante")]
        public string correo_estudiante { get; set; }

        [Phone(ErrorMessage = "Ingrese numero de telefono")]
        [MinLength(10, ErrorMessage = "El teléfono debe tener al menos 10 dígitos.")]
        [Column("telefono_estudiante")]
        public string telefono_estudiante { get; set; }

        [Required(ErrorMessage = "Escriba su fecha de nacimiento")]
        [DataType(DataType.Date)]
        [Column("fecha_nacimiento")]
        public DateTime fecha_nacimiento { get; set; }


        [Required(ErrorMessage = "Seleccione")]
        [Column("genero_estudiante")]
        public string genero_estudiante { get; set; }


        [Required(ErrorMessage = "Elige turno")]
        [Column("turno")]
        public string turno { get; set; }

        [Required(ErrorMessage = "Seleccione Ingreso")]
        [Column("tipo_ingreso")]
        public string tipo_ingreso { get; set; }

        [Column("becado")]
        public bool becado { get; set; }


        [Range(0, 100, ErrorMessage = "Debe agregar su porcentaje")]
        [Column("porcentaje_beca")]
        public int porcentaje_beca { get; set; }

        [Required(ErrorMessage = "Debe aceptar los términos y condiciones.")]
        [Column("terminos_condiciones")]
        public bool terminos_condiciones { get; set; }

    }
}





//Emely Ferreras Acosta
//SD-2023-04969