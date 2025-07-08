using System.ComponentModel.DataAnnotations;


namespace Actividad4LengProg3.Models
{
    public class MateriaViewModel
    {

        [Key]
        [Required (ErrorMessage = "Ingrese codigo de la materia")]
        public string codigo { get; set; }

        [Required (ErrorMessage = "Ingrese nombre de la materia")]
        [StringLength (100)]
        public string nombre_materia { get; set;}

        [Required (ErrorMessage ="Ingrese los creditos de la materia")]
        [Range (1,10)]
        public int creditos { get; set;}

        [Required (ErrorMessage ="Ingrese la carrera que corresponde a la materia")]
        public string carrera { get; set;}
    }
}
