CREATE PROCEDURE [dbo].[InsertEmployee]
    @EmployeeName NVARCHAR(100) = NULL,
    @FirstName NVARCHAR(50) = NULL,
    @LastName NVARCHAR(50) = NULL,
    @CompanyName NVARCHAR(50),
    @Position NVARCHAR(30) = NULL,
    @Street NVARCHAR(50),
    @City NVARCHAR(20) = NULL,
    @State NVARCHAR(50) = NULL,
    @ZipCode NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    IF (
        ( @EmployeeName IS NULL OR TRIM(@EmployeeName) = '' )
        AND ( @FirstName IS NULL OR TRIM(@FirstName) = '' )
        AND ( @LastName IS NULL OR TRIM(@LastName) = '' )
        AND ( @CompanyName IS NULL OR TRIM(@CompanyName) = '' )
    )
    BEGIN
        RAISERROR('At least one field (EmployeeName, FirstName, LastName or CompanyName) must be not empty.', 16, 1);
        RETURN;
    END

    DECLARE @TruncCompanyName NVARCHAR(20) = LEFT(@CompanyName, 20);

    DECLARE @AddressId INT;
    SELECT @AddressId = Id FROM [Address]
        WHERE Street = @Street
          AND ISNULL(City, '') = ISNULL(@City, '')
          AND ISNULL(State, '') = ISNULL(@State, '')
          AND ISNULL(ZipCode, '') = ISNULL(@ZipCode, '')

    IF @AddressId IS NULL
    BEGIN
        INSERT INTO [Address] ([Street], [City], [State], [ZipCode])
        VALUES (@Street, @City, @State, @ZipCode);

        SET @AddressId = SCOPE_IDENTITY();
    END

    DECLARE @PersonId INT = NULL;
    IF @FirstName IS NOT NULL OR @LastName IS NOT NULL
    BEGIN
        SELECT @PersonId = Id FROM [Person]
         WHERE ISNULL(FirstName, '') = ISNULL(@FirstName, '')
           AND ISNULL(LastName, '') = ISNULL(@LastName, '');

        IF @PersonId IS NULL
        BEGIN
            INSERT INTO [Person] ([FirstName], [LastName])
            VALUES (@FirstName, @LastName);
            SET @PersonId = SCOPE_IDENTITY();
        END
    END

    INSERT INTO [Employee] ([AddressId], [PersonId], [CompanyName], [Position], [EmployeeName])
    VALUES (
        @AddressId,
        @PersonId,
        @TruncCompanyName,
        @Position,
        @EmployeeName
    );
END