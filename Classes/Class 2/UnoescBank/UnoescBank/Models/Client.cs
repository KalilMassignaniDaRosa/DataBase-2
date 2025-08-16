using System.ComponentModel.DataAnnotations;

namespace UnoescBank.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string? ClientName { get; set; }
        public List<ClientAccount>? ClientAccounts { get; set; }
    }
}
