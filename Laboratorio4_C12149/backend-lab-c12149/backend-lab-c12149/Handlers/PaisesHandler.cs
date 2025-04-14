using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using backend_lab_c12149.Models;
using Microsoft.Extensions.Configuration;

namespace backend_lab_c12149.Handlers
{
    public class PaisesHandler
    {
        private SqlConnection _conexion;
        private string _rutaConexion;

        public PaisesHandler()
        {
            // Construir configuración para leer appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            _rutaConexion = configuration.GetConnectionString("PaisesContext");
            _conexion = new SqlConnection(_rutaConexion);
        }

        private DataTable CrearTablaConsulta(string consulta)
        {
            SqlCommand comandoParaConsulta = new SqlCommand(consulta, _conexion);
            SqlDataAdapter adaptadorParaTabla = new SqlDataAdapter(comandoParaConsulta);
            DataTable consultaFormatoTabla = new DataTable();

            _conexion.Open();
            adaptadorParaTabla.Fill(consultaFormatoTabla);
            _conexion.Close();

            return consultaFormatoTabla;
        }

        public List<PaisesModel> ObtenerPaises()
        {
            List<PaisesModel> paises = new List<PaisesModel>();
            string consulta = "SELECT * FROM dbo.Pais";
            DataTable tablaResultado = CrearTablaConsulta(consulta);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                paises.Add(new PaisesModel
                {
                    Id = Convert.ToInt32(fila["Id"]),
                    Nombre = Convert.ToString(fila["Nombre"]),
                    Idioma = Convert.ToString(fila["Idioma"]),
                    Continente = Convert.ToString(fila["Continente"])
                });
            }

            return paises;
        }
    }
}
