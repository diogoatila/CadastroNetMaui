using System.Collections.ObjectModel;
using System.Windows.Input;
using ClienteCadastroApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace ClienteCadastroApp.ViewModels;

public partial class ClientesViewModel : ObservableObject
{
    private readonly IClienteService _clienteService;
    private readonly INavigationService _navigation;

    public ObservableCollection<Cliente> Clientes => _clienteService.Clientes;

    public ICommand AdicionarCommand { get; }
    public ICommand EditarCommand { get; }
    public ICommand ExcluirCommand { get; }
    public ICommand SalvarCommand { get; }
    public ICommand CancelarCommand { get; }

    private Cliente _cliente;
    public ClientesViewModel(IClienteService clienteService, INavigationService navigationService, Cliente cliente = null)
    {
        _clienteService = clienteService;
        _navigation = navigationService;
        _cliente = cliente ?? new Cliente();


        AdicionarCommand = new RelayCommand(AdicionarCliente);
        EditarCommand = new RelayCommand<Cliente>(EditarCliente);
        ExcluirCommand = new RelayCommand<Cliente>(ExcluirCliente);
        SalvarCommand = new RelayCommand(Salvar);
        CancelarCommand = new RelayCommand(Cancelar);
    }

    private async void AdicionarCliente()
    {
        await _navigation.PushModalAsync(new ClienteFormPage());
    }

    private async void EditarCliente(Cliente cliente)
    {
        if (cliente == null) return;
        await _navigation.PushModalAsync(new ClienteFormPage(cliente));
    }

    private async void ExcluirCliente(Cliente cliente)
    {
        if (cliente == null) return;

        bool confirmar = await Application.Current.MainPage.DisplayAlert(
            "Confirmação",
            $"Deseja excluir {cliente.Name} {cliente.Lastname}?",
            "Sim",
            "Não"
        );

        if (confirmar)
        {
            _clienteService.Remover(cliente);
        }
    }

    private async void Salvar()
    {
        if (string.IsNullOrWhiteSpace(_cliente.Name) || string.IsNullOrWhiteSpace(_cliente.Lastname))
        {
            await Application.Current.MainPage.DisplayAlert("Erro", "Nome e Sobrenome são obrigatórios.", "OK");
            return;
        }

        if (!_clienteService.Clientes.Contains(_cliente))
        {
            _clienteService.Adicionar(_cliente);
        }

        await _navigation.PopModalAsync(); // Volta para MainPage
    }

    private async void Cancelar()
    {

        await _navigation.PopModalAsync();


    }
}
