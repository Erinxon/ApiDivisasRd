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
    [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 5)]
    public class DivisasController : ControllerBase
    {
        private readonly IDivisaService _divisaService;

        public DivisasController(IDivisaService divisaService)
        {
            this._divisaService = divisaService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<Divisa>>> Get()
        {
            var response = await _divisaService.GetDivisaAsync();
            return response.Data == null ||
                !response.Success ? BadRequest(response) :
                Ok(response);
        }
    }
}
