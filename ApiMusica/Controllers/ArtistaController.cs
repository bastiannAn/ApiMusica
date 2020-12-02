using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMusica.Azure;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMusica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistaController : ControllerBase
    {
        
        // GET: api/<ArtistaController>/all
        [HttpGet("all")]
        public JsonResult ObtenerArtistas()
        {
            var artistasRecibidos = MusicaAzure.ObtenerArtistas();
            return new JsonResult(artistasRecibidos);
        }
        
       
    }
}
