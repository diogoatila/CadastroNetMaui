using ClienteCadastroApp.Models;
using System.Collections.ObjectModel;

public interface IClienteService
{
    ObservableCollection<Cliente> Clientes { get; }
    void Adicionar(Cliente cliente);
    void Remover(Cliente cliente);
    void Atualizar(Cliente cliente);
}
