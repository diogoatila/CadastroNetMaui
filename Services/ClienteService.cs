using ClienteCadastroApp.Data;
using ClienteCadastroApp.Models;
using System.Collections.ObjectModel;

namespace ClienteCadastroApp.Services;

public class ClienteService : IClienteService
{
    private readonly ClienteDatabase _db;
    public ObservableCollection<Cliente> Clientes { get; private set; } = new();

    public ClienteService(ClienteDatabase db)
    {
        _db = db;
        _ = LoadClientes(); // Carrega os dados ao inicializar
    }

    public Task<List<Cliente>> ObterTodosAsync() =>
    _db.GetClientesAsync();

    public Task<Cliente> ObterPorIdAsync(int id) =>
    _db.GetClienteByIdAsync(id);
    private async Task LoadClientes()
    {
        var lista = await _db.GetClientesAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Clientes = new ObservableCollection<Cliente>(lista);
        });
    }

    public async Task Adicionar(Cliente cliente)
    {
        await _db.SaveClienteAsync(cliente);
        Clientes.Add(cliente);
    }

    public async void Remover(Cliente cliente)
    {
        await _db.DeleteClienteAsync(cliente);
        Clientes.Remove(cliente);
    }

    public async Task Atualizar(Cliente cliente)
    {
        await _db.UpdateClienteAsync(cliente);

        var existente = Clientes.FirstOrDefault(c => c.Id == cliente.Id);
        if (existente != null)
        {
            var index = Clientes.IndexOf(existente);
            Clientes.RemoveAt(index);       
            Clientes.Insert(index, cliente); 
        }
    }
}
