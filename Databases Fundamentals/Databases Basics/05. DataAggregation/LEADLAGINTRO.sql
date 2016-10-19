USE Gringotts
GO


SELECT ABS(SumD.SumDifference)
FROM
(SELECT SUM(d.Differences) AS SumDifference
FROM
(SELECT w.DepositAmount
       ,w.DepositAmount - LEAD(w.DepositAmount, 1) OVER (ORDER BY id)
	   AS Differences
FROM WizzardDeposits AS w) AS d
) AS SumD