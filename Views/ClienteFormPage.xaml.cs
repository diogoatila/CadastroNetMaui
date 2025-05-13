using ClienteCadastroApp.Models;
using ClienteCadastroApp.ViewModels;

namespace ClienteCadastroApp;

public partial class ClienteFormPage : ContentPage
{

    public ClienteFormPage(Cliente cliente = null)
    {
        InitializeComponent();

        var navigationService = ((App)App.Current).Services.GetRequiredService<INavigationService>();
        var clienteService = ((App)App.Current).Services.GetRequiredService<IClienteService>();
        BindingContext = new ClientesViewModel(clienteService, navigationService, cliente);
    }

}