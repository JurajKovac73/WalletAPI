CREATE PROCEDURE [dbo].[WinTransaction]
	@Id UNIQUEIDENTIFIER,
	@PlayerId UNIQUEIDENTIFIER,
	@TransactionType int,
	@MoneyAmount decimal,
	@Accepted tinyInt,
	@ResultMessage varchar,
	@DateOfTransaction Datetime
AS
IF(@Accepted = 1)
	BEGIN
		UPDATE dbo.PlayersWallet SET Balance = (Balance + @MoneyAmount) WHERE PlayerId = @PlayerId
	END

	INSERT INTO dbo.BalanceTransactions (Id, PlayerId, TransactionType, MoneyAmount, Accepted, ResultMessage, DateOfTransaction) 
	VALUES(@Id, @PlayerId, @TransactionType, @MoneyAmount, @Accepted, @ResultMessage, @DateOfTransaction)
	
RETURN 0