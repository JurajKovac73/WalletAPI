CREATE TABLE [dbo].[BalanceTransactions]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [PlayerId] UNIQUEIDENTIFIER NOT NULL FOREIGN KEY (PlayerId) REFERENCES Players(id), 
    [TransactionType] INT NOT NULL FOREIGN KEY (TransactionType) REFERENCES TransactionTypes(id), 
    [MoneyAmount] DECIMAL NOT NULL, 
    [Accepted] TINYINT NOT NULL, 
    [DateOfTransaction] DATETIME NOT NULL, 
    [ResultMessage] NVARCHAR(300) NULL, 
)
