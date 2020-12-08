using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMusica.Models
{
    public class Artista
    {
        public int idArtista { get; set; }
        public int edad { get; set; }
        public int aniosActivo { get; set; }
        public string nombreArtista { get; set; }
        
        

    }

    public class Administradores
    {
        public int idAdministrador { get; set; }
        public string nombreAdmin { get; set; }
        public string correo { get; set; }

    }

    public class User
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public int ID_admin { get; set; }    
        public int ID_usuario { get; set; }
    }
    public class Album
    {
        public int ID_album { get; set; }
        public int ID_cancion { get; set; }
        public int DuracionAlbum { get; set; }
    }
    public class Usuarios
    {
        public int ID_usuario { get; set; }
        public string nombre { get; set; }
        public string Nombre_usuario { get; set; }
        public string correo { get; set; }
    }
    public class letra
    {
        public int ID_letra { get; set; }
        public string Letra { get; set; }
    }
    public class Canciones 
    {
        public int ID_cancion { get; set; }
        public int ID_letra { get; set; }
        public string Nombre_cancion { get; set; }
        public int Duracion_cancion { get; set; }
    }
}
//test upload
//Proband22
