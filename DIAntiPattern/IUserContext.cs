namespace DIAntiPattern
{
    public interface IUserContext
    {
        Currency GetSelectedCurrency(User currentUser);
        User GetCurrentUser();
    }
}