using BookingDentist.Business.BusinessLogic;
using BookingDentist.Business.Common;
using BookingDentist.Business.Common.Payload.Request;
using BookingDentist.Business.Common.Payload.Response;
using Microsoft.AspNetCore.Mvc;

namespace BookingDentist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistServiceController : ControllerBase
    {
        private readonly DentistServiceBusiness _dentistServiceBusiness;

        public DentistServiceController(DentistServiceBusiness dentistServiceBusiness)
        {
            _dentistServiceBusiness = dentistServiceBusiness;
        }
        [HttpGet("getdentistservice")]
        public async Task<IActionResult> GetDentistService()
        {
            var dentistSeviceList = await _dentistServiceBusiness.GetAllDentistService();
            if(dentistSeviceList == null)
            {
                return NotFound();
            }
            return Ok(ApiResult<GetAllDentistServiceResponse>.Succeed(new GetAllDentistServiceResponse
            {
                dentistServices = dentistSeviceList
            }));
            
        }
        [HttpGet("getdentistservicebyid/{id}")]
        public async Task<IActionResult> GetDentistServiceByid(int id)
        {
            var dentistService = await _dentistServiceBusiness.GetDentistServiceById(id);
            if(dentistService == null)
            {
                return NotFound();
            }
            return Ok(ApiResult<GetDentistServiceByIdResponse>.Succeed(new GetDentistServiceByIdResponse
            {
                DentistServiceModel = dentistService
            }));
        }
        [HttpPost("cratedentistservice")]
        public async Task<IActionResult> CreateDentistService([FromBody] CreateDentistServiceRequest request)
        {
            var dsNew =  request.ToDentistServiceModel();
            var result = await _dentistServiceBusiness.CraeteDentistService(dsNew);
            if(ModelState.IsValid)
            {
                return Ok(ApiResult<CreateDentistServiceResponse>.Succeed(new CreateDentistServiceResponse
                {
                    dentistServiceModel = dsNew
                }));
            }
            else { return BadRequest(); }
        }
        [HttpPost("updatedetistservice/{id}")]
        public async Task<IActionResult> UpdateDentistService([FromRoute] int id, [FromBody] UpdateDentistServiceRequest request)
        {
            var dsExist = await _dentistServiceBusiness.GetDentistServiceById(id);
            if(dsExist == null)
            {
                return NotFound();
            }
            var result = await _dentistServiceBusiness.UpdateDentistService(id, request);
            if(ModelState.IsValid)
            {
                return Ok(ApiResult<UpdateDentistServiceReponse>.Succeed(new UpdateDentistServiceReponse
                {
                    message = "update sucess"
                }));
            }
            return BadRequest();
        }
    }
}
