using BookingDentist.Business.BusinessLogic;
using BookingDentist.Business.Common;
using BookingDentist.Business.Common.Payload.Request;
using BookingDentist.Business.Common.Payload.Response;
using Microsoft.AspNetCore.Mvc;

namespace BookingDentist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ServiceBusiness _serviceBusiness;

        public ServiceController(ServiceBusiness serviceBusiness)
        {
            _serviceBusiness = serviceBusiness;
        }
        [HttpGet("getallservice")]
        public async Task<IActionResult> GetAllService()
        {
            var service = await _serviceBusiness.GetAllService();
            if(service == null)
            {
                return NotFound();
            }
            return Ok(ApiResult<GetAllServiceResponse>.Succeed(new GetAllServiceResponse
            {
                serviceModels = service
            }));
        }
        [HttpGet("getservicebyid/{id}")]
        public async Task<IActionResult> GetServiceById([FromRoute]int id)
        {
            var service = await _serviceBusiness.GetServiceById(id);
            if(service == null)
            {
                return NotFound();
            }
            return Ok(ApiResult<GetServiceByIdResponse>.Succeed(new GetServiceByIdResponse
            {
                ServiceModel = service
            }));
        }
        [HttpGet("getservicebyname/{name}")]
        public async Task<IActionResult> GetServiceByName([FromRoute] string name)
        {
            var service = await _serviceBusiness.GetServiceByName(name);
            if(service == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ApiResult<GetServiceByIdResponse>.Succeed(new GetServiceByIdResponse
                {
                    ServiceModel = service
                }));
            }
        }

        [HttpPost("createservice")]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceRequest request)
        {

            var service = request.ToServiceModel();
            var result = await _serviceBusiness.CreateService(service);
            if(result == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(ApiResult<CreateServiceResponse>.Succeed(new CreateServiceResponse
                {
                    ServiceModel = service
                }));
            }
        }
    }
}
