USE Gringotts
GO

SELECT fl.FirstLetter
FROM
(SELECT LEFT(w.FirstName,1) AS FirstLetter
FROM WizzardDeposits AS w
WHERE w.DepositGroup = 'Troll Chest') AS fl
GROUP BY fl.FirstLetter


