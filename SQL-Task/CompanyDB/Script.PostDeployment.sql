/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-- Address
IF NOT EXISTS (SELECT 1 FROM [dbo].[Address] WHERE Id = 1)
    INSERT INTO [dbo].[Address] ([Id], [Street], [City], [State], [ZipCode]) VALUES (1, N'Khreshchatyk', N'Kyiv', N'Kyiv oblast', N'01001');

IF NOT EXISTS (SELECT 1 FROM [dbo].[Address] WHERE Id = 2)
    INSERT INTO [dbo].[Address] ([Id], [Street], [City], [State], [ZipCode]) VALUES (2, N'Lenina', N'Dnipro', N'Dnipropetrovsk oblast', N'49000');

IF NOT EXISTS (SELECT 1 FROM [dbo].[Address] WHERE Id = 3)
    INSERT INTO [dbo].[Address] ([Id], [Street], [City], [State], [ZipCode]) VALUES (3, N'Shevchenka', N'Lviv', N'Lviv oblast', N'79000');

IF NOT EXISTS (SELECT 1 FROM [dbo].[Address] WHERE Id = 4)
    INSERT INTO [dbo].[Address] ([Id], [Street], [City], [State], [ZipCode]) VALUES (4, N'Pushkina', N'Harkiv', N'Harkiv oblast', N'61000');

IF NOT EXISTS (SELECT 1 FROM [dbo].[Address] WHERE Id = 5)
    INSERT INTO [dbo].[Address] ([Id], [Street], [City], [State], [ZipCode]) VALUES (5, N'Soborna', N'Odessa', N'Odessa oblast', N'65000');

IF NOT EXISTS (SELECT 1 FROM [dbo].[Address] WHERE Id = 6)
    INSERT INTO [dbo].[Address] ([Id], [Street], [City], [State], [ZipCode]) VALUES (6, N'Tarasova', N'Poltava', N'Poltava oblast', N'36000');

IF NOT EXISTS (SELECT 1 FROM [dbo].[Address] WHERE Id = 7)
    INSERT INTO [dbo].[Address] ([Id], [Street], [City], [State], [ZipCode]) VALUES (7, N'Osvity', N'Zaporizhzhia', N'Zaporizhzhia oblast', N'69000');

IF NOT EXISTS (SELECT 1 FROM [dbo].[Address] WHERE Id = 8)
    INSERT INTO [dbo].[Address] ([Id], [Street], [City], [State], [ZipCode]) VALUES (8, N'Peremohy', N'Chernivtsi', N'Chernivtsi oblast', N'58000');

IF NOT EXISTS (SELECT 1 FROM [dbo].[Address] WHERE Id = 9)
    INSERT INTO [dbo].[Address] ([Id], [Street], [City], [State], [ZipCode]) VALUES (9, N'Druzhby', N'Vinnytsia', N'Vinnytsia oblast', N'21000');

IF NOT EXISTS (SELECT 1 FROM [dbo].[Address] WHERE Id = 10)
    INSERT INTO [dbo].[Address] ([Id], [Street], [City], [State], [ZipCode]) VALUES (10, N'Franka', N'Uzhhorod', N'Zakarpattia oblast', N'88000');


-- Person
IF NOT EXISTS (SELECT 1 FROM [dbo].[Person] WHERE Id = 1)
    INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (1, N'Ivan', N'Ivanov');
IF NOT EXISTS (SELECT 1 FROM [dbo].[Person] WHERE Id = 2)
    INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (2, N'Petro', N'Petrenko');
IF NOT EXISTS (SELECT 1 FROM [dbo].[Person] WHERE Id = 3)
    INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (3, N'Svitlana', N'Bondarenko');
IF NOT EXISTS (SELECT 1 FROM [dbo].[Person] WHERE Id = 4)
    INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (4, N'Dmytro', N'Shevchenko');
IF NOT EXISTS (SELECT 1 FROM [dbo].[Person] WHERE Id = 5)
    INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (5, N'Olena', N'Kovalchuk');
IF NOT EXISTS (SELECT 1 FROM [dbo].[Person] WHERE Id = 6)
    INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (6, N'Andriy', N'Melnyk');
IF NOT EXISTS (SELECT 1 FROM [dbo].[Person] WHERE Id = 7)
    INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (7, N'Iryna', N'Tkachuk');
IF NOT EXISTS (SELECT 1 FROM [dbo].[Person] WHERE Id = 8)
    INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (8, N'Yulia', N'Polishchuk');
