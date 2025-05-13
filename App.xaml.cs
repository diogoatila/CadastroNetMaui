using Microsoft.UI.Windowing;
using Microsoft.UI;
using System.Diagnostics;
using WinRT.Interop;

namespace ClienteCadastroApp
{
    public partial class App : Application
    {
        public IServiceProvider Services { get; }
        public App(MainPage mainPage, IServiceProvider services)
        {
            InitializeComponent();

            Services = services;
            MainPage = new NavigationPage(mainPage);
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Title = "Cadastro de Clientes";
            window.Width = 1024;
            window.Height = 768;
            window.MaximumWidth = double.PositiveInfinity;
            window.MaximumHeight = double.PositiveInfinity;
          
            return window;
        }
    }
}