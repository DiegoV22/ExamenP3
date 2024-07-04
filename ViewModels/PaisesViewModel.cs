using ExamenP3.Models;
using ExamenP3.Repositories;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamenP3.ViewModels
{
    public class PaisesViewModel : BindableObject
    {
        private ObservableCollection<Paises> paisesList;

        public ObservableCollection<Paises> PaisesList
        {
            get => paisesList;
            set
            {
                paisesList = value;
                OnPropertyChanged();
            }
        }

        public ICommand ObtenerPaisesCommand { get; }
        public ICommand GuardarPaisCommand { get; }
        public ICommand ActualizarPaisCommand { get; }
        public ICommand EliminarPaisCommand { get; }

        public PaisesViewModel()
        {
            PaisesList = new ObservableCollection<Paises>(App.PaisesRepo.DevuelveListadoPaises());

            ObtenerPaisesCommand = new Command(async () => await ObtenerPaises());
            GuardarPaisCommand = new Command<Paises>(GuardarPais);
            ActualizarPaisCommand = new Command<Paises>(ActualizarPais);
            EliminarPaisCommand = new Command<Paises>(EliminarPais);
        }

        private async Task ObtenerPaises()
        {
            var paisesDesdeApi = await App.PaisesRepo.ObtenerPaisesDesdeApiAsync();

            foreach (var pais in paisesDesdeApi)
            {
                App.PaisesRepo.GuardarPais(pais);
                PaisesList.Add(pais);
            }
        }

        private void GuardarPais(Paises pais)
        {
            App.PaisesRepo.GuardarPais(pais);
            PaisesList.Add(pais);
        }

        private void ActualizarPais(Paises pais)
        {
            App.PaisesRepo.ActualizarPais(pais);
            var index = PaisesList.IndexOf(pais);
            PaisesList[index] = pais;
        }

        private void EliminarPais(Paises pais)
        {
            App.PaisesRepo.EliminarPais(pais);
            PaisesList.Remove(pais);
        }
    }
}