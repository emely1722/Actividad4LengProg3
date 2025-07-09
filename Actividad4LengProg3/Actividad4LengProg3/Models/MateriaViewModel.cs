using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Actividad4LengProg3.Models
{
    public class MateriaViewModel
    {

        [Key]
        [Required (ErrorMessage = "Ingrese codigo de la materia")]
        [StringLength (20)]
        [Column ("CODIGO_MATERIA")]
        [Display(Name  = "Codigo de Materia")]
        public string codigo { get; set; }

        [Required (ErrorMessage = "Ingrese nombre de la materia")]
        [StringLength (100)]
        [Column ("NOMBRE_MATERIA")]
        [Display (Name = "Nombre de la Materia")]
        public string nombre_materia { get; set;}


        [Required (ErrorMessage ="Ingrese los creditos de la materia")]
        [Range (1,4, ErrorMessage ="Credito debe estar entre 1 y 4.")]
        [Column ("CREDITOS")]
        public int creditos { get; set;}

        [Required (ErrorMessage ="Ingrese la carrera que corresponde a la materia")]
        [StringLength (100)]
        [Column("CARRERA")]
        [Display(Name ="Carreras")]
        public string carrera { get; set;}
    }
}




//Emely Ferreras Acosta
//SD-2023-04969
