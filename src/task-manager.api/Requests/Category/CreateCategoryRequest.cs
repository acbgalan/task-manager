using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace task_manager.api.Requests.Category
{
    public class CreateCategoryRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        [StringLength(25, ErrorMessage = "Se esperaba una cadena de texto con un máximo de {1} caracteres")]
        public string Name { get; set; }
    }
}
