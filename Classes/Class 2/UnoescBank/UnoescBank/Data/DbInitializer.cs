namespace UnoescBank.Data
{
    public class DbInitializer
    {
        public static void Initialize(BankContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
