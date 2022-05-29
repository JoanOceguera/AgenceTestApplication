using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AgenceTestApplication.Models
{
    [Table("cao_fatura")]
    public partial class CaoFatura
    {
        [Key]
        [Column("co_fatura")]
        public uint CoFatura { get; set; }
        [Column("co_cliente")]
        public int CoCliente { get; set; }
        [Column("co_sistema")]
        public int CoSistema { get; set; }
        [Column("co_os")]
        public int CoOs { get; set; }
        [Column("num_nf")]
        public int NumNf { get; set; }
        [Column("total")]
        public float Total { get; set; }
        [Column("valor")]
        public float Valor { get; set; }
        [Column("data_emissao", TypeName = "date")]
        public DateTime DataEmissao { get; set; }
        [Required]
        [Column("corpo_nf", TypeName = "text")]
        public string CorpoNf { get; set; }
        [Column("comissao_cn")]
        public float ComissaoCn { get; set; }
        [Column("total_imp_inc")]
        public float TotalImpInc { get; set; }
    }
}
