using ClienteCadastroApp.Services;
using ClienteCadastroApp.ViewModels;
using Microsoft.Extensions.Logging;

namespace ClienteCadastroApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // Configuração da aplicação
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Registra os serviços de DI
            builder.Services.AddSingleton<IClienteService, ClienteService>();
            builder.Services.AddSingleton<ClientesViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();

            // Criação do objeto MauiApp
          return builder.Build();

    
        }

    }
}
