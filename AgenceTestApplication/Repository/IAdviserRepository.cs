using AgenceTestApplication.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenceTestApplication.Repository
{
    public interface IAdviserRepository
    {
        List<AdviserDto> GetAdvisers();

        List<AdviserSummaryDto> SummaryAdvisers(List<string> advisers, DateTime inicio, DateTime fin);
    }
}
