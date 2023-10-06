using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_manager.data.Models
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [DisplayName("Tarea")]
        public string Name { get; set; }

        [DisplayName("Aviso")]
        public DateTime? RemenberMe { get; set; }

        [DisplayName("Fecha de vencimiento")]
        public DateTime? ExpirationTime { get; set; }

    }
}
