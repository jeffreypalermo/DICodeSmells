namespace DIAntiPattern
{
    public class UserContext : IUserContext
    {
        public Currency GetSelectedCurrency(User currentUser)
        {
            return Currency.ILS;
        }

        public User GetCurrentUser()
        {
            return new User();
        }
    }
}