using ApiDivisas.Models;
using ApiDivisas.Response;
using ApiDivisas.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDivisas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisasController : ControllerBase
    {
        private readonly IDivisaService _divisaService;

        public DivisasController(IDivisaService divisaService)
        {
            this._divisaService = divisaService;
        }
        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 5)]
        public async Task<ActionResult<ApiResponse<Divisa>>> Get()
        {
            var response = new ApiResponse<Divisa>();
            try
            {
                response.Data = await _divisaService.GetDivisaAsync();
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.message = ex.Message;
            }
            return Ok(response);
        }
    }
}
