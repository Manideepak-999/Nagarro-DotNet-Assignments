USE AdventureWorks2017;

/* Question 1.1 */
/* Display the number of records in the table */

SELECT COUNT(BusinessEntityID) AS 'Number of Records'
FROM Sales.SalesPerson;

/* Question 1.2 */
/* Select Both First and Last Names from person table firstname begins with B */

SELECT FirstName , LastName
FROM Person.Person
WHERE FirstName LIKE 'B%';

/* Question 1.3 */
/* Select Employee Names of Role Design Engineer, Tool Designer or Marketing Assistant */

SELECT PP.FirstName, pp.LastName
FROM Person.Person AS PP INNER JOIN
	HumanResources.Employee HE ON
	PP.BusinessEntityID = HE.BusinessEntityID
WHERE HE.JobTitle = 'Design Engineer' OR
	  HE.JobTitle = 'Tool Designer' OR
	  HE.JobTitle = 'Marketing Assistant';

/* Question 1.4 */
/* Display the Name & Colour of the product with the maximum weight */

SELECT [Name], Color
FROM Production.Product
WHERE Weight = (Select MAX(Weight) FROM Production.Product);

/* Question 1.5 */
/* Display Description & MaxQty fields from the special offer table Some are NULL */

SELECT Description, COALESCE(MaxQty,0.00) AS 'MAXIMUM Quantity'
FROM Sales.SpecialOffer;

/* Question 1.6 */
/* Display the overall average of the [currencyrate].[avgrate] values for exchange rate usd to gbp */

SELECT AVG(AverageRate) AS 'Average Rate of the Day'
FROM Sales.CurrencyRate
WHERE FromCurrencyCode = 'USD' AND
	  ToCurrencyCode = 'GBP';

/* Question 1.7 */
/* Display First and Last name of records from person table where first name contains the letters 'ss' */
/* Display the additional coloumn with sequential numbers for each row returned beginner at integer 1 */

SELECT ROW_NUMBER() OVER(ORDER BY FirstName) AS 'Sequence', FirstName, LastName
FROM Person.Person
WHERE FirstName LIKE '%ss%';

/* Question 1.8 */
/* Sales people receive various commission rates belong to 1 of 4 bands */

SELECT BusinessEntityID AS 'SalesPersonID',
	CASE	
			WHEN CommissionPct = 0.00 THEN 'BAND 0'
			WHEN CommissionPct > 0.00 AND CommissionPct <= 0.01 THEN 'BAND 1'
			WHEN CommissionPct > 0.01 AND CommissionPct <= 0.015 THEN 'BAND 2'
			WHEN CommissionPct > 0.015 THEN 'BAND 3'
    END AS 'Commission Band'
FROM Sales.SalesPerson
ORDER BY [Commission Band];

/* Question 1.9 */
/* Display the managerial hierarchy from Ruth Ellerbrock upto CEO Ken Sanchez */

SELECT Person, HumanResources
FROM uspGetEmployeeManagers;

/* Question 1.10 */
/* Display the product id of product with largest stock level */
SELECT ProductID AS 'Product ID'
FROM Production.Product
WHERE SafetyStockLevel = (SELECT MAX(SafetyStockLevel) FROM Production.Product);