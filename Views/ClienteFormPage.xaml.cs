using ClienteCadastroApp.Models;
using ClienteCadastroApp.ViewModels;
using System.Text.RegularExpressions;

namespace ClienteCadastroApp;

public partial class ClienteFormPage : ContentPage
{

    public ClienteFormPage(Cliente cliente = null)
    {
        InitializeComponent();

        var navigationService = ((App)App.Current).Services.GetRequiredService<INavigationService>();
        var clienteService = ((App)App.Current).Services.GetRequiredService<IClienteService>();
        BindingContext = new ClientesViewModel(clienteService, navigationService, cliente);
    }

    private void OnAgeTextChanged(object sender, TextChangedEventArgs e)
    {
        // Verifica se o valor inserido é um número inteiro
        if (!string.IsNullOrEmpty(e.NewTextValue) && !int.TryParse(e.NewTextValue, out _))
        {
           
            ((Entry)sender).Text = e.OldTextValue; // Reverte a alteração se não for apenas números
        }
    }
    private void OnNameTextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = (Entry)sender;
        if (!string.IsNullOrEmpty(entry.Text) && !Regex.IsMatch(entry.Text, @"^[a-zA-Z\s]*$"))
        {
            entry.Text = e.OldTextValue; // Reverte a alteração se não for apenas letras
        }
    }

    private void OnLastnameTextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = (Entry)sender;
        if (!string.IsNullOrEmpty(entry.Text) && !Regex.IsMatch(entry.Text, @"^[a-zA-Z\s]*$"))
        {
            entry.Text = e.OldTextValue; // Reverte a alteração se não for apenas letras
        }
    }



}