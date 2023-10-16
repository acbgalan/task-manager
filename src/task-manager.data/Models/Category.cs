using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_manager.data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [DisplayName("Categoría")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        [StringLength(25, ErrorMessage = "Se esperaba una cadena de texto con un máximo de {1} caracteres")]
        public string Name { get; set; }

        public List<Task> Tasks { get; set; }
    }
}
