USE AdventureWorks2017;

/* By using join Statement */
SELECT PP.FirstName + PP.LastName AS 'Customer Name'
FROM Person.Person PP INNER JOIN
	Sales.Customer SC ON
	PP.BusinessEntityID = SC.CustomerID LEFT JOIN
	Sales.SalesOrderHeader SS ON
	SC.CustomerID = SS.CustomerID
WHERE SS.SalesOrderID IS NULL;

/* By Using Sub Query */
SELECT FirstName + LastName AS 'Customer Name'
FROM Person.Person
WHERE BusinessEntityID IN (SELECT CustomerID
		FROM Sales.Customer
		WHERE CustomerID NOT IN (SELECT CustomerID
			FROM Sales.SalesOrderHeader));

/* By using CTE's */
WITH UnorderProductCustomers (CustomerName)
AS (
	SELECT PP.FirstName + PP.LastName AS 'Customer Name'
	FROM Person.Person PP INNER JOIN
	Sales.Customer SC ON
	PP.BusinessEntityID = SC.CustomerID LEFT JOIN
	Sales.SalesOrderHeader SS ON
	SC.CustomerID = SS.CustomerID
	WHERE SS.SalesOrderID IS NULL
	)
SELECT CustomerName
FROM UnorderProductCustomers;

/* By using Exists */
SELECT PP.FirstName + PP.LastName AS 'Customer Name'
FROM Person.Person PP
WHERE EXISTS (SELECT SC.CustomerID
			  FROM Sales.Customer SC
			  WHERE PP.BusinessEntityID = SC.CustomerID AND
				NOT EXISTS(SELECT SS.CustomerID
					FROM Sales.SalesOrderHeader SS
					WHERE SC.CustomerID = SS.CustomerID));
