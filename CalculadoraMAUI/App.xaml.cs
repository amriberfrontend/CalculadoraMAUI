using Microsoft.Extensions.DependencyInjection;

namespace CalculadoraMAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window window = new Window(new AppShell());

            window.Width = 300;
            window.Height = 500;

            return window;
        }
    }
}