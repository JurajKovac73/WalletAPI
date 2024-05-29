using WalletAPI.Models;

namespace WalletAPI.Services.DatabaseConnections
{
    public interface IDatabaseProvider
    {
        public Task<bool> OpenConnection();
        public Task<bool> CloseConnection();
        public Task<BalanceTransactionResult> GetTransaction(Guid transactionId);

        public Task<decimal> GetPlayerBalance(Guid playerId);

        public Task<List<BalanceTransactionResult>> GetPlayerTransactions(Guid playerId);

        public Task<BalanceTransactionResult> DepositTransaction(BalanceTransactionResult balanceTransaction);

        public Task<BalanceTransactionResult> StakeTransaction (BalanceTransactionResult balanceTransaction);

        public Task<BalanceTransactionResult> WinTransaction (BalanceTransactionResult balanceTransaction);

        public Task<bool> IsTransactionProcessed (Guid transactionId);

        public Task<bool> IsTransactionAccepted (Guid transactionId);
    }
}
