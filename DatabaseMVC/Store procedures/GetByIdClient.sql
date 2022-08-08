CREATE PROCEDURE [dbo].[GetByIdClient]
	@Id Int
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT 
		Id,
		Name, 
		LastName, 
		IdentificationNumber 
	FROM Client
	WHERE Id = @Id;

END
