using AgenceTestApplication.Models.Dto;
using AgenceTestApplication.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenceTestApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviserController : ControllerBase
    {
        private readonly IAdviserRepository _adviserRepository;
        protected ResponseDto _response;

        public AdviserController(IAdviserRepository adviserRepository)
        {
            _adviserRepository = adviserRepository;
            _response = new ResponseDto();
        }

        // GET: api/Adviser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAdvisers()
        {
            try
            {
                var advisers = await _adviserRepository.GetAdvisers();
                _response.Result = advisers;
                _response.DisplayMessage = "Lista de consultores";
            }
            catch (Exception e)
            {

                _response.IsSuccess = false;
                _response.DisplayMessage = "A ocurrido un error";
                _response.ErrorMessages = new List<string> { e.ToString() };
                return BadRequest(_response);
            }
            return Ok(_response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdviserSummaryDto>>> GetAdvisersSummary(List<string> advicers, DateTime begin, DateTime end)
        {
            try
            {
                var advisers = await _adviserRepository.SummaryAdvisers(advicers, begin, end);
                _response.Result = advisers;
                _response.DisplayMessage = "Resumen de las operaciones de un grupo de consultores en un período de tiempo";
            }
            catch (Exception e)
            {

                _response.IsSuccess = false;
                _response.DisplayMessage = "A ocurrido un error";
                _response.ErrorMessages = new List<string> { e.ToString() };
                return BadRequest(_response);
            }
            return Ok(_response);
        }

    }
}
