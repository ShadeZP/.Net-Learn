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
INSERT INTO [dbo].[Address] ([Id], [Street], [City], [State], [ZipCode]) VALUES
(1, N'Khreshchatyk', N'Kyiv', N'Kyiv oblast', N'01001'),
(2, N'Lenina', N'Dnipro', N'Dnipropetrovsk oblast', N'49000'),
(3, N'Shevchenka', N'Lviv', N'Lviv oblast', N'79000'),
(4, N'Pushkina', N'Harkiv', N'Harkiv oblast', N'61000'),
(5, N'Soborna', N'Odessa', N'Odessa oblast', N'65000'),
(6, N'Tarasova', N'Poltava', N'Poltava oblast', N'36000'),
(7, N'Osvity', N'Zaporizhzhia', N'Zaporizhzhia oblast', N'69000'),
(8, N'Peremohy', N'Chernivtsi', N'Chernivtsi oblast', N'58000'),
(9, N'Druzhby', N'Vinnytsia', N'Vinnytsia oblast', N'21000'),
(10, N'Franka', N'Uzhhorod', N'Zakarpattia oblast', N'88000');

-- Person
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES
(1, N'Ivan', N'Ivanov'),
(2, N'Petro', N'Petrenko'),
(3, N'Svitlana', N'Bondarenko'),
(4, N'Dmytro', N'Shevchenko'),
(5, N'Olena', N'Kovalchuk'),
(6, N'Andriy', N'Melnyk'),
(7, N'Iryna', N'Tkachuk'),
(8, N'Yulia', N'Polishchuk'),
(9, N'Sergiy', N'Zakharchenko'),
(10, N'Kateryna', N'Romanenko');

-- Company
INSERT INTO [dbo].[Company] ([Id], [Name], [AddressId]) VALUES
(1, N'SoftLine', 1),
(2, N'IT World', 2),
(3, N'DataExpert', 3);

-- Employee
INSERT INTO [dbo].[Employee] ([Id], [AddressId], [PersonId], [CompanyName], [Position], [EmployeeName]) VALUES
(1, 1, 1, N'SoftLine', N'Developer', N'Ivan Ivanov'),
(2, 2, 2, N'IT World', N'Manager', N'Petro Petrenko'),
(3, 3, 3, N'DataExpert', N'QA', N'Svitlana Bondarenko'),
(4, 4, 4, N'SoftLine', N'Support', N'Dmytro Shevchenko'),
(5, 5, 5, N'SoftLine', N'HR', N'Olena Kovalchuk'),
(6, 6, 6, N'IT World', N'Admin', N'Andriy Melnyk'),
(7, 7, 7, N'DataExpert', N'Analyst', N'Iryna Tkachuk'),
(8, 8, 8, N'SoftLine', N'Trainee', N'Yulia Polishchuk'),
(9, 9, 9, N'IT World', N'Intern', N'Sergiy Zakharchenko'),
(10, 10, 10, N'DataExpert', N'Consultant', N'Kateryna Romanenko');
