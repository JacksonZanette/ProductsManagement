ALTER PROCEDURE [dbo].[InsertProduct]
AS
	INSERT INTO [dbo].[Products] VALUES (NEWID(), 'Procedure product', 'Created at ' +  CONVERT(VARCHAR, GETDATE(), 0), 500);
GO;

EXECUTE dbo.InsertProduct;

ALTER FUNCTION [DBO].[GETPRODUCTS_AS_JSON] () 
RETURNS NVARCHAR(MAX) AS
BEGIN
    DECLARE @RETURN NVARCHAR(MAX) = (SELECT Id, Name, Description, Price FROM Products FOR JSON PATH);    
    RETURN @RETURN
END;

SELECT DBO.GETPRODUCTS_AS_JSON();