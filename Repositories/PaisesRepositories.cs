using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ExamenP3.Models;
using Newtonsoft.Json.Linq;
using SQLite;

namespace ExamenP3.Repositories
{
    public class PaisesRepositories
    {
        public string _dbPath;
        private SQLiteConnection conn;

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Paises>();
        }

        public PaisesRepositories(string dbPath)
        {
            _dbPath = dbPath;
        }

        public List<Paises> DevuelveListadoPaises()
        {
            Init();
            return conn.Table<Paises>().ToList();
        }

        public void GuardarPais(Paises pais)
        {
            Init();
            pais.GenerarCodigo();
            conn.Insert(pais);
        }

        public void ActualizarPais(Paises pais)
        {
            Init();
            conn.Update(pais);
        }

        public void EliminarPais(Paises pais)
        {
            Init();
            conn.Delete(pais);
        }

        public async Task<List<Paises>> ObtenerPaisesDesdeApiAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://restcountries.com/v3.1/all");
                string responseJson = await response.Content.ReadAsStringAsync();

                JArray jsonArray = JArray.Parse(responseJson);
                List<Paises> paises = new List<Paises>();

                foreach (var item in jsonArray)
                {
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
                }

                return paises;
            }
        }
    }
}
