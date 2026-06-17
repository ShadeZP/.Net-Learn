CREATE VIEW [dbo].[EmployeeInfo]
AS
SELECT
    e.Id AS EmployeeId,
    CASE
        WHEN e.EmployeeName IS NOT NULL THEN e.EmployeeName
        ELSE p.FirstName + ' ' + p.LastName
    END AS EmployeeFullName,
    a.ZipCode + '_' + a.State + ', ' + a.City + '-' + a.Street AS EmployeeFullAddress,
    e.CompanyName + '(' + ISNULL(e.Position, '') + ')' AS EmployeeCompanyInfo
FROM [Employee] e
INNER JOIN [Person] p ON e.PersonId = p.Id
INNER JOIN [Address] a ON e.AddressId = a.Id;