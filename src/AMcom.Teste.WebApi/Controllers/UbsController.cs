﻿using Microsoft.AspNetCore.Mvc;

namespace AMcom.Teste.WebApi.Controllers
{
    [Route("api/ubs")]
    public class UbsController : Controller
    {
        // Implemente um método que seja acessível por HTTP GET e retorne a lista das 5 UBSs
        // (Unidades Básicas de Saúde) mas próximas de um ponto (latitude e longitude) e ordenada
        // por avaliação (da melhor para a pior). O retorno deve ser no formato JSON.
    }
}
