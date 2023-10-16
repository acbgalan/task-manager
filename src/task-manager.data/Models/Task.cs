﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_manager.data.Models
{
    [Table("Tasks")]
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [DisplayName("Fecha de creación")]
        public DateTime CreationTime { get; set; }

        [DisplayName("Descripción")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        [StringLength(500, ErrorMessage = "Se esperaba una cadena de texto con un máximo de {1} caracteres")]
        public string Description { get; set; }

        [DisplayName("Recuérdame")]
        public DateTime? RemenberMe { get; set; }

        [DisplayName("Fecha de vencimiento")]
        public DateTime? ExpirationTime { get; set; }


        public List<Category> Categories { get; set; }
        public List<Step> Steps { get; set; }
    }
}