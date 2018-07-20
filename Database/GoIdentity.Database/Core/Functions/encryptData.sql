CREATE FUNCTION [Core].[encryptData]
(
	@plainText VARCHAR(8000)
)
RETURNS varbinary(8000)
as
begin
	DECLARE @passphrase NVARCHAR(128)= 'goidentity7h#passVVVVVVVsecure';
	
	RETURN ENCRYPTBYPASSPHRASE(@passphrase, @plainText);
end
