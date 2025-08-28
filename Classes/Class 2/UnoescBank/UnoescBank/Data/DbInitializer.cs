using UnoescBank.Models;

namespace UnoescBank.Data
{
    public class DbInitializer
    {
        public static void Initialize(BankContext context)
        {
            context.Database.EnsureCreated();
            if (context.Clients.Any())
            {
                return;   // DB has been seeded
            }

            var clients = new Client[]
            {
                new Client { ClientName = "João Silva" },
                new Client { ClientName = "Maria Oliveira" },
                new Client { ClientName = "Carlos Souza" },
                new Client { ClientName = "Ana Pereira" }
            };

            foreach (Client c in clients)
            {
                context.Clients.Add(c);
            }
            context.SaveChanges();

            var accounts = new Account[]
            {
                new Account { AccountNumber = 1001 },
                new Account { AccountNumber = 1002 },
                new Account { AccountNumber = 1003 },
                new Account { AccountNumber = 1004 },
                new Account { AccountNumber = 1005 }
            };

            // Forma de fazer todos os inserts
            context.Accounts.AddRange(accounts);
            context.SaveChanges();

            var clientAccounts = new ClientAccount[]
            {
                new ClientAccount { ClientId = clients[0].ClientId, AccountId = accounts[0].AccountId }, // João → 1001
                new ClientAccount { ClientId = clients[1].ClientId, AccountId = accounts[1].AccountId }, // Maria → 1002
                new ClientAccount { ClientId = clients[2].ClientId, AccountId = accounts[2].AccountId }, // Carlos → 1003
                new ClientAccount { ClientId = clients[3].ClientId, AccountId = accounts[3].AccountId }, // Ana → 1004
                new ClientAccount { ClientId = clients[0].ClientId, AccountId = accounts[4].AccountId }, // João → 1005
            };
            context.ClientAccounts.AddRange(clientAccounts);
            context.SaveChanges();
        }
    }
}
