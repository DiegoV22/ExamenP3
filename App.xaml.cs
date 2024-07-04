using ExamenP3.Repositories;

namespace ExamenP3
{
    public partial class App : Application
    {
        public static PaisesRepositories PaisesRepo { get; private set; }

        public App(PaisesRepositories repo)
        {
            InitializeComponent();

            MainPage = new AppShell();

            PaisesRepo = repo;
        }
    }
}
