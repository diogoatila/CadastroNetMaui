public class NavigationService : INavigationService
{
    public Task PushModalAsync(Page page) =>
        Application.Current.MainPage.Navigation.PushModalAsync(page);

    public Task PopModalAsync() =>
        Application.Current.MainPage.Navigation.PopModalAsync();
}
