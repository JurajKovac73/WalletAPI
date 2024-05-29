using WalletAPI.Models;

namespace WalletAPI.Services.DatabaseConnections
{
    public class InMemoryDatabase : IDatabaseProvider
    {
        public Task<bool> OpenConnection()
        {
            //Open connections simulation
            return Task.FromResult(true);
        }

        public Task<bool> CloseConnection()
        {
            //Close connections simulation
            return Task.FromResult(true);
        }

        public Task<BalanceTransactionResult> GetTransaction(Guid transactionId)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetPlayerBalance(Guid playerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<BalanceTransactionResult>> GetPlayerTransactions(Guid playerId)
        {
            throw new NotImplementedException();
        }

        public Task<BalanceTransactionResult> DepositTransaction(BalanceTransactionResult balanceTransaction)
        {
            throw new NotImplementedException();
        }

        public Task<BalanceTransactionResult> StakeTransaction(BalanceTransactionResult balanceTransaction)
        {
            throw new NotImplementedException();
        }

        public Task<BalanceTransactionResult> WinTransaction(BalanceTransactionResult balanceTransaction)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsTransactionProcessed(Guid transactionId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsTransactionAccepted(Guid transactionId)
        {
            throw new NotImplementedException();
        }
    }
}
