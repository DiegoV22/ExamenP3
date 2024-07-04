using ExamenP3.Models;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExamenP3.Repositories
{
    public class PaisesRepository
    {
        private readonly string _dbPath;
        private SQLiteConnection conn;

        public PaisesRepository(string dbPath)
        {
            _dbPath = dbPath;
            Init();
        }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Paises>();
        }

        public List<Paises> GetSavedPaises()
        {
            Init();
            return conn.Table<Paises>().ToList();
        }

        public void SavePais(Paises pais)
        {
            Init();
            conn.Insert(pais);
        }

        public void UpdatePais(Paises pais)
        {
            Init();
            conn.Update(pais);
        }

        public void DeletePais(Paises pais)
        {
            Init();
            conn.Delete(pais);
        }

        public async Task<List<Paises>> FetchPaisesFromApiAsync()
        {
<<<<<<< HEAD
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://restcountries.com/v3.1/all");
                string responseJson = await response.Content.ReadAsStringAsync();

                JArray jsonArray = JArray.Parse(responseJson);
                List<Paises> paises = new List<Paises>();

                foreach (var item in jsonArray)
                {
<<<<<<< HEAD
                    Paises pais = new Paises
                    {
                        Name = item["name"]?["official"]?.ToString(),
                        Region = item["region"]?.ToString(),
                        Subregion = item["subregion"]?.ToString(),
                        Status = item["status"]?.ToString(),
                        Nombre = "Diego Vega"  // Agrega tu nombre aquí para generar el código
                    };
                    pais.GenerarCodigo();
                    paises.Add(pais);
=======
                    var nombreOficial = item["name"]?["official"]?.ToString();
                    if (!string.IsNullOrEmpty(nombreOficial))
                    {
                        Paises pais = new Paises
                        {
                            Name = nombreOficial,
                            Region = item["region"]?.ToString(),
                            Subregion = item["subregion"]?.ToString(),
                            Status = item["status"]?.ToString(),
                            Nombre = nombreOficial  // Usa el nombre oficial para generar el código
                        };
                        pais.GenerarCodigo();
                        paises.Add(pais);
                    }
>>>>>>> feAgregar archivos de proyecto.
                }

                return paises;
            }
=======
            using HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://restcountries.com/v3.1/all");
            var paises = JsonConvert.DeserializeObject<List<Paises>>(response);
            return paises;
>>>>>>> penultima
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> feAgregar archivos de proyecto.
