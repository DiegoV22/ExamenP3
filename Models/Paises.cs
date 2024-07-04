using System;
using System.Linq;
using SQLite;

namespace ExamenP3.Models
{
    public class Paises
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public string Status { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public void GenerarCodigo()
        {
            var iniciales = ObtenerIniciales(Name);
            var numeroAleatorio = new Random().Next(1000, 2001);
            Codigo = $"{iniciales}{numeroAleatorio}";
        }

        private string ObtenerIniciales(string nombre)
        {
            var palabras = nombre.Split(' ');
            var iniciales = string.Concat(palabras.Select(p => p[0])).ToUpper();
            return iniciales;
        }
    }
}
