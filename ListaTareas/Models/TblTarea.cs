using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ListaTareas.Models
{
    [Table("tblTareas")]
    public partial class TblTarea
    {
        public TblTarea()
        {
            TblCategoriaTareas = new HashSet<TblCategoriaTarea>();
        }

        [Key]
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
        [Column("fechaLimite", TypeName = "datetime")]
        public DateTime FechaLimite { get; set; }
        [Column("fechaCreacion", TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }
        [Column("idUsuario")]
        public int IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(TblUsuario.TblTareas))]
        public virtual TblUsuario IdUsuarioNavigation { get; set; }
        [InverseProperty(nameof(TblCategoriaTarea.IdTareaNavigation))]
        public virtual ICollection<TblCategoriaTarea> TblCategoriaTareas { get; set; }
    }
}
