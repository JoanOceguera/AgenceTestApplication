using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AgenceTestApplication.Models
{
    [Table("cao_usuario")]
    [Index(nameof(CoUsuario), Name = "co_usuario", IsUnique = true)]
    [Index(nameof(CoUsuario), nameof(NoUsuario), nameof(DtAlteracao), Name = "co_usuario_2")]
    public partial class CaoUsuario
    {
        [Key]
        [Column("co_usuario")]
        [StringLength(20)]
        public string CoUsuario { get; set; }
        [Required]
        [Column("no_usuario")]
        [StringLength(50)]
        public string NoUsuario { get; set; }
        [Required]
        [Column("ds_senha")]
        [StringLength(14)]
        public string DsSenha { get; set; }
        [Column("co_usuario_autorizacao")]
        [StringLength(20)]
        public string CoUsuarioAutorizacao { get; set; }
        [Column("nu_matricula")]
        public ulong? NuMatricula { get; set; }
        [Column("dt_nascimento", TypeName = "date")]
        public DateTime? DtNascimento { get; set; }
        [Column("dt_admissao_empresa", TypeName = "date")]
        public DateTime? DtAdmissaoEmpresa { get; set; }
        [Column("dt_desligamento", TypeName = "date")]
        public DateTime? DtDesligamento { get; set; }
        [Column("dt_inclusao", TypeName = "datetime")]
        public DateTime? DtInclusao { get; set; }
        [Column("dt_expiracao", TypeName = "date")]
        public DateTime? DtExpiracao { get; set; }
        [Column("nu_cpf")]
        [StringLength(14)]
        public string NuCpf { get; set; }
        [Column("nu_rg")]
        [StringLength(20)]
        public string NuRg { get; set; }
        [Column("no_orgao_emissor")]
        [StringLength(10)]
        public string NoOrgaoEmissor { get; set; }
        [Column("uf_orgao_emissor")]
        [StringLength(2)]
        public string UfOrgaoEmissor { get; set; }
        [Column("ds_endereco")]
        [StringLength(150)]
        public string DsEndereco { get; set; }
        [Column("no_email")]
        [StringLength(100)]
        public string NoEmail { get; set; }
        [Column("no_email_pessoal")]
        [StringLength(100)]
        public string NoEmailPessoal { get; set; }
        [Column("nu_telefone")]
        [StringLength(64)]
        public string NuTelefone { get; set; }
        [Column("dt_alteracao", TypeName = "datetime")]
        public DateTime DtAlteracao { get; set; }
        [Column("url_foto")]
        [StringLength(255)]
        public string UrlFoto { get; set; }
        [Column("instant_messenger")]
        [StringLength(80)]
        public string InstantMessenger { get; set; }
        [Column("icq")]
        public uint? Icq { get; set; }
        [Column("msn")]
        [StringLength(50)]
        public string Msn { get; set; }
        [Column("yms")]
        [StringLength(50)]
        public string Yms { get; set; }
        [Column("ds_comp_end")]
        [StringLength(50)]
        public string DsCompEnd { get; set; }
        [Column("ds_bairro")]
        [StringLength(30)]
        public string DsBairro { get; set; }
        [Column("nu_cep")]
        [StringLength(10)]
        public string NuCep { get; set; }
        [Column("no_cidade")]
        [StringLength(50)]
        public string NoCidade { get; set; }
        [Column("uf_cidade")]
        [StringLength(2)]
        public string UfCidade { get; set; }
        [Column("dt_expedicao", TypeName = "date")]
        public DateTime? DtExpedicao { get; set; }
    }
}
