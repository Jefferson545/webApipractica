using System.ComponentModel.DataAnnotations;
namespace webApipractica.Models
{
    public class carreras
    {
        [Key]
        public int carrera_id { get; set; }
        public string? nombre_carrera { get; set; }

        public int? factultad_id { get; set; }
    }
}
