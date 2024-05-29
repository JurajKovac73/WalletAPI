CREATE PROCEDURE [dbo].[GetPlayerTransactionHistory]
	@PlayerId UNIQUEIDENTIFIER
AS
	SELECT Id, PlayerId, TransactionType, MoneyAmount, Accepted, ResultMessage, DateOfTransaction 
	FROM dbo.BalanceTransactions
	WHERE PlayerId = @PlayerId 
	ORDER BY DateOfTransaction
RETURN 0
