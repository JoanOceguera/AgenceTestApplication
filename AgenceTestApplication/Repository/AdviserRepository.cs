using AgenceTestApplication.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenceTestApplication.Repository
{
    public class AdviserRepository : IAdviserRepository
    {

        public AdviserRepository()
        {
        }
        public async Task<List<string>> GetAdvisers()
        {
            return new List<string>() { "test" };
        }

        public async Task<List<AdviserSummaryDto>> SummaryAdvisers(List<string> advisers, DateTime begin, DateTime end)
        {
            return new List<AdviserSummaryDto>();
        }
    }
}
