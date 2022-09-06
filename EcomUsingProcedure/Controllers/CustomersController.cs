using EcomUsingProcedure.Model;
using EcomUsingProcedure.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcomUsingProcedure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepository _customerRepo;

        public CustomersController(ICustomersRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [HttpGet]
        [Route("/[action]")]
        public async Task<IActionResult> viewcustomers()
        {
            try
            {
                var customer = await _customerRepo.viewcustomers();
                return Ok(customer);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpOptions]
        [Route("[action]")]
        public async Task<IActionResult> Login(DtoLogin log)
        {
            try
            {
                var customer = await _customerRepo.Login(log);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("/[action]")]
        public async Task<IActionResult> IUDCustomer(gender gen, customers cust)
        {
            try
            {
                var result = await _customerRepo.IUDCustomer(gen, cust);

                if (result == null)
                {
                    return StatusCode(409, "The request could not be processed because of conflict in the request");
                }
                else if(cust.flag=="i")
                {
                    return StatusCode(200, string.Format("Record Inserted Successfuly", result));
                }
                else if (cust.flag == "u")
                {
                    return StatusCode(200, string.Format("Record Updated Successfuly", result));
                }
                else
                {
                    return StatusCode(200, string.Format("Record deleted Successfuly", result));
                }

            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
