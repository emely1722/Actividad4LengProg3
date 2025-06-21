using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Actividad3LengProg3.Models
{
    public class EstudianteViewModel
    {
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(100)]
        [Display(Name = "Nombre completo del estudiante")]
        public string nombre_estudiante { get; set; }



        [Required(ErrorMessage = "Matricula es obligatoria")]
        [StringLength(20), MinLength(6)]
        [Display(Name = "Matrícula")]
        public string matricula_estudiante { get; set; }



        [Required(ErrorMessage = "Eliga una carrera")]
        [Display(Name = "Carrera")]
        public string carrera_estudiante { get; set; }
        public List<SelectListItem> carreras { get; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "Ingeniería en Software", Text = "Ingeniería en Software" },
        new SelectListItem { Value = "Administración de Empresas", Text = "Administración de Empresas" },
        new SelectListItem { Value = "Odontología", Text = "Odontología" },
    };


        [Required(ErrorMessage = "Correo Obligatorio.")]
        [EmailAddress (ErrorMessage = "Correo no válido")]
        [Display (Name= "Correo Institucional")]
        public string correo_estudiante { get; set; }


        [Phone]
        [MinLength(10)]
        [Display(Name = "Número")]
        public string telefono_estudiante { get; set; }


        [Required(ErrorMessage = "Escriba su fecha de nacimiento")]
        [DataType (DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime fecha_nacimiento { get; set; }

        [Required]
        [Display (Name = "Genero")]
        public string genero_estudiante { get; set; }


        [Required (ErrorMessage = "Elige Turno")]
        [Display (Name = "Turno")]
        public string turno { get; set; }
        public List<SelectListItem> turnos { get; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "Matutino", Text = "Matutino" },
        new SelectListItem { Value = "Vespertino", Text = "Vespertino" },
        new SelectListItem { Value = "Nocturno", Text = "Nocturno" }
    };


        [Required (ErrorMessage = "Tipo de Ingreso")]
        [Display (Name = "Tipo de Ingreso")]
        public string tipo_ingreso { get; set; }
        public List<SelectListItem> ingreso { get; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "Nuevo Ingreso", Text = "Nuevo Ingreso" },
        new SelectListItem { Value = "Ingreso por Transferencia", Text = "Ingreso por Transferencia" },
        new SelectListItem { Value = "Reingreso", Text = "Reingreso" },
        new SelectListItem { Value = "Doctorado", Text = "Doctorado" }
    };


        [Display (Name = "¿Tienes beca?")]
        public bool becado { get; set; }




		[Display(Name = "Agrege su porcentaje de beca.")]
		[Range(0, 100)]
        public int? porcentaje_beca { get; set; }



        [Range(typeof(bool), "true", "true", ErrorMessage = "Acepte los términos y condiciones!!.")]
        [Display(Name = "Acepte términos y condiciones.")]
        public bool terminos_condiciones { get; set; }


    }
}