using ClienteCadastroApp.ViewModels;
using ClienteCadastroApp.Services;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace ClienteCadastroApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(IClienteService clienteService, INavigationService navigationService)
        {
            InitializeComponent();

            // Passa as dependências para a ViewModel
            BindingContext = new ClientesViewModel(clienteService, navigationService);
        }
    }
}
