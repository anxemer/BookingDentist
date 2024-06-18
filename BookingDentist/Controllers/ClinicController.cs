using BookingDentist.Business.BusinessLogic;
using BookingDentist.Business.BusinessModel;
using BookingDentist.Business.Common;
using BookingDentist.Business.Common.Payload.Request;
using BookingDentist.Business.Common.Payload.Response;
using Microsoft.AspNetCore.Mvc;

namespace BookingDentist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly ClinicBusiness _clinicBusiness;

        public ClinicController(ClinicBusiness clinicBusiness)
        {
            _clinicBusiness = clinicBusiness;
        }
        [HttpGet("GetAllClinic")]
        public async Task<IActionResult> GetAllClinic()
        {
            var clinicList = await _clinicBusiness.GetAllClinic();
            return Ok(ApiResult<GetClinicResponse>.Succeed(new GetClinicResponse
            {
                Clinic = clinicList
            }));
        }
        [HttpGet("getclinicbyid/{id}")]
        public async Task<IActionResult> GetClinicById([FromRoute] int id)
        {
            var clinic = await _clinicBusiness.GetClinicById(id);
            if(clinic == null)
            {
                return BadRequest();
            }
            return Ok(ApiResult<GetClinicByIdResponse>.Succeed(new GetClinicByIdResponse
            {
                clinicModel = clinic
            }));
        }
        [HttpPost("createclinic")]
        public async Task<IActionResult> CreateClinic([FromBody] CreateClinicRequest request)
        {
            var clinic = request.ToClinicModel();
            var result = await _clinicBusiness.CreateClinic(clinic);
            if(result == null)
            {
                return BadRequest();
            }
            return Ok(ApiResult<CreateClinicResonse>.Succeed(new CreateClinicResonse
            {
                Clinic = clinic,
                message = "Create Success",
            }));
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateClinic(int id, [FromBody] UpdateClinicRequest request)
        {
            var clinicExist = await _clinicBusiness.GetClinicById(id);
            if(clinicExist == null)
            {
                return NotFound();
            }
            var updateClinic = _clinicBusiness.UpdateClinic(id, request);
            if(updateClinic == null)
            {
                return BadRequest();
            }
            return Ok(ApiResult<UpdateAccountResponse>.Succeed(new UpdateAccountResponse
            {
                message = "Clinic Updated"
            }));
        }
        [HttpPut("changestatus/{id}")]
        public async Task<IActionResult> ChangeStatusClinic(int id, [FromBody] UpdateStatusClinicRequest status)
        {
            var updateClinic = await _clinicBusiness.ChangeStatus(id, status.status);
            if(updateClinic)
            {
                return Ok(ApiResult<UpdateClinicResponse>.Succeed(new UpdateClinicResponse
                {
                    message = "Updated"
                }));
            }
            else { return BadRequest(ApiResult<UpdateClinicResponse>.Error(new UpdateClinicResponse
            {
                message = "faled"
            })); }
        }
    }
}
