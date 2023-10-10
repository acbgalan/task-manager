using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace task_manager.api.Responses.Category
{
    public class CategoryResponse
    {
        public int Id { get; set; }

        [DisplayName("Categoría")]
        public string Name { get; set; }
    }
}
