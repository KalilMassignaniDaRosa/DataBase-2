using System.ComponentModel.DataAnnotations;

namespace UnoescBank.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public int AccountNumber { get; set; }
        public List<ClientAccount>? ClientAccounts { get; set; }
    }
}
