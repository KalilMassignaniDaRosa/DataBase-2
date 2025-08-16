using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnoescBank.Models
{
    [PrimaryKey(nameof(ClientId), nameof(AccountId))]
    public class ClientAccount
    {
        [ForeignKey(nameof(ClientId))]
        public int ClientId { get; set; }
        
        public Client? Client { get; set; }

        [ForeignKey(nameof(AccountId))]
        public int AccountId { get; set; }
        public Account? Account { get; set; }

    }
}
