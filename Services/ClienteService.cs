using ClienteCadastroApp.Models;
using System.Collections.ObjectModel;

namespace ClienteCadastroApp.Services;

public class ClienteService : IClienteService
{
    public ObservableCollection<Cliente> Clientes { get; } = new();

    public void Adicionar(Cliente cliente) => Clientes.Add(cliente);
    public void Remover(Cliente cliente) => Clientes.Remove(cliente);
    public void Atualizar(Cliente cliente)
    {
        var index = Clientes.ToList().FindIndex(clientes => clientes.Id == cliente.Id);
        if (index >= 0)
        {
            Clientes[index] = cliente;
        }
    }
}
