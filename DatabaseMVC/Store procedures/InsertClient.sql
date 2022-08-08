CREATE PROCEDURE [dbo].[InsertClient]
	@Id int OUTPUT,
	@Name Varchar(100),
	@LastName Varchar(100),
	@IdentificationNumber Varchar(100)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Client 
	(Name, LastName, IdentificationNumber)
	VALUES (@Name, @LastName, @IdentificationNumber);

	SET @Id = SCOPE_IDENTITY();

END
