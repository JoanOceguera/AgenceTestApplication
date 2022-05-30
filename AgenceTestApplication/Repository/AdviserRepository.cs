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
               .Join(_context.CaoOs, usuario => usuario.CoUsuario, os => os.CoUsuario, (usuario, os) => new {
                usuario.CoUsuario,
                os.CoOs})
               .Join(_context.CaoFaturas, usuario => usuario.CoOs, fatura => fatura.CoOs, (usuario, fatura) => new {
                usuario.CoUsuario,
                fatura.DataEmissao,
                fatura.Valor,
                fatura.TotalImpInc,
                fatura.ComissaoCn
            }).Where( summary => summary.DataEmissao >= begin && summary.DataEmissao <= end).ToList();

            foreach (var adviser in advisers)
            {
                if (adviser != null)
                {
                    Dictionary<DateTime, float> operationsSummary = new Dictionary<DateTime, float>();
                    Dictionary<DateTime, float> commissions = new Dictionary<DateTime, float>();
                    var adviserSummary = new AdviserSummaryDto
                    {
                        co_consultor = adviser,
                        no_usuario = _context.CaoUsuarios.Where(usuario => usuario.CoUsuario == adviser).Single().NoUsuario,
                        operationsSummary = operationsSummary,
                        commissions = commissions
                    };
                    var salario = _context.CaoSalarios.Where(salario => salario.CoUsuario == adviser).ToList();
                    if (salario.Any())
                    {
                        adviserSummary.fixed_cost = salario.First().BrutSalario;
                    }
                    else
                    {
                        adviserSummary.fixed_cost = 0;
                    }
                    var adviserData = data.Where(usuario => usuario.CoUsuario == adviser).OrderBy(date => date.DataEmissao).ToList();
                    if (adviserData.Any())
                    {
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
                    }
                    listAdviserSummaryDto.Add(adviserSummary);
                }
            }
            return listAdviserSummaryDto;
        }
    }
}
