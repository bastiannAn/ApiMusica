using ApiMusica.Azure;
using ApiMusica.Models;
using System;
using System.Linq;
using Xunit;

namespace XUnitApiMusica
{
    public class UnitTestArtista
    {
        [Fact]
        public void ObtenerArtistas()
        {
            //Arrange
            bool estaVacio = false;
            //Act
            var Resultado = MusicaAzure.ObtenerArtistas();

            estaVacio = !Resultado.Any();
           
            //Assert
            Assert.False(estaVacio);
            
        }

        [Fact]
        public void TestObtenerArtistaporId()
        {
            //Arrage
            int idprobar = 1;
            Artista artistaRetonado;

            //Act
            artistaRetonado = MusicaAzure.ObtenerArtistaPorId(idprobar);

            //Assert
            Assert.NotNull(artistaRetonado);
        }

        [Fact]
        public void TestObtenerArtistaporNombre()
        {
            //Arrage
            string nombreArtista = "Lorde";
            Artista artistaRetonado;

            //Act
            artistaRetonado = MusicaAzure.obtenerArtistaPorNombre(nombreArtista);

            //Assert
            Assert.NotNull(artistaRetonado);
        }


        [Fact]
        public void TestActualizarArtistaPorId()
        {
            //Arrange
            int resultadoEsperado = 1;
            int resultadoObtenido = 0;

            Artista artista = new Artista();
            artista.idArtista = 1;
            artista.edad = 22;
            artista.aniosActivo = 5;
            artista.nombreArtista = "Lord";

            //Act
            resultadoObtenido = MusicaAzure.ActualizarArtistaPorId(artista);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoObtenido);
        }
    }
}
