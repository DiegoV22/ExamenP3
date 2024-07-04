<<<<<<< HEAD
<<<<<<< HEAD
﻿namespace ExamenP3
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

=======
﻿using Microsoft.Maui.Controls;

namespace ExamenP3
{
    public partial class MainPage : ContentPage
    {
>>>>>>> feAgregar archivos de proyecto.
=======
using Microsoft.Maui.Controls;

namespace ExamenP3
{
    public partial class MainPage : ContentPage
    {
>>>>>>> penultima
        public MainPage()
        {
            InitializeComponent();
        }
<<<<<<< HEAD
<<<<<<< HEAD

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

=======
    }
>>>>>>> feAgregar archivos de proyecto.
=======
    }
>>>>>>> penultima
}

