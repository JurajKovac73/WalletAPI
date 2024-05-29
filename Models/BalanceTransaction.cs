using Newtonsoft.Json;
using WalletAPI.Enums;

namespace WalletAPI.Models
{
    public class BalanceTransaction
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("playerId")]
        public Guid PlayerId { get; set; }

        [JsonProperty("transactionType")]
        public TransactionType TransactionType { get; set; }

        [JsonProperty("moneyAmount")]
        public decimal MoneyAmount { get; set; }
    }
}
