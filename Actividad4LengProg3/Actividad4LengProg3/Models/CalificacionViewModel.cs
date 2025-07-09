using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Actividad4LengProg3.Models

{
    public class CalificacionViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required (ErrorMessage = "Matricula obligatoria")]
        [StringLength (15, MinimumLength = 6, ErrorMessage = "Matricula debe estar entre 6 y 15 caracteres.")]
        [Column ("MATRICULA_ESTUDIANTE")]
        [Display (Name ="Matricula")]
        public string MATRICULA_ESTUDIANTE { get; set; }

        [Required (ErrorMessage ="Es necesario el codigo de la materia")]
        [Column("CODIGO_MATERIA")]
        [Display(Name = "Codigo de Materia")]
        public string CODIGO_MATERIA { get; set; }

        [Required(ErrorMessage ="Nota requerida")]
        [Range (0,100, ErrorMessage ="Nota debe ser entre 0 y 100")]
        [Column("NOTA")]
        [Display(Name ="Nota")]
        public decimal NOTA { get; set; }

        [Required(ErrorMessage ="El periodo es necesario")]
        [Column("PERIODO")]
        [Display(Name ="Periodo")]
        public string PERIODO {  get; set; }


        [ForeignKey("MATRICULA_ESTUDIANTE")]
        public virtual EstudianteViewModel? Estudiante { get; set; }

        [ForeignKey("CODIGO_MATERIA")]
        public virtual EstudianteViewModel? Materia { get; set; }

    }
}

