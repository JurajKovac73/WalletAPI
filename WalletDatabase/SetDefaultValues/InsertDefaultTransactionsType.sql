IF (OBJECT_ID('dbo.TransactionTypes', 'U') IS NOT NULL)
BEGIN
	IF (NOT EXISTS(SELECT 1 FROM [dbo].[TransactionTypes]))
		BEGIN
			INSERT INTO [dbo].[TransactionTypes] 
			(Id, TransactionType) 
			VALUES 
			(0, 'Deposit'), 
			(1, 'Stake'), 
			(2, 'Win'),
			(3, 'Unknown')
		END
END