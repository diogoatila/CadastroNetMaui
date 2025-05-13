namespace ClienteCadastroApp.Models;
public class Cliente
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Lastname { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
}
