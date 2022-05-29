using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenceTestApplication.Models.Dto
{
    public class AdviserSummaryDto
    {
        // Representa el código del consultor
        public string co_consultor { get; set; }

        // Representa el nombre del consultor
        public string no_usuario { get; set; }

        // Una lista que representa en un diccionario los meses y la sumatoria de todas las facturas del consultor en ese mes (ganancias netas, es decir
        // despúes de impuestos)
        public Dictionary<DateTime, float> operationsSummary { get; set; }

        // Representa el costo fijo mensual del consultor
        public float fixed_cost { get; set; }

        // Una lista que representa en un diccionario los meses y la sumatoria de todas las comisiones del consultor en ese mes
        public Dictionary<DateTime, float> commissions { get; set; }
    }
}
