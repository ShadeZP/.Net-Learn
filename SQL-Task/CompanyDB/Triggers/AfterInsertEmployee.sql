CREATE TRIGGER AfterInsert_Employee
ON [dbo].[Employee]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[Company] ([Name], [AddressId])
    SELECT i.CompanyName, i.AddressId
    FROM inserted i
    WHERE NOT EXISTS (
        SELECT 1 
        FROM [dbo].[Company] c
        WHERE c.Name = i.CompanyName
          AND c.AddressId = i.AddressId
    )
END