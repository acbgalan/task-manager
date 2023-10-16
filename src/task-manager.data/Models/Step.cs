using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_manager.data.Models
{
    [Table("Steps")]
    public class Step
    {
        public int Id { get; set; }

        [DisplayName("Descripción")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "Se esperaba uan cadena con un máximo de {1} caracteres")]
        public string Description { get; set; }

        [ForeignKey("Task")]
        public Guid TaskId { get; set; }

        public Task Task { get; set; }
    }
}
