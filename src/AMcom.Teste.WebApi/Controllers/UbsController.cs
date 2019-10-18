using AMcom.Teste.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AMcom.Teste.WebApi.Controllers
{
    [Route("api/ubs")]
    public class UbsController : Controller
    {
        private readonly IUbsService _ubsService;

        public UbsController(IUbsService ubsService)
        {
            _ubsService = ubsService;
        }

        [HttpGet("/proximas/{latitude}/{longitude}")]
        public IActionResult ListaUbs(double latitude, double longitude)
        {
            try
            {
                return Ok(_ubsService.BucarUbsProximas(latitude, longitude));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }             
}