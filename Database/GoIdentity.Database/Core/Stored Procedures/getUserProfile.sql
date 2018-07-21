CREATE PROCEDURE [Core].[getUserProfile]
	@userId INT
AS
BEGIN
	SELECT * FROM Core.trUserProfile WHERE UserId = @userId;
END
