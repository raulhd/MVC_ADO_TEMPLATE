CREATE PROCEDURE [dbo].[GetAllClient]
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT
		Id,
		Name, 
		LastName, 
		IdentificationNumber 
	FROM Client;

END
