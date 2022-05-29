using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AgenceTestApplication.Models
{
    [Table("cao_salario")]
    public partial class CaoSalario
    {
        [Key]
        [Column("co_usuario")]
        [StringLength(20)]
        public string CoUsuario { get; set; }
        [Key]
        [Column("dt_alteracao", TypeName = "date")]
        public DateTime DtAlteracao { get; set; }
        [Column("brut_salario")]
        public float BrutSalario { get; set; }
        [Column("liq_salario")]
        public float LiqSalario { get; set; }
    }
}
