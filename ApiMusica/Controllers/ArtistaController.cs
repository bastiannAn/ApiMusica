using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMusica.Azure;
using ApiMusica.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMusica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistaController : ControllerBase
    {

        //GET: api/<ArtistaController>/all
        [HttpGet("all")]
        public JsonResult ObtenerArtistas()
        {
            var artistasRecibidos = MusicaAzure.ObtenerArtistas();
            return new JsonResult(artistasRecibidos);
        }

        //GET: api/artista/{1}-{nombre}
        [HttpGet("{idArtista}")]
        public JsonResult ObtenerArtistas(string idArtista)
        {

            var conversionExitosa = int.TryParse(idArtista, out int idConvertido);
            Artista artistasRecibidos;

            if (conversionExitosa)
            {
                artistasRecibidos = MusicaAzure.ObtenerArtistaPorId(idConvertido);
            }
            else
            {
                artistasRecibidos = MusicaAzure.obtenerArtistaPorNombre(idArtista);
            }

            if(artistasRecibidos is null)
            {
                return new JsonResult($"Intente nuevamente con un valor distinto a {idArtista}");
            }
            else
            {
                return new JsonResult(artistasRecibidos);
            }
            
        }

        //[HttpPut ("all")]
        //public JsonResult ActualizarArtista()


    }
}
