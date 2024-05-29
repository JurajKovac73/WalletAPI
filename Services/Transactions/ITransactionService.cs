using WalletAPI.Enums;
using WalletAPI.Models;

namespace WalletAPI.Services.Transactions
{
    public interface ITransactionService
    {
        Task<BalanceTransactionResult> ExecuteTransaction(BalanceTransaction trasaction);
    }
}
