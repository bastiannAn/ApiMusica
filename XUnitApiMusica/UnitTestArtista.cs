using ApiMusica.Azure;
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
    }
}
