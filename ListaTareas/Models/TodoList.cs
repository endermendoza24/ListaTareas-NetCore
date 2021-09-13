using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ListaTareas.Models
{
    [Keyless]
    public partial class TodoList
    {
        [Column("idUsuario")]
        public int IdUsuario { get; set; }
        [Required]
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("idTarea")]
        public int IdTarea { get; set; }
        [Required]
        [Column("titulo")]
        [StringLength(100)]
        public string Titulo { get; set; }
        [Required]
        [Column("descripcion")]
        public string Descripcion { get; set; }
        [Column("prioridad")]
        public int Prioridad { get; set; }
        [Column("idCategoria")]
        public int IdCategoria { get; set; }
        [Required]
        [StringLength(50)]
        public string Expr1 { get; set; }
        [Column("fechaCreacion", TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }
    }
}
