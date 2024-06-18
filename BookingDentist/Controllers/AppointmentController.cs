using BookingDentist.Business.BusinessLogic;
using BookingDentist.Business.Common;
using BookingDentist.Business.Common.Payload.Request;
using BookingDentist.Business.Common.Payload.Response;
using Microsoft.AspNetCore.Mvc;

namespace BookingDentist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentBusiness _appointmentBusiness;

        public AppointmentController(AppointmentBusiness appointmentBusiness)
        {
            _appointmentBusiness = appointmentBusiness;
        }
        [HttpGet("getappoitment")]
        public async Task<IActionResult> GetAllAppointment()
        {
            var appo =  await _appointmentBusiness.GetAllAppointment();
            if (appo == null)
            {
                return NotFound();
            }
            return Ok(ApiResult<GetAllAppointmentResponse>.Succeed(new GetAllAppointmentResponse
            {
                appointmentModels = appo
            }));
        }
        [HttpGet("getappointmentbyid/{id}")]
        public async Task<IActionResult> GetAppointmentById([FromRoute] int id)
        {
            var appo = await _appointmentBusiness.GetAppointmentById(id);
            if (appo == null)
            {
                return NotFound();
            }
            return Ok(ApiResult<GetAppointmentByIdResponse>.Succeed(new GetAppointmentByIdResponse
            {
                AppointmentModel = appo
            }));
        }
        [HttpPost("createappointment")]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentsRequest appointmentsRequest)
        {
            var appoNew = appointmentsRequest.ToAppointmentModel();
            var result = await _appointmentBusiness.CreateAppointment(appoNew);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(ApiResult<CreateAppointmentResponse>.Succeed(new CreateAppointmentResponse
            {
                AppointmentModel = appoNew
            }));
        }
        [HttpPut("updateappointment/{id}")]
        public async Task<IActionResult> UpdateAppointment([FromRoute] int id,UpdateAppointmentRequest updateAppointmentRequest)
        {
            var appoNew = updateAppointmentRequest.ToAppointmentModel();
            var result = await _appointmentBusiness.UpdateAppointment(id, appoNew);
            if(result == null)
            {
                return BadRequest();
            }
            return Ok(ApiResult<UpdateAppointmentResponse>.Succeed(new UpdateAppointmentResponse
            {
                message = "update success"
            }));
        }
    }

}
