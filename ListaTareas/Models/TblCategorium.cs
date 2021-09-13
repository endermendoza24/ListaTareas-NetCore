using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ListaTareas.Models
{
    [Table("tblCategoria")]
    public partial class TblCategorium
    {
        public TblCategorium()
        {
            TblCategoriaTareas = new HashSet<TblCategoriaTarea>();
        }

        [Key]
        [Column("idCategoria")]
        public int IdCategoria { get; set; }
        [Required]
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Column("fechaCreacion", TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }

        [InverseProperty(nameof(TblCategoriaTarea.IdCategoriaNavigation))]
        public virtual ICollection<TblCategoriaTarea> TblCategoriaTareas { get; set; }

        //public static implicit operator TblCategorium(TblCategorium v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
