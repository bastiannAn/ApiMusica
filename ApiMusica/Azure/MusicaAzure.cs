﻿using ApiMusica.Models;
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var consultaSql = $"select * from Artista where nombreArtista = '{nombreArtista}'";

                var comando = consultaSqlArtista(connection, consultaSql);

                var dataTable = LLenarDataTable(comando);

                return CreacionArtista(dataTable);
            }
        }


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



        private static DataTable retornoDeArtistasSQL(SqlConnection connection)
        {
            
            SqlCommand sqlCommand = new SqlCommand(null, connection);
            sqlCommand.CommandText = "select * from Artista";
            connection.Open();
            return LLenarDataTable(sqlCommand);
        }
    
        private static SqlCommand consultaSqlArtista(SqlConnection connection, string consulta)
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
    }


}
