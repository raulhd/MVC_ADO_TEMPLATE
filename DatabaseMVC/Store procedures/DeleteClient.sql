CREATE PROCEDURE [dbo].[DeleteClient]
	@Id Int
AS
BEGIN
	
	DELETE dbo.Client WHERE Id = @Id;

END
