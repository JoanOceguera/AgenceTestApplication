using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AgenceTestApplication.Models
{
    [Table("permissao_sistema")]
    [Index(nameof(CoUsuario), nameof(CoTipoUsuario), nameof(CoSistema), nameof(DtAtualizacao), Name = "co_usuario")]
    public partial class PermissaoSistema
    {
        [Key]
        [Column("co_usuario")]
        [StringLength(20)]
        public string CoUsuario { get; set; }
        [Key]
        [Column("co_tipo_usuario")]
        public ulong CoTipoUsuario { get; set; }
        [Key]
        [Column("co_sistema")]
        public ulong CoSistema { get; set; }
        [Required]
        [Column("in_ativo")]
        [StringLength(1)]
        public string InAtivo { get; set; }
        [Column("co_usuario_atualizacao")]
        [StringLength(20)]
        public string CoUsuarioAtualizacao { get; set; }
        [Column("dt_atualizacao", TypeName = "datetime")]
        public DateTime DtAtualizacao { get; set; }
    }
}
