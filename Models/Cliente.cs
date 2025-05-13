using SQLite;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ClienteCadastroApp.Models;

public partial class Cliente : ObservableObject
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }


    //Com a utilização de observable property não é possível escrever a propriedade com Letra maiúscula...
    [ObservableProperty]
    private string name;

    [ObservableProperty]
    private string lastname;

    [ObservableProperty]
    private int? age;

    [ObservableProperty]
    private string address;
}
