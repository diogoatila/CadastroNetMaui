using ClienteCadastroApp.Models;
using System.Collections.ObjectModel;

public interface IClienteService
{
    ObservableCollection<Cliente> Clientes { get; }

    Task<List<Cliente>> ObterTodosAsync();
    Task<Cliente> ObterPorIdAsync(int id);
    Task Adicionar(Cliente cliente);
    Task Atualizar(Cliente cliente);
    void Remover(Cliente cliente);
    
}
