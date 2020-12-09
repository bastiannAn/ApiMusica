using ApiMusica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMusica.Azure
{
    public class MusicaAzure
    {
        static string connectionString = @"Server=DESKTOP-AGHFPDH\SQLEXPRESS;Database=ApiMusica;Trusted_Connection=True;";
        public static List<Artista> artistas;
        //--------------------------------------------------------------------------- Canciones
        //Obtener todas las canciones
        public static List<Artista> ObtenerCancion()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var dataTableCancion = retornoDeCancionesSQL(connection);
                return LlenadoCanciones(dataTableCancion);

            }
        }

        public static Canciones ObtenerCancionPorId_cancion(int ID_cancion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var consultaSql = $"select * from Canciones where ID_cancion = {ID_cancion}";

                //CREAMOS Y ABRIMOS LA CONEXION
                var comando = ConsultaSql(connection, consultaSql);

                //LLENAMOS EL DATATABLE(CONVERSION)
                var dataTable = LLenarDataTable(comando);

                //CREAR Y RETORNAR EL OBJETO ARTISTA
                return CreacionCancion(dataTable);
            }
        }

        public static Canciones obtenerCancionPorNombre(string Nombre_cancion)
        {
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var consultaSql = $"select * from Canciones where Nombre_cancion = '{Nombre_cancion}'";

                var comando = consultaSqlArtista(connection, consultaSql);

                var dataTable = LLenarDataTable(comando);

                return CreacionCancion(dataTable);
            }
        }

        //CRUD Canciones
        public static int AgregarCancion(Canciones canciones)
        {
            int resultado = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "Insert into Canciones (ID_cancion,ID_letra,Nombre_cancion,Duracion_cancion) values (@ID_cancion,@ID_letra,@Nombre_cancion,@Duracion_cancion)";
                sqlCommand.Parameters.AddWithValue("@ID_cancion", canciones.ID_cancion);
                sqlCommand.Parameters.AddWithValue("@ID_letra", canciones.ID_letra);
                sqlCommand.Parameters.AddWithValue("@Nombre_cancion", canciones.Nombre_cancion);
                sqlCommand.Parameters.AddWithValue("@Duracion_cancion", canciones.Duracion_cancion);

                try
                {
                    connection.Open();
                    resultado = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return resultado;
        }

        public static int EliminarCancionPorID_cancion(int ID_cancion)
        {
            int resultado = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "Delete from Canciones where ID_cancion = @ID_cancion";
                sqlCommand.Parameters.AddWithValue("@ID_cancion", ID_cancion);

                try
                {
                    connection.Open();
                    resultado = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return resultado;
        }

        public static int ActualizarCancionPorId(Canciones canciones)
        {
            int resultado = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "Update Canciones SET Nombre_cancion = @Nombre_cancion, Duracion_cancion = @Duracion_cancionre where ID_cancion = @ID_cancion";
                sqlCommand.Parameters.AddWithValue("@Nombre_cancion", canciones.Nombre_cancion);
                sqlCommand.Parameters.AddWithValue("@Duracion_cancion", canciones.Duracion_cancion);

                try
                {
                    sqlConnection.Open();
                    resultado = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            return resultado;
        }


        // -------------------------------------------------------------------------- USUARIOS
        //Obtener todos los Usuarios
        public static List<Usuarios> ObtenerUsuarios()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var dataTableUsuarios = retornoDeUsuariosSQL(connection);
                return LlenadoUsuarios(dataTableUsuarios);

            }
        }

        public static Usuarios ObtenerUsuariosPorId(int ID_usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //HACEMOS LA CONSULTA
                var consultaSql = $"select * from Artista where ID_Usuario = {ID_usuario}";

                //CREAMOS Y ABRIMOS LA CONEXION
                var comando = ConsultaSql(connection, consultaSql);

                //LLENAMOS EL DATATABLE(CONVERSION)
                var dataTable = LLenarDataTable(comando);

                //CREAR Y RETORNAR EL OBJETO ARTISTA
                return CreacionUsuario(dataTable);
            }
        }

        public static Usuarios obtenerUsuarioPorNombreDeUsuario(string Nombre_usuario)
        {
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var consultaSql = $"select * from Artista where nombreArtista = '{Nombre_usuario}'";

                var comando = ConsultaSql(connection, consultaSql);

                var dataTable = LLenarDataTable(comando);

                return CreacionUsuario(dataTable);
            }
        }
        //CRUD USUARIOS
        public static int AgregarUsuarios(Usuarios usuario)
        {
            int resultado = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "Insert into Usuarios (ID_usuario,Nombre,Nombre_usuario,Correo) values (@ID_usuario,@Nombre,@Nombre_usuario,@Correo)";
                sqlCommand.Parameters.AddWithValue("@ID_usuario", usuario.ID_usuario);
                sqlCommand.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                sqlCommand.Parameters.AddWithValue("@Nombre_usuario", usuario.Nombre_usuario);
                sqlCommand.Parameters.AddWithValue("@Correo", usuario.Correo);

                try
                {
                    connection.Open();
                    resultado = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return resultado;
        }
        public static int EliminarUsuarioPorNombreUsuario(string Nombre_usuario)
        {
            int resultado = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "Delete from Artista where Nombre_usuario = @Nombre_usuario";
                sqlCommand.Parameters.AddWithValue("@Nombre_usuario", Nombre_usuario);

                try
                {
                    connection.Open();
                    resultado = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return resultado;
        }
        public static int ActualizarUsuarioPorId(Usuarios usuario)
        {
            int resultado = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "Update Usuarios set (@Nombre = Nombre, @Nombre_usuario = Nombre_usuario,@Correo = Correo) where ID_usuario = @ID_usuario";
                sqlCommand.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                sqlCommand.Parameters.AddWithValue("@Nombre_usuario", usuario.Nombre_usuario);
                sqlCommand.Parameters.AddWithValue("@Correo", usuario.Correo);

                try
                {
                    sqlConnection.Open();
                    resultado = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            return resultado;
        }

        //--------------------------------------------------------------------------- ARTISTAS
        //Obtener todos los artistas
        public static List<Artista> ObtenerArtistas()
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var dataTableArtistas = retornoDeArtistasSQL(connection);
                return LlenadoArtistas(dataTableArtistas);

            }             
        }

        public static Artista ObtenerArtistaPorId(int idArtista)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var consultaSql = $"select * from Artista where idArtista = {idArtista}";

                //CREAMOS Y ABRIMOS LA CONEXION
                var comando = consultaSqlArtista(connection, consultaSql);

                //LLENAMOS EL DATATABLE(CONVERSION)
                var dataTable = LLenarDataTable(comando);

                //CREAR Y RETORNAR EL OBJETO ARTISTA
                return CreacionArtista(dataTable);
            }
        }

        public static Artista obtenerArtistaPorNombre(string nombreArtista)
        {
            var dataTable = new DataTale();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var consultaSql = $"select * from Artista where nombreArtista = '{nombreArtista}'";

                var comando = consultaSqlArtista(connection, consultaSql);

                var dataTable = LLenarDataTable(comando);

                return CreacionArtista(dataTable);
            }
        }

        //CRUD ARTISTA
        public static int AgregarArtista(Artista artista)
        {
            int resultado = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "Insert into Artista (edad,aniosActivo,nombreArtista) values (@edad,@aniosActivo,@nombreArtista)";
                sqlCommand.Parameters.AddWithValue("@edad", artista.edad);
                sqlCommand.Parameters.AddWithValue("@aniosActivo", artista.aniosActivo);
                sqlCommand.Parameters.AddWithValue("@nombreArtista", artista.nombreArtista);

                try
                {
                    connection.Open();
                    resultado = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                   Console.WriteLine(ex.Message);
                }
            }
            return resultado;
        }

        public static int EliminarArtistaPorNombre(string nombreArtista)
        {
            int resultado = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "Delete from Artista where nombreArtista = @nombreArtista";
                sqlCommand.Parameters.AddWithValue("@nombreArtista", nombreArtista);

                try
                {
                    connection.Open();
                    resultado = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return resultado;
        }

        public static int ActualizarArtistaPorId(Artista artista)
        {
            int resultado = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, sqlConnection);
                sqlCommand.CommandText = "Update Artista SET edad = @edad, aniosActivo = @aniosActivo, nombreArtista = @nombreArtista where idArtista = @idArtista";
                sqlCommand.Parameters.AddWithValue("@idArtista", artista.idArtista);
                sqlCommand.Parameters.AddWithValue("@edad", artista.edad);
                sqlCommand.Parameters.AddWithValue("@aniosActivo", artista.aniosActivo);
                sqlCommand.Parameters.AddWithValue("@nombreArtista", artista.nombreArtista);

                try
                {
                    sqlConnection.Open();
                    resultado = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            return resultado;
        }


        //-----------------Automatización de código para Artistas
        private static DataTable retornoDeArtistasSQL(SqlConnection connection)
        {
            
            SqlCommand sqlCommand = new SqlCommand(null, connection);
            sqlCommand.CommandText = "select * from Artista";
            connection.Open();
            return LLenarDataTable(sqlCommand);
        }
    
        private static List<Artista> LlenadoArtistas(DataTable dataTable)
        {
            artistas = new List<Artista>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Artista artista = new Artista();
                artista.idArtista = int.Parse(dataTable.Rows[i]["idArtista"].ToString());
                artista.edad = int.Parse(dataTable.Rows[i]["edad"].ToString());
                artista.aniosActivo = int.Parse(dataTable.Rows[i]["aniosActivo"].ToString());
                artista.nombreArtista = dataTable.Rows[i]["nombreArtista"].ToString();
                artistas.Add(artista);
            }
            return artistas;
        }

        private static Artista CreacionArtista(DataTable dataTable)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                Artista artista = new Artista();
                artista.idArtista = int.Parse(dataTable.Rows[0]["idArtista"].ToString());
                artista.edad = int.Parse(dataTable.Rows[0]["edad"].ToString());
                artista.aniosActivo = int.Parse(dataTable.Rows[0]["aniosActivo"].ToString());
                artista.nombreArtista = dataTable.Rows[0]["nombreArtista"].ToString();

                return artista;
            }
            else
            {
                return null;
            }
        }
        //----------------- Automatización de código para Canciones
        private static DataTable retornoDeCancionesSQL(SqlConnection connection)
        {

            SqlCommand sqlCommand = new SqlCommand(null, connection);
            sqlCommand.CommandText = "select * from Canciones";
            connection.Open();
            return LLenarDataTable(sqlCommand);
        }

        private static List<Canciones> LlenadoCanciones(DataTable dataTable)
        {
            cancion = new List<Canciones>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Canciones canciones = new Canciones();
                canciones.ID_cancion = int.Parse(dataTable.Rows[i]["ID_cancion"].ToString());
                canciones.ID_letra = int.Parse(dataTable.Rows[i]["ID_letra"].ToString());
                canciones.Nombre_cancion = string.Parse(dataTable.Rows[i]["Nombre_canciones"].ToString());
                canciones.Duracion_cancion = int.Parse(dataTable.Rows[i]["Duracion_cancion"].ToString());
                cancion.Add(canciones);
            }
            return cancion;
        }
        private static Canciones CreacionCancion(DataTable dataTable)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                Canciones cancion = new Canciones();
                cancion.ID_cancion = int.Parse(dataTable.Rows[0]["ID_cancion"].ToString());
                cancion.ID_letra = int.Parse(dataTable.Rows[0]["ID_letra"].ToString());
                cancion.Nombre_cancion = string.Parse(dataTable.Rows[0]["Nombre_cancion"].ToString());
                cancion.Duracion_cancion = int.Parse(dataTable.Rows[0]["Duracion_cancion"].ToString());

                return cancion;
            }
            else
            {
                return null;
            }
        }

        //----------------- Automatización de código para Usuarios
        private static DataTable retornoDeUsuariosSQL(SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand(null, connection);
            sqlCommand.CommandText = "select * from Usuarios";
            connection.Open();
            return LLenarDataTable(sqlCommand);
        }
        private static List<Usuarios> LlenadoUsuarios(DataTable dataTable)
        {
            Usuarioss = new List<Usuarios>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Usuarios usuarios = new Usuarios();
                usuarios.ID_usuario = int.Parse(dataTable.Rows[i]["ID_usuario"].ToString());
                usuarios.Nombre = string.Parse(dataTable.Rows[i]["Nombre"].ToString());
                usuarios.Nombre_usuario = string.Parse(dataTable.Rows[i]["Nombre_usuario"].ToString());
                usuarios.Correo = string.Parse(dataTable.Rows[i]["Correo"].ToString());
                Usuarioss.Add(usuarios);
            }
            return Usuarioss;
        }
        private static Usuarios CreacionUsuario(DataTable dataTable)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                Usuarios usuario = new Usuarios();
                usuario.ID_usuario = int.Parse(dataTable.Rows[0]["ID_usuario"].ToString());
                usuario.Nombre = string.Parse(dataTable.Rows[0]["Nombre"].ToString());
                usuario.Nombre_usuario = string.Parse(dataTable.Rows[0]["Nombre_usuario"].ToString());
                usuario.Correo = string.Parse(dataTable.Rows[0]["nombreArtista"].ToString());

                return usuario;
            }
            else
            {
                return null;
            }
        }
        //Llenado de datos y ConsultaSQL general
        private static SqlCommand ConsultaSql(SqlConnection connection, string consulta)
        {
            //CREAMOS Y ABRIMOS LA CONEXION
            SqlCommand sqlCommand = new SqlCommand(null, connection);
            sqlCommand.CommandText = consulta;
            connection.Open();
            return sqlCommand;
        }

        private static DataTable LLenarDataTable(SqlCommand comando)
        {
            //LLENAMOS EL DATATABLE(CONVERSION)
            var dataTable = new DataTable();
            var dataAdapter = new SqlDataAdapter(comando);
            dataAdapter.Fill(dataTable);
            return dataTable;
        }








    }


}
