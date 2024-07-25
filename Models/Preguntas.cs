using System.ComponentModel.DataAnnotations;

namespace CRUD_Preguntas.Models
{
    public class Preguntas
    {

        [Key]
        public int PreguntaID { get; set; }

        [Display(Name = "Texto de la Pregunta")]
        [Required(ErrorMessage = "El texto de la Pregunta es Obligarotrio")]
        public string TextoPregunta { get; set; }

        [Display(Name = "Respuesta Correcta")]
        [Required(ErrorMessage = "La Respuesta Correcta es Obligatoria")]
        public string Correcta { get; set; }

        [Display(Name = "Respuesta Incorrecta #1")]
        [Required(ErrorMessage = "La Respuesta Incoorrecta #1 es Obligatoria")]
        public string Incorrecta1 { get; set; }

        [Display(Name = "Respuesta Incorrecta #2")]
        [Required(ErrorMessage = "La Respuesta Incoorrecta #3 es Obligatoria")]
        public string Incorrecta2 { get; set; }

        [Display(Name = "Respuesta Incorrecta #3")]
        [Required(ErrorMessage = "La Respuesta Incoorrecta #3 es Obligatoria")]
        public string Incorrecta3 { get; set; }
    }
}
