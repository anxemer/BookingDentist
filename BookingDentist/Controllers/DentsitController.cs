using BookingDentist.Business;
using BookingDentist.Business.BusinessLogic;
using BookingDentist.Business.BusinessModel;
using BookingDentist.Business.Common;
using BookingDentist.Business.Common.Payload.Request;
using BookingDentist.Business.Common.Payload.Response;
using BookingDentist.DataAccess;
using BookingDentist.DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingDentist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentsitController : ControllerBase
    {
        private DentistBusiness _dentistBusiness;
        public DentsitController(DentistBusiness dentistBusiness)
        {
            _dentistBusiness = dentistBusiness;
        }
        // GET: DentsitController
        [HttpGet("getalldentist")]
        public async  Task<IActionResult> GetAllDentist()
        {
            var dentistList = await _dentistBusiness.GetAllDentist();
            if (dentistList == null)
            {
                return BadRequest("Nothing to show");
            }
            return Ok(ApiResult<GetAllDentistResponse>.Succeed(new GetAllDentistResponse
            {
                DentistModels = dentistList
            }));
        }
        [HttpGet("getdentistbyid/{id}")]
        public async Task<IActionResult> GetDentistById([FromRoute] int id)
        {
            var dentist = await _dentistBusiness.GetDentistById(id);
            if(dentist == null)
            {
                return BadRequest();
            }
            return Ok(ApiResult<GetDentistByIdRespnse>.Succeed(new GetDentistByIdRespnse {
                dentistModel = dentist
            }));
        }
        [HttpGet("getdentistbyname/{name}")]
        public async Task<IActionResult> GetDentistByname(string name)
        {
            var dentist = await _dentistBusiness.GetDentistByName(name);
            if(dentist == null)
            {
                return BadRequest();
            }
            return Ok(ApiResult<GetDentistByIdRespnse>.Succeed(new GetDentistByIdRespnse
            {
                dentistModel = dentist
            }));
        }
        [HttpPost("createdentist")]
        public async Task<IActionResult> CreateDentist([FromBody]CreateDentistRequest request) {
            var dentistModel = request.ToDentistModel();
            var dentist = await _dentistBusiness.CreateDentist(dentistModel);
            if(dentist == null)
            {
                return BadRequest();
            }
            return Ok(ApiResult<CreateDentistResponse>.Succeed(new CreateDentistResponse
            {
                dentistModel = dentistModel
            }));
        }
    }
}
