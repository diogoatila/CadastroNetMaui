using SQLite;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ClienteCadastroApp.Models;

public partial class Cliente : ObservableObject
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Lastname { get; set; }

    public int? Age { get; set; }

    public string Address { get; set; }
}
