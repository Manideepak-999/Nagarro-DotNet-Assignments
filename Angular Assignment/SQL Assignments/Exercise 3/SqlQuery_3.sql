/* Question 3 */

USE AdventureWorks2017;
SELECT TOP 5 SalesOrderID AS 'Order ID',
	OrderDate AS 'Date of order',
	AccountNumber AS 'Account Number',
	SUM(TotalDue) AS 'Amount Spent'
FROM Sales.SalesOrderHeader
GROUP BY AccountNumber, OrderDate, SalesOrderID
HAVING SUM(TotalDue) > 70000
ORDER BY OrderDate DESC;