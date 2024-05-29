using System.Transactions;
using WalletAPI.Enums;
using WalletAPI.Models;
using WalletAPI.Services.DatabaseConnections;
using Microsoft.Extensions.Logging;

namespace WalletAPI.Services.Transactions
{
    public class TransactionService : ITransactionService
    {
        private readonly IDatabaseProvider _databaseProvider;
        private readonly ILogger _logger;

        public TransactionService(IDatabaseProvider databaseProvider, ILogger logger)
        {
            _databaseProvider = databaseProvider;
            _logger = logger;
        }

        public async Task<BalanceTransactionResult> ExecuteTransaction(BalanceTransaction transaction)
        {
            bool isConnectionOpen = false;
            BalanceTransactionResult result;
            try
            {
                isConnectionOpen = await _databaseProvider.OpenConnection();
                //if transaction was already proccessed
                bool isTransactionProcessed = await _databaseProvider.IsTransactionProcessed(transaction.Id);
                if (isTransactionProcessed)
                {
                    return await _databaseProvider.GetTransaction(transaction.Id);
                }

                switch (transaction.TransactionType)
                {
                    case TransactionType.Deposit:
                        result = await Deposit(transaction);
                         break;

                    case TransactionType.Stake:
                        result = await Stake(transaction);
                        break;

                    case TransactionType.Win:
                        result = await Win(transaction);
                        break;

                    default:
                        transaction.TransactionType = TransactionType.Unknown;
                        result = TransactionRejected(transaction, "This type of transaction is not supported.");
                        break;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.StackTrace, transaction);
                //There could be some retry logic if we wanted to be sure, when connection or database are ready, the transaction gets accepted but to keep it simple...
                result = TransactionRejected(transaction, "Something went wrong, please contact our support team on email@email...");
            }
            finally {
                if (isConnectionOpen)
                {
                    await _databaseProvider.CloseConnection();
                }
            }
            return result;
        }

        private async Task<BalanceTransactionResult> Deposit(BalanceTransaction transaction)
        {                    
               return await _databaseProvider.DepositTransaction(TransactionAccepted(transaction, "Deposit:"));         
        }

        private async Task<BalanceTransactionResult> Stake(BalanceTransaction transaction)
        {
            decimal balance = await _databaseProvider.GetPlayerBalance(transaction.PlayerId);
            if (HasPlayerBalanceForStake(balance, transaction.MoneyAmount))
            {
                return await _databaseProvider.StakeTransaction(TransactionAccepted(transaction, "Stake:"));             
            }

            return TransactionRejected(transaction, "You do not have enough money in your account for this stake.");
        }

        private async Task<BalanceTransactionResult> Win(BalanceTransaction transaction)
        {
                return await _databaseProvider.WinTransaction(TransactionAccepted(transaction, "Win:"));
        }

        private bool HasPlayerBalanceForStake(decimal balance, decimal stakeAmount)
        {
            return (balance >= stakeAmount);
        }

        private BalanceTransactionResult TransactionAccepted(BalanceTransaction transaction, string acceptedMessage)
        {
            return new BalanceTransactionResult
            {
                Id = transaction.Id,
                PlayerId = transaction.PlayerId,
                TransactionType = transaction.TransactionType,
                Accepted = true,
                MoneyAmount = transaction.MoneyAmount,
                ResultMessage = $"{acceptedMessage} transaction was accepted."
            };

        }

        private BalanceTransactionResult TransactionRejected(BalanceTransaction transaction, string rejectionMessage)
        {
            return new BalanceTransactionResult
            {
                Id = transaction.Id,
                PlayerId = transaction.PlayerId,
                TransactionType = transaction.TransactionType,
                MoneyAmount = transaction.MoneyAmount,
                Accepted = false,
                ResultMessage = $"Your transaction was rejected. {rejectionMessage}"
            };
        }
    }
}
