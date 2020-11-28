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

        //Obtener todos los artistas

        public static List<Artista> ObtenerArtistas()
        {
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(null, connection);
                sqlCommand.CommandText = "select * from Artista";

                connection.Open();
                var DataAdapter = new SqlDataAdapter(sqlCommand);

                DataAdapter.Fill(dataTable);

                artistas = new List<Artista>();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Artista artista = new Artista();
                    artista.idArtista = int.Parse(dataTable.Rows[0]["idArtista"].ToString());
                    artista.edad = int.Parse(dataTable.Rows[0]["edad"].ToString());
                    artista.aniosActivo = int.Parse(dataTable.Rows[0]["aniosActivo"].ToString());
                    artista.nombreArtista = dataTable.Rows[0]["nombreArtista"].ToString();

                    artistas.Add(artista);

                }


            }
                
                  

            return artistas;
        }
    }
}
