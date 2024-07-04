using ExamenP3.Models;
using ExamenP3.Repositories;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace ExamenP3.ViewModels
{
    public class PaisesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Paises> Countries { get; set; }
        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }
        public ICommand GetCountriesCommand { get; }

        public PaisesViewModel()
        {
            Countries = new ObservableCollection<Paises>();
            GetCountriesCommand = new Command(async () => await GetCountries());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task GetCountries()
        {
            try
            {
                var countries = await App.PaisesRepo.FetchPaisesFromApiAsync();
                foreach (var country in countries)
                {
                    country.Codigo = GenerateCode(country.Nombre, country.Region, country.Subregion, country.Status);
                    App.PaisesRepo.SavePais(country);
                }
                LoadCountries();
                Message = "Países obtenidos correctamente.";
            }
            catch (Exception ex)
            {
                Message = $"Error al obtener países: {ex.Message}";
            }
        }

        private string GenerateCode(string name, string region, string subregion, string status)
        {
            Random random = new Random();
            int number = random.Next(1000, 2000);
            string initials = "DV";
            return $"{initials}{number}{region}{subregion}_{status}";
        }

        private void LoadCountries()
        {
            var countries = App.PaisesRepo.GetSavedPaises();
            Countries.Clear();
            foreach (var country in countries)
            {
                Countries.Add(country);
            }
        }
    }
}
