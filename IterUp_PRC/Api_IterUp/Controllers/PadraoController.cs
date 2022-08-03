using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using IterUpApi.Data;
using IterUpApi.Dto;
using IterUpApi.Model;
using IterUpApi.Service;
using Microsoft.AspNetCore.Authorization;

namespace IterUpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Padrao : ControllerBase
    {

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Get()
        {
            return Ok(new
            {
                nome = "IterUp",
                tipo = "Web Api",
                Responsavel = "Augusto Cesar"
            });
        }

    }
}
