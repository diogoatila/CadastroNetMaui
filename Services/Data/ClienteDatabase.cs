using ClienteCadastroApp.Models;
using SQLite;

namespace ClienteCadastroApp.Data;

public class ClienteDatabase
{
    private readonly SQLiteAsyncConnection _database;

    public ClienteDatabase(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Cliente>().Wait();
    }

    public Task<List<Cliente>> GetClientesAsync() =>
        _database.Table<Cliente>().ToListAsync();

    public Task<Cliente> GetClienteByIdAsync(int id) =>
        _database.Table<Cliente>()
                 .Where(c => c.Id == id)
                 .FirstOrDefaultAsync();
    public async Task SaveClienteAsync(Cliente cliente)
    {
        await _database.InsertAsync(cliente);
    }
    public async Task UpdateClienteAsync(Cliente cliente)
    {
        await _database.UpdateAsync(cliente);
    }

    public Task<int> DeleteClienteAsync(Cliente cliente) =>
        _database.DeleteAsync(cliente);
}
