SELECT c.CurrencyCode,
	   de.Currency,
	   de.NumberOfCountries
FROM
(SELECT  cur.Description AS Currency,
		COUNT(c.CountryName) AS NumberOfCountries
FROM Countries AS c
	RIGHT JOIN Currencies AS cur
		ON c.CurrencyCode = cur.CurrencyCode
GROUP BY cur.Description) AS de
INNER JOIN Currencies AS c
	ON de.Currency = c.Description
ORDER BY NumberOfCountries DESC, de.Currency