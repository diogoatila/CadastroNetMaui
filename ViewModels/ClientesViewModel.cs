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

    private ObservableCollection<Cliente> _clientes;
    public ObservableCollection<Cliente> Clientes
    {
        get => _clientes;
        set => SetProperty(ref _clientes, value);
    }


    private Cliente _cliente;
    public Cliente Cliente
    {
        get => _cliente;
        set => SetProperty(ref _cliente, value);
    }


    public ICommand AdicionarCommand { get; }
    public ICommand EditarCommand { get; }
    public ICommand ExcluirCommand { get; }
    public ICommand SalvarCommand { get; }
    public ICommand CancelarCommand { get; }


    public ClientesViewModel(IClienteService clienteService, INavigationService navigationService, Cliente cliente = null)
    {
        _clienteService = clienteService;
        _navigation = navigationService;
        Cliente = cliente ?? new Cliente();



        AdicionarCommand = new RelayCommand(AdicionarCliente);
        EditarCommand = new RelayCommand<Cliente>(EditarCliente);
        ExcluirCommand = new RelayCommand<Cliente>(ExcluirCliente);
        SalvarCommand = new RelayCommand(Salvar);
        CancelarCommand = new RelayCommand(Cancelar);
    }

    public async Task CarregarClientesAsync()
    {
        var lista = await _clienteService.ObterTodosAsync();
        Clientes = new ObservableCollection<Cliente>(lista);
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

            //Remove do Grid
            Clientes.Remove(cliente);
        }
    }

    private async void Salvar()
    {
        if (string.IsNullOrWhiteSpace(Cliente.Name) || string.IsNullOrWhiteSpace(Cliente.Lastname))
        {
            await Application.Current.MainPage.DisplayAlert("Erro", "Nome e Sobrenome são obrigatórios.", "OK");
            return;
        }

    var existente = _clienteService.Clientes.FirstOrDefault(c => c.Id == Cliente.Id);

    if (existente != null)
    {
        // Se o cliente já existe, atualiza as propriedades da instância existente
        existente.Name = Cliente.Name;
        existente.Lastname = Cliente.Lastname;
        existente.Age = Cliente.Age;
        existente.Address = Cliente.Address;

         await _clienteService.Atualizar(existente); 
    }
    else
    {
        // Se o cliente não está na lista, adiciona um novo
        await _clienteService.Adicionar(Cliente);
     
    }

        await _navigation.PopModalAsync(); 
    }


    private async void Cancelar()
    {

        await _navigation.PopModalAsync();


    }
}
