CREATE FUNCTION [Core].[decryptData]
(
	@cipherText VARBINARY(8000)
)
RETURNS VARCHAR(8000)
as
begin
	DECLARE @passphrase NVARCHAR(128)= 'goidentity7h#passVVVVVVVsecure';
	
	RETURN convert(varchar(8000), DECRYPTBYPASSPHRASE(@passphrase, @cipherText));
end
