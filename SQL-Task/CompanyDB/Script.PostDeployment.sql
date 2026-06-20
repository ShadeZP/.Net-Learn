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

DELETE FROM [Employee];
DELETE FROM [Company];
DELETE FROM [Person];
DELETE FROM [Address];

DBCC CHECKIDENT ('Employee', RESEED, 0);
DBCC CHECKIDENT ('Company', RESEED, 0);
DBCC CHECKIDENT ('Person', RESEED, 0);
DBCC CHECKIDENT ('Address', RESEED, 0);

-- Address
INSERT INTO [dbo].[Address] ([Street], [City], [State], [ZipCode]) VALUES
(N'Khreshchatyk', N'Kyiv', N'Kyiv oblast', N'01001'),
(N'Lenina', N'Dnipro', N'Dnipropetrovsk oblast', N'49000'),
(N'Shevchenka', N'Lviv', N'Lviv oblast', N'79000'),
(N'Pushkina', N'Harkiv', N'Harkiv oblast', N'61000'),
(N'Soborna', N'Odessa', N'Odessa oblast', N'65000'),
(N'Tarasova', N'Poltava', N'Poltava oblast', N'36000'),
(N'Osvity', N'Zaporizhzhia', N'Zaporizhzhia oblast', N'69000'),
(N'Peremohy', N'Chernivtsi', N'Chernivtsi oblast', N'58000'),
(N'Druzhby', N'Vinnytsia', N'Vinnytsia oblast', N'21000'),
(N'Franka', N'Uzhhorod', N'Zakarpattia oblast', N'88000');

-- Person
INSERT INTO [dbo].[Person] ([FirstName], [LastName]) VALUES
(N'Ivan', N'Ivanov'),
(N'Petro', N'Petrenko'),
(N'Svitlana', N'Bondarenko'),
(N'Dmytro', N'Shevchenko'),
(N'Olena', N'Kovalchuk'),
(N'Andriy', N'Melnyk'),
(N'Iryna', N'Tkachuk'),
(N'Yulia', N'Polishchuk'),
(N'Sergiy', N'Zakharchenko'),
(N'Kateryna', N'Romanenko');


-- Company
INSERT INTO [dbo].[Company] ([Name], [AddressId])
VALUES
(N'SoftLine',      (SELECT Id FROM [Address] WHERE [Street]=N'Khreshchatyk')),
(N'IT World',      (SELECT Id FROM [Address] WHERE [Street]=N'Lenina')),
(N'DataExpert',    (SELECT Id FROM [Address] WHERE [Street]=N'Shevchenka'));


-- Employee
INSERT INTO [dbo].[Employee] ([AddressId], [PersonId], [CompanyName], [Position], [EmployeeName])
VALUES
((SELECT Id FROM [Address] WHERE [Street]=N'Khreshchatyk'), (SELECT Id FROM [Person] WHERE [FirstName]=N'Ivan' AND [LastName]=N'Ivanov'),      N'SoftLine',   N'Developer',    N'Ivan Ivanov'),
((SELECT Id FROM [Address] WHERE [Street]=N'Lenina'),        (SELECT Id FROM [Person] WHERE [FirstName]=N'Petro' AND [LastName]=N'Petrenko'),  N'IT World',   N'Manager',      N'Petro Petrenko'),
((SELECT Id FROM [Address] WHERE [Street]=N'Shevchenka'),    (SELECT Id FROM [Person] WHERE [FirstName]=N'Svitlana' AND [LastName]=N'Bondarenko'),  N'DataExpert', N'QA',      N'Svitlana Bondarenko'),
((SELECT Id FROM [Address] WHERE [Street]=N'Pushkina'),      (SELECT Id FROM [Person] WHERE [FirstName]=N'Dmytro' AND [LastName]=N'Shevchenko'),   N'SoftLine',   N'Support',     N'Dmytro Shevchenko'),
((SELECT Id FROM [Address] WHERE [Street]=N'Soborna'),       (SELECT Id FROM [Person] WHERE [FirstName]=N'Olena' AND [LastName]=N'Kovalchuk'),     N'SoftLine',   N'HR',          N'Olena Kovalchuk'),
((SELECT Id FROM [Address] WHERE [Street]=N'Tarasova'),      (SELECT Id FROM [Person] WHERE [FirstName]=N'Andriy' AND [LastName]=N'Melnyk'),       N'IT World',   N'Admin',       N'Andriy Melnyk'),
((SELECT Id FROM [Address] WHERE [Street]=N'Osvity'),        (SELECT Id FROM [Person] WHERE [FirstName]=N'Iryna' AND [LastName]=N'Tkachuk'),       N'DataExpert', N'Analyst',     N'Iryna Tkachuk'),
((SELECT Id FROM [Address] WHERE [Street]=N'Peremohy'),      (SELECT Id FROM [Person] WHERE [FirstName]=N'Yulia' AND [LastName]=N'Polishchuk'),    N'SoftLine',   N'Trainee',     N'Yulia Polishchuk'),
((SELECT Id FROM [Address] WHERE [Street]=N'Druzhby'),       (SELECT Id FROM [Person] WHERE [FirstName]=N'Sergiy' AND [LastName]=N'Zakharchenko'), N'IT World',   N'Intern',      N'Sergiy Zakharchenko'),
((SELECT Id FROM [Address] WHERE [Street]=N'Franka'),        (SELECT Id FROM [Person] WHERE [FirstName]=N'Kateryna' AND [LastName]=N'Romanenko'), N'DataExpert', N'Consultant',  N'Kateryna Romanenko');
