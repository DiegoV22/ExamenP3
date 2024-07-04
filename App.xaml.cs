using ExamenP3.Repositories;
<<<<<<< HEAD
=======
using Microsoft.Maui.Controls;
using System;
using System.IO;
>>>>>>> penultima

namespace ExamenP3
{
    public partial class App : Application
    {
<<<<<<< HEAD
        public static PaisesRepositories PaisesRepo { get; private set; }

        public App(PaisesRepositories repo)
        {
            InitializeComponent();

            MainPage = new AppShell();

            PaisesRepo = repo;
=======
        public static PaisesRepository PaisesRepo { get; private set; }

        public App()
        {
            InitializeComponent();

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "paises.db3");
            PaisesRepo = new PaisesRepository(dbPath);

            MainPage = new AppShell(); // Cambia aquí para usar AppShell en lugar de PaisesView
>>>>>>> penultima
        }
    }
}
