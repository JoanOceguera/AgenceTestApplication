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
        public ActionResult<IEnumerable<AdviserDto>> GetAdvisers()
        {
            try
            {
                var advisers = _adviserRepository.GetAdvisers();
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

        // GET: api/Adviser
        [HttpGet("GetAdvisersSummary")]
        public ActionResult<IEnumerable<AdviserSummaryDto>> GetAdvisersSummary([FromQuery] List<string> advicers, DateTime begin, DateTime end)
        {
            if (begin > end)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "La fecha de inicio debe ser menor que la fecha final";
                return BadRequest(_response);
            }
            if (advicers == null || advicers.Count == 0)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Debe seleccionar al menos un consultor";
                return BadRequest(_response);
            }
            try
            {
                DateTime fullBegin = new DateTime(begin.Year, begin.Month, 1);
                DateTime fullEnd = new DateTime(end.Year, end.Month, DateTime.DaysInMonth(end.Year, end.Month));
                var advisers = _adviserRepository.SummaryAdvisers(advicers, fullBegin, fullEnd);
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
