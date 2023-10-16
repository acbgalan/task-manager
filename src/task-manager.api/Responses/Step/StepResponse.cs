using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace task_manager.api.Responses.Step
{
    public class StepResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Guid TaskId { get; set; }
    }
}
