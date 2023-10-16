using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace task_manager.api.Requests.Step
{
    public class CreateStepRequest
    {
        [DisplayName("Descripción")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "Se esperaba uan cadena con un máximo de {1} caracteres")]
        public string Description { get; set; }

        public Guid TaskId { get; set; }
    }
}