IF NOT EXISTS (SELECT 1 FROM [dbo].[Person] WHERE Id = 9)
    INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (9, N'Sergiy', N'Zakharchenko');
IF NOT EXISTS (SELECT 1 FROM [dbo].[Person] WHERE Id = 10)
    INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (10, N'Kateryna', N'Romanenko');


-- Company
IF NOT EXISTS (SELECT 1 FROM [dbo].[Company] WHERE Id = 1)
    INSERT INTO [dbo].[Company] ([Id], [Name], [AddressId]) VALUES (1, N'SoftLine', 1);
IF NOT EXISTS (SELECT 1 FROM [dbo].[Company] WHERE Id = 2)
    INSERT INTO [dbo].[Company] ([Id], [Name], [AddressId]) VALUES (2, N'IT World', 2);
IF NOT EXISTS (SELECT 1 FROM [dbo].[Company] WHERE Id = 3)
    INSERT INTO [dbo].[Company] ([Id], [Name], [AddressId]) VALUES (3, N'DataExpert', 3);


-- Employee
IF NOT EXISTS (SELECT 1 FROM [dbo].[Employee] WHERE Id = 1)
    INSERT INTO [dbo].[Employee] ([Id], [AddressId], [PersonId], [CompanyName], [Position], [EmployeeName])
    VALUES (1, 1, 1, N'SoftLine', N'Developer', N'Ivan Ivanov');
IF NOT EXISTS (SELECT 1 FROM [dbo].[Employee] WHERE Id = 2)
    INSERT INTO [dbo].[Employee] ([Id], [AddressId], [PersonId], [CompanyName], [Position], [EmployeeName])
    VALUES (2, 2, 2, N'IT World', N'Manager', N'Petro Petrenko');
IF NOT EXISTS (SELECT 1 FROM [dbo].[Employee] WHERE Id = 3)
    INSERT INTO [dbo].[Employee] ([Id], [AddressId], [PersonId], [CompanyName], [Position], [EmployeeName])
    VALUES (3, 3, 3, N'DataExpert', N'QA', N'Svitlana Bondarenko');
IF NOT EXISTS (SELECT 1 FROM [dbo].[Employee] WHERE Id = 4)
    INSERT INTO [dbo].[Employee] ([Id], [AddressId], [PersonId], [CompanyName], [Position], [EmployeeName])
    VALUES (4, 4, 4, N'SoftLine', N'Support', N'Dmytro Shevchenko');
IF NOT EXISTS (SELECT 1 FROM [dbo].[Employee] WHERE Id = 5)
    INSERT INTO [dbo].[Employee] ([Id], [AddressId], [PersonId], [CompanyName], [Position], [EmployeeName])
    VALUES (5, 5, 5, N'SoftLine', N'HR', N'Olena Kovalchuk');
IF NOT EXISTS (SELECT 1 FROM [dbo].[Employee] WHERE Id = 6)
    INSERT INTO [dbo].[Employee] ([Id], [AddressId], [PersonId], [CompanyName], [Position], [EmployeeName])
    VALUES (6, 6, 6, N'IT World', N'Admin', N'Andriy Melnyk');
IF NOT EXISTS (SELECT 1 FROM [dbo].[Employee] WHERE Id = 7)
    INSERT INTO [dbo].[Employee] ([Id], [AddressId], [PersonId], [CompanyName], [Position], [EmployeeName])
    VALUES (7, 7, 7, N'DataExpert', N'Analyst', N'Iryna Tkachuk');
IF NOT EXISTS (SELECT 1 FROM [dbo].[Employee] WHERE Id = 8)
    INSERT INTO [dbo].[Employee] ([Id], [AddressId], [PersonId], [CompanyName], [Position], [EmployeeName])
    VALUES (8, 8, 8, N'SoftLine', N'Trainee', N'Yulia Polishchuk');
IF NOT EXISTS (SELECT 1 FROM [dbo].[Employee] WHERE Id = 9)
    INSERT INTO [dbo].[Employee] ([Id], [AddressId], [PersonId], [CompanyName], [Position], [EmployeeName])
    VALUES (9, 9, 9, N'IT World', N'Intern', N'Sergiy Zakharchenko');
IF NOT EXISTS (SELECT 1 FROM [dbo].[Employee] WHERE Id = 10)
    INSERT INTO [dbo].[Employee] ([Id], [AddressId], [PersonId], [CompanyName], [Position], [EmployeeName])
    VALUES (10, 10, 10, N'DataExpert', N'Consultant', N'Kateryna Romanenko');
