using AgenceTestApplication.Data;
using AgenceTestApplication.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenceTestApplication.Repository
{
    public class AdviserRepository : IAdviserRepository
    {
        private readonly ApplicationDbContext _context;

        public AdviserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<AdviserDto> GetAdvisers()
        {
            var advisersList = _context.CaoUsuarios.Join(_context.PermissaoSistemas, usuario => usuario.CoUsuario, permiso => permiso.CoUsuario, (usuario, permiso) => new
            {
                CoUsuario = usuario.CoUsuario,
                NoUsuario = usuario.NoUsuario,
                CoSistema = permiso.CoSistema,
                InAtivo = permiso.InAtivo,
                CoTipoUsuario = permiso.CoTipoUsuario
            }).Where(permiso => permiso.InAtivo == "S" && permiso.CoSistema == 1 && ((new List<int>() { 0, 1, 2 }).Contains((int)permiso.CoTipoUsuario))).ToList();

            var advisers = new List<AdviserDto>();
            foreach (var adviser in advisersList)
            {
                advisers.Add(new AdviserDto() { coUsuario = adviser.CoUsuario, noUsuario = adviser.NoUsuario});
            }
            return advisers;
        }

        public List<AdviserSummaryDto> SummaryAdvisers(List<string> advisers, DateTime begin, DateTime end)
        {
            var listAdviserSummaryDto = new List<AdviserSummaryDto>();
            var data = _context.CaoUsuarios.Where(usuario => advisers.Contains(usuario.CoUsuario))
                .Join(_context.CaoSalarios, usuario => usuario.CoUsuario, salario => salario.CoUsuario, (usuario, salario) => new { 
                salario.BrutSalario,
                usuario.CoUsuario,
                usuario.NoUsuario})                
               .Join(_context.CaoOs, usuario => usuario.CoUsuario, os => os.CoUsuario, (usuario, os) => new {
                usuario.CoUsuario,
                usuario.BrutSalario,
                usuario.NoUsuario,
                os.CoOs})
               .Join(_context.CaoFaturas, usuario => usuario.CoOs, fatura => fatura.CoOs, (usuario, fatura) => new {
                usuario.CoUsuario,
                usuario.NoUsuario,
                usuario.BrutSalario,
                fatura.DataEmissao,
                fatura.Valor,
                fatura.TotalImpInc,
                fatura.ComissaoCn
            }).Where( summary => summary.DataEmissao >= begin && summary.DataEmissao <= end).ToList();

            foreach (var adviser in advisers)
            {
                if (adviser != null)
                {
                    var adviserData = data.Where(usuario => usuario.CoUsuario == adviser).OrderBy(date => date.DataEmissao).ToList();
                    var adviserSummary = new AdviserSummaryDto
                    {
                        co_consultor = adviser,
                        no_usuario = adviserData.FirstOrDefault().NoUsuario,
                        fixed_cost = adviserData.FirstOrDefault().BrutSalario,
                    };

                    Dictionary<DateTime, float> operationsSummary = new Dictionary<DateTime, float>();
                    Dictionary<DateTime, float> commissions = new Dictionary<DateTime, float>();
                    foreach (var fatura in adviserData)
                    {
                        if (operationsSummary.Keys.Where(date => date.Month == fatura.DataEmissao.Month && date.Year == fatura.DataEmissao.Year).Any())
                        {
                            var key = operationsSummary.Keys.Where(date => date.Month == fatura.DataEmissao.Month && date.Year == fatura.DataEmissao.Year).First();
                            operationsSummary[key] += fatura.Valor - fatura.Valor * (fatura.TotalImpInc / 100);
                        }
                        else
                        {
                            operationsSummary.Add(fatura.DataEmissao, fatura.Valor - fatura.Valor * (fatura.TotalImpInc / 100));
                        }

                        if (commissions.Keys.Where(date => date.Month == fatura.DataEmissao.Month && date.Year == fatura.DataEmissao.Year).Any())
                        {
                            var key = commissions.Keys.Where(date => date.Month == fatura.DataEmissao.Month && date.Year == fatura.DataEmissao.Year).First();
                            commissions[key] += (fatura.Valor - fatura.Valor * (fatura.TotalImpInc / 100)) * (fatura.ComissaoCn / 100);
                        }
                        else
                        {
                            commissions.Add(fatura.DataEmissao, (fatura.Valor - fatura.Valor * (fatura.TotalImpInc / 100)) * (fatura.ComissaoCn / 100));
                        }
                    }

                    adviserSummary.operationsSummary = operationsSummary;
                    adviserSummary.commissions = commissions;
                    listAdviserSummaryDto.Add(adviserSummary);
                }
            }
            return listAdviserSummaryDto;
        }
    }
}
