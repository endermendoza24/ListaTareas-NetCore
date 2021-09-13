using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ListaTareas.Models
{
    [Table("tblUsuario")]
    public partial class TblUsuario
    {
        public TblUsuario()
        {
            TblTareas = new HashSet<TblTarea>();
        }

        [Key]
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
        [Column("fechaCreacion", TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }

        [InverseProperty(nameof(TblTarea.IdUsuarioNavigation))]
        public virtual ICollection<TblTarea> TblTareas { get; set; }
    }
}
