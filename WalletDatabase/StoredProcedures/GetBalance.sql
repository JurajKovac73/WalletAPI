CREATE PROCEDURE [dbo].[GetBalance]
	@PlayerId UNIQUEIDENTIFIER
AS
	SELECT Balance FROM dbo.PlayersWallet
	WHERE PlayerId = @PlayerId	
RETURN 0
