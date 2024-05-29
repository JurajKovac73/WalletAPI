using WalletAPI.Enums;

namespace WalletAPI.Models
{
    public class BalanceTransactionResult
    {
        public Guid Id { get; set; }

        public Guid PlayerId { get; set; }
        public TransactionType TransactionType { get; set; }

        public decimal MoneyAmount { get; set; }
        public bool Accepted { get; set; }

        public string? ResultMessage { get; set; }

    }
}
