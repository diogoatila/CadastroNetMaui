using ClienteCadastroApp.ViewModels;
using ClienteCadastroApp.Services;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace ClienteCadastroApp
{
    public partial class MainPage : ContentPage
    {
        private readonly ClientesViewModel _viewModel;
        public MainPage(IClienteService clienteService, INavigationService navigationService)
        {
            InitializeComponent();

            // Passa as dependências para a ViewModel
            _viewModel = new ClientesViewModel(clienteService, navigationService);
            BindingContext = _viewModel;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.CarregarClientesAsync(); // Carrega os dados ao abrir a tela
        }
    }
}
