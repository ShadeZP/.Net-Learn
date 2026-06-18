CREATE TRIGGER AfterInsert_Employee
ON [dbo].[Employee]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[Company] ([Name], [AddressId])
    SELECT i.CompanyName, i.AddressId
    FROM inserted i;
END