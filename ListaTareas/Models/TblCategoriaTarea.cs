using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ListaTareas.Models
{
    [Table("tblCategoriaTarea")]
    public partial class TblCategoriaTarea
    {
        [Key]
        [Column("idCatTarea")]
        public int IdCatTarea { get; set; }
        [Column("idTarea")]
        public int IdTarea { get; set; }
        [Column("idCategoria")]
        public int IdCategoria { get; set; }

        [ForeignKey(nameof(IdCategoria))]
        [InverseProperty(nameof(TblCategorium.TblCategoriaTareas))]
        public virtual TblCategorium IdCategoriaNavigation { get; set; }
        [ForeignKey(nameof(IdTarea))]
        [InverseProperty(nameof(TblTarea.TblCategoriaTareas))]
        public virtual TblTarea IdTareaNavigation { get; set; }
    }
}
