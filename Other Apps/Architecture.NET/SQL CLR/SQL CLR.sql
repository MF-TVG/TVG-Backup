CREATE FUNCTION dbo.SplitString(@input nvarchar(max), @delimiter nvarchar(max))
RETURNS TABLE (StringValue NVARCHAR(MAX)) WITH EXECUTE AS CALLER
AS
EXTERNAL NAME [USAACE.SQLCLR].[USAACE.SQLCLR.Functions].[SplitString]