using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AgenceTestApplication.Models
{
    [Table("cao_os")]
    public partial class CaoO
    {
        [Key]
        [Column("co_os")]
        public int CoOs { get; set; }
        [Column("nu_os")]
        public int? NuOs { get; set; }
        [Column("co_sistema")]
        public int? CoSistema { get; set; }
        [Column("co_usuario")]
        [StringLength(50)]
        public string CoUsuario { get; set; }
        [Column("co_arquitetura")]
        public int? CoArquitetura { get; set; }
        [Column("ds_os")]
        [StringLength(200)]
        public string DsOs { get; set; }
        [Column("ds_caracteristica")]
        [StringLength(200)]
        public string DsCaracteristica { get; set; }
        [Column("ds_requisito")]
        [StringLength(200)]
        public string DsRequisito { get; set; }
        [Column("dt_inicio", TypeName = "date")]
        public DateTime? DtInicio { get; set; }
        [Column("dt_fim", TypeName = "date")]
        public DateTime? DtFim { get; set; }
        [Column("co_status")]
        public int? CoStatus { get; set; }
        [Column("diretoria_sol")]
        [StringLength(50)]
        public string DiretoriaSol { get; set; }
        [Column("dt_sol", TypeName = "date")]
        public DateTime? DtSol { get; set; }
        [Column("nu_tel_sol")]
        [StringLength(20)]
        public string NuTelSol { get; set; }
        [Column("ddd_tel_sol")]
        [StringLength(5)]
        public string DddTelSol { get; set; }
        [Column("nu_tel_sol2")]
        [StringLength(20)]
        public string NuTelSol2 { get; set; }
        [Column("ddd_tel_sol2")]
        [StringLength(5)]
        public string DddTelSol2 { get; set; }
        [Column("usuario_sol")]
        [StringLength(50)]
        public string UsuarioSol { get; set; }
        [Column("dt_imp", TypeName = "date")]
        public DateTime? DtImp { get; set; }
        [Column("dt_garantia", TypeName = "date")]
        public DateTime? DtGarantia { get; set; }
        [Column("co_email")]
        public int? CoEmail { get; set; }
        [Column("co_os_prospect_rel")]
        public int? CoOsProspectRel { get; set; }
    }
}
