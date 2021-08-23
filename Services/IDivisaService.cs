using ApiDivisas.Models;
using ApiDivisas.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDivisas.Services
{
    public interface IDivisaService
    {
        Task<ApiResponse<Divisa>> GetDivisaAsync();
    }
}
