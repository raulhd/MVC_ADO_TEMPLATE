CREATE PROCEDURE [dbo].[UpdateClient]
	@Id Int,
	@Name Varchar(100),
	@LastName Varchar(100),
	@IdentificationNumber Varchar(100)
AS
BEGIN
	
	UPDATE dbo.Client SET
		Name = @Name,
		LastName = @LastName,
		IdentificationNumber = @IdentificationNumber
	WHERE Id = @Id;

END
