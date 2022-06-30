USE AdventureWorks2017;
GO
CREATE PROCEDURE Person.up_DisplayPersonInfo
	@FirstName nvarchar(20) = 'Tommy'
AS
BEGIN
	SELECT BusinessEntityID AS 'ID',
		   FirstName + LastName AS 'NAME',
		   PersonType
	FROM Person.Person
	WHERE FirstName = @FirstName
END

EXECUTE Person.up_DisplayPersonInfo
EXECUTE Person.up_DisplayPersonInfo @FirstName = 'Blake'

GO