public interface INavigationService
{
    Task PushModalAsync(Page page);
    Task PopModalAsync();
}
