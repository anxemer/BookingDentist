using BookingDentist.Business.BusinessLogic;
using BookingDentist.Business.Common;
using BookingDentist.Business.Common.Payload.Request;
using BookingDentist.Business.Common.Payload.Response;
using Microsoft.AspNetCore.Mvc;

namespace BookingDentist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicServiceController : ControllerBase
    {
        private readonly ClinicServiceBusiness _clinicServiceBusiness;

        public ClinicServiceController(ClinicServiceBusiness clinicServiceBusiness)
        {
            _clinicServiceBusiness = clinicServiceBusiness;
        }
        [HttpGet("getclinicservice")]
        public async Task<IActionResult> GetAllClinicService()
        {
            var clinicService = await _clinicServiceBusiness.GetAllClinicService();
            if (clinicService == null)
            {
                return NotFound();
            }
            return Ok(ApiResult<GetClinicServiceResponse>.Succeed(new GetClinicServiceResponse
            {
                clinicServiceModels = clinicService
            }));
        }
        [HttpGet("getclinicservicebyid/{id}")]
        public async Task<IActionResult> GetClinincServiceById(int id)
        {
            var clinic = await _clinicServiceBusiness.GetClinicServiceById(id);
            if (clinic == null)
            {
                return NotFound();
            }
            return Ok(ApiResult<GetClinicServiceById>.Succeed(new GetClinicServiceById
            {
                ClinicServiceModel = clinic
            }));
        }
        [HttpPut("updateclinicservice/{id}")]
        public async Task<IActionResult> UpdateClinicService([FromRoute] int id, [FromBody] UpdateClinicServiceRequest request)
        {
            var csNew = request.ToClinicServiceModel();
            var result = _clinicServiceBusiness.UpdateClinicService(id, csNew);
            if (result is not null)
            {
                return Ok(ApiResult<UpdateClinicServiceResponse>.Succeed(new UpdateClinicServiceResponse
                {
                    messagge = "update sucessful"
                }));
            }
            else return BadRequest();
        }
        
    }
}
